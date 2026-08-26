namespace DevX.Cecil.Metadata
{
	public sealed class PropertyMapTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 21;

		private RowCollection m_rows;

		public PropertyMapRow this[int index]
		{
			get
			{
				return m_rows[index] as PropertyMapRow;
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

		public int Id => 21;

		internal PropertyMapTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitPropertyMapTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
