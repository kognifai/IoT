Welcome to IoT_Documentation! 

Explore these pages to know more about **IoT Edge Connectors**. 


In this section, we talk about:

[What is IoT?](#what-is-iot-----)

[What can you achieve with Kognifai IoT Platform?](#what-can-you-achieve-with-kognifai-iot-platform)

[Part and parcel of Kognifai IoT platform](#part-and-parcel-of-kognifai-iot-platform) 



# What is IoT ?    [![Gitter Join the chat](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/kognifai/Lobby)

Internet of things (IoT) is the inter-networking of physical devices, vehicles, buildings, and other items embedded with electronics, software, sensors, actuators, and network connectivity that enable them to collect and exchange data. 

IoT Platforms form the basis for development of scalable IoT applications and services that connect the real and virtual world between those physical devices, systems and people. Kognifai IoT platform includes software running at the edge, integrating the edge systems with the cloud, and also \the tools in the cloud required to securely manage your edge installations in a safe and secure manner.

## What can you achieve with Kognifai IoT Platform?

Kognifai IoT platform enables you to:
- Connect to a wide variety of source systems
    - Support for a growing number of source systems such as OPC DA, OPC UA and so on.
    - Connector SDK is available for the clients to build their own Connectors for proprietary source systems.

- Remotely configure the Kongsberg Edge system in a safe and secure manner
- Manage a fleet of Edge installations from the cloud in an efficient manner
- Transport data to and from the cloud in a reliable manner
- Buffer data locally at the Edge when the internet connection is down
- Stream data into your cloud applications 
- Make data available for processing in cloud analytics applications
- Use the data from the edge directly in your on-premise applications via the API's exposed by the Kognifai cloud solutions
- Monitor edge installations for intrusion attempts
- Deploy storage, calculation, and presentation capabilities at the Edge
    - it is possible to deploy both the storage and presentation tools in the cloud and at the Edge
- Reduce bandwidth usage between edge locations and cloud due to the very efficient data compression methods used by the Kognifai IoT Platform.

## Part and Parcel of Kognifai IoT platform

The Kognifai IoT platform is comprised of the following parts:

### Edge gateway
Edge gateway connects the edge devices with the cloud and transfers your data securely to the cloud. If the internet connection is unavailable, the Edge gateway buffers data locally, and retransmits once the internet connection is reestablished. The Edge gateway comes with a set of integrated connectors which can be used to connect the common protocols such as OPC DA and OPC U/A.  The Edge gateway hosts endpoints to which third parties can send data (which they want to sent to the cloud). A connector SDK is also available for clients to write custom connectors which send data to the Edge gateway.

### IoT device connectors

Kognifai Edge gateway comes with a set of integrated connectors to connect to the common source systems. In addition, it is possible to build your own device connectors using the Kognifai Connector SDK. 

### Reliable and secure transport

Kognifai Edge gateway encrypts data and sends  the data and all communications to the cloud in a secure manner. The Edge gateway solution buffers data whenever the internet connection is uavailable and retransmits the data once the internet connection is reestablished.

### IoT Cloud dispatcher

IOT gateway ensures connectivity by acting as an adapter between devices and instruments in the field and on the cloud services. It relays messages from the IoT hub/Event hub to the correct recipients on the cloud side. The Kognifai IoT Cloud dispatcher makes it possible to send messages securely back to the specific edge installations from the cloud.

### Storage

This is the layer in which the IoT data is stored and retrieved. The Kognifai Storage Solution can be deployed both at the edge and in the cloud. 

### Presentation

The Kognifai Application Framework provides a powerful visualization platform. It can be deployed at the edge, in the cloud, in the user interface (UI), in the industrial design field of human–computer interaction which is the space where interactions between humans and machines occur. Kognifai provides strong out-of-the-box collection of data visualization applications such as dashboard, trends, reports, data export and event analytics, and supports various customer IoT cases.


--------------------------------------------------------------------------------------------------------------------------
See also:
- [IoT Platform Architecture overview](IoT%20Documentation/Overview%20-%20IoT%20Platform%20Architecture%20Overview.md)
- [Edge deployment models](https://github.com/kognifai/IoT/blob/master/IoT%20Documentation/Overview%20-%20Edge%20Deployment%20Models.md)
- [Edge connectors and endpoints overview](IoT%20Documentation/Overview%20%20Connectors%20and%20Endpoints%20.md)
- [Sensor Configuration overview](IoT%20Documentation/Overview%20-%20Sensor%20Configuration%20Overview.md)
- [IoT platform security](IoT%20Documentation/Overview%20-%20Security.md)
- [Edge gateway components](IoT%20Documentation/Edge%20Gateway%20Components.md)
- [Register a new device](IoT%20Documentation/Deploy-%20register%20a%20new%20edge%20device.md)
- [Edge hardware](IoT%20Documentation/Edge%20Hardware.md)
- [Remote diagnostics](IoT%20Documentation/Remote%20Diagnostics.md)
- [Connector SDK](SDK%20Documentation/readme.md)
- [Support for low bandwidth scenarios](IoT%20Documentation/Support%20for%20low%20bandwidth%20scenarios.md)
--------------------------------------------------------------------------------------------------------------------------



## License
Read the copyright information and terms and conditions for Usage and Development of the software [here](https://github.com/kognifai/Kognifai/blob/master/License.md#copyright--year-kongsberg-digital-as).



