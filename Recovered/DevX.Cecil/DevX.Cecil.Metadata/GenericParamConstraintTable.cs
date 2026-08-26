namespace DevX.Cecil.Metadata
{
	public sealed class GenericParamConstraintTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 44;

		private RowCollection m_rows;

		public GenericParamConstraintRow this[int index]
		{
			get
			{
				return m_rows[index] as GenericParamConstraintRow;
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

		public int Id => 44;

		internal GenericParamConstraintTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitGenericParamConstraintTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
