namespace DevX.Cecil.Metadata
{
	public sealed class FieldMarshalTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 13;

		private RowCollection m_rows;

		public FieldMarshalRow this[int index]
		{
			get
			{
				return m_rows[index] as FieldMarshalRow;
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

		public int Id => 13;

		internal FieldMarshalTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitFieldMarshalTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
