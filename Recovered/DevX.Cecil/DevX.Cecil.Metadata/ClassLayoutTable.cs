namespace DevX.Cecil.Metadata
{
	public sealed class ClassLayoutTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 15;

		private RowCollection m_rows;

		public ClassLayoutRow this[int index]
		{
			get
			{
				return m_rows[index] as ClassLayoutRow;
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

		public int Id => 15;

		internal ClassLayoutTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitClassLayoutTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
