namespace DevX.Cecil.Binary
{
	public sealed class ImportLookupTable : IBinaryVisitable
	{
		public RVA HintNameRVA;

		internal ImportLookupTable()
		{
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitImportLookupTable(this);
		}
	}
}
