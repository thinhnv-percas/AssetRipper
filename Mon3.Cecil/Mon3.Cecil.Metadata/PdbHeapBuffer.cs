namespace Mon3.Cecil.Metadata;

internal sealed class PdbHeapBuffer : HeapBuffer
{
	public override bool IsEmpty => false;

	public PdbHeapBuffer()
		: base(0)
	{
	}
}
