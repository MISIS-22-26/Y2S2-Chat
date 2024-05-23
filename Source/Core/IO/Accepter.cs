namespace App.Core.IO;
public abstract class Accepter<T> : Multithreading.Proccess
{
    public List<T> Accepted { get; } = [];
	protected abstract void Accept();
    protected override void Operate() => Accept();
}