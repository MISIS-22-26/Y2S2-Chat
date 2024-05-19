namespace App;
public class Program
{
	public static async void Main(){
		await new Server.Server().Start();
	}
}