using Mon3.Cecil.PE;

namespace Mon3.Cecil.Metadata;

internal abstract class HeapBuffer : ByteBuffer
{
	public bool IsLarge => length > 65535;

	public abstract bool IsEmpty { get; }

	protected HeapBuffer(int length)
		: base(length)
	{
	}
}
