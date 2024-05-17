using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace App.Core;
public class Socket
{
	public enum MODE { SERVER, CLIENT };
	MODE mode { get; }
	IPEndPoint endpoint { get; } 
	System.Net.Sockets.Socket socket { get; }
	void Open()
	{
		
		try
		{
			switch (mode)
			{
				case MODE.SERVER :
					socket.Bind(endpoint);
					this.socket.Listen();
					socket.Accept();
				break;
				case MODE.CLIENT : 
					socket.Connect(endpoint);
				break;
			}
			Console.WriteLine("Success");
		}
		catch
		{
			Console.WriteLine("Failure, Reconnecting ...");
		}
	}
	void Send()
	{
		socket.Send(Encoding.UTF8.GetBytes("Sample"));
	}
	void Read()
	{
		socket.Read();
	}
	public Socket(MODE mode, int port ,IPAddress? address = null ,ProtocolType protocol = ProtocolType.Tcp)
	{
		this.mode = mode;
		address = ((mode == MODE.CLIENT) && (address != null)) ? address : IPAddress.Loopback;
		socket = new(AddressFamily.InterNetwork, SocketType.Stream, protocol);
		endpoint = new(address, port);
		
		Open();
	}
	~Socket()
	{
		socket.Shutdown(SocketShutdown.Both);
		socket.Disconnect(false);
		socket.Close();
	}
}