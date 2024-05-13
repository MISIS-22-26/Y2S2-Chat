namespace App.Core.Socket;
public abstract class Socket<T> : ISocket<T>, INode where T : IDisposable
{
	T ISocket<T>.socket { get; set; }
	string INode.ip { get; set; }
	int INode.port { get; set; }

	public abstract void Close();
	public abstract void Open(string ip = "localhost", int port = 8888);
	public abstract void Read();
	public abstract void Write();
}