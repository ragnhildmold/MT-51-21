# -*- coding: utf-8 -*-
"""
Created on Thu May 13 13:45:38 2021

@author: Ragnhild
"""

from fenics import *
from elmag import powerdens
import numpy
import math as mt
from math import pi
import scipy.special as sp
from paho.mqtt import client as mqtt_client
import random
from time import time, sleep
import signal

done = False

broker = '192.168.10.129'
# port can be defined, or 1883 will be chosen by default
port = 1883
# topic to subscribe messages from
subscribe_topics = [("convmodel/frequency",0), ("convmodel/current",0),("setpoint/mqtt",0)]
# topic to pulish messages to
publish_topic1 = "appmodel/temp"
# generate client ID 
client_id = f'python-mqtt-{random.randint(0, 100)}'


publish_topic2 = "appmodel/temparray"
publish_topic3 = "appmodel/temparray_coordinates"

class State:
    def __init__(self, F, Hs, targettime):
        self.F = F
        self.Hs = Hs
        self.targettime = targettime

I = State(F=100,Hs=0,targettime=1000)
 

def on_connect(client, userdata, flags, rc):
    if rc == 0:
        print("Connected to MQTT Broker!")
        client.subscribe(subscribe_topics)
    else:
        print("Failed to connect, return code %d\n", rc)


def on_message(client, userdata, msg):
    if msg.topic == "convmodel/frequency":
        print(f"Received '{msg.payload.decode()}' from '{msg.topic}' topic")
        I.F = float(msg.payload.decode())            
    if msg.topic == "convmodel/current":
        print(f"Received '{msg.payload.decode()}' from '{msg.topic}' topic")
        Iset = float(msg.payload.decode())
        I.Hs = Iset/0.071
    if msg.topic == "setpoint/mqtt":
        print(f"Received '{msg.payload.decode()}' from '{msg.topic}' topic")
        mqtt_on = float(msg.payload.decode())
        global done
        if mqtt_on == 0:
            done = True
        
client = mqtt_client.Client(client_id) 
client.on_connect = on_connect
client.on_message = on_message
client.connect(broker,port)
client.loop_start()  


class Material:
    def __init__(self, ro=7.4e-7, mur=1., C=500., gamma=8000., k=14.): # Material properties for Stainless Steel 316L
        self.ro = ro
        self.mur = mur
        self.C = C
        self.gamma = gamma
        self.k = k


class Power(UserExpression):
    def __init__(self, R, material, Hs=1e5, F=1e4, degree=2, **kwargs):
        super().__init__(**kwargs) 
        self.R = R
        self.Hs = Hs
        self.F = F
        self.ro = material.ro
        self.mur = material.mur
        self.degree = degree
    def acceptNewHs(self, Hs):
        self.Hs = Hs
    def acceptNewF(self, F):
        self.F = F
    def eval(self,values,x):
        values[0] = powerdens(x, self.R, self.Hs, self.F, self.ro, self.mur)

          
