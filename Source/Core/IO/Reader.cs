namespace App.Core.IO;
public abstract class Reader(int buffer_size) : Node(buffer_size)
{
	protected abstract void Read();
    public override void Operate() => Read();
}