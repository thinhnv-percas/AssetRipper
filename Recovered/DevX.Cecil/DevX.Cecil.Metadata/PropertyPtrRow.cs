namespace DevX.Cecil.Metadata
{
	public sealed class PropertyPtrRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Property;

		internal PropertyPtrRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitPropertyPtrRow(this);
		}
	}
}
