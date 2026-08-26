namespace DevX.Cecil.Metadata
{
	public sealed class InterfaceImplRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Class;

		public MetadataToken Interface;

		internal InterfaceImplRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitInterfaceImplRow(this);
		}
	}
}
