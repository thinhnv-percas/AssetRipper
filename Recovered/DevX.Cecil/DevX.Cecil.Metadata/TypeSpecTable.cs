namespace DevX.Cecil.Metadata
{
	public sealed class TypeSpecTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 27;

		private RowCollection m_rows;

		public TypeSpecRow this[int index]
		{
			get
			{
				return m_rows[index] as TypeSpecRow;
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

		public int Id => 27;

		internal TypeSpecTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitTypeSpecTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
