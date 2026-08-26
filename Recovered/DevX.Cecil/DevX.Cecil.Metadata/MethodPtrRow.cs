namespace DevX.Cecil.Metadata
{
	public sealed class MethodPtrRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Method;

		internal MethodPtrRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitMethodPtrRow(this);
		}
	}
}
