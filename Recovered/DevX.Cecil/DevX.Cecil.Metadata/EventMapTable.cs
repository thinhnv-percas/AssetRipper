namespace DevX.Cecil.Metadata
{
	public sealed class EventMapTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 18;

		private RowCollection m_rows;

		public EventMapRow this[int index]
		{
			get
			{
				return m_rows[index] as EventMapRow;
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

		public int Id => 18;

		internal EventMapTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitEventMapTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
