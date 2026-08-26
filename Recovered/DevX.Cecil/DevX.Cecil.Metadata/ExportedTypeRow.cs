namespace DevX.Cecil.Metadata
{
	public sealed class ExportedTypeRow : IMetadataRow, IMetadataRowVisitable
	{
		public TypeAttributes Flags;

		public uint TypeDefId;

		public uint TypeName;

		public uint TypeNamespace;

		public MetadataToken Implementation;

		internal ExportedTypeRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitExportedTypeRow(this);
		}
	}
}
