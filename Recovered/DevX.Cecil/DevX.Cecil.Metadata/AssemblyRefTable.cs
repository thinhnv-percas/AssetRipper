namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyRefTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 35;

		private RowCollection m_rows;

		public AssemblyRefRow this[int index]
		{
			get
			{
				return m_rows[index] as AssemblyRefRow;
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

		public int Id => 35;

		internal AssemblyRefTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitAssemblyRefTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
