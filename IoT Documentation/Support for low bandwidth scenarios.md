# Support for low bandwidth scenarios

It is quite common for IoT equipment to be deployed in remote locations with poor and intermittent network connectivity. The Kognifai IoT platform has been designed with this in mind to reduce bandwidth consumption:

- The edge gateway will time multiplex data: All data received in a configurable interval (e.g. 3 seconds) will be buffered, compressed and sent as one package over the network. This gives better compression and less "chatty" communication over the network.
- The Kognifai IoT platform uses a compact protobuf schema to define the telemetry data to be sent to the cloud, which together with compression reduces the payload sent across the network


It is also important that the solution we deploy in the field is resilient and will continue to work in case the internet connection is lost: 

- The Kognifai Edge gateway will buffer data to disk and resume transmission once the network is up.
- When the network is up the Kognifai Edge gateway will stream data via azure blob storage for direct bulk ingest into cloud storage solutions. This offers a  cost efficient and robust mechanism to upload data gathered while the internet connection was down.

## Configurable transports
The cost of various IoT transport and cloud ingest solutions is in constant development. The Kognifai Edge solution employs a pluggable transport design, which will make it possible to adapt to future changes in this area. We currently use Azure Event hubs for telemetry data, which offers a cost efficient solution.
