namespace App.Core.Net;
public class Writer(int buffer_size, string proccess_name = "Network Writer") : IO.Writer<byte>(buffer_size, proccess_name)
{
	private System.Net.Sockets.Socket? Socket { get; set; } = null;
    protected override void Write () { while (Socket != null && Socket.Connected) Socket.Send(Buffer.Body); }
}