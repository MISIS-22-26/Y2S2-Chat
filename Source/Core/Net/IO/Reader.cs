namespace App.Core.Net;
public class Reader(int buffer_size, string proccess_name = "Client Writer") : IO.Reader<byte>(buffer_size, proccess_name)
{
	private System.Net.Sockets.Socket? socket { get; set; } = null;
   	public Socket<Reader,Writer>? Socket {  set => socket = value?.Body ?? throw new NullReferenceException("Socket Can Not Be Null!"); }
    protected override void Read () { while (socket != null && socket.Connected) socket.Receive(Buffer.Body); }
}