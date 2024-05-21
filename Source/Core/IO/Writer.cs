using App.Core.Bufferization;

namespace App.Core.IO;
public abstract class Writer(int buffer_size = 1024) : Bufferized<byte>(buffer_size), IRunnable
{
    bool IRunnable.Shutdown { get; set; } = false;
    bool IRunnable.Startup { get; set; } = false;
    bool IRunnable.Running { get; set; } = false;
    bool Writing { get; set; } = false;
    void IRunnable.Tick() {
        Writing = true;
        Write();
        Writing = false;
    }
    
    protected abstract void Write();
}