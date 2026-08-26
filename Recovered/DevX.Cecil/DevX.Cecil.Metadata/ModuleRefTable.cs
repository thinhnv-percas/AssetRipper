namespace DevX.Cecil.Metadata
{
	public sealed class ModuleRefTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 26;

		private RowCollection m_rows;

		public ModuleRefRow this[int index]
		{
			get
			{
				return m_rows[index] as ModuleRefRow;
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

		public int Id => 26;

		internal ModuleRefTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitModuleRefTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
