namespace DevX.Cecil.Metadata
{
	public sealed class GenericParamRow : IMetadataRow, IMetadataRowVisitable
	{
		public ushort Number;

		public GenericParameterAttributes Flags;

		public MetadataToken Owner;

		public uint Name;

		internal GenericParamRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitGenericParamRow(this);
		}
	}
}
