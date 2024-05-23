using System.Net;
using App.Core.Multithreading;
namespace App.Core.Net;

// A simple Threaded DNS resolver
public class Resolver(string domain) : IRunnable
{
	public string Domain { get; set; } = domain;
	public IPAddress[] Addresses { get; private set; } = [];
	public IPAddress Address => Addresses[0];

	
	
	
	
	
	
	
	
	
	/* IRunnable Implementation */

    Thread? IRunnable.Thread { get; set; } = null;
    
	
	bool IRunnable.Initialized { get; set; } = false;
	bool IRunnable.Initializing { get; set; } = false;
	bool IRunnable.Shutdown { get; set; } = false;
	bool IRunnable.Startup { get; set; } = false;
	bool IRunnable.Running { get; set; } = false;
    bool IRunnable.Present { get; set; } = false;

    void IRunnable.Init() {}
    void IRunnable.Tick() => Addresses = Dns.GetHostEntry(Domain).AddressList;
}