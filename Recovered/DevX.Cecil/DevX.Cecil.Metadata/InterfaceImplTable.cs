namespace DevX.Cecil.Metadata
{
	public sealed class InterfaceImplTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 9;

		private RowCollection m_rows;

		public InterfaceImplRow this[int index]
		{
			get
			{
				return m_rows[index] as InterfaceImplRow;
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

		public int Id => 9;

		internal InterfaceImplTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitInterfaceImplTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
