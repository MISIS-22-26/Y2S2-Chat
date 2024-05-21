using System.Net;
using System.Net.Sockets;
using App.Core.IO;


namespace App.Core.Net.Socket;
public abstract class Socket(IPAddress? address = null, int port = 8888, int buffer_size = 1024, ProtocolType protocol = ProtocolType.Tcp)
{
	// Compiler wouldn't allow IPAddress.Loopbackloopback to be passed as 
	// a default AddressType, thus coalesce expression and null default 
	// values are used here to work around it
	protected IPEndPoint Endpoint { get; } = new(address ?? IPAddress.Loopback, port);
	protected System.Net.Sockets.Socket Body { get; } = new(AddressFamily.InterNetwork, SocketType.Stream, protocol);
	public Reader Reader { get; }
	protected Writer Writer { get; }
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