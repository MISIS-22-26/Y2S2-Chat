namespace App;
public class Program
{
	public static void Main(){
		Server.Server server = new();
		server.Accept();
	}
}