namespace App.Core.Net.Socket;
public class Buffer(int size = 1024)
{
	public Core.Buffer ReadBuffer = new(size);
	public Core.Buffer WriteBuffer = new(size);
	public void Flush()
	{
		ReadBuffer.Flush();
		WriteBuffer.Flush();
	}
}