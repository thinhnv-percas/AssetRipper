namespace DevX.Cecil.Metadata
{
	public sealed class FieldLayoutTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 16;

		private RowCollection m_rows;

		public FieldLayoutRow this[int index]
		{
			get
			{
				return m_rows[index] as FieldLayoutRow;
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

		public int Id => 16;

		internal FieldLayoutTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitFieldLayoutTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
