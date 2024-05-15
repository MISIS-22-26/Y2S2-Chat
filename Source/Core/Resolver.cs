using System.Net;

public class Resolver(string domain)
{
	public string domain { get; private set; } = domain;
	IPAddress[] addresses = [];
	public IPAddress address => addresses[0];
	async Task Resolve()
	{
		IPHostEntry addresses = await Dns.GetHostEntryAsync(domain);
		this.addresses = addresses.AddressList;
	}
}