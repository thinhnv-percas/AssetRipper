namespace DevX.Cecil.Metadata
{
	public sealed class ModuleTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 0;

		private RowCollection m_rows;

		public ModuleRow this[int index]
		{
			get
			{
				return m_rows[index] as ModuleRow;
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

		public int Id => 0;

		internal ModuleTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitModuleTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
