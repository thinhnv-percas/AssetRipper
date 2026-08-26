namespace DevX.Cecil.Metadata
{
	public sealed class NestedClassRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint NestedClass;

		public uint EnclosingClass;

		internal NestedClassRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitNestedClassRow(this);
		}
	}
}
