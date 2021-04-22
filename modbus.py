# -*- coding: utf-8 -*-
"""
Created on Mon Apr 19 15:07:31 2021

@author: Ragnhild
"""

from pyModbusTCP.client import ModbusClient
import time
import random
from paho.mqtt import client as mqtt_client


broker = '172.19.2.81'
publish_topic_temp = "real/temp"
client_id = f'python-mqtt-{random.randint(0, 100)}'

def on_connect(client, userdata, flags, rc):
    if rc == 0:
            print("Connected to MQTT Broker!")
    else:
        print("Failed to connect, return code %d\n", rc)

client = mqtt_client.Client(client_id) 
client.on_connect = on_connect
client.connect(broker)
client.loop_start()

c = ModbusClient(host="172.19.2.61", port=502, unit_id=1, auto_open=True)

while True:
    regs = int(c.read_holding_registers(2, 1)[0])/10.0    
    time.sleep(0.1)
    print(regs)
    client.publish(publish_topic_temp, regs)
