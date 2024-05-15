using System.Net;

public class Resolver(string domain)
{
	public bool enabled { get; private set; } = false;
	public string domain { get; private set; } = domain;
	IPAddress[] addresses = [];
	public IPAddress address => addresses[0];
	async Task Resolve()
	{
		IPHostEntry addresses = await Dns.GetHostEntryAsync(domain);
		this.addresses = addresses.AddressList;
	}

	async Task Run()
	{
		while(enabled) await Resolve();
	}
		public async void Start()
	{
		enabled = true;
		await Run();
	}
	public void Stop() => enabled = false;
}