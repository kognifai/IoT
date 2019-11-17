#  Architectural Overview of the Kognifai IoT Platform

The Kognifai IoT Platform consists of a series of edge and cloud side components:

![](.%20IoTImages/kognifai_iotplatform_architecture_edge_simple.png?raw=true)

## Edge Components 

 
- **The Edge Management Agent** will regularly send request to the -Edge Management Gateway- if new software can be downloaded onto the edge device, if yes, then download and install the software updates. The Edge Management Client will also regularly download new authentication tokens for use with other services. 
The Edge Management Client uses the -Trusted Platform Module (TPM)- to authenticate with the cloud through a TPM challenge. 

- **The Edge gateway** comes in different flavours, and it is the entity that takes care of receiving, buffering, and sending sensor data to the cloud. The edge gateway contains a set of connectors and endpoints. For example the "Generic Linux Edge gateway distribution" will contain both a MQTT endpoint (broker) and also connectors for both NMEA and MODBUS.

- **Other containers** - The container system makes it possible to deploy a wide range of containers, and these containers could in principle offer both backend functionality and frontend/web applications.

## Cloud Components 
- **The Edge Management Gateway** will enable new edge devices to be registered, it will relay new software updates and it issues new access tokens to the Edge devices on a regular basis.

- **Azure Event Hub** is used for receiving and relaying sensor data to cloud applications. It buffers data when the data arrives at the cloud, ensuring that a restart of a cloud service does not cause any data loss.

- **IoT Management Portal** is used to approve new edge devices, push software updates to the edge devices and for remote configuration of the edge devices.

- **Sensor Configuration Application** is used to choose sensors for replication to the cloud.
