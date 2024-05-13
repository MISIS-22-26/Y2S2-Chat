namespace App.Core.Socket;
public interface ISocket<T> where T : IDisposable
{
	protected T socket { get; set; }
	
	public void Open(string ip, int port);
	public void Close();

	public void Write();
	public void Read();
}