namespace App.Core;
public interface IRunnable
{
	/* States */
	public bool Initializing { get; protected set; }
	public bool Shutdown { get; protected set; }
	public bool Startup { get; protected set; }
	public bool Running { get; protected set; }
	

	/* Misc */
	protected Thread? Thread { get; set; }	
	

	/* Runtime */
	protected void Init();
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

		Initializing = true;
		Init();
		Initializing = false;

		Startup = true;
		Thread ??= new(new ThreadStart(Run)); // If thread is null
		Thread.Start();
		Startup = false;
	}
	public void Stop() => Shutdown = true;
}