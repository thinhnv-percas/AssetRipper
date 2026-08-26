namespace DevX.Cecil.Metadata
{
	public sealed class CustomAttributeRow : IMetadataRow, IMetadataRowVisitable
	{
		public MetadataToken Parent;

		public MetadataToken Type;

		public uint Value;

		internal CustomAttributeRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitCustomAttributeRow(this);
		}
	}
}
