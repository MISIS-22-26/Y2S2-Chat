# VERSION
This file contains versions of the app as well as key features of a release:
## 0.0.1
	1. Built raw api to interface with dotnet's sockets
	2. Made basic single tunnel Client-Server connection.

#### TODO
	1. Client Message Sender
	2. Server Message Reciever

## [*] 0.0.2
	1. Reimplemented Socket Communication in Core.Net.Socket
	2. Added One to One Socket Connection with the ability to wirite messages to one another
#### TODO
	1. Make Client-Server Response not Buggy (Delayed output bug)
		1.1. Move reader to different thread
		1.2. Move writer to different thread
		1.3. Move Printer to different thread
	2. Add Multi-Client Connection Server