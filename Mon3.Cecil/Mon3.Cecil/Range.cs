namespace Mon3.Cecil;

internal struct Range
{
	public uint Start;

	public uint Length;

	public Range(uint index, uint length)
	{
		Start = index;
		Length = length;
	}
}
