namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyRefOSRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint OSPlatformID;

		public uint OSMajorVersion;

		public uint OSMinorVersion;

		public uint AssemblyRef;

		internal AssemblyRefOSRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitAssemblyRefOSRow(this);
		}
	}
}
