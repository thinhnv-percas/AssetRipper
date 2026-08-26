namespace Mon3.Cecil.Metadata;

internal struct TableInformation
{
	public uint Offset;

	public uint Length;

	public uint RowSize;

	public bool IsLarge => Length > 65535;
}
