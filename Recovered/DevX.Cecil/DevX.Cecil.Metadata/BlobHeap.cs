using System.IO;

namespace DevX.Cecil.Metadata
{
	public class BlobHeap : MetadataHeap
	{
		internal BlobHeap(MetadataStream stream)
			: base(stream, "#Blob")
		{
		}

		public byte[] Read(uint index)
		{
			return ReadBytesFromStream(index);
		}

		public BinaryReader GetReader(uint index)
		{
			return new BinaryReader(new MemoryStream(Read(index)));
		}

		public override void Accept(IMetadataVisitor visitor)
		{
			visitor.VisitBlobHeap(this);
		}
	}
}
