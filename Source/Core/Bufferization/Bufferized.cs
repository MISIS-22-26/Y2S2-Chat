namespace App.Core.Bufferization;

/// Default Implementation of IBufferized
public class Bufferized<T>(int buffer_size = 1024) : IBufferized<T>
{
    bool IBufferized<T>.busy { get; set;}
    Buffer<T> IBufferized<T>.buffer { get; set; } = new(buffer_size);
}