namespace DevX.Cecil.Metadata
{
	public sealed class ParamPtrTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 7;

		private RowCollection m_rows;

		public ParamPtrRow this[int index]
		{
			get
			{
				return m_rows[index] as ParamPtrRow;
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

		public int Id => 7;

		internal ParamPtrTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitParamPtrTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
