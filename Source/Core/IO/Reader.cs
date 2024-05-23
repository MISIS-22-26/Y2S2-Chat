namespace App.Core.IO;
public abstract class Reader(int buffer_size) : Bufferizer(buffer_size)
{
	protected abstract void Read();
    protected override void Operate() => Read();
}