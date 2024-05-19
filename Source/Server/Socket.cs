using System.Text;
namespace App.Server;
public class Socket : App.Core.Net.Socket.Socket
{
	protected System.Net.Sockets.Socket Target { get; set; }
	protected override void Init()
	{
		Body.Bind(Endpoint);
		Body.Listen();
		Target = Body.Accept();
	}

	protected override void Recieve()
	{
		Buffer.ReadBuffer.Flush();
		Target.Receive(Buffer.ReadBuffer.Body);
	}
	protected override void Send()
	{
		Target.Send(Buffer.WriteBuffer.Body);
		Buffer.WriteBuffer.Flush();
	}
	void Tick()
	{
		// loopback behaviour
		Recieve();
		var message = Encoding.UTF8.GetString(Buffer.ReadBuffer.Body);
		Console.WriteLine($"Recieved: {message}");

		Buffer.WriteBuffer.Body = Encoding.UTF8.GetBytes($"Somebody Wrote: {message}");
		Send();	

		Buffer.Flush();
	}
	void Run()
	{
		Init();
		while (Target.Connected) Tick();
	}
	public Socket(int port, int buffer_size = 1024, System.Net.Sockets.ProtocolType protocol = System.Net.Sockets.ProtocolType.Tcp) : base(port, null, buffer_size, protocol) => Run();

}