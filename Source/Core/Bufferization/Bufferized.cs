namespace App.Core.Bufferization;

/// Default Implementation of IBufferized
public class Bufferized<T>(int buffer_size) : IBufferized<T>
{
    bool IBufferized<T>.Busy { get; set;}
    Buffer<T> IBufferized<T>.buffer { get; set; } = new(buffer_size);
}