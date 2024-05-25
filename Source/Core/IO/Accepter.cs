namespace App.Core.IO;
public abstract class Accepter<T>(string proccess_name = "Accepter Proccess") : Multithreading.Proccess(proccess_name)
{
    public List<T> Accepted { get; } = [];
	protected abstract void Accept();
    protected override void Operate() => Accept();
}