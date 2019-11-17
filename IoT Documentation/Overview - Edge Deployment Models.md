# Edge Deployment models

Edge installations can be deployed in various configurations, depending on client requirements:

- A deployment can incorporate an edge gateway, a full storage solution, a set of containers with application funcitionality etc
- The system can be deployed both on windows and linux. Containers are only supported on linux.

There are several variants of how a lightweight edge solution might be deployed:

**1.**	Kognifai Edge Gateway with integrated connectors (clients) to consume data from third party systems such as for example OPC servers. Integrated connectors can be managed and re-configured from a remote location.

**2.**	Kongsberg Edge Gateway deployed with one or more endpoints to which third party systems can send data. The Kognifai Edge Gateway supports a MQTT endpoint and there is a connector SDK which will help third parties go get started with writing connectors that can send data to the Kognifai Edge Gateway. 

**3.**	A combination of **1)** and **2)**. The Kognifai Edge Gateways are available in several distributions, and a distribution will contain a set of integrated connectors and endpoints to which clients can send data.

![Kognifai Edge Gateway Distribution](.%20IoTImages/Kognifai%20Edge%20Gateway%20Distribution.png?raw=true)

The figure above, shows a deployment with an integrated connector which will poll or subscribe data from a source system and then forward it via our reliable transfer module.

![Edge Gateway Distribution with MQTT Endpoint](.%20IoTImages/Kgnifai%20Edge%20Gateway%20Distribution%20with%20MQTT%20endpoint.png?raw=true)

The above figure shows a deployment where the connector SDK has used to write a custom/standalone connector, which talks to the Edge gateway over MQTT and sends packages serialized with protobuf. The Reliable transfer component will then transfer this data to the cloud.
dsfs
