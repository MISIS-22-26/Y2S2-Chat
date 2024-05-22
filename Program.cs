using System.Net;
using System.Net.Sockets;
namespace App.Client;
public class Program
{
	public static void Main(string[] args)
	{
		new Client(IPAddress.Loopback, 8888, ProtocolType.Tcp).Start();
	}
}