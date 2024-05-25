namespace App.Client;
public class Entrypoint
{
	public static void Main() => _ = new Client("localhost", 8080, System.Net.Sockets.ProtocolType.Tcp);
}