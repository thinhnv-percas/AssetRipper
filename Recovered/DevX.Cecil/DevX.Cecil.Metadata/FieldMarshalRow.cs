namespace DevX.Cecil.Metadata
{
	public sealed class FieldMarshalRow : IMetadataRow, IMetadataRowVisitable
	{
		public MetadataToken Parent;

		public uint NativeType;

		internal FieldMarshalRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitFieldMarshalRow(this);
		}
	}
}
