# -*- coding: utf-8 -*-
"""
Created on Tue Apr 13 13:56:32 2021

@author: Ragnhild
"""

from DataStorage import WriteToFile
from ConvModel import Calc
#from rag_fen1d_v2 import solv1
from paho.mqtt import client as mqtt_client
import random
import time
import sys


broker = 'localhost'
subscribe_topic = "setpoint/off"
client_id = f'python-mqtt-{random.randint(0, 100)}'

def on_connect(client, userdata, flags, rc):
    if rc == 0:
#            print("Connected to MQTT Broker!")
            client.subscribe(subscribe_topic)
    else:
        print("Failed to connect, return code %d\n", rc)
        
def on_message(client, userdata, msg):
    print(f"Received `{msg.payload.decode()}` from `{msg.topic}` topic")
    S.Off = int(msg.payload.decode())
    print(S.Off)


client = mqtt_client.Client(client_id) 
client.on_connect = on_connect
client.on_message = on_message
#client.username_pw_set(username="mqtt",password="ragnhild")
client.connect(broker)
client.loop_start()

class Stop:
    def __init__(self, Off):
        self.Off = Off
    
S = Stop(Off=1)

try:
    while True:
    #   solv1.solve()
        Calc()
        WriteToFile()
        print(S.Off)
        time.sleep(1)
        if S.Off == 0:
            print("Simulation ending")
            sys.exit()
except KeyboardInterrupt:
    print("Simulation ending")
    sys.exit()
