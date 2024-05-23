using System.Net;

namespace App.Server;
public class Server(IPAddress? address, int port, System.Net.Sockets.ProtocolType protocol, int buffer_size = 1024)
{
	List<Socket> Sockets { get; }= [];
	public void Start() { foreach(var socket in Sockets) socket.Open();}
}