# Kognifai Connector SDK

After reading this article you will get to know about:

[What do I need to create a connector?](#what-do-i-need-to-create-a-connector-)

[Kognifai Connector SDK tools](#kognifai-connector-sdk-tools)

[Sending messages to the Edge gateway from your own device connector](#sending-messages-to-the-edge-gateway-from-your-own-device-connector)


--------------------------------------------------------------------------------------------------------------------------
### See also:
- [Working with the connector SDK](Working%20with%20Connector%20SDK.md)
- [Serialization](Serialization.md)
- [Serialize timestamp and value](Serialize%20Timestamp%20and%20Value.md)
- [Serialize an alarm](Serialize%20an%20Alarm.md)
- [Send Serialized data to the edge gateway](Send%20Serialized%20data%20to%20the%20Edge%20Gateway.md)

--------------------------------------------------------------------------------------------------------------------------
The following figure depicts the Kognifai Connector SDK that includes "Kognifai-  Edge, Kognifai- Data Processing Analytics and Management",  and "Presentation & Enterprise connectivity":

![](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/PlatformRefArch.png?raw=true)

## What do I need to create a connector?

To create a connector, you need a client library which understands the **_MQTT standard_**:

- MQTT is a popular and well known publish subscribe protocol
- The Kognifai Edge gateway hosts a MQTT server endpoint
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

The Edge gateway can be deployed with a MQTT endpoint. Once the Edge gateway is started, it will start its MQTT service. Custom connectors can then connect to the Edge gateway using the standard MQTT on port 1883.

As MQTT libraries are available in many programming languages you are not required to use the MQTT client library that comes with the connector SDK, you can use any library which implements the MQTT standard properly. If you are implementing your connector using C#, we recommend that you use the MQTT client libraries bundled with the Connector SDK. The Kognifai.m2mqtt is a fork of the widely used m2mqtt library and it is available from nuget.org

In order for the messages to be understood by the edge gateway, they must be serialized with google protobuf, using the Kognifai Edge protobuf schema.

## Exchanging transmit lists with the edge gateway
- The MQTT endpoint has a topic for publishing a list of sensors that your connector supports. If you send a list of available sensors to the MQTT endpoint it will propagate to the Sensor Configuration App in the cloud, and the end user will be able to configure which sensors to stream to the cloud. The use of this functionality is illustrated in the [sample code](https://github.com/kognifai/IoT/blob/master/IoT%20Samples/M2MqttExampleClient.sln).

## Filtering sensor data sent to the cloud
- The MQTT endpoint supports filtering of the sensor data you send to the edge gateway. Only data from sensors which you have configured in the Sensor Configuration App will be forwarded to the cloud. The end user can use the Sensor Configuration App in the cloud to configure which sensors to stream to the cloud.
The use of this functionality is illustrated in the [sample code](https://github.com/kognifai/IoT/blob/master/IoT%20Samples/M2MqttExampleClient.sln).
- It is recommended to send the list of available sensors to the MQTT endpoint on start-up of your connector and then subsequently every 24 hours.
- The MQTT endpoint does also have a topic where it publishes the list of sensors to be replicated to the cloud. It is not required to use this in your custom connector. However, if you are performing CPU intensive load per sensor you stream to the MQTT endpoint, you may optimize the dataflow by only sending data from sensors which will be sent to the cloud.
