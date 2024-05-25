
using System.Net;
using System.Net.Sockets;

namespace App.Client.Net;
public class Socket
(IPAddress address,int port,ProtocolType protocol,int buffer_size) : Core.Net.Socket<IO.Reader,IO.Writer>
( address, port, protocol, new IO.Reader(buffer_size), new IO.Writer(buffer_size) )
{
	public byte[] Read() => Reader.Buffer.Body;
	public void Write(ref byte[] data) => Writer.Buffer.Body = data;
	protected override void Init() => Body.Connect(Endpoint);
}