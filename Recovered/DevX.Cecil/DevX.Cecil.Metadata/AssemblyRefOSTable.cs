namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyRefOSTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 37;

		private RowCollection m_rows;

		public AssemblyRefOSRow this[int index]
		{
			get
			{
				return m_rows[index] as AssemblyRefOSRow;
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

		public int Id => 37;

		internal AssemblyRefOSTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitAssemblyRefOSTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
