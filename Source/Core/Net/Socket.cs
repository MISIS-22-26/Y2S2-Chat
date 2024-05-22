using System.Net;
using System.Net.Sockets;
using App.Core.IO;


namespace App.Core.Net;
public abstract class Socket(IPAddress? address, int port, ProtocolType protocol, Reader reader, Writer writer)
{
	// Compiler wouldn't allow IPAddress.Loopbackloopback to be passed as 
	// a default AddressType, thus coalesce expression and null default 
	// values are used here to work around it
	protected IPEndPoint Endpoint { get; } = new(address ?? IPAddress.Loopback, port);
	protected System.Net.Sockets.Socket Body { get; } = new(AddressFamily.InterNetwork, SocketType.Stream, protocol);





	protected List<Node> Proccesses { get; } = [];
	public Reader Reader { get; } = reader;
	public Writer Writer { get; } = writer;
	
	

	// User-Defined Preparations before actual Startup.
	protected abstract void Setup();
	
	// Core-Defined Preparations with followed up startup
	public void Init (){
		Setup();
		Proccesses.Add(Reader);
		Proccesses.Add(Writer);

		foreach(var proccess in Proccesses) proccess.Start();
	}
	public void Close () 
	{
		try
		{
			foreach (var proccess in Proccesses) ((IRunnable) proccess).Stop();
			Body.Shutdown(SocketShutdown.Both); 
			Body.Close();
		}
		catch
		{
			Console.WriteLine("Socket Shutdown Failure");
		}
	}
}