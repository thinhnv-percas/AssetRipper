namespace DevX.Cecil.Metadata
{
	public interface IMetadataVisitor
	{
		void VisitMetadataRoot(MetadataRoot root);

		void VisitMetadataRootHeader(MetadataRoot.MetadataRootHeader header);

		void VisitMetadataStreamCollection(MetadataStreamCollection streams);

		void VisitMetadataStream(MetadataStream stream);

		void VisitMetadataStreamHeader(MetadataStream.MetadataStreamHeader header);

		void VisitGuidHeap(GuidHeap heap);

		void VisitStringsHeap(StringsHeap heap);

		void VisitTablesHeap(TablesHeap heap);

		void VisitBlobHeap(BlobHeap heap);

		void VisitUserStringsHeap(UserStringsHeap heap);

		void TerminateMetadataRoot(MetadataRoot root);
	}
}
