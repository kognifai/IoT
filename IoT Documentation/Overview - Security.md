# Kognifai IoT Platform Security

The Kognifai IoT Platform takes a layered approach to security in order to protect the edge installation, the data and the cloud system. It can be compared to peeling layers of an onion, - and we want to provide security at every layer. This is sometimes also called "security in depth" by security professionals.

# Hardware based root of trust at the Edge
The Kognifai IoT Platform supports hardware based root of trust. We use the trusted platform module (TPM 2.0) of the edge device to store the edge device's private/public key-pair. This makes it close to impossible to retrieve the device's private key without physically destroying the device.

The hardware based root of trust is used to authenticate the edge device with the cloud when the edge management client connects to the cloud.  This is done through what is called a TPM challenge. Basically the cloud will send the edge device a random number encrypted with the edge's public key. This can only be decrypted by the TPM chip, and it can only be done by the correct device. Once the device sends the de-crypted number back to the cloud, it confirms its identity.

# Signed software
The software that is downloaded to the device by the Edge Management Client is signed in order to prevent any tampering with the software

# Updatable security
The software running at the edge can be updated remotely. Any security patches fot the edge gateway software can easily be deployed across many devices.

# Secure network
All of the connections between the edge device is run over encrypted channels (AMQP with encryption for streaming and TLS for webservices). In addition the network between the edge device and the cloud can be set up with SSL VPN.

# Lock down of edge devices
Edge devices will be locked down, and functionlity such as for example boot from USB will be disabled for un-authorized users.

# Monitor edge installations
The edge software contains functionality for streaming of edge system logs to the cloud for security inspection. This makes it possible

# Secure storage of secrets in the cloud
Any secret information in the cloud will be stored in a HSM device (Azure Vault)


