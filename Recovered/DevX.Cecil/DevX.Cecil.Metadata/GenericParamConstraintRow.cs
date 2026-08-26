namespace DevX.Cecil.Metadata
{
	public sealed class GenericParamConstraintRow : IMetadataRow, IMetadataRowVisitable
	{
		public uint Owner;

		public MetadataToken Constraint;

		internal GenericParamConstraintRow()
		{
		}

		public void Accept(IMetadataRowVisitor visitor)
		{
			visitor.VisitGenericParamConstraintRow(this);
		}
	}
}
