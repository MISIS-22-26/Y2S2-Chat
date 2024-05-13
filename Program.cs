namespace App;
public static class Program
{
	public static void Main(){
		Server.Server server = new();
		server.Accept();
	}
}