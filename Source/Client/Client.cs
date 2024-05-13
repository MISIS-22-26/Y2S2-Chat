using App.Core;
using App.Core.Socket;

namespace App.Client;
public class Client<T> : IRunnable where T : IDisposable
{
	protected Socket<T> socket { get; }
	void IRunnable.Run() => throw new NotImplementedException();
	public void Connect(string ip = "localhost", int port = 8888) => socket.Open(ip, port);
}