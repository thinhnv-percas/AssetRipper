namespace DevX.Cecil.Metadata
{
	public sealed class MethodTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 6;

		private RowCollection m_rows;

		public MethodRow this[int index]
		{
			get
			{
				return m_rows[index] as MethodRow;
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

		public int Id => 6;

		internal MethodTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitMethodTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
