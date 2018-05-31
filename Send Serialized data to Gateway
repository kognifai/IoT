
The source code for the full example can be found here: https://github.com/kognifai/IoT_Samples  When connecting to the MQTT endpoint, you have to specify a client-id which should be unique.

````
client.Connect(clientId ,"","", false;60);
````

Once a client session is established, you can publish messages to a MQTT topic. Messages sent to the “CloudBound” topic, will be sent to the cloud.

````
client.Publish(Topics.cloudBound,messageWrapper,ToByteArray(),MqttMsgBase.QOS_LEVEL_ATLEAST_ONCE, false);
````
MQTT uses different quality of service categories. It is recommended to use the “at least once” policy.
