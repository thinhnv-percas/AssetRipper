namespace DevX.Cecil.Metadata
{
	public sealed class MethodSpecRow : IMetadataRow, IMetadataRowVisitable
	{
		public MetadataToken Method;

		public uint Instantiation;

		internal MethodSpecRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitMethodSpecRow(this);
		}
	}
}
