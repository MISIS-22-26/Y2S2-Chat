namespace App.Core.IO;
public abstract class Writer<T>(int buffer_size) : Bufferizer<T>(buffer_size)
{
	protected abstract void Write();
    protected override void Operate() => Write();
}