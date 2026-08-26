namespace DevX.Cecil.Metadata
{
	public sealed class GenericParamTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 42;

		private RowCollection m_rows;

		public GenericParamRow this[int index]
		{
			get
			{
				return m_rows[index] as GenericParamRow;
			}
			set
			{
				m_rows[index] = value;
			}
		}

		public RowCollection Rows
		{
			get
			{
				return m_rows;
			}
			set
			{
				m_rows = value;
			}
		}

		public int Id => 42;

		internal GenericParamTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitGenericParamTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
