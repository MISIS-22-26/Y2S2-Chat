namespace App;
public class Program
{
	public static async Task Main(){
		await new Client.Client().Start();
	}
}