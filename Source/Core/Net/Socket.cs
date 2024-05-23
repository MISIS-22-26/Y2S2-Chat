using System.Net;
using System.Net.Sockets;
using App.Core.IO;


namespace App.Core.Net;
public abstract class Socket(IPAddress? address, int port, ProtocolType protocol, int buffer_size)
{
	public int BufferSize { get; } = buffer_size;
	protected IPEndPoint Endpoint { get; } = new(address ?? IPAddress.Loopback, port);
	public System.Net.Sockets.Socket Body { get;} = new(AddressFamily.InterNetwork, SocketType.Stream, protocol);
	protected List<IRunnable> Proccesses { get; } = [];


	
	public Reader<byte> Reader { get; protected set; }
	public Writer<byte> Writer { get; protected set; }
	
	

	protected abstract void Init();
	public void Open()
	{
		Init();
		Proccesses.Add(Reader);
		Proccesses.Add(Writer);

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