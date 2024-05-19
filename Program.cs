namespace App;
public class Program
{
	public static async void Main(){
		await new Client.Client().Start();
	}
}