namespace DevX.Cecil.Metadata
{
	public sealed class TypeRefRow : IMetadataRow, IMetadataRowVisitable
	{
		public MetadataToken ResolutionScope;

		public uint Name;

		public uint Namespace;

		internal TypeRefRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitTypeRefRow(this);
		}
	}
}
