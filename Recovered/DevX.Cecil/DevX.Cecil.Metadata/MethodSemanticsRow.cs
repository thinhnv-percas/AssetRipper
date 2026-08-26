namespace DevX.Cecil.Metadata
{
	public sealed class MethodSemanticsRow : IMetadataRow, IMetadataRowVisitable
	{
		public MethodSemanticsAttributes Semantics;

		public uint Method;

		public MetadataToken Association;

		internal MethodSemanticsRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitMethodSemanticsRow(this);
		}
	}
}
