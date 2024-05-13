using System.Net;
using System.Net.Sockets;

namespace App.Client;
public class Socket : Core.Socket.Socket<TcpClient>
{
	public override void Close()
	{
		socket.Close();
	}

	public override void Open(string ip, int port)
	{
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
