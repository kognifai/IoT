
This article explains the components of Kognifai edge gateway and their placement in the edge gateway architecture.

 The following diagram illustrates how multiple components of the Kognifai edge gateway are distributed and communicate with each other in the edge gateway:

![Kognifai Edge Gateway Distribution](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/Kognifai%20Edge%20Gateway%20Distribution.png?raw=true)

An edge gateway distribution is composed of multiple components:

- An MQTT endpoint to which standalone connectors can send messages
- Integrated connector(s),- components which act as clients to third party systems such as OPC servers etc
- A configuration manager which ensures that each component has the configuration it needs.
- Reliable transport,- this component will send data to the cloud. If the cloud connection is down, this component will buffer data to disk and re-send the data once the
connection is up again.
- The core components of the Edge gateway are written in .Net standard, which makes it possible to run the Edge gateway on multiple platforms.

