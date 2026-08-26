namespace DevX.Cecil.Metadata
{
	public sealed class EventPtrRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Event;

		internal EventPtrRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitEventPtrRow(this);
		}
	}
}
