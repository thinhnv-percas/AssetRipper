namespace DevX.Cecil.Metadata
{
	public sealed class FieldRVATable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 29;

		private RowCollection m_rows;

		public FieldRVARow this[int index]
		{
			get
			{
				return m_rows[index] as FieldRVARow;
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

		public int Id => 29;

		internal FieldRVATable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitFieldRVATable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
