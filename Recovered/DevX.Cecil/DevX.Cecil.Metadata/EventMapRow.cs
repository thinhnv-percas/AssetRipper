namespace DevX.Cecil.Metadata
{
	public sealed class EventMapRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Parent;

		public uint EventList;

		internal EventMapRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitEventMapRow(this);
		}
	}
}
