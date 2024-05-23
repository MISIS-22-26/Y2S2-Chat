namespace App.Server.IO;
public class Reader(System.Net.Sockets.Socket socket, int buffer_size) : Core.IO.Reader(buffer_size)
{
    private System.Net.Sockets.Socket Socket { get; } = socket;
    protected override void Read()
    {
        if (!Socket.Connected) return;
        Socket.Receive(Buffer.Body);
    }
}