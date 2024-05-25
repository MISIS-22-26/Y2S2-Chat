using System.Net;
namespace App.Client;
public class Entrypoint
{
	public static void Main() => new Client(Dns.GetHostEntry("localhost").AddressList[0], 8888, System.Net.Sockets.ProtocolType.Tcp).Start();
}