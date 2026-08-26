namespace DevX.Cecil.Metadata
{
	public sealed class ManifestResourceTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 40;

		private RowCollection m_rows;

		public ManifestResourceRow this[int index]
		{
			get
			{
				return m_rows[index] as ManifestResourceRow;
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

		public int Id => 40;

		internal ManifestResourceTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitManifestResourceTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
