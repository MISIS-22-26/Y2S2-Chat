namespace App;
public static class Program
{
	public static void Main(){
		App.Core.Resolver resolver = new("localhost");
		Console.WriteLine(resolver.address);
	}
}