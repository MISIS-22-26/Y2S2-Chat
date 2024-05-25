using System.Net;
using System.Net.Sockets;
namespace App.Client;
public class Client(IPAddress address, int port, ProtocolType protocol, int buffer_size = 1024)
{
    private readonly Net.Socket socket = new(address, port, protocol, buffer_size);
	public void Start() => socket.Open();
}