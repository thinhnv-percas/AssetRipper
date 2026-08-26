namespace DevX.Cecil.Metadata
{
	public sealed class ExportedTypeTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 39;

		private RowCollection m_rows;

		public ExportedTypeRow this[int index]
		{
			get
			{
				return m_rows[index] as ExportedTypeRow;
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

		public int Id => 39;

		internal ExportedTypeTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitExportedTypeTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
