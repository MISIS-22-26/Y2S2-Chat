using App.Core.Bufferization;

namespace App.Core.IO;
public abstract class Writer(int buffer_size = 1024) : IRunnable
{
    public Buffer Buffer { get; set; } = new(size: buffer_size);
    bool Writing { get; set; } = false;
    protected abstract void Write();




    /* IRunnable Implementation */
    Thread? IRunnable.Thread { get; set; } = null;
    bool IRunnable.Shutdown { get; set; } = false;
    bool IRunnable.Startup { get; set; } = false;
    bool IRunnable.Running { get; set; } = false;
    void IRunnable.Tick() {
        Writing = true;
        Write();
        Writing = false;
    }
    
}