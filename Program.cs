namespace App;
public static class Program
{
	public static void Main(){
		Resolver resolver = new("google.com");
		Console.WriteLine(resolver.address);
	}
}