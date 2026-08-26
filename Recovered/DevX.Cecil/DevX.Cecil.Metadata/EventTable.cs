namespace DevX.Cecil.Metadata
{
	public sealed class EventTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 20;

		private RowCollection m_rows;

		public EventRow this[int index]
		{
			get
			{
				return m_rows[index] as EventRow;
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

		public int Id => 20;

		internal EventTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitEventTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
