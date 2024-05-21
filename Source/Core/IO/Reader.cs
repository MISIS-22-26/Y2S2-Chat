
namespace App.Core.IO;
public abstract class Reader(int buffer_size = 1024) : IRunnable
{
	public Buffer Buffer { get; set; } = new(size: buffer_size);
	bool Reading { get; set; } = false;
	protected abstract void Read();







	/* IRunnable Implementation */

	Thread? IRunnable.Thread { get; set; } = null;
	bool IRunnable.Shutdown { get; set; } = false;
	bool IRunnable.Startup { get; set; } = false;
	bool IRunnable.Running { get; set; } = false;
	void IRunnable.Tick() {
		Reading = true;
		Read();
		Reading = false;
	}
}