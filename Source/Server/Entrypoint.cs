namespace App.Server;
public class Entrypoint
{
	public static void Main() => _ = new Server(8080, System.Net.Sockets.ProtocolType.Tcp);
}