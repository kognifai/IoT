# Kognifai IoT Platform Architecture Overview

![](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/Kognifai Iot Platform - platform overview.png?raw=true)

The Kognifai IoT Platform consists of a series of edge and cloud side components:

## Edge:
- The Edge Registration Tool will register a new device with the Kognifai cloud and install the Edge Management Client. As part of this registration, a private/public key-pair will be generated within the TPM chip of the device. 
- The Edge Management Client will regularly ask the Edge Management Gateway if new software can be downloaded and onto the edge device, and then download and install the software updates. The Edge Management Client will also regularly download new authentication tokens for use with other services. The Edge Management Client uses the Trusted Platform Module (TPM) to authenticate with the cloud through a TPM challenge. 
- The Edge gateway software distribution comes in different flavors, and it is the entity that takes care of receiving, buffering and sending sensor data to the cloud.

## Cloud
- The Edge Management Gateway will be enable new edge devices to be registered, it will relay new software updates and it will on a regular basis issue new access tokens to the Edge devices. When the Edge device is requested to download a new software version, the Edge management Gateway will issue a manifest for the new software, containing a signature of all the files that should be downloaded from blob storage.
- Azure IoT hub is used to send push messages from the cloud to the device
- Azure Event Hub is used for receving and relaying sensor data to cloud applications.
- IoT Management Portal is used to approve new edge devices, push software updates to the edge devices and for remote configuration of the edge devices
