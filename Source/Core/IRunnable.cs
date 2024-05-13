namespace App.Core;
public interface IRunnable
{
	public void Start() => Run(); 
	protected void Run();
}