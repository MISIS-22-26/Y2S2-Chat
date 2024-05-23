namespace App.Core.IO;
public abstract class Bufferizer<T>(int buffer_size) : Node
{
    protected int Size { get; } = buffer_size; // Default size for each buffer in Buffers

	// Buffer of Buffers
	public List<Bufferization.Buffer<T>> Buffers { get; } = [ ];
	// Main Buffer in case there are more than one buffer in Buffers
	public Bufferization.Buffer<T> Buffer 
	{
		get => Buffers[0];
		private set => Buffers[0] = value;
	}
	protected override void Setup(){
		Buffers.Add(new(Size)); // If you use Bufferized class you probably want at least 1 buffer existing.. duh.
	}
}