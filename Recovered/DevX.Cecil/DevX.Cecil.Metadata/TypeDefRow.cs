namespace DevX.Cecil.Metadata
{
	public sealed class TypeDefRow : IMetadataRow, IMetadataRowVisitable
	{
		public TypeAttributes Flags;

		public uint Name;

		public uint Namespace;

		public MetadataToken Extends;

		public uint FieldList;

		public uint MethodList;

		internal TypeDefRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitTypeDefRow(this);
		}
	}
}
