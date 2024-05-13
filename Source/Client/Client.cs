using App.Core;

namespace App.Client;
public class Client : IRunnable
{
	protected Socket socket { get; }
	void IRunnable.Run() => throw new NotImplementedException();
	public void Connect(string ip = "localhost", int port = 8888) => socket.Open(ip, port);
	public Client(){
		socket = new();
	}
}