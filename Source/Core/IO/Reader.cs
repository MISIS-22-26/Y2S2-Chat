namespace App.Core.IO;
public class Reader<T>(int buffer_size) : Bufferized<T>(buffer_size)
{
	protected virtual void Read() {}
    protected override void Operate() => Read();
}