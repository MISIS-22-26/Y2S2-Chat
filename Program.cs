namespace App;
public class Program
{
	public static void Main(){
		Client.Client client = new();
		client.Connect();
	}
}