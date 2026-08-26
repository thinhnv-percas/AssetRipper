namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyRow : IMetadataRow, IMetadataRowVisitable
	{
		public AssemblyHashAlgorithm HashAlgId;

		public ushort MajorVersion;

		public ushort MinorVersion;

		public ushort BuildNumber;

		public ushort RevisionNumber;

		public AssemblyFlags Flags;

		public uint PublicKey;

		public uint Name;

		public uint Culture;

		internal AssemblyRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitAssemblyRow(this);
		}
	}
}
