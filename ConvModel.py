# -*- coding: utf-8 -*-
"""
Created on Tue Mar 16 14:12:59 2021

@author: Ragnhild
"""
import signal, sys
from math import pi, sqrt
import time
from paho.mqtt import client as mqtt_client
import random



#broker = 'localhost'
broker = '172.19.2.81'
#port = 1883
# topic to subscribe messages from
subscribe_topics = [("appmodel/resistance",0), ("appmodel/inductance",0), ("setpoint/power/convmodel",0), ("setpoint/current",0), ("setpoint/mqtt",0)]
# topics to pulish messages to
publish_topic_current = "convmodel/current"
publish_topic_frequency = "convmodel/frequency"
publish_topic_power = "convmodel/power"
# generate client ID with pub prefix randomly
client_id = f'python-mqtt-{random.randint(0, 100)}'


def signal_handler(signal, frame):
    print("\nExiting program")     
    C.mqtt_off == 0

signal.signal(signal.SIGINT, signal_handler)

# Connecting to broker and subscribe to topics

def on_connect(client, userdata, flags, rc):
    if rc == 0:
            print("Connected to MQTT Broker!")
            client.subscribe(subscribe_topics)
    else:
        print("Failed to connect, return code %d\n", rc)

# Handling received messages from topics

def on_message(client, userdata, msg):
    if msg.topic == "setpoint/power/convmodel":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        C.Power_on = int(msg.payload.decode())
        if C.Power_on == 1:
            print("Power is on")
        else:
            print("Power is off")
         
    if msg.topic == "setpoint/current" and C.Power_on == 1:
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        C.Iset = float(msg.payload.decode())
        C.Calc()
        
    if msg.topic == "appmodel/resistance" and C.Power_on == 1:
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        C.Rtotal = float(msg.payload.decode())
        C.Calc()
    
    if msg.topic == "appmodel/inductance" and C.Power_on == 1:
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        C.L = float(msg.payload.decode())
        C.Calc()

    if msg.topic == "setpoint/mqtt":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        C.mqtt_off = int(msg.payload.decode())
        print(C.mqtt_off)
        if C.mqtt_off == 0:
            signal_handler()
#            sys.exit()



client = mqtt_client.Client(client_id) 
client.on_connect = on_connect
client.on_message = on_message
client.connect(broker)
client.loop_start()


#
#time.sleep(10)

class Converter:  
    def __init__(self):
        self.L = 4e-3
        self.C = 1e-6
        self.P = 10000
        self.N = 100
        self.Vac = 100
        self.Rtotal = 0.1
        self.Iset = 1
        self.Power_on = 0
        self.mqtt_off = 1
        self.Pmax = 1
    def Calc(self):
        self.F = 1/(2*pi*sqrt(C.L/self.N*self.C)) # Resonance frequency
        self.Xc = 1/2*pi*self.F*self.C # Reactance in capacitor
        Ic = self.Vac/self.Xc # Current through capacitor
        Ieffect = sqrt(self.P/C.Rtotal) # Total effect
        Iac = self.Vac/C.Rtotal # Current from the converter
        Current = [Ic, Ieffect, Iac]
        self.Icoil = min(Current) # Max current in coil
        self.Vac = self.Icoil*C.Rtotal # Voltage from converter
        Vc = self.Icoil*self.Xc # Voltage across capacitor
        if self.Icoil > self.Iset:
            self.Pmax = (self.Iset*self.N)**2*C.Rtotal # Max effect with coil current
            client.publish(publish_topic_current, self.Iset*self.N)
            client.publish(publish_topic_frequency, self.F)
            client.publish(publish_topic_power, self.Pmax)
            print('Icoil: ', self.Iset*self.N)
            print('Frequency: ', self.F)
            time.sleep(1)
        else:
            self.Pmax = (self.Icoil*self.N)**2*C.Rtotal # Max effect with coil current
            client.publish(publish_topic_current, self.Icoil*self.N)
            client.publish(publish_topic_frequency, self.F)
            client.publish(publish_topic_power, self.Pmax)
            print('Icoil: ', self.Icoil*self.N)
            print('Frequency: ', self.F)
            time.sleep(1)

C = Converter()


while (C.mqtt_off != 0):
    time.sleep(1)

