namespace DevX.Cecil.Metadata
{
	public sealed class TypeRefTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 1;

		private RowCollection m_rows;

		public TypeRefRow this[int index]
		{
			get
			{
				return m_rows[index] as TypeRefRow;
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

		public int Id => 1;

		internal TypeRefTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitTypeRefTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
