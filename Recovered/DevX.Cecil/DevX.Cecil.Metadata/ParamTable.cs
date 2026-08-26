namespace DevX.Cecil.Metadata
{
	public sealed class ParamTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 8;

		private RowCollection m_rows;

		public ParamRow this[int index]
		{
			get
			{
				return m_rows[index] as ParamRow;
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

		public int Id => 8;

		internal ParamTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitParamTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
