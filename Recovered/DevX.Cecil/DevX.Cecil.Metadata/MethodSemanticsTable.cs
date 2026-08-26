namespace DevX.Cecil.Metadata
{
	public sealed class MethodSemanticsTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 24;

		private RowCollection m_rows;

		public MethodSemanticsRow this[int index]
		{
			get
			{
				return m_rows[index] as MethodSemanticsRow;
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

		public int Id => 24;

		internal MethodSemanticsTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitMethodSemanticsTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
