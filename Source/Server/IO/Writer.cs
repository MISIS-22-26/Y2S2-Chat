namespace App.Server.IO;
public class Writer(System.Net.Sockets.Socket socket, int buffer_size) : Core.IO.Writer(buffer_size)
{
    private System.Net.Sockets.Socket Socket { get; } = socket;
    protected override void Write()
    {
        if (!Socket.Connected) return;
        Socket.Send(Buffer.Body);
    }
}