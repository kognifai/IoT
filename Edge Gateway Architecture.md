# Edge Gateway Architecture
After reading this article you will get to know the components of Kognifai edge gateway and their placement in the edge gateway architecture.

 The following diagram illustrates how multiple components of the Kognifai edge gateway are distributed and communicate with each other in the edge gateway:

![Kognifai Edge Gateway Distribution](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/Kognifai%20Edge%20Gateway%20Distribution.png?raw=true)

An edge gateway distribution is composed of multiple components:

- An MQTT endpoint to which standalone connectors can send messages
- Integrated connector(s),- components which act as clients to third party systems such as OPC servers etc
- A configuration manager which ensures that each component has the configuration it needs.
- Reliable transport,- this component will send data to the cloud. If the cloud connection is down, this component will buffer data to disk and re-send the data once the
connection is up again.
- The core components of the Edge gateway are written in .Net standard, which makes it possible to run the Edge gateway on multiple platforms.

# Edge Hardware
The hardware usage on the edge will vary depending on whether a full stack of products including edge gateway, storage, stream analytics, and presentation is deployed, or if just an Edge gateway is deployed. For situations where the Kognifai Edge gateway is deployed in a standalone configuration, the hardware requirements are small, but they will of course depend on how many sensor values that will be handled per second.

Clients can either deploy the software on existing hardware, or Kongsberg may provide the hardware and the software as a part of a turn-key solution. In both cases it is strongly recommended that the hardware has a TPM 2.0 chip in order to protect secrets and configuration stored at the edge.
