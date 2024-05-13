using App.Core;
using App.Core.Socket;

namespace App.Server;
public class Server<T> : IRunnable where T : IDisposable
{
	protected Socket<T> socket { get; }
	void IRunnable.Run() => throw new NotImplementedException();
	public void Accept(string ip = "localhost", int port = 8888) => socket.Open(ip, port);
}