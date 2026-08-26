namespace DevX.Cecil.Metadata
{
	public sealed class ImplMapRow : IMetadataRow, IMetadataRowVisitable
	{
		public PInvokeAttributes MappingFlags;

		public MetadataToken MemberForwarded;

		public uint ImportName;

		public uint ImportScope;

		internal ImplMapRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitImplMapRow(this);
		}
	}
}
