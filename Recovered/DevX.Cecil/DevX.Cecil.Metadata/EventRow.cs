namespace DevX.Cecil.Metadata
{
	public sealed class EventRow : IMetadataRow, IMetadataRowVisitable
	{
		public EventAttributes EventFlags;

		public uint Name;

		public MetadataToken EventType;

		internal EventRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitEventRow(this);
		}
	}
}
