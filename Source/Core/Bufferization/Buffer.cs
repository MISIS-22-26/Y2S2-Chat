using System.Numerics;

namespace App.Core.Bufferization;

// struct since it contains mostly links to the objects in haep, so it is a good idea to place buffer in stack.
public class Buffer<T>(int size)
{
    public int Size { get; } = size;
	public T[] Body { get; } = new T[size];
    public virtual void Flush() => throw new NotImplementedException();
}