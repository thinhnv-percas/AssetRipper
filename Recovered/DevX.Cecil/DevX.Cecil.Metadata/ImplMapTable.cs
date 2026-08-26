namespace DevX.Cecil.Metadata
{
	public sealed class ImplMapTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 28;

		private RowCollection m_rows;

		public ImplMapRow this[int index]
		{
			get
			{
				return m_rows[index] as ImplMapRow;
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

		public int Id => 28;

		internal ImplMapTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitImplMapTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
