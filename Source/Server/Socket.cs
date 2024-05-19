using System.Text;
namespace App.Server;
public class Socket(int port, int buffer_size = 1024, System.Net.Sockets.ProtocolType protocol = System.Net.Sockets.ProtocolType.Tcp) : Core.Net.Socket.Socket(port, null, buffer_size, protocol)
{
	protected System.Net.Sockets.Socket Target { get; set; }
	protected override void Init()
	{
		Body.Bind(Endpoint);
		Body.Listen();
		Target = Body.Accept();
	}

	protected override async Task Recieve()
	{
		Buffer.ReadBuffer.Flush();
		await Target.ReceiveAsync(Buffer.ReadBuffer.Body);
	}
	protected override async Task Send()
	{
		await Target.SendAsync(Buffer.WriteBuffer.Body);
		Buffer.WriteBuffer.Flush();
	}
	async Task Tick()
	{
		// loopback behaviour
		await Recieve();
		var message = Encoding.UTF8.GetString(Buffer.ReadBuffer.Body);
		Console.WriteLine($"Recieved: {message}");

		Buffer.WriteBuffer.Body = Encoding.UTF8.GetBytes($"Somebody Wrote: {message}");
		await Send();	

		Buffer.Flush();
	}
	public async Task Run()
	{
		Init();
		while (Target.Connected) await Tick();
	}
}