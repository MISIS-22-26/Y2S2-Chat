namespace App.Core;
public interface IRunnable
{
	public void Start() => Run(); 
	protected abstract void Run();
}