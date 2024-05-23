
namespace App.Server;
public class Socket(System.Net.IPAddress? address, int port, System.Net.Sockets.ProtocolType protocol, int buffer_size) : Core.Net.Socket(address,port,protocol,buffer_size)
{
	public byte[] Read() => Reader.Buffer.Body;
	public void Write(ref byte[] data) => Writer.Buffer.Body = data;
	public IO.Accepter Accepter { get; protected set; }

	protected override void Init()
	{
		Accepter = new IO.Accepter(Body);
		// Reimplement:
		// Reader = new IO.Reader(Body, BufferSize);
		// Writer = new IO.Writer(Body, BufferSize);
	}
}