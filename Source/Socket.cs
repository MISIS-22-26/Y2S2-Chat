namespace App.Core;

public interface ISocket<T> where T : IDisposable
{
	protected T Socket { get; set; }
}