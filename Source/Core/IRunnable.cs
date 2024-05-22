namespace App.Core;
public interface IRunnable
{
	public delegate void Operation();
	protected Thread? Thread { get; set; }
	public bool Shutdown { get; protected set; }
	public bool Startup { get; protected set; }
	public bool Running { get; protected set; }
	public bool TickState { get; protected set; }
	public void Start(Operation tick_operation)
	{   
		if (Running || Startup || Shutdown) return;
		
		Startup = true;
		Thread ??= new(new ThreadStart(() => Run(ref tick_operation))); // If thread is null
		Thread.Start();
		Startup = false;
	}
	protected void Tick(ref Operation tick_operaton)
	{
		TickState = true;
		tick_operaton();
		TickState = false;
	}
	private void Run(ref Operation tick_operation)
	{
		Running = true;
		while(!Shutdown) Tick(ref tick_operation);
		Running = false;
		
		Shutdown = false;
	}
	public void Stop() => Shutdown = true;
}