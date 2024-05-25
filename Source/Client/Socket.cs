
using System.Net;
using System.Net.Sockets;

namespace App.Client;
public class Socket
(IPAddress address,int port,ProtocolType protocol,int buffer_size) : Core.Net.Socket<Core.Net.Reader,Core.Net.Writer>
( address, port, protocol, new Core.Net.Reader(buffer_size), new Core.Net.Writer(buffer_size) )
{
	public byte[] Read() => Reader.Buffer.Body;
	public void Write(ref byte[] data) => Writer.Buffer.Body = data;
	protected override void Init()
	{
		Body.Connect(Endpoint); // TODO handle socket connection refused exception
		Reader.Socket = Body;
		Writer.Socket = Body;
	}
}