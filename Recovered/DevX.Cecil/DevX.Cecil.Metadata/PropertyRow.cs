namespace DevX.Cecil.Metadata
{
	public sealed class PropertyRow : IMetadataRow, IMetadataRowVisitable
	{
		public PropertyAttributes Flags;

		public uint Name;

		public uint Type;

		internal PropertyRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitPropertyRow(this);
		}
	}
}
