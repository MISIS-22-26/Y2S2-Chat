using App.Core;

namespace App.Client;
public class Client<T> : IRunnable where T : IDisposable
{
	void IRunnable.Run() => throw new NotImplementedException();
}