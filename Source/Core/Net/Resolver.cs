using System.Net;
namespace App.Core.Net;
public class Resolver(string domain)
{
	public string Domain { get; set; } = domain;
	public IPAddress Address => Dns.GetHostEntry(Domain).AddressList[0];
}