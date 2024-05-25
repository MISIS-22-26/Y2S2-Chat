using System.Net;
using App.Core.Multithreading;
namespace App.Core.Net;

// A simple Threaded DNS resolver
public class Resolver(string domain, string proccess_name = "Resolver Proccess") : Proccess(proccess_name)
{
	public string Domain { get; } = domain;
	public IPAddress[] Addresses { get; private set; } = [];
	public IPAddress Address => Addresses[0];

    protected override void Operate() =>  Addresses = Dns.GetHostEntry(Domain).AddressList;
    protected override void Setup() => Operate();
}