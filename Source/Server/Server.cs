namespace App.Server;
public class Server(int port = 8888)
{
	Socket socket = new(port);
}