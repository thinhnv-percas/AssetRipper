namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 32;

		private RowCollection m_rows;

		public AssemblyRow this[int index]
		{
			get
			{
				return m_rows[index] as AssemblyRow;
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

		public int Id => 32;

		internal AssemblyTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitAssemblyTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
