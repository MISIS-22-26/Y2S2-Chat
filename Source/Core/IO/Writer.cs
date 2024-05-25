namespace App.Core.IO;
public class Writer<T>(int buffer_size, string proccess_name = "Bufferized Writer") : Bufferized<T>(buffer_size, proccess_name)
{
	protected virtual void Write() {}
    protected override void Operate() => Write();
}