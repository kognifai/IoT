# Setting up a new edge device
In order to set up a new edge device, there are three steps which need to be carried out:
1) Run the edge registration tool.
 The Edge Registration Tool will register a new device with the Kognifai cloud and install the Edge Management Client. As part of this registration, a private/public key-pair will be generated within the TPM chip of the device.  
2) A Kongsberg employee will approve the device in the IoT Management Portal and select which software that should be pushed to the device. The software will automatically be downloaded and installed.
3) Use the  [Sensor configuration App](Overview%20-%20Sensor%20Configuration%20Overview.md) to determine which sensors that should be streamed to the cloud

## Vessel Insight service
Kognifai Edge is an integrated part of the Vessel Insight service. If the Kognifai Edge device is part of the Vessel Insight service, the edge device will be pre-configured with software and registered in the IoT Management system prior to shipment to edge location.

# See Also
[IoT Platform Architecture](Overview%20-%20IoT%20Platform%20Architecture%20Overview.md)
