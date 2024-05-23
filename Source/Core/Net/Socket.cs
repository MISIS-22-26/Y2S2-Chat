using System.Net;
using System.Net.Sockets;
using App.Core.IO;


namespace App.Core.Net;
public abstract class Socket
{
	public Socket(IPAddress address, int port, ProtocolType protocol, int buffer_size, Reader<byte> reader, Writer<byte> writer)
	{
		BufferSize = buffer_size;
		
		var endpoint = new IPEndPoint(address ?? IPAddress.Loopback, port);
		var socket = new System.Net.Sockets.Socket(endpoint.AddressFamily, SocketType.Stream, protocol);		
	
		Endpoint = endpoint;
		Body = socket;

		Reader = reader;
		Writer = writer;

		Proccesses.Add(Reader);
		Proccesses.Add(Writer);

	}
	public EndPoint Endpoint { get; protected set; }
    public System.Net.Sockets.Socket Body { get; }


	public int BufferSize { get; }
    protected List<Multithreading.IRunnable> Proccesses { get; } = [];
	public Reader<byte> Reader { get; protected set; }
	public Writer<byte> Writer { get; protected set; }
	
	

	protected abstract void Init();
	public void Open()
	{
		Init();
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