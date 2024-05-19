namespace App;
public class Program
{
	public static void Main(String[] args){
		Core.Net.Resolver.Resolver resolver = new("localhost");
		Console.WriteLine(resolver.address);

        //Core.Net.Socket.Socket socket = new(Core.Net.Socket.Mode.Server, 8888, System.Net.IPAddress.Loopback);
		//socket.Start();
	}
}