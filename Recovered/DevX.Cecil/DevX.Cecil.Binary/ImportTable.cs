namespace DevX.Cecil.Binary
{
	public sealed class ImportTable : IBinaryVisitable
	{
		public RVA ImportLookupTable;

		public uint DateTimeStamp;

		public uint ForwardChain;

		public RVA Name;

		public RVA ImportAddressTable;

		internal ImportTable()
		{
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitImportTable(this);
		}
	}
}
