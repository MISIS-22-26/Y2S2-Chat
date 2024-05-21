namespace App.Core.Net.Socket;
public class Buffer(int size = 1024)
{
	public Core.Buffer Read = new(size);
	public Core.Buffer Write = new(size);
	public void Flush()
	{
		Read.Flush();
		Write.Flush();
	}
}