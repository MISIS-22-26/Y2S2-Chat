namespace App.Core.Bufferization;
public class IOBuffer(int size = 1024)
{
	public Buffer<byte> Read = new(size);
	public Buffer<byte> Write = new(size);
	public void Flush()
	{
		Read.Flush();
		Write.Flush();
	}
}