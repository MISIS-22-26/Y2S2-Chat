namespace App.Core;
public interface IRunnable
{
    protected Thread? Thread { get; set; }
    public bool Shutdown { get; protected set; }
    public bool Startup { get; protected set; }
    public bool Running { get; protected set; }
    public void Start()
    {
        if (Running || Startup || Shutdown) return;
        
        Startup = true;
        Run();
    }
    protected void Tick();
    private void Run()
    {
        Running = true;
        while(!Shutdown) Tick();
        Running = false;
        
        Shutdown = false;
    }
    public void Stop() => Shutdown = true;
}