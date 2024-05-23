namespace App.Core.IO;
public class Node : IRunnable
{
    /* IRunnable Implementation */

    Thread? IRunnable.Thread { get; set; } = null;
	bool IRunnable.Initializing { get; set; } = false;
	bool IRunnable.Shutdown { get; set; } = false;
	bool IRunnable.Startup { get; set; } = false;
	bool IRunnable.Running { get; set; } = false;
	void IRunnable.Init() => Setup();
    void IRunnable.Tick() => Operate();
	// User-Defined method to be called during initialization
	protected virtual void Setup() {}

	/* Non-Implemented */
	protected virtual void Operate() => throw new NotImplementedException();
}