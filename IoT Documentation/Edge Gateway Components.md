# Edge Gateway Components
After reading this article you will get to know the components of Kognifai edge gateway and their placement in the edge gateway architecture. There are several variants/distributions of the Edge gateway software, but as you will see below, they all share some common components. The Edge gateway distribution should be chosen depending on the data source and network at the edge location.


![Kognifai Edge Gateway Distribution](.%20IoTImages/Kognifai%20Edge%20Gateway%20Distribution.png?raw=true)

The figure above, shows a deployment with an integrated connector which will poll or subscribe data from a source system and then forward it via our reliable transfer module.

The components:

- Integrated connector(s) - components which act as clients to third party systems such as OPC servers etc. These connectors will subscribe or poll for updated sensor values.
- A configuration manager which ensures that each component has the configuration it needs.
- Reliable transport- this component will send data to the cloud. If the cloud connection is down, this component will buffer data to disk and re-send the data once the
connection is up again.
- The core components of the Edge gateway are written in .Net standard, which makes it possible to run the Edge gateway on multiple platforms.


![Edge Gateway Distribution with MQTT Endpoint](.%20IoTImages/Kgnifai%20Edge%20Gateway%20Distribution%20with%20MQTT%20endpoint.png?raw=true)

The above figure shows a deployment where the connector SDK has used to write a custom/standalone connector, which talks to the Edge gateway over MQTT and sends packages serialized with protobuf. The Reliable transfer component will then transfer this data to the cloud.

The components:

- An MQTT endpoint to which standalone connectors can send messages
- The MQTT endpoint will also allow Connector SDK users to send list of available sensors to the endpoint and optionally also to subscribe for changes to the sensor transmit list
- A configuration manager which ensures that each component has the configuration it needs.
- Reliable transport- this component will send data to the cloud. If the cloud connection is down, this component will buffer data to disk and re-send the data once the connection is up again.
- The core components of the Edge gateway are written in .Net standard, which makes it possible to run the Edge gateway on multiple platforms.

