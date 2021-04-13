# -*- coding: utf-8 -*-
"""
Created on Sun Apr 11 10:22:27 2021

@author: Ragnhild
"""

from datetime import datetime
import time
from paho.mqtt import client as mqtt_client
import random
import csv

broker = 'localhost'
#broker = '192.168.10.200'
port = 1883
# topic to subscribe messages from
subscribe_topics = [("appmodel/resistance",0), ("appmodel/inductance",0), ("setpoint/power/converter",0), ("setpoint/power/convmodel",0), ("setpoint/current",0), ("convmodel/current_coil",0), ("convmodel/frequency",0)]
# generate client ID with pub prefix randomly
client_id = f'python-mqtt-{random.randint(0, 100)}'

def on_connect(client, userdata, flags, rc):
    if rc == 0:
            print("Connected to MQTT Broker!")
            client.subscribe(subscribe_topics)
            I.Connected = True
            I.WritetoFile()
            
            
    else:
        print("Failed to connect, return code %d\n", rc)


def on_message(client, userdata, msg):
    if msg.topic == "setpoint/power":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        I.Power_on = float(msg.payload.decode())

    if msg.topic == "setpoint/current":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        Iset = float(msg.payload.decode())
        if I.Iset != Iset:
            I.Iset = Iset
            I.WritetoFile()
        
    if msg.topic == "appmodel/resistance":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        Rtotal = float(msg.payload.decode())
        if I.Rtotal != Rtotal:
            I.Rtotal = Rtotal
            I.WritetoFile()
    
    if msg.topic == "appmodel/inductance":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        L = float(msg.payload.decode())
        if I.L != L:
            I.L = L
            I.WritetoFile()

    if msg.topic == "convmodel/currentcoil":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        Icoil = float(msg.payload.decode())
        if I.Icoil != Icoil:
            I.Icoil = Icoil
            I.WritetoFile()
        
client = mqtt_client.Client(client_id) 
client.on_connect = on_connect
client.on_message = on_message
client.connect(broker)

client.loop_start()

class DataStorage:
    def __init__(self, Iset, Icoil, Power_on, Time, Rtotal, L):
        self.Iset = Iset
        self.Icoil = Icoil
        self.Power_on = Power_on
        self.Time = Time
        self.Rtotal = Rtotal
        self.L = L
        self.Connected = False
    def WritetoFile(self):
#        while (not I.Connected):
        Changed = datetime.now().strftime('%Y %m %d_%H:%M:%S ')
        file = open('SimulationResults.csv', 'a+', newline = '')
        header = ['data1', 'data2', 'data3', 'Time changed']
        writer = csv.DictWriter(file, fieldnames = header)
        writer.writeheader()
        with file:
            writer.writerow({'data1' : I.Iset, 
                     'data2': I.Icoil, 
                     'data3': I.Rtotal, 'Time changed' : Changed})

I = DataStorage(Iset=1,Icoil=1,Power_on=1,Time=1,Rtotal=1,L=1)


# Messages to be received
#while True:
#    time.sleep(1)

