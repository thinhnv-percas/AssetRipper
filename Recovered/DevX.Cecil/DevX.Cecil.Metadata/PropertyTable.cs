namespace DevX.Cecil.Metadata
{
	public sealed class PropertyTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 23;

		private RowCollection m_rows;

		public PropertyRow this[int index]
		{
			get
			{
				return m_rows[index] as PropertyRow;
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

		public int Id => 23;

		internal PropertyTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitPropertyTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
