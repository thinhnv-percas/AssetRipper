namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyRefRow : IMetadataRow, IMetadataRowVisitable
	{
		public ushort MajorVersion;

		public ushort MinorVersion;

		public ushort BuildNumber;

		public ushort RevisionNumber;

		public AssemblyFlags Flags;

		public uint PublicKeyOrToken;

		public uint Name;

		public uint Culture;

		public uint HashValue;

		internal AssemblyRefRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitAssemblyRefRow(this);
		}
	}
}
