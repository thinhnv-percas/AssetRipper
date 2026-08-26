namespace DevX.Cecil.Metadata
{
	public class TablesHeap : MetadataHeap
	{
		public const int MaxTableCount = 45;

		public uint Reserved;

		public byte MajorVersion;

		public byte MinorVersion;

		public byte HeapSizes;

		public byte Reserved2;

		public long Valid;

		public long Sorted;

		private TableCollection m_tables;

		public TableCollection Tables
		{
			get
			{
				return m_tables;
			}
			set
			{
				m_tables = value;
			}
		}

		public IMetadataTable this[int id]
		{
			get
			{
				return m_tables[id];
			}
			set
			{
				m_tables[id] = value;
			}
		}

		internal TablesHeap(MetadataStream stream)
			: base(stream, "#~")
		{
		}

		public bool HasTable(int id)
		{
			return (Valid & (1L << id)) != 0;
		}

		public override void Accept(IMetadataVisitor visitor)
		{
			visitor.VisitTablesHeap(this);
		}
	}
}
