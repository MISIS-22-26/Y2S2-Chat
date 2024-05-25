using System.Net;
using System.Net.Sockets;

namespace App.Server;
public class Socket
(int port, ProtocolType protocol, int buffer_size) : Core.Net.Socket<Core.Net.Reader,Core.Net.Writer>
(IPAddress.Loopback, port, protocol, new Core.Net.Reader(buffer_size), new Core.Net.Writer(buffer_size) )
{
	System.Net.Sockets.Socket? Outbound { get; set; } = null;
	public byte[] Read() => Reader.Buffer.Body;
	public void Write(ref byte[] data) => Writer.Buffer.Body = data;
	protected override void Init()
	{
		Body.Bind(Endpoint);
		Body.Listen();
		Outbound = Body.Accept();
		Reader.Socket = Outbound;
		Writer.Socket = Outbound;
	}
}