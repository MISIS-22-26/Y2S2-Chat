namespace App.Core;
public interface IRunnable
{
    public bool Shutdown { get; protected set; }
    public bool Startup { get; protected set; }
    public bool Running { get; protected set; }
    public void Start()
    {
        Startup = true;
        Run();
    }
    protected void Tick();
    private void Run()
    {
        Startup = false;
        Running = true;
        while(!Shutdown) Tick();
        Running = false;
    }
    public void Stop() => Shutdown = true;
}