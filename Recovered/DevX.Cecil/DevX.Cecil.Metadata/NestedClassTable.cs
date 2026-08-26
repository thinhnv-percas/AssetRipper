namespace DevX.Cecil.Metadata
{
	public sealed class NestedClassTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 41;

		private RowCollection m_rows;

		public NestedClassRow this[int index]
		{
			get
			{
				return m_rows[index] as NestedClassRow;
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

		public int Id => 41;

		internal NestedClassTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitNestedClassTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
