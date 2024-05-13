using System.Net.Sockets;

namespace App.Client;
public class Socket : Core.Socket.Socket<TcpClient>
{
	public override void Close()
	{
		if (!socket.Connected) return;
		socket.Close();
	}

	public override void Open(string ip, int port)
	{
		if(socket.Connected) return;
		this.ip = ip;
		this.port = port;

		socket = new(ip, port);
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
