namespace DevX.Cecil.Metadata
{
	public sealed class DeclSecurityTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 14;

		private RowCollection m_rows;

		public DeclSecurityRow this[int index]
		{
			get
			{
				return m_rows[index] as DeclSecurityRow;
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

		public int Id => 14;

		internal DeclSecurityTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitDeclSecurityTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
