Edge installations can be deployed in various configurations, depending on client requirements:

- A deployment can incorporate an edge gateway, a full storage solution, stream analytics and application framework /viewer.  
- Most edge installations are more lightweight, and will only include the edge gateway. The Edge gateway will buffer sensor data and forward it to the cloud solution.

  ![Edge Deployment Model](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/Edge%20Deployment.png?raw=true)

There are several variants of how a lightweight edge solution might be deployed:

**1.**	Kognifai EdgeGateway with integrated connectors (clients) to consume data from third party systems such as for example OPC servers. Integrated connectors can be managed and re-configured from a remote location.

**2.**	Kongsberg EdgeGateway deployed with one or more endpoints to which third party systems can send data. The Kognifai EdgeGateway supports a MQTT endpoint and there is a connector SDK which will help third parties go get started with writing connectors that can send data to the Kognifai EdgeGateway. 

**3.**	A combination of **1)** and **2)**. The Kognifai EdgeGateways are available in several distributions, and a distribution will contain a set of integrated connectors and endpoints to which clients can send data.

![Kognifai Edge Gateway Distribution](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/Kognifai%20Edge%20Gateway%20Distribution.png?raw=true)

The figure above, shows a deployment with an integrated connector which will poll or subscribe data from a source system and then forward it via our reliable transfer module.

![Edge Gateway Distribution with MQTT Endpoint](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/Kgnifai%20Edge%20Gateway%20Distribution%20with%20MQTT%20endpoint.png?raw=true)

The above figure shows a deployment where the connector SDK has used to write a custom/standalone connector, which talks to the Edge gateway over MQTT and sends packages serialized with protobuf. The Reliable transfer component will then transfer this data to the cloud.
