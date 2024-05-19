using System.Net;
using System.Net.Sockets;
namespace App.Core.Net.Socket;
public abstract class Socket(int port ,IPAddress? address = null, int buffer_size = 1024, ProtocolType protocol = ProtocolType.Tcp)
{



	// Compiler wouldn't allow IPAddress.Loopbackloopback to be passed as 
	// a default AddressType, thus coalesce expression and null default 
	// values are used here to work around it.
	IPEndPoint Endpoint { get; } = new(address ?? IPAddress.Loopback, port);
	System.Net.Sockets.Socket Body { get; } = new(AddressFamily.InterNetwork, SocketType.Stream, protocol);
	Buffer Buffer { get; } = new(size: buffer_size);

	protected abstract void Init ();
	protected abstract void Send ();
	protected abstract void Recieve ();
	public void Close () 
	{
		try
		{
			Body.Shutdown(SocketShutdown.Both); 
			Body.Close();
		}
		catch
		{
			Console.WriteLine("Socket Shutdown Failure");
		}
	}
}