# -*- coding: utf-8 -*-
"""
Created on Sun Apr 11 10:22:27 2021

@author: Ragnhild
"""

from datetime import datetime
import signal
import time
from paho.mqtt import client as mqtt_client
import random
import csv

broker = '172.19.2.81'
#broker = '192.168.10.200'
port = 1883
# topic to subscribe messages from
subscribe_topics = [("appmodel/temp",0), ("appmodel/resistance",0), ("appmodel/inductance",0), ("setpoint/power/converter",0), ("setpoint/power/convmodel",0), ("setpoint/current",0), ("convmodel/current",0), ("convmodel/frequency",0), ("converter/frequency",0), ("converter/power",0), ("converter/current",0),("real/temp",0),("setpoint/file",0),("setpoint/report",0)]
# generate client ID with pub prefix randomly
client_id = f'python-mqtt-{random.randint(0, 100)}'


#        

def signal_handler(signal, frame):
    print("\nExiting program")     
    I.mqtt_off = 0

signal.signal(signal.SIGINT, signal_handler)

def on_connect(client, userdata, flags, rc):
    if rc == 0:
            print("Connected to MQTT Broker!")
            client.subscribe(subscribe_topics)            
            
    else:
        print("Failed to connect, return code %d\n", rc)


def on_message(client, userdata, msg):
    if msg.topic == "setpoint/power/converter":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        I.Power_on_conv = float(msg.payload.decode())
        I.WritetoFileOnChange()
        
    if msg.topic == "setpoint/power/convmodel":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        I.Power_on_convmodel = float(msg.payload.decode())
        I.WritetoFileOnChange()

    if msg.topic == "setpoint/current":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        Iset = float(msg.payload.decode())
        if I.Iset != Iset:
            I.Iset = Iset
            I.WritetoFileOnChange()

        
    if msg.topic == "appmodel/resistance":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        Rtotal = float(msg.payload.decode())
        if I.Rtotal != Rtotal:
            I.Rtotal = Rtotal
            I.WritetoFileOnChange()

    
    if msg.topic == "appmodel/inductance":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        L = float(msg.payload.decode())
        if I.L != L:
            I.L = L
            I.WritetoFileOnChange()


    if msg.topic == "appmodel/temp":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
        T = float(msg.payload.decode())
        if I.T != T:
            I.T = T
            I.WritetoFileOnChange()


    if msg.topic == "convmodel/current":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        Icoil = float(msg.payload.decode())
        if I.Icoil != Icoil:
            I.Icoil = Icoil
            I.WritetoFileOnChange()


    if msg.topic == "convmodel/power":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        P = float(msg.payload.decode())
        if I.P != P:
            I.P = P
            I.WritetoFileOnChange()


    if msg.topic == "convmodel/frequency":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        F = float(msg.payload.decode())
        if I.F != F:
            I.F = F
            I.WritetoFileOnChange()


    if msg.topic == "converter/frequency":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        Freal = float(msg.payload.decode())
        if I.Freal != Freal:
            I.Freal = Freal
            I.WritetoFileOnChange()


    if msg.topic == "real/temp":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        Treal = float(msg.payload.decode())
        if I.Treal != Treal:
            I.Treal = Treal
            I.WritetoFileOnChange()

            
    if msg.topic == "converter/power":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        Preal = float(msg.payload.decode())
        if I.Preal != Preal:
            I.Preal = Preal
            I.WritetoFileOnChange()


    if msg.topic == "converter/current":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        Ireal = float(msg.payload.decode())
        if I.Ireal != Ireal:
            I.Ireal = Ireal
            I.WritetoFileOnChange()
            
    if msg.topic == "setpoint/file":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        File_name = msg.payload.decode()
        if I.File_name != File_name:
            I.File_name = File_name
            I.WritetoFileOnChange()
            print("Filename changed to: ", I.File_name)

    if msg.topic == "setpoint/mqtt":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        I.mqtt_off = int(msg.payload.decode())


    if msg.topic == "setpoint/report":
        print(f"Received `{msg.payload.decode()}` from `{msg.topic}`")
        I.ReportEnable = int(msg.payload.decode())
        if I.ReportEnable:
            I.file = open(I.File_name, 'a+', newline = '')
            header = ['Time', 'Power_on_conv', 'Power_on_convmodel', 'Iset', 'Treal', 'T', 'Preal', 'P', 'Freal', 'F', 'Icoil', 'Ireal' ]
            for n in header:
                I.file.write(n+",")
            I.file.write("\n")
            print("open file")
        else:
            I.file.close()  
            print("closing file")



client = mqtt_client.Client(client_id) 
client.on_connect = on_connect
client.on_message = on_message
client.connect(broker)

client.loop_start()



class DataStorage:
    def __init__(self, Iset, Icoil, Power_on, Time, Rtotal, L, T, F, P, Treal, Freal, Preal, Ireal, File_name, mqtt_off):
        self.Iset = Iset
        self.Icoil = Icoil
        self.Power_on_conv = 0
        self.Power_on_convmodel = 0
        self.Time = Time
        self.Rtotal = Rtotal
        self.L = L
        self.T = T
        self.F = F
        self.P = P
        self.Treal = Treal
        self.Freal = Freal
        self.Preal = Preal
        self.Ireal = Ireal
        self.File_name = File_name
        self.mqtt_off = mqtt_off
        self.ReportOnChange = False # Set to true to report on change
        self.ReportOnTime = True # Set to true to report on time interval
        self.ReportEnable = False
        self.file = 0
    def WriteFileOnTime(self):
        if (self.ReportEnable):
            print("WriteOnTime()")
            Changed = datetime.now().strftime('%Y %m %d_%H:%M:%S:%f ')          
            self.file.write(str(Changed)+","+str(I.Power_on_conv)+","+ str(I.Power_on_convmodel)+","+ str(I.Iset)+","+ str(I.Treal)+","+ str(I.T)+","+ 
                     str(I.Preal)+","+str(I.P)+","+ 
                     str(I.Freal)+","+str(I.F)+","+str(I.Icoil)+","+str(I.Ireal)+"\n")
    
    def WritetoFileOnChange(self):
        if (self.ReportOnChange) and (self.ReportEnable):
            Changed = datetime.now().strftime('%Y %m %d_%H:%M:%S:%f ')
            self.file.write(str(Changed)+","+str(I.Power_on)+ str(I.Power_on_convmodel)+","+ str(I.Iset)+","+ str(I.Treal)+","+ str(I.T)+","+ 
                     str(I.Preal)+","+str(I.P)+","+ 
                     str(I.Freal)+","+str(I.F)+","+str(I.Icoil)+","+str(I.Ireal)+"\n")


    
    
I = DataStorage(Iset=-1,Icoil=-1,Power_on=1,Time=1,Rtotal=1,L=1,T=-20,F=-1,Treal=-20, Freal=-1,Preal=1,P=-1,Ireal=-1, File_name = 'SimulationResults.csv', mqtt_off=1)



while (I.mqtt_off != 0):
    time.sleep(0.1)
    if (I.ReportOnTime == True):
        I.WriteFileOnTime()

if not I.file.closed:        
    I.file.close()

print("Done")

