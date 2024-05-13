namespace App.Core.Socket;
public abstract class Socket<T> : ISocket<T> where T : IDisposable
{
	T ISocket<T>.socket { get; set; }
	protected string ip { get; set; }
	protected int port { get; set; }

	public abstract void Close();
	public abstract void Open(string ip, int port);
	public abstract void Read();
	public abstract void Write();
}