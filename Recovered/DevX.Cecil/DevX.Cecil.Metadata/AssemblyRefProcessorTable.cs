namespace DevX.Cecil.Metadata
{
	public sealed class AssemblyRefProcessorTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 36;

		private RowCollection m_rows;

		public AssemblyRefProcessorRow this[int index]
		{
			get
			{
				return m_rows[index] as AssemblyRefProcessorRow;
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

		public int Id => 36;

		internal AssemblyRefProcessorTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitAssemblyRefProcessorTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
