namespace DevX.Cecil.Metadata
{
	public sealed class EventPtrTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 19;

		private RowCollection m_rows;

		public EventPtrRow this[int index]
		{
			get
			{
				return m_rows[index] as EventPtrRow;
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

		public int Id => 19;

		internal EventPtrTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitEventPtrTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
