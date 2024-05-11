namespace App.Core;
public interface INode (string ip = "localhost", int port = 2002)
{
	public string ip { get; private set; }
	public int port { get; private set; }
}