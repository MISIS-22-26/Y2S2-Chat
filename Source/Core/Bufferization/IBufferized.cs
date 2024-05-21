using App.Core.Exceptions;

namespace App.Core.Bufferization;
public interface IBufferized<T>
{
    protected bool busy { get; set; }
    public bool Busy { get => busy; protected set => busy = value; }
    
    protected Buffer<T> buffer { get; set; }
    public Buffer<T> Buffer
    {
        get { Occupy(); var result = buffer; Release(); return result; }
        set { Occupy(); buffer = value; Release(); }
    }
    public void Flush() => Buffer.Flush();
    void Occupy()
    {
        if (!Busy) Busy = true;
        else throw new UnsafeAccessException("Buffer Already Occupied!");
    }
    void Release()
    {
        if (Busy) Busy = false;
        else throw new DuplicateOperationException("Buffer Already Released.");
    }
}