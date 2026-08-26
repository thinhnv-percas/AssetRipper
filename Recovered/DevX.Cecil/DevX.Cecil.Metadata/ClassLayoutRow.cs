namespace DevX.Cecil.Metadata
{
	public sealed class ClassLayoutRow : IMetadataRow, IMetadataRowVisitable
	{
		public ushort PackingSize;

		public uint ClassSize;

		public uint Parent;

		internal ClassLayoutRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitClassLayoutRow(this);
		}
	}
}
