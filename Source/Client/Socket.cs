
using System.Text;
namespace App.Client;
public class Socket(System.Net.IPAddress? address, int port, System.Net.Sockets.ProtocolType protocol) : Core.Net.Socket.Socket(port, address, buffer_size, protocol)
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
		string output = $"{Console.ReadLine()}";
		if(output != "")
		{
			Buffer.WriteBuffer.Body = Encoding.UTF8.GetBytes(output);
			await Send();
			Buffer.WriteBuffer.Flush();
		}
		await Recieve();

		string input = Encoding.UTF8.GetString(Buffer.ReadBuffer.Body);
		if(input != "")
		{
			Console.WriteLine(input);
			Buffer.WriteBuffer.Flush();
		}
	}
	public async Task Run()
	{
		Init();
		while (Body.Connected) await Tick();
	}
}