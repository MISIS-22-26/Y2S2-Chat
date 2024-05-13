namespace App.Core.Socket;
public interface ISocket<T> where T : IDisposable
{
	protected T Socket { get; set; }
	
	public abstract void Open();
	public abstract void Close();

	public abstract void Write();
	public abstract void Read();
}