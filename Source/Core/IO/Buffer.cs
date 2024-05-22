using App.Core.Bufferization;

namespace App.Core.IO.Internal;

public class Buffer(int size) : Bufferized(size) {}

// Made soly to iiimplement Flush() method without spamming file-destinct entities.
// Only used by Buffer above.
public class Bufferized : Bufferized<byte>
{
	internal class Buffer(int size) : Buffer<byte>(size)
	{
        public override void Flush()
        {
            for (int id = 1; id <= Body.Length; id++)  Body[id] = 0;
        }
    
	}		
	public Bufferized(int size) : base(size) => ((IBufferized<byte>) (Bufferized<byte>) this).Buffer = new Buffer(size);
}
