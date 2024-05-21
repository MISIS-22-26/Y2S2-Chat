using System.Net;
namespace App.Core.Net.Resolver;
public class Resolver(string domain)
{
	public string domain { get; set; } = domain;
	public IPAddress address => Dns.GetHostEntry(domain).AddressList[0];
}