# Connectors and endpoints

An edge gateway distribution can contain multiple connectors and endpoints.
- A connector is a component which will connect to a source system as a client and retrieve sensor data. There are two types of connectors,- integrated and custom, which are described below.
- An endpoint is a server being hosted by the edge gateway distribution which allow thrid party systems and custom connectors to push sensor data to the edge gateway.

## Connectors
Kognifai Edge Gateway supports two types of connectors; Integrated Connectors and Custom/System specific connectors. 
In this section, you will learn about these two types of connectors and how they are different with each other.

The following figure illustrates the Koginifai Connectors:
![](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/Kognifai%20Connectors%20.png?raw=true)

## Integrated connectors
Integrated connectors are part of the Kognifai Edge software build. They work as clients to consume data from third party systems for example OPC DA or OPC U/A servers. Integrated connectors can be managed and re-configured from a remote location.

## Custom/System specific connectors 
Connectors can be built using the Kognifai Edge connector SDK. These connectors will then be used to query client systems at the edge location and push data to the Kognfai Edge gateway over the MQTT protocol. The Kognifai Edge gateway will then receive, buffer and forward messages received.

## Endpoints
- An endpoint is a server being hosted by the edge gateway distribution which allow thrid party systems and custom connectors to push sensor data to the edge gateway.
- We currently support two endpoints: the MQTT endpoint and the WCF endpoint.