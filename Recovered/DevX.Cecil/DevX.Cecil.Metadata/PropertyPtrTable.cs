namespace DevX.Cecil.Metadata
{
	public sealed class PropertyPtrTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 22;

		private RowCollection m_rows;

		public PropertyPtrRow this[int index]
		{
			get
			{
				return m_rows[index] as PropertyPtrRow;
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

		public int Id => 22;

		internal PropertyPtrTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitPropertyPtrTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
