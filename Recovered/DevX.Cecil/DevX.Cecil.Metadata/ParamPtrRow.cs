namespace DevX.Cecil.Metadata
{
	public sealed class ParamPtrRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Param;

		internal ParamPtrRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitParamPtrRow(this);
		}
	}
}
