namespace App;
public class Program
{
	public static async Task Main(String[] args){
		Core.Resolver resolver = new("localhost");
		Console.WriteLine(resolver.address);
        Core.Socket.Socket socket = new(Core.Socket.Mode.Server, 8888, System.Net.IPAddress.Loopback);
		await socket.Start();
	}
}