namespace App.Core;
public interface IRunnable
{
	/* States */
	public bool Shutdown { get; protected set; }
	public bool Startup { get; protected set; }
	public bool Running { get; protected set; }
	

	/* Misc */
	protected Thread? Thread { get; set; }	
	

	/* Runtime */
	protected void Tick();
	private void Run()
	{
		Running = true;
		while(!Shutdown) Tick();
		Running = false;
		
		Shutdown = false;
	}

	public void Start()
	{   
		if (Running || Startup || Shutdown) return;
		
		Startup = true;
		Thread ??= new(new ThreadStart(Run)); // If thread is null
		Thread.Start();
		Startup = false;
	}
	public void Stop() => Shutdown = true;
}