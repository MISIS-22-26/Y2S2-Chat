
using System.Text;
namespace App.Client;
public class Socket : Core.Net.Socket.Socket
{
	protected override void Init() => Body.Connect(Endpoint);

	protected override void Recieve()
	{
		Buffer.ReadBuffer.Flush();
		Body.Receive(Buffer.ReadBuffer.Body);
	}
	protected override void Send()
	{
		Body.Send(Buffer.WriteBuffer.Body);
		Buffer.WriteBuffer.Flush();
	}
	void Tick()
	{
		Buffer.WriteBuffer.Body = Encoding.UTF8.GetBytes($"{Console.ReadLine()}");
		Send();
		Recieve();
		Console.WriteLine(Encoding.UTF8.GetString(Buffer.ReadBuffer.Body));
		Buffer.Flush();
	}
	void Run()
	{
		Init();
		while (Body.Connected) Tick();
	}
	public Socket(int port, System.Net.IPAddress? address = null, int buffer_size = 1024, System.Net.Sockets.ProtocolType protocol = System.Net.Sockets.ProtocolType.Tcp) : base(port, address, buffer_size, protocol) => Run();
}