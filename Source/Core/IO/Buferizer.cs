namespace App.Core.IO;
public abstract class Bufferizer(int buffer_size) : Node
{
    public Bufferization.Buffer<byte> Buffer { get; } = new(buffer_size);
}