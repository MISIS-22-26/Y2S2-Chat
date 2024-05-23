namespace App.Core.IO;
public abstract class Reader<T>(int buffer_size) : Bufferizer<T>(buffer_size)
{
	protected abstract void Read();
    protected override void Operate() => Read();
}