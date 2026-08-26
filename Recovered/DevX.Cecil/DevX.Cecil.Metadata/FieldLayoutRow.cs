namespace DevX.Cecil.Metadata
{
	public sealed class FieldLayoutRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Offset;

		public uint Field;

		internal FieldLayoutRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitFieldLayoutRow(this);
		}
	}
}
