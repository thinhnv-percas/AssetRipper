namespace DevX.Cecil.Metadata
{
	public sealed class ManifestResourceRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Offset;

		public ManifestResourceAttributes Flags;

		public uint Name;

		public MetadataToken Implementation;

		internal ManifestResourceRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitManifestResourceRow(this);
		}
	}
}
