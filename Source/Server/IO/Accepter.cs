namespace App.Server.IO;
public class Accepter(System.Net.Sockets.Socket gateway) : Core.IO.Accepter<Socket>
{   
	System.Net.Sockets.Socket Gateway { get; } = gateway;
	protected override void Accept() => throw new NotImplementedException();
}