class TransientTSolver:
    def __init__(self, mesh, ds, Ti, P, theta, Hconv, Text, material):
        self.mesh = mesh
        self.ds = ds
        self.Ti = Constant(Ti)
        self.V = FunctionSpace(self.mesh, 'Lagrange', 1)
        self.P = project(P,self.V)
        self.T = TrialFunction(self.V)
        self.v = TestFunction(self.V)
        self.T_n = Function(self.V)
        self.T_n = project(self.Ti, self.V)
        self.r = Expression('x[0]', degree=2)
        self.Hconv = Constant(Hconv)
        self.Text = Constant(Text)
        self.theta = Constant(theta)
        self.InitTime = time()
        self.LastCalcTime = time()
        self.NewCalcTime = self.LastCalcTime
        self.dt = 1
        self.m = material
        self.F = (1.0/self.dt)*self.r*self.m.C*self.m.gamma*(self.T-self.T_n)*self.v*dx + \
               self.theta*self.steady(self.T,self.v,self.P)+ \
               (1.0-self.theta)*self.steady(self.T_n, self.v, self.P)
        self.Tsol = Function(self.V)
        self.T_n.interpolate(self.Ti)

    def acceptNewPower(self, P):
        self.P = project(P,self.V)
        self.F = (1.0/self.dt)*self.r*self.m.C*self.m.gamma*(self.T-self.T_n)*self.v*dx + \
               self.theta*self.steady(self.T,self.v,self.P)+ \
               (1.0-self.theta)*self.steady(self.T_n, self.v, self.P)

    def steady(self, u, v, P):
        r = self.r
        Hconv = self.Hconv
        Text = self.Text
        k = self.m.k
        return r*k*(Dx(u,0)*Dx(v,0))*dx+k*Dx(u,0)*v*dx+r*Hconv*u*v*ds(1)-r*Hconv*Text*v*ds(1)-r*P*v*dx
    def solve(self, dt):         
        self.dt = dt
        self.F = (1.0/self.dt)*self.r*self.m.C*self.m.gamma*(self.T-self.T_n)*self.v*dx + \
               self.theta*self.steady(self.T,self.v,self.P)+ \
               (1.0-self.theta)*self.steady(self.T_n, self.v, self.P)
        solve(lhs(self.F) == rhs(self.F), self.Tsol)
        self.T_n.assign(self.Tsol)

             
def logdensemesh(a, b, N):
    gridi = numpy.linspace(1.,10., N)
    gridl = numpy.log(gridi) #logarithmic
    gridn = gridl/max(gridl) #logarithminc normilized to 0..1
    return a+(b-a)*gridn #projected to required a..b
    
    
steel = Material()

R_int = 0. # minimum point
R_ext = 0.1 # maximum point

nr = 100 # number of cells in mesh
mesh = IntervalMesh(nr, R_int, R_ext)
mesh.coordinates()[:,0] = logdensemesh(R_int, R_ext, nr+1)


class Boundary(SubDomain):
    TOL = 1e-14
    def __init__(self, R):
        self.R = R
        SubDomain.__init__(self) 
    def inside(self, x, on_boundary):
        return on_boundary and near(x[0], self.R, self.TOL)    


boundary_markers = MeshFunction('size_t', mesh, mesh.topology().dim()-1, 0)        
bxInt = Boundary(R_int)
bxInt.mark(boundary_markers, 0)
bxExt = Boundary(R_ext)
bxExt.mark(boundary_markers, 1)
ds = Measure('ds', domain=mesh, subdomain_data=boundary_markers)


P = Power(R_ext, steel, I.Hs, I.F, degree=2)

num_steps = 1 # number of time steps

Ti = 20.
theta = 1.0
Hconv = 0.0
Text = 20.


def signal_handler(signal, frame):
    print("\nExiting program")
    global done
    done = True
    
signal.signal(signal.SIGINT, signal_handler)

solv1 = TransientTSolver(mesh, ds, Ti, P, theta, Hconv, Text, steel)

while (done != True):
    solv1.NewCalcTime = time()
    TimeSinceLastCalc = solv1.NewCalcTime - solv1.LastCalcTime
    I.targettime = TimeSinceLastCalc
    solv1.solve(TimeSinceLastCalc)
    P.acceptNewHs(Hs=I.Hs)
    P.acceptNewF(F=I.F)
    solv1.acceptNewPower(P)
    
    print(solv1.Tsol.vector().get_local()[0])

    client.publish(publish_topic1, str(solv1.Tsol.vector().get_local()[0]))
    solv1.NewCalcTime = solv1.LastCalcTime
    sleep(1)

import matplotlib.pyplot as plt
plt.plot(numpy.flip(mesh.coordinates()[:,0]), solv1.Tsol.vector().get_local(),'-o')
plt.savefig('fen1d.png')
