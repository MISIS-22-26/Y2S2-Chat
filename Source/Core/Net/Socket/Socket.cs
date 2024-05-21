using System.Net;
using System.Net.Sockets;
using App.Core.IO;


namespace App.Core.Net.Socket;
public abstract class Socket(IPAddress? address, int port, ProtocolType protocol, Reader reader, Writer writer)
{
	// Compiler wouldn't allow IPAddress.Loopbackloopback to be passed as 
	// a default AddressType, thus coalesce expression and null default 
	// values are used here to work around it
	protected IPEndPoint Endpoint { get; } = new(address ?? IPAddress.Loopback, port);
	protected System.Net.Sockets.Socket Body { get; } = new(AddressFamily.InterNetwork, SocketType.Stream, protocol);





	protected List<IRunnable> Proccesses { get; } = [];
	public Reader Reader { get; }
	public Writer Writer { get; }
	
	


	protected abstract void Setup();
	public void Init (){
		Setup();
		Proccesses.Add((IRunnable) Reader);
		Proccesses.Add((IRunnable) Writer);

		foreach(var proccess in Proccesses) proccess.Start();
	}
	public void Close () 
	{
		try
		{
			foreach (var proccess in Proccesses) proccess.Stop();
			Body.Shutdown(SocketShutdown.Both); 
			Body.Close();
		}
		catch
		{
			Console.WriteLine("Socket Shutdown Failure");
		}
	}
}