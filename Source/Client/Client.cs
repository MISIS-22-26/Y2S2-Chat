namespace App.Client;
public class Client(System.Net.IPAddress address, int port, System.Net.Sockets.ProtocolType protocol, int buffer_size = 1024)
{
    private readonly Socket socket = new(address, port, protocol, buffer_size);
	public void Start() => socket.Open();
}