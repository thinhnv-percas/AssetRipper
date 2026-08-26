namespace DevX.Cecil.Metadata
{
	public sealed class MethodImplRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Class;

		public MetadataToken MethodBody;

		public MetadataToken MethodDeclaration;

		internal MethodImplRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitMethodImplRow(this);
		}
	}
}
