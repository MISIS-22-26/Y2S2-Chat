namespace App.Client.IO;
public class Writer(int buffer_size) : Core.IO.Writer<byte>(buffer_size)
{
	private System.Net.Sockets.Socket? socket { get; set; } = null;
   	public Net.Socket? Socket {  set => socket = value?.Body ?? throw new NullReferenceException("Socket Can Not Be Null!"); }
    protected override void Write () { while (socket != null && socket.Connected) socket.Send(Buffer.Body); }
}