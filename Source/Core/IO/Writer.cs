namespace App.Core.IO;
public abstract class Writer(int buffer_size) : Node(buffer_size)
{
	protected abstract void Write();
    public override void Operate() => Write();
}