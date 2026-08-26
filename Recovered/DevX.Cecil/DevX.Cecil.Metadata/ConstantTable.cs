namespace DevX.Cecil.Metadata
{
	public sealed class ConstantTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 11;

		private RowCollection m_rows;

		public ConstantRow this[int index]
		{
			get
			{
				return m_rows[index] as ConstantRow;
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

		public int Id => 11;

		internal ConstantTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitConstantTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
