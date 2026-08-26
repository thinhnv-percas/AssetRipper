namespace DevX.Cecil.Metadata
{
	public sealed class CustomAttributeTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 12;

		private RowCollection m_rows;

		public CustomAttributeRow this[int index]
		{
			get
			{
				return m_rows[index] as CustomAttributeRow;
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

		public int Id => 12;

		internal CustomAttributeTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitCustomAttributeTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
