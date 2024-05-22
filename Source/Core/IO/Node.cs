
using App.Core.Bufferization;

namespace App.Core.IO;
public class Node(int buffer_size) : IRunnable
{
	private Internal.Buffer buffer { get; set; } = new(size: buffer_size);
	protected Buffer<byte> Buffer => ((IBufferized<byte>) buffer).Buffer;
    bool IRunnable.TickState { get; set; } = false;
	public bool Operating => ((IRunnable) this).TickState;


	/* IRunnable Implementation */

	Thread? IRunnable.Thread { get; set; } = null;
	bool IRunnable.Shutdown { get; set; } = false;
	bool IRunnable.Startup { get; set; } = false;
	bool IRunnable.Running { get; set; } = false;



	/* Persona */
	public virtual void Operate() => throw new NotImplementedException();
	public void Start() => ( (IRunnable) this).Start(Operate);
}