namespace DevX.Cecil.Metadata
{
	public class MetadataStream : IMetadataVisitable
	{
		public class MetadataStreamHeader : IMetadataVisitable
		{
			public uint Offset;

			public uint Size;

			public string Name;

			private MetadataStream m_stream;

			public MetadataStream Stream => m_stream;

			internal MetadataStreamHeader(MetadataStream stream)
			{
				m_stream = stream;
			}

			public void Accept(IMetadataVisitor visitor)
			{
				visitor.VisitMetadataStreamHeader(this);
			}
		}

		public const string Strings = "#Strings";

		public const string Tables = "#~";

		public const string IncrementalTables = "#-";

		public const string Blob = "#Blob";

		public const string GUID = "#GUID";

		public const string UserStrings = "#US";

		private MetadataStreamHeader m_header;

		private MetadataHeap m_heap;

		public MetadataStreamHeader Header
		{
			get
			{
				return m_header;
			}
			set
			{
				m_header = value;
			}
		}

		public MetadataHeap Heap
		{
			get
			{
				return m_heap;
			}
			set
			{
				m_heap = value;
			}
		}

		internal MetadataStream()
		{
			m_header = new MetadataStreamHeader(this);
		}

		public void Accept(IMetadataVisitor visitor)
		{
			visitor.VisitMetadataStream(this);
			m_header.Accept(visitor);
			if (m_heap != null)
			{
				m_heap.Accept(visitor);
			}
		}
	}
}
