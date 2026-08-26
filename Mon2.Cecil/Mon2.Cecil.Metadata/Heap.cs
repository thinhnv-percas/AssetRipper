using Mon2.Cecil.PE;

namespace Mon2.Cecil.Metadata;

internal abstract class Heap
{
	public int IndexSize;

	public readonly Section Section;

	public readonly uint Offset;

	public readonly uint Size;

	protected Heap(Section section, uint offset, uint size)
	{
		Section = section;
		Offset = offset;
		Size = size;
	}
}
