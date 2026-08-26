namespace DevX.Cecil.Metadata
{
	public sealed class ParamRow : IMetadataRow, IMetadataRowVisitable
	{
		public ParameterAttributes Flags;

		public ushort Sequence;

		public uint Name;

		internal ParamRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitParamRow(this);
		}
	}
}
