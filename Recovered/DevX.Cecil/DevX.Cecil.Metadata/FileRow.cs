namespace DevX.Cecil.Metadata
{
	public sealed class FileRow : IMetadataRow, IMetadataRowVisitable
	{
		public FileAttributes Flags;

		public uint Name;

		public uint HashValue;

		internal FileRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitFileRow(this);
		}
	}
}
