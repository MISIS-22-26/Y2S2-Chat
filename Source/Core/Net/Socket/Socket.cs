using System.Net;
using System.Net.Sockets;
using App.Core.Bufferization;

namespace App.Core.Net.Socket;
public abstract class Socket(int port ,IPAddress? address = null, int buffer_size = 1024, ProtocolType protocol = ProtocolType.Tcp)
{
	// Compiler wouldn't allow IPAddress.Loopbackloopback to be passed as 
	// a default AddressType, thus coalesce expression and null default 
	// values are used here to work around it.
	protected IPEndPoint Endpoint { get; } = new(address ?? IPAddress.Loopback, port);
	protected System.Net.Sockets.Socket Body { get; } = new(AddressFamily.InterNetwork, SocketType.Stream, protocol);
	protected IOBuffer Buffer { get; } = new(size: buffer_size);

	protected abstract void Init ();
	protected abstract Task Send ();
	protected abstract Task Recieve ();
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