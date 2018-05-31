#Kognifai Connector SDK

After reading this article you will get to know about:

[What do I need to create a connector ?](https://github.com/kognifai/IoT_Documentation/wiki/Kognifai-Connector-SDK#what-do-i-need-to-create-a-connector-)

[Kognifai Connector SDK tools](https://github.com/kognifai/IoT_Documentation/wiki/Kognifai-Connector-SDK#kognifai-connector-sdk-tools)

[Sending messages to the Edge gateway from your own device connector](https://github.com/kognifai/IoT_Documentation/wiki/Kognifai-Connector-SDK#sending-messages-to-the-edge-gateway-from-your-own-device-connector)


--------------------------------------------------------------------------------------------------------------------------

The following figure depicts the Kognifai Connector SDK that includs "Kognifai-  Edge, Kognifai- Data Processing Analytics and Management",  and "Presentation & Enterprise connectivity":

![](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/PlatformRefArch.png?raw=true)

## What do I need to create a connector ?

To create a connector, you need a client library which understands the **_MQTT standard_** :

- MQTT is a popular and wellknown publish subscribe protocol
- The Kognfai Edge gateway hosts a MQTT server endpoint
- In order to send messages to the Kognifai edge gateway, you just publish messages to a MQTT topic

You need to send messages which are serialized in such a way that the Kognifai Edge Gateway understands them:

- The Kognifai Edge Gateway uses Google protobuf for serialization
- The protobuf schema is part of the Connector SDK
- Since both MQTT and Protobuf are supported in a wide range of programming languages, it will be possible to create connectors using almost any programming language

## Kognifai Connector SDK tools
- Protobuf definitions for standardized messages
- Nuget package for serialization for clients using .Net [link]
- Nuget package A MQTT client [link]
- Examples of "how to create a connector" (Click here to find the example to create a connector)

## Sending messages to the Edge gateway from your own device connector

MQTT is a simple and lightweight protocol which is used in many IoT scenarios.

The Edgegateway can be deployed with a MQTT endpoint. Once the Edgegateway is started, it will start its MQTT service. Custom connectors can then connect to the Edgegateway using the standard MQTT on port 1883.

As MQTT libraries are available in many programming languages you are not required to use the MQTT client library that comes with the connector SDK, you can use any library which implements the MQTT standard properly. If you are implementing your connector using C#, we reccomend that you use the MQTT client libaries bundled with the Connector SDK. The Kognifai.m2mqtt is a fork of the widely used m2mqtt library and it is available from nuget.org

In order for the messages to be understood by the edge gateway, they must be serialized with google protobuf, using the Kognifai Edge protobuf schema.
