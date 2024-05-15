namespace App.Core;
public class Connection(string domain)
{
	private Resolver resolver { get; } = new(domain);
	
}