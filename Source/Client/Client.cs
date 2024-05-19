using System.Net;

namespace App.Client;
public class Client(int port = 8888, IPAddress? address = null)
{
	Socket socket = new(port, address);
	public async Task Start() => await socket.Run();
}