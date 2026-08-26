namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyOSRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint OSPlatformID;

		public uint OSMajorVersion;

		public uint OSMinorVersion;

		internal AssemblyOSRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitAssemblyOSRow(this);
		}
	}
}
