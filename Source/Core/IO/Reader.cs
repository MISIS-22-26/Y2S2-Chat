using App.Core.Bufferization;

namespace App.Core.IO;
public abstract class Reader(int buffer_size = 1024) : Bufferized<byte>(buffer_size), IRunnable
{
    bool IRunnable.Shutdown { get; set; } = false;
    bool IRunnable.Startup { get; set; } = false;
    bool IRunnable.Running { get; set; } = false;
    bool Reading { get; set; } = false;
    void IRunnable.Tick() {
        Reading = true;
        Read();
        Reading = false;
    }
    protected abstract void Read();

}