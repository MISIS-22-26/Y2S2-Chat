
namespace App.Client;
public class Socket(System.Net.IPAddress? address, int port, System.Net.Sockets.ProtocolType protocol, IO.Reader reader, IO.Writer writer) : Core.Net.Socket(address,port,protocol,reader,writer)
{
	public byte[] Read() => Reader.Buffer.Body;
	public void Write(ref byte[] data) => Writer.Buffer.Body = data;
	protected override void Init() => Body.Connect(Endpoint);
}