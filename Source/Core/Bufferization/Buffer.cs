namespace App.Core.Bufferization;

// struct since it contains mostly links to the objects in haep, so it is a good idea to place buffer in stack.
public class Buffer<T>(int size = 1024)
{
    public int Size = size;
	public T[] Body = new T[size];
    public void Flush() => Body = new T[Size];
}