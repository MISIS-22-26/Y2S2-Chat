namespace App.Core;

// struct since it contains mostly links to the objects in haep, so it is a good idea to place buffer in stack.
public struct Buffer(int size = 1024)
{
    public int Size { get; } = size;
	public byte[] Body { get; private set; } = new byte[size];
    public void Flush() => Body = new byte[Size];
}