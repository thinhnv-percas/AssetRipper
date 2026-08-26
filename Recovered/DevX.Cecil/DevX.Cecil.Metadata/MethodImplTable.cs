namespace DevX.Cecil.Metadata
{
	public sealed class MethodImplTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 25;

		private RowCollection m_rows;

		public MethodImplRow this[int index]
		{
			get
			{
				return m_rows[index] as MethodImplRow;
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

		public int Id => 25;

		internal MethodImplTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitMethodImplTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
