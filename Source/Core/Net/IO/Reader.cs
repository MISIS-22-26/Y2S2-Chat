namespace App.Core.Net;
public class Reader(int buffer_size, string proccess_name = "Network Writer") : IO.Reader<byte>(buffer_size, proccess_name)
{
	public System.Net.Sockets.Socket? Socket { get; set; } = null;
    protected override void Read () { while (Socket != null && Socket.Connected) Socket.Receive(Buffer.Body); }
}