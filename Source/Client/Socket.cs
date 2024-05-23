
using System.Net;
using System.Net.Sockets;

namespace App.Client;
public class Socket
(IPAddress address,int port,ProtocolType protocol,int buffer_size)
:	Core.Net.Socket<IO.Reader,IO.Writer>
	(
		address, port, protocol,
		new(new(new IPEndPoint(address, port).AddressFamily, SocketType.Stream, protocol ),buffer_size ), 
		new(new(new IPEndPoint(address, port).AddressFamily,SocketType.Stream,protocol),buffer_size)
	)
{
	public byte[] Read() => Reader.Buffer.Body;
	public void Write(ref byte[] data) => Writer.Buffer.Body = data;
	protected override void Init() => Body.Connect(Endpoint);
}