using System.Net;
using System.Net.Sockets;
using App.Core.IO;
using App.Core.Multithreading;


namespace App.Core.Net;
public abstract class Socket<R,W> where R : Reader<byte> where W : Writer<byte>
{
	public Socket(IPAddress address, int port, ProtocolType protocol, R reader, W writer)
	{

		// Network
		Endpoint = new IPEndPoint(address, port);
		Body = new Socket(Endpoint.AddressFamily, SocketType.Stream, protocol); // socket


		// Bufferized IO
		Reader = reader;
		Writer = writer;
		Proccesses.Add(Reader);
		Proccesses.Add(Writer);

	}


	/* Network */
	public EndPoint Endpoint { get; protected set; }
    public Socket Body { get; }


	/* Bufferized IO */
    protected List<IRunnable> Proccesses { get; } = [];
	public R Reader { get; protected set; }
	public W Writer { get; protected set; }
	
	

	/* Controllers */
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