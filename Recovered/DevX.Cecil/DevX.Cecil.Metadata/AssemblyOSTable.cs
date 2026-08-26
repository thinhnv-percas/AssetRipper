namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyOSTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 34;

		private RowCollection m_rows;

		public AssemblyOSRow this[int index]
		{
			get
			{
				return m_rows[index] as AssemblyOSRow;
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

		public int Id => 34;

		internal AssemblyOSTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitAssemblyOSTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
