namespace DevX.Cecil.Metadata
{
	public abstract class BaseMetadataVisitor : IMetadataVisitor
	{
		public virtual void VisitMetadataRoot(MetadataRoot root)
		{
		}

		public virtual void VisitMetadataRootHeader(MetadataRoot.MetadataRootHeader header)
		{
		}

		public virtual void VisitMetadataStreamCollection(MetadataStreamCollection streams)
		{
		}

		public virtual void VisitMetadataStream(MetadataStream stream)
		{
		}

		public virtual void VisitMetadataStreamHeader(MetadataStream.MetadataStreamHeader header)
		{
		}

		public virtual void VisitGuidHeap(GuidHeap heap)
		{
		}

		public virtual void VisitStringsHeap(StringsHeap heap)
		{
		}

		public virtual void VisitTablesHeap(TablesHeap heap)
		{
		}

		public virtual void VisitBlobHeap(BlobHeap heap)
		{
		}

		public virtual void VisitUserStringsHeap(UserStringsHeap heap)
		{
		}

		public virtual void TerminateMetadataRoot(MetadataRoot root)
		{
		}
	}
}
