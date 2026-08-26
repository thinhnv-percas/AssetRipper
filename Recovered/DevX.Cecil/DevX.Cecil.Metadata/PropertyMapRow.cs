namespace DevX.Cecil.Metadata
{
	public sealed class PropertyMapRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Parent;

		public uint PropertyList;

		internal PropertyMapRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitPropertyMapRow(this);
		}
	}
}
