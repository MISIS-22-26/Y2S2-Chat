namespace App.Core.IO;
public class Reader<T>(int buffer_size, string proccess_name = "Bufferized Reader") : Bufferized<T>(buffer_size, proccess_name)
{
	protected virtual void Read() {}
    protected override void Operate() => Read();
}