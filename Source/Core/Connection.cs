namespace App.Core;
public class Connection(string server)
{
	Resolver resolver { get; } = new(server);
}