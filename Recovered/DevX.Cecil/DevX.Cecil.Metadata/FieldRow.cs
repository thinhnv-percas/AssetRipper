namespace DevX.Cecil.Metadata
{
	public sealed class FieldRow : IMetadataRow, IMetadataRowVisitable
	{
		public FieldAttributes Flags;

		public uint Name;

		public uint Signature;

		internal FieldRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitFieldRow(this);
		}
	}
}
