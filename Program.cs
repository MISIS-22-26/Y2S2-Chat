namespace App;
public static class Program
{
	public static void Main(){
		Client.Client client = new();
		client.Connect();
	}
}