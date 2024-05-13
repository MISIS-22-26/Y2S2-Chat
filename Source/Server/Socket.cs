using System.Net.Sockets;

namespace App.Server;
public class Socket : Core.Socket.Socket<TcpListener>
{
	public override void Close()
	{
		socket.Stop();
	}

	public override void Open(string ip, int port)
	{
		this.port = port;
		socket = new(port);
		Console.WriteLine("Server Is Listening");
		socket.AcceptSocket();
		Console.WriteLine("Client Accepted.");
	}

	public override void Read()
	{
		throw new NotImplementedException();
	}

	public override void Write()
	{
		throw new NotImplementedException();
	}
}