namespace App.Core.IO;
public abstract class Writer(int buffer_size) : Bufferizer(buffer_size)
{
	protected abstract void Write();
    protected override void Operate() => Write();
}