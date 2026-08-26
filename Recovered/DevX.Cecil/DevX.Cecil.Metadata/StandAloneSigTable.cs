namespace DevX.Cecil.Metadata
{
	public sealed class StandAloneSigTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 17;

		private RowCollection m_rows;

		public StandAloneSigRow this[int index]
		{
			get
			{
				return m_rows[index] as StandAloneSigRow;
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

		public int Id => 17;

		internal StandAloneSigTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitStandAloneSigTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
