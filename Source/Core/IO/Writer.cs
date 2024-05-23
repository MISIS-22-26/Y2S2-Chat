namespace App.Core.IO;
public class Writer<T>(int buffer_size) : Bufferized<T>(buffer_size)
{
	protected virtual void Write() {}
    protected override void Operate() => Write();
}