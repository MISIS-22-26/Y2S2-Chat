namespace App.Core.Socket;
public abstract class Socket<T>(string ip, int port) : ISocket<T>, INode where T : IDisposable
{
	T ISocket<T>.Socket { get; set; }
	string INode.ip { get; set; } = ip;
	int INode.port { get; set; } = port;
}