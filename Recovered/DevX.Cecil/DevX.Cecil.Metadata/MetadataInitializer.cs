using DevX.Cecil.Binary;

namespace DevX.Cecil.Metadata
{
	internal sealed class MetadataInitializer : BaseMetadataVisitor
	{
		private MetadataRoot m_root;

		public MetadataInitializer(ImageInitializer init)
		{
			m_root = init.Image.MetadataRoot;
		}

		public override void VisitMetadataRoot(MetadataRoot root)
		{
			root.Header = new MetadataRoot.MetadataRootHeader();
			root.Streams = new MetadataStreamCollection();
		}

		public override void VisitMetadataRootHeader(MetadataRoot.MetadataRootHeader header)
		{
			header.SetDefaultValues();
		}

		public override void VisitMetadataStreamCollection(MetadataStreamCollection coll)
		{
			MetadataStream metadataStream = new MetadataStream();
			metadataStream.Header.Name = "#~";
			metadataStream.Heap = MetadataHeap.HeapFactory(metadataStream);
			TablesHeap tablesHeap = metadataStream.Heap as TablesHeap;
			tablesHeap.Tables = new TableCollection(tablesHeap);
			m_root.Streams.Add(metadataStream);
		}

		public override void VisitTablesHeap(TablesHeap th)
		{
			th.Reserved = 0u;
			th.MajorVersion = 1;
			th.MinorVersion = 0;
			th.Reserved2 = 1;
			th.Sorted = 2199879023104L;
		}
	}
}
