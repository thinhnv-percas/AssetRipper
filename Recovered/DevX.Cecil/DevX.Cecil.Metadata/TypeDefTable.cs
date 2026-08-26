namespace DevX.Cecil.Metadata
{
	public sealed class TypeDefTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 2;

		private RowCollection m_rows;

		public TypeDefRow this[int index]
		{
			get
			{
				return m_rows[index] as TypeDefRow;
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

		public int Id => 2;

		internal TypeDefTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitTypeDefTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
