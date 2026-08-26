namespace DevX.Cecil.Metadata
{
	public sealed class FieldPtrRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Field;

		internal FieldPtrRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitFieldPtrRow(this);
		}
	}
}
