namespace App.Core;
public interface IRunnable
{
	public void Start() => Run(); 
	public void Run();
}