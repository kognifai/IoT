Welcome to the IoT_Documentation! 

Explore these pages to know more about **IoT** and **Edge Connectors**. 

In this section, we talk about:

[What is IoT?](https://github.com/kognifai/IoT_Documentation/wiki#what-is-iot-)

[What can you achieve with Kognifai IoT Platform?](https://github.com/kognifai/IoT_Documentation/wiki#what-can-you-achieve-with-kognifai-iot-platform?)

[Part and Parcel of Kognifai IoT platform](https://github.com/kognifai/IoT_Documentation/wiki#what-can-you-achieve-with-kognifai-iot-platform) 


[Commonly used protocols and technologies in Kognifai IoT Platform and deployment](https://github.com/kognifai/IoT/blob/master/SDK%20Documentation/protocols%20and%20technologies.md)

--------------------------------------------------------------------------------------------------------------------------
# What is IoT ?

The Internet of things (IoT) is the inter-networking of physical devices, vehicles, buildings, and other items, embedded with electronics, software, sensors, actuators, and network connectivity that enable them to collect and exchange data. IoT Platforms form the basis for development of scalable IoT applications and services that connect the real and virtual worlds between those physical devices, systems and people. The Kognifai IoT platform is includes  software running at the edge, integrating the edge systems with the cloud, and also the tools in the cloud required to securely manage your edge installations in a safe and secure manner.

## What can you achieve with Kognifai IoT Platform?

The Kognifai IoT platform will enable you to:

- Connect to a wide variety of source systems
- Remotely configure the edge systems in a safe and secure manner
- Efficiently manage a fleet of edge installations from the cloud
- Transport data to and from the cloud in a reliable manner
- Buffer data locally at the Edge when the internet connection is down
- Stream data into your cloud applications 
- Make data available for processing in cloud analytics applications
- Use the data from the edge direcly in your on-premise applications via the api's exposed by the Kognifai cloud solutions
- Monitor edge installations for intrusion attempts
- Deploy storage, calculation and presentation capabilities at the Edge

## Part and Parcel of Kognifai IoT platform

The Kognfai IoT platform is comprised of the following parts:

- [Edge gateway](https://github.com/kognifai/IoT_Documentation/wiki#edge-gateway)
- [IoT device connectors](https://github.com/kognifai/IoT_Documentation/wiki#iot-device-connectors)
- [Reliable and Secure transport](https://github.com/kognifai/IoT_Documentation/wiki#reliable-and-secure-transport)
- [IoT Event Hub](https://github.com/kognifai/IoT_Documentation/wiki#iot-event-hub)
- [Tools for remote configuration of Edge systems](https://github.com/kognifai/IoT_Documentation/wiki#iot-cloud-dispatcher)
- [Storage](https://github.com/kognifai/IoT_Documentation/wiki#storage)
- [Presentation](https://github.com/kognifai/IoT_Documentation/wiki#presentation)
- [Steam analytics](https://github.com/kognifai/IoT_Documentation/wiki#stream-analytics)

### Edge gateway
The edge gateway connects the edge devices with the cloud. The Edge gateway will transfer your data securely to the cloud. If the internet connection is un-available, the edge-gateway will buffer data locally, and re-transmit once the internet connection is re-established. The Edge gateway comes with a set of integrated connectors which can be used to connect using common protocols such as for example OPC DA and OPC U/A.  The Edge gateway does also host endpoints to which thirdparties can send data which they want sent to the cloud. A connector SDK is also available for clients to write custom connectors which will send data to the Edge gateway.

### IoT device connectors
The Kongifai Edge gateway comes with a set of integrated connnectors to connect to common source systems. In addition it is possible to build your own device connectors using the Kognifai Connector SDK. 

### Reliable and secure transport
The Kognifai Edge gateway will encrypt the data that is sent to the cloud and all communication with the cloud happens in a secure manner. The Edge gateway solution is also buffering data and in the event of a loss of the internet connection, data will be re-sent to the cloud when the connection comes back up. 

### IoT Event HUB
IoT Hub is a Microsoft Azure service for providing secure and scalable two-way communication between devices, instruments and IOT gateways in the field and the cloud. It buffers data when the data arrive at the cloud, ensuring that a restart of a cloud service don't cause any dataloss.

### IoT Cloud dispatcher
The IOT gateway ensure connectivity by serving as an adapter between devices and instruments in the field and the cloud services. It relays messages from the IoT hub to the correct recipients on the cloud side. The Kognifai IoT Cloud dispatcher does also make it possible to send messages back to specific edge installations from the cloud in a secure manner.

### Storage
This is the layer in which the IoT data is stored and retrieved. The Kognifai Storage Solution can be deployed both at the edge and in the cloud. 

### Presentation
The Kognifai Application Framework provides a powerful visualization platform. It can be deployed both at the edge and in the cloud, and iuser interface (UI), in the industrial design field of human–computer interaction, is the space where interactions between humans and machines occur. kognifai provides strong out-of-the-box collection of data visualization applications such as dashboard, trends, reports, data export and event analytics, supporting various customer IoT cases.

### Stream Analytics
Stream processing analyzes and performs calculations on collected real-time field data as they arrive in the system. The Kognifai stream analytics solution can be deployed both at the edge and in the cloud. 

# References to commonly used protocols and technologies in Kognifai IoT Platform and deployment scenarios

## Google protocol buffers
https://developers.google.com/protocol-buffers/

## OPC Technologies (HDA, DA, UA, AE)
OPC is the interoperability standard for the secure and reliable exchange of data in the industrial automation space and in other industries. It is platform independent and ensures the seamless flow of information among devices from multiple vendors. The OPC Foundation is responsible for the development and maintenance of this standard.

The OPC standard is a series of specifications developed by industry vendors, end-users and software developers. These specifications define the interface between Clients and Servers, as well as Servers and Servers, including access to real-time data, monitoring of alarms and events, access to historical data and other applications.

Read more on https://opcfoundation.org/about/what-is-opc/ and https://en.wikipedia.org/wiki/OPC_Unified_Architecture.

## Industrial interfaces and bus technologies
Connecting to industry standard systems often go through automation protocols, for example Modbus and Profibus.

Read more on https://en.wikipedia.org/wiki/List_of_automation_protocols. 

## Transport protocols
IoT protocols commonly used in Kognifai is Message Queuing Telemetry Transport (MQTT) and Advanced Message Queuing Protocol (AMQP).

Read more on https://en.wikipedia.org/wiki/MQTT and https://en.wikipedia.org/wiki/Advanced_Message_Queuing_Protocol. 


# License
Read the copyright information and terms and conditions for Usage and Development of the software [here](https://github.com/kognifai/Kognifai/blob/master/License.md#copyright--year-kongsberg-digital-as).
