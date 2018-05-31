The following section explains how to work with Connector SDK:


The Edge gateway expects to receive messages serialized with protobuf. A protobuf schema has been defined for the messages supported by the Edge gateway.  
           See Serialization for more details. 

An example application available under [IoT_Samples](https://github.com/kognifai/IoT_Samples) illustrates how to send time series data to the Edge gateway using the Connector SDK.

## Sending messages to the Edge gateway from your own device connector

MQTT is a simple and lightweight protocol which is used in many IoT scenarios. The Edge gateway can be deployed with a MQTT endpoint. Once the Edge gateway is started, it will start its MQTT service. Custom connectors can then connect to the Edge gateway using the standard MQTT on port 1883.

As MQTT libraries are available in many programming languages you are not required to use the MQTT client library that comes with the connector SDK, you can use any library which implements the MQTT standard properly. If you are implementing your connector using C#, we recommend that you use the MQTT client libraries bundled with the Connector SDK. The Kognifai.m2mqtt is a fork of the widely used m2mqtt library and it is available from nuget.org

In order for the messages to be understood by the edge gateway, they must be serialized with google protobuf, using the Kognifai Edge protobuf schema.
