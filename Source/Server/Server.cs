using App.Core;

namespace App.Server;
public class Server<T> : IRunnable where T : IDisposable
{
	void IRunnable.Run() => throw new NotImplementedException();
}