
using System.Text;
namespace App.Client;
public class Socket : Core.Net.Socket.Socket
{
	protected override void Init() => Body.Connect(Endpoint);

	protected override async Task Recieve()
	{
		Buffer.ReadBuffer.Flush();
		await Body.ReceiveAsync(Buffer.ReadBuffer.Body);
	}
	protected override async Task Send()
	{
		await Body.SendAsync(Buffer.WriteBuffer.Body);
		Buffer.WriteBuffer.Flush();
	}
	async Task Tick()
	{
		Buffer.WriteBuffer.Body = Encoding.UTF8.GetBytes($"{Console.ReadLine()}");
		await Send();
		await Recieve();
		Console.WriteLine(Encoding.UTF8.GetString(Buffer.ReadBuffer.Body));
		Buffer.Flush();
	}
	async Task Run()
	{
		Init();
		while (Body.Connected) await Tick();
	}
	public Socket(int port, System.Net.IPAddress? address = null, int buffer_size = 1024, System.Net.Sockets.ProtocolType protocol = System.Net.Sockets.ProtocolType.Tcp) : base(port, address, buffer_size, protocol) => Run();
}