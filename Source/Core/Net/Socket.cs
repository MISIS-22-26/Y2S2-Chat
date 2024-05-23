using System.Net;
using System.Net.Sockets;
using App.Core.IO;


namespace App.Core.Net;
public abstract class Socket(System.Net.Sockets.Socket socket, int buffer_size)
{
    public Socket(IPAddress? address, int port, ProtocolType protocol, int buffer_size) : this(new(new IPEndPoint(address ?? IPAddress.Loopback, port).AddressFamily , SocketType.Stream, protocol), buffer_size) {}



    public int BufferSize { get; } = buffer_size;
    public System.Net.Sockets.Socket Body { get; } = socket;
    protected List<IRunnable> Proccesses { get; } = [];


	
	public Reader<byte>? Reader { get; protected set; } = null;
	public Writer<byte>? Writer { get; protected set; } = null;
	
	

	protected abstract void Init();
	public void Open()
	{
		Init();

		 // If null throw null ref exception
		Proccesses.Add(Reader ?? throw new NullReferenceException("Reader Can't be null"));
		Proccesses.Add(Reader ?? throw new NullReferenceException("Writer Can't be null"));

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