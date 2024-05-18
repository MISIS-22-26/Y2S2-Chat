using System.Net;
using System.Net.Sockets;
using System.Text;
namespace App.Core.Net;
public class Socket(Mode mode, int port ,IPAddress? address = null , int buffer_size = 1024, ProtocolType protocol = ProtocolType.Tcp)
{



	// Compiler wouldn't allow IPAddress.Loopbackloopback to be passed as 
	// a default AddressType, thus coalesce expression with address fallback
	// to null as a default are used here to hack around it.
	IPAddress address { get; } = address ?? IPAddress.Loopback; 



	
	Mode mode { get; } = mode;
	IPEndPoint endpoint { get; } = new(address ?? IPAddress.Loopback, port);







	System.Net.Sockets.Socket socket { get; } = new(AddressFamily.InterNetwork, SocketType.Stream, protocol);
	System.Net.Sockets.Socket connection { get; set; }








	int buffer_size { get; } = buffer_size;
	byte[] read_buffer { get; set; } = new byte[buffer_size];
	byte[] write_buffer { get; set; } = new byte[buffer_size];
	string message => Read();








	void Open()
	{
		// This is a comment
		try
		{

			socket.Bind(endpoint);
			socket.Listen();
			Console.WriteLine("Socket opened and is listening for incoming connections ...");
		}
		catch
		{

			Console.WriteLine("Failure whilst openning socket..");
		}
	}
	async Task Connect()
	{
		// This is a comment
		try
		{
			await socket.ConnectAsync(endpoint);
			Console.WriteLine("Scoket is connecting to the remote ...");
		}
		catch
		{
			Console.WriteLine("Connection failure..");
		}
	}
	async Task Accept()
	{
		try
		{
			connection = await socket.AcceptAsync();
		}
		catch
		{
			Console.WriteLine(" Failed to Accept Connection");
		}
	}


	async Task Run()
	{
		System.Net.Sockets.Socket? target = null;
		switch(mode)
		{
			case Mode.Server: Open(); await Accept(); target = connection; break;
			case Mode.Client: await Connect(); target = socket; break;
		}
		while (target != null && target.Connected) {
			await Recieve();
			await Send();
			Console.WriteLine(message);;
			Write($"{Console.ReadLine()}" );
		}

	}
	
	
	
	
	
	
	public async Task Start() => await Run();
	public void Stop()
	{	
		try
		{
			socket.Shutdown(SocketShutdown.Both);
			socket.Disconnect(false);
			socket.Close();
			Console.WriteLine("Socket Closed.");

		}
		catch
		{
			Console.WriteLine("Failure whilst disconnecting socket..");
		}
	}






	async Task Send() 
	{
		if (write_buffer.Length == 0) return;
		switch (mode)
		{
			case Mode.Server :
				await connection.SendAsync(write_buffer);
			break;
			case Mode.Client :
				await socket.SendAsync(write_buffer);
			break;
		}
	}
	async Task Recieve() 
	{
		if (read_buffer.Length == 0) return;
		switch (mode)
		{
			case Mode.Server :
				await connection.ReceiveAsync(read_buffer);
			break;
			case Mode.Client :
				await socket.ReceiveAsync(read_buffer);
			break;
		}
	}






	public void Write(string message) => write_buffer = Encoding.UTF8.GetBytes(message);
	public string Read() => Encoding.UTF8.GetString(read_buffer);
}