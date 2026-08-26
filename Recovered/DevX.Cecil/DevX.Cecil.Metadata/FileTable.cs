namespace DevX.Cecil.Metadata
{
	public sealed class FileTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 38;

		private RowCollection m_rows;

		public FileRow this[int index]
		{
			get
			{
				return m_rows[index] as FileRow;
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

		public int Id => 38;

		internal FileTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitFileTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
