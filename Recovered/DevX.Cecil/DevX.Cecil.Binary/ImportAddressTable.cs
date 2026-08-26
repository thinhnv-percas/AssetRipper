namespace DevX.Cecil.Binary
{
	public sealed class ImportAddressTable : IBinaryVisitable
	{
		public RVA HintNameTableRVA;

		internal ImportAddressTable()
		{
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitImportAddressTable(this);
		}
	}
}
