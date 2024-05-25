namespace App.Core.IO;
public abstract class Bufferized<T>(int buffer_size, string proccess_name = "Befferized Proccess") : Multithreading.Proccess(proccess_name)
{
    protected int Size { get; } = buffer_size; // Default size for each buffer in Buffers

	// List of Buffers
	public List<Bufferization.Buffer<T>> Buffers { get; } = [ ];
	// Link to main/first buffer
	public Bufferization.Buffer<T> Buffer 
	{
		get => Buffers[0];
		private set => Buffers[0] = value;
	}
	protected override void Setup() => Buffers.Add(new(Size)); // If you use Bufferized class you probably want at least 1 buffer existing.. duh.
}