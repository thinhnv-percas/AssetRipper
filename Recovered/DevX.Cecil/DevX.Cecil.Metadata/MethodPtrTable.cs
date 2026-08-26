namespace DevX.Cecil.Metadata
{
	public sealed class MethodPtrTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 5;

		private RowCollection m_rows;

		public MethodPtrRow this[int index]
		{
			get
			{
				return m_rows[index] as MethodPtrRow;
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

		public int Id => 5;

		internal MethodPtrTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitMethodPtrTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
