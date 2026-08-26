namespace DevX.Cecil.Metadata
{
	public sealed class ConstantRow : IMetadataRow, IMetadataRowVisitable
	{
		public ElementType Type;

		public MetadataToken Parent;

		public uint Value;

		internal ConstantRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitConstantRow(this);
		}
	}
}
