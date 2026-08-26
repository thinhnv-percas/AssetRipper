namespace dnlib.DotNet.Writer;

public sealed class TablesHeapOptions
{
	public uint? Reserved1;

	public byte? MajorVersion;

	public byte? MinorVersion;

	public bool? UseENC;

	public uint? ExtraData;

	public bool? HasDeletedRows;

	public static TablesHeapOptions CreatePortablePdbV1_0()
	{
		return new TablesHeapOptions
		{
			Reserved1 = 0u,
			MajorVersion = (byte)2,
			MinorVersion = 0,
			UseENC = null,
			ExtraData = null,
			HasDeletedRows = null
		};
	}
}
