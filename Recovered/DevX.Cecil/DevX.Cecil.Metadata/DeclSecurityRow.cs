namespace DevX.Cecil.Metadata
{
	public sealed class DeclSecurityRow : IMetadataRow, IMetadataRowVisitable
	{
		public SecurityAction Action;

		public MetadataToken Parent;

		public uint PermissionSet;

		internal DeclSecurityRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitDeclSecurityRow(this);
		}
	}
}
