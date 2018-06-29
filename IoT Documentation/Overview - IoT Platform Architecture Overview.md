#  Architectural Overview of the Kognifai IoT Platform

The Kognifai IoT Platform consists of a series of edge and cloud side components:

![](.%20IoTImages/Kognifai%20Iot%20Platform%20-%20platform%20overview.png?raw=true)


## Edge Component 
- **The Edge Registration Tool** will register a new device with the Kognifai cloud and install the -Edge Management Client-. As part of this registration, a private/public key-pair will be generated within the TPM chip of the device.
 
- **The Edge Management Client** will regularly send request to the -Edge Management Gateway- if new software can be downloaded onto the edge device, if yes, then download and install the software updates. The Edge Management Client will also regularly download new authentication tokens for use with other services. 
The Edge Management Client uses the -Trusted Platform Module (TPM)- to authenticate with the cloud through a TPM challenge. 

- **The Edge gateway software distribution** comes in different flavours, and it is the entity that takes care of receiving, buffering, and sending sensor data to the cloud.

## Cloud Component 
- **The Edge Management Gateway** will enable new edge devices to be registered, it will relay new software updates and it issues new access tokens to the Edge devices on a regular basis. When the Edge device is requested to download a new software version, the Edge management Gateway will issue a manifest for the new software containing a signature of all the files that should be downloaded from blob storage.

- **Azure IoT hub** is used to send push messages from the cloud to the device. IoT Hub is a Microsoft Azure service for providing secure and scalable two-way communication between devices, instruments, and IOT gateways in the field and the cloud. It buffers data when the data arrive at the cloud, ensuring that a restart of a cloud service doest not cause any data loss.

- **Azure Event Hub** is used for receiving and relaying sensor data to cloud applications. It buffers data when the data arrives at the cloud, ensuring that a restart of a cloud service does not cause any data loss.

- **Edge Device Management Portal** is used to approve new edge devices, push software updates to the edge devices and for remote configuration of the edge devices.

- **Sensor Configuration Web Application** is used to choose sensors which are available and that we would like to replicate to the cloud.

- **IoT Cloud dispatcher** - relays messages from the IoT hub & event hub to the correct recipients on the cloud side.
