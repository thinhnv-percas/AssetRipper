namespace DevX.Cecil.Metadata
{
	public sealed class MemberRefRow : IMetadataRow, IMetadataRowVisitable
	{
		public MetadataToken Class;

		public uint Name;

		public uint Signature;

		internal MemberRefRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitMemberRefRow(this);
		}
	}
}
