M2MQTT client example using Kognifai Serialization library for serializing

Copyright Kongsberg Digital AS © 2017
 
 The example client shows how to connect/disconnect to/from a MQTT server/broker
 as well as giving examples on how to send messages to the Kognifai platform
 using the Kognifai Serialization library.
 
 The following messages are supported:
 - TimeseriesDoublesReplicationMessage
 - AlarmReplicationMessage
 - StateChangeReplicationMessage
 - DataframeReplicationMessage
 
 The program also includes an example on how messages can be grouped together and
 sent in a container.

 Supports both Net40 and Net462

 To run this example with the Kognifai platform a edge gateway must be created.
 The name of the edge gateway should be set to M2MqttExampleClient.

 The edge gateway configuration can be created using the Edge Gateway Manager

 The included gateway configuration files (alarmlist.csv/sensorlist.csv, statechangelist.csv and dataframelist.csv) 
 should be copied to the Edge gateway configuration folder. The Edge Gateway manager can be used to open the configuration
 folder (typically C:\ProgramData\Kongsberg\IotHubGateway\Kognifai.EdgeGateway.Dist.MQTTWin\<device id>\mqtt\source).

 The Kognifai EdgeGateway MQTTWin service must be running on a computer accessible for the M2MqttExampleClient.

 When starting the client a client id and the server address/host name must be specified
 M2MqttClient.exe abcd NOKRS026