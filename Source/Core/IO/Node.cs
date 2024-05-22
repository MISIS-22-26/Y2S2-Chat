
using App.Core.Bufferization;

namespace App.Core.IO;
public class Node(int buffer_size) : IRunnable
{
	public Buffer<byte> Buffer { get; } = new(buffer_size);



    /* IRunnable Implementation */

    Thread? IRunnable.Thread { get; set; } = null;
	bool IRunnable.Shutdown { get; set; } = false;
	bool IRunnable.Startup { get; set; } = false;
	bool IRunnable.Running { get; set; } = false;

	void IRunnable.Start() => ((IRunnable) this).Start();
    void IRunnable.Tick() => Operate();


	/* Non-Implemented */
	protected virtual void Operate() => throw new NotImplementedException();
}