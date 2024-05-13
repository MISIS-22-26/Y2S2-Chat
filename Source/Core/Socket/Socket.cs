namespace App.Core.Socket;
public abstract class Socket<T> : ISocket<T>, INode where T : IDisposable
{
	T ISocket<T>.Socket { get; set; }
	string INode.ip { get; set; }
	int INode.port { get; set; }

	public abstract void Close();
	public abstract void Open();
	public abstract void Read();
	public abstract void Write();
}