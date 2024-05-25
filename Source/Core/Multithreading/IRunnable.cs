namespace App.Core.Multithreading;

// IRunnable interface partially adopts concept of state machine,
// since it is great for multithreading and thus quite desirable here,
// since IRunnable Tries to make it easier to work with multithreading
public interface IRunnable
{
	/* Data */
	protected Thread? Thread { get; set; }	// Thread in which IRunnable is running
	public string Name { get; } // IRunnable and its Thread name







	/* Startup */
	public void Start()
	{   
		if (Running || Startup || Shutdown) return;
		
		if (!Initialized)
		{

			if(!Initializing) Initializing = true;
			Thread ??= new(start: new ThreadStart(Run)); // If thread is null
			Thread.Name = Name;
			Initialize();
			Initializing = false;
		}

		
		
		Startup = true;
		Thread?.Start();
		Startup = false;
	}
	public bool Startup { get; protected set; }









	/* Initialization */
	protected void Init(); // Called once during initialization phase
	public void Initialize()
	{
		// Ensures singular Init() execution and state shift
		if(Initialized) return;
		Init();
		Initialized = true;
	} // Method, which iensures singular Init() call during init. Is called by <External Initializer>() or by Start() during startup
	public bool Initialized { get; protected set; }
	public bool Initializing { get; protected set; }





	/* Runtime  */
	private void Run()
	{
		// Ticks IRunnable onbject
		Running = true;
		while(!Shutdown)
		{
			Present = true;
			Tick();
			Present = false;
		}
		Running = false;
		
		Shutdown = false;
	}
	public bool Running { get; protected set; } // In the looping state
	public bool Paused => !Running;
	protected void Tick(); // Continously called during runtime of IRunnable
	public bool Present { get; protected set; } // In tick phase
	public bool Away => !Present;





	/* Shutdown */
	public void Stop() => Shutdown = true;
	public bool Shutdown { get; protected set; }
}