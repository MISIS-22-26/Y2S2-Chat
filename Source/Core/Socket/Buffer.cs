namespace App.Core.Net.Socket;
public struct Buffer
{
	public Core.Buffer ReadBuffer { get; private set; }
	public Core.Buffer WriteBuffer { get; private set; }

	public readonly void Flush()
	{
		ReadBuffer.Flush();
		WriteBuffer.Flush();
	}

	public Buffer(int size = 1024)
	{
		ReadBuffer = new(size: size);
		WriteBuffer = new(size: size); 
	}
	public Buffer(int read_size = 1024, int write_size = 1024)
	{
		ReadBuffer = new(size: read_size);
		WriteBuffer = new(size: write_size); 
	}
}