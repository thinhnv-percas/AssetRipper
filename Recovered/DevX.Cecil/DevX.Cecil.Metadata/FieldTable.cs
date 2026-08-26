namespace DevX.Cecil.Metadata
{
	public sealed class FieldTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 4;

		private RowCollection m_rows;

		public FieldRow this[int index]
		{
			get
			{
				return m_rows[index] as FieldRow;
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

		public int Id => 4;

		internal FieldTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitFieldTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
