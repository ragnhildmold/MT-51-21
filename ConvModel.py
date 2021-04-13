# -*- coding: utf-8 -*-
"""
Created on Tue Mar 16 14:12:59 2021

@author: Ragnhild
"""
import sys, signal
from math import pi, sqrt
import time
from paho.mqtt import client as mqtt_client
import random



broker = 'localhost'
#broker = '81.167.204.42'
#broker = '192.168.10.190'
port = 1883
# topic to subscribe messages from
subscribe_topics = [("appmodel/resistance",0), ("appmodel/inductance",0), ("setpoint/power/convmodel",0), ("setpoint/current",0)]
# topics to pulish messages to
publish_topic_current = "convmodel/current_coil"
publish_topic_frequency = "convmodel/frequency"
# generate client ID with pub prefix randomly
client_id = f'python-mqtt-{random.randint(0, 100)}'


def signal_handler(signal, frame):
    print("\nExiting program")
    sys.exit(0)

signal.signal(signal.SIGINT, signal_handler)

# Connecting to broker

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
        print('Power is on: ', C.Power_on)
        if C.Power_on == 0:
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


client = mqtt_client.Client(client_id) 
client.on_connect = on_connect
client.on_message = on_message
#client.username_pw_set(username="mqtt",password="ragnhild")
client.connect(broker, port)
client.loop_start()


#
#time.sleep(10)

class Converter:  
    def __init__(self):
        self.L = 1e-3
        self.C = 1e-6
        self.P = 10000
        self.N = 100
        self.Vac = 100
        self.Rtotal = 0.1
        self.Iset = 100
        self.Power_on = 0
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
        Pmax = self.Icoil**2*C.Rtotal # Max effect with coil current
#        print('Icoil: ', self.Icoil)
        if self.Icoil > self.Iset:
            client.publish(publish_topic_current, self.Iset)
            client.publish(publish_topic_frequency, self.F)
            print('Icoil: ', self.Iset)
            time.sleep(1)
        else:
            client.publish(publish_topic_current, self.Icoil)
            client.publish(publish_topic_frequency, self.F)
            print('Icoil: ', self.Icoil)
            time.sleep(1)

C = Converter()

#C.Calc()
#while True:
#    time.sleep(1)

client.loop_stop()
client.disconnect()