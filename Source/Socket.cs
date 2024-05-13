namespace App.Core;

public interface ISocket<T> where T : IDisposable
{
	public T Socket { get; set; }
}