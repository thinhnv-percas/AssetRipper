namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyProcessorTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 33;

		private RowCollection m_rows;

		public AssemblyProcessorRow this[int index]
		{
			get
			{
				return m_rows[index] as AssemblyProcessorRow;
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

		public int Id => 33;

		internal AssemblyProcessorTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitAssemblyProcessorTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
