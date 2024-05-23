namespace App.Core.IO;
public abstract class Accepter<T> : Node
{
    public List<T> Accepted { get; } = [];
	protected abstract void Accept();
    protected override void Operate() => Accept();
}