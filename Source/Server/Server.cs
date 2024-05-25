using System.Net.Sockets;
namespace App.Server;
public class Server 
{
	public Server(int port, ProtocolType protocol, int buffer_size = 1024)
	{
        // Acceptoer
        Sockets.Add(new(port, protocol, buffer_size));
        Sockets[0].Open();
    }
	List<Socket> Sockets { get; }= [];
	public void Start() { foreach(var socket in Sockets) socket.Open();}
	public void Stop()
    {
        // Stop Accepter
		foreach (var socket in Sockets) socket.Close();
    }
}