namespace DevX.Cecil.Metadata
{
	public sealed class FieldPtrTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 3;

		private RowCollection m_rows;

		public FieldPtrRow this[int index]
		{
			get
			{
				return m_rows[index] as FieldPtrRow;
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

		public int Id => 3;

		internal FieldPtrTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitFieldPtrTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
