using System.Net;

public class Resolver(string domain)
{
	public string domain { get; private set; } = domain;
	public IPAddress address => Dns.GetHostEntry(domain).AddressList[0];
}