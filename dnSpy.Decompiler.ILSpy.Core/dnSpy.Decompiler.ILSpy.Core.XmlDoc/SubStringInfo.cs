namespace dnSpy.Decompiler.ILSpy.Core.XmlDoc;

internal struct SubStringInfo
{
	public readonly int Index;

	public readonly int Length;

	public SubStringInfo(int index, int length)
	{
		Index = index;
		Length = length;
	}
}
