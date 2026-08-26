namespace DevX.Cecil.Metadata
{
	public sealed class TypeSpecRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Signature;

		internal TypeSpecRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitTypeSpecRow(this);
		}
	}
}
