namespace DevX.Cecil.Metadata
{
	public sealed class MethodSpecTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 43;

		private RowCollection m_rows;

		public MethodSpecRow this[int index]
		{
			get
			{
				return m_rows[index] as MethodSpecRow;
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

		public int Id => 43;

		internal MethodSpecTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitMethodSpecTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
