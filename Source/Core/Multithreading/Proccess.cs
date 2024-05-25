namespace App.Core.Multithreading;
public abstract class Proccess(string proccess_name = "IRunnable Proccess") : IRunnable
{
	// User-Defined method to be called during initialization
	protected abstract void Setup();
	// User-Defined action executed every tick of the proccess
	protected abstract void Operate();
	
	






    /* IRunnable Implementation */

    Thread? IRunnable.Thread { get; set; } = null;
	string IRunnable.Name { get; } = proccess_name;
	bool IRunnable.Initialized { get; set; } = false;
	bool IRunnable.Initializing { get; set; } = false;
	bool IRunnable.Shutdown { get; set; } = false;
	bool IRunnable.Startup { get; set; } = false;
	bool IRunnable.Running { get; set; } = false;
    bool IRunnable.Present { get; set; } = false;

    void IRunnable.Init() => Setup();
    void IRunnable.Tick() => Operate();
}