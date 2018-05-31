The following topics are covered in this section:

[Serialization - Supported datatypes](https://github.com/kognifai/IoT_Documentation/wiki/Serialization#serialization---supported-datatypes)

[Understanding the protobuf object structure](https://github.com/kognifai/IoT_Documentation/wiki/Serialization#understanding-the-protobuf-object-structure)

[Protobuf schema and message routing](https://github.com/kognifai/IoT_Documentation/wiki/Serialization#protobuf-schema-and-message-routing)

--------------------------------------------------------------------------------------------------------------------------
The edge gateway expects to receive messages serialized with protobuf. Protobuf is a very efficient serialization format for which there are tools/libraries in many programming languages. This will enable having connectors implemented in many different languages. For C# there is also a nugget package which contains pre-built binaries.

# Serialization - Supported datatypes

The serialization system is extensible. It does currently support the following datatypes:

- Timeseries
- Dataframe (sampleset)
- Alarm
- StateChange

The protobuf schema that describes the objects used by the Kognifai Edge gateway can be downloaded here [link?]. 

# Understanding the protobuf object structure

Here is the Protobuf Schema explained through following figure:

![](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/Kognifai%20Protbuf.png?raw=true)

- In order to optimize the bandwidth utilization for the solution and to simplify message flow, a set of messages from the Edge gateway are grouped together.
- Each of the messages are serialized to a byte array and inserted into a “MessageWrapper”. 
- An array of “MessageWrappers” will be compressed and put into a “MessageArrayContainer”. Since this compression will operate on a number of messages,the compression ratio will be higher compared to compressing  just individual messages.
- Once the MessageArrayContainer is prepared, it will be sent to the consumer using the MQTT protocol.

For more information on Protocol Buffers, refer:: https://developers.google.com/protocol-buffers/

# Protobuf schema and message routing

 The prootobuf MessageWrapper object can contain any message inside, serialized as a byte array.

- In order to facilitate routing on the cloud side, we use a subprotocol number to indicate what area the message is related to. 
- Timeseries data will use subprotocol 0.
- Within each subprotocol each message type will have a unique message number, which can then be used for more fine-grained message routing within a message handler for that sub protocol in the cloud.

![](https://github.com/kognifai/IoT_Documentation/blob/master/IoT_Images/Protobuf%20Schema.png?raw=true)

