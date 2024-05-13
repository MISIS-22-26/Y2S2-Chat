namespace App.Core.Socket;
public interface ISocket
{
	public void Open(string ip, int port);
	public void Close();

	public void Write();
	public void Read();
}