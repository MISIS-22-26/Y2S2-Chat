using App.Core;

namespace App.Server;
public class Server : IRunnable
{
	protected Socket socket { get; }
	void IRunnable.Run() => throw new NotImplementedException();
	public void Accept(string ip = "localhost", int port = 8888) => socket.Open(ip, port);
}