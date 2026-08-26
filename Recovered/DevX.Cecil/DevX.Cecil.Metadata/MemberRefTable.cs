namespace DevX.Cecil.Metadata
{
	public sealed class MemberRefTable : IMetadataTable, IMetadataTableVisitable
	{
		public const int RId = 10;

		private RowCollection m_rows;

		public MemberRefRow this[int index]
		{
			get
			{
				return m_rows[index] as MemberRefRow;
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

		public int Id => 10;

		internal MemberRefTable()
		{
		}

		public void Accept(IMetadataTableVisitor visitor)
		{
			visitor.VisitMemberRefTable(this);
			Rows.Accept(visitor.GetRowVisitor());
		}
	}
}
