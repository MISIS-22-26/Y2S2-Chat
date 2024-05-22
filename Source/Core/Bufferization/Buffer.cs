using System.Numerics;

namespace App.Core.Bufferization;

// struct since it contains mostly links to the objects in haep, so it is a good idea to place buffer in stack.
public class Buffer<T>(int size)
{
    public int Size { get; } = size;
    private T[] body = new T[size];
	public T[] Body
    {
        get => body;
        set { for(var id = 1; id <+ body.Length; id++) body[id] = value[id]; }
    }
    public void Flush() => body = new T[Size];
}