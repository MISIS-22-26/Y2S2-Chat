namespace App.Core.Socket;
public interface ISocket<T> where T : IDisposable
{
	protected T Socket { get; set; }
	
	public virtual void Open() => throw new NotImplementedException();
	public virtual void Close() => throw new NotImplementedException();

	public virtual void Write() => throw new NotFiniteNumberException();
	public virtual void Read() => throw new NotImplementedException();
}