using DevX.Cecil.Binary;
using System;
using System.IO;
using System.Text;

namespace DevX.Cecil.Metadata
{
	internal sealed class MetadataReader : BaseMetadataVisitor
	{
		private ImageReader m_ir;

		private BinaryReader m_binaryReader;

		private MetadataTableReader m_tableReader;

		private MetadataRoot m_root;

		public MetadataTableReader TableReader => m_tableReader;

		public MetadataReader(ImageReader brv)
		{
			m_ir = brv;
			m_binaryReader = brv.GetReader();
		}

		public MetadataRoot GetMetadataRoot()
		{
			return m_root;
		}

		public BinaryReader GetDataReader(RVA rva)
		{
			return m_ir.Image.GetReaderAtVirtualAddress(rva);
		}

		public override void VisitMetadataRoot(MetadataRoot root)
		{
			m_root = root;
			root.Header = new MetadataRoot.MetadataRootHeader();
			root.Streams = new MetadataStreamCollection();
		}

		public override void VisitMetadataRootHeader(MetadataRoot.MetadataRootHeader header)
		{
			long position = m_binaryReader.BaseStream.Position;
			header.Signature = m_binaryReader.ReadUInt32();
			if (header.Signature != 1112167234)
			{
				throw new MetadataFormatException("Wrong magic number");
			}
			header.MajorVersion = m_binaryReader.ReadUInt16();
			header.MinorVersion = m_binaryReader.ReadUInt16();
			header.Reserved = m_binaryReader.ReadUInt32();
			uint num = m_binaryReader.ReadUInt32();
			if (num != 0)
			{
				long position2 = m_binaryReader.BaseStream.Position;
				byte[] array = new byte[num];
				int num2 = 0;
				while (num2 < num)
				{
					byte b = (byte)m_binaryReader.ReadSByte();
					if (b == 0)
					{
						break;
					}
					array[num2++] = b;
				}
				byte[] array2 = new byte[num2];
				Buffer.BlockCopy(array, 0, array2, 0, num2);
				header.Version = Encoding.UTF8.GetString(array2, 0, array2.Length);
				position2 += num - position + 3;
				position2 &= -4;
				position2 += position;
				m_binaryReader.BaseStream.Position = position2;
			}
			else
			{
				header.Version = string.Empty;
			}
			header.Flags = m_binaryReader.ReadUInt16();
			header.Streams = m_binaryReader.ReadUInt16();
		}

		public override void VisitMetadataStreamCollection(MetadataStreamCollection coll)
		{
			for (int i = 0; i < m_root.Header.Streams; i++)
			{
				coll.Add(new MetadataStream());
			}
		}

		public override void VisitMetadataStreamHeader(MetadataStream.MetadataStreamHeader header)
		{
			header.Offset = m_binaryReader.ReadUInt32();
			header.Size = m_binaryReader.ReadUInt32();
			StringBuilder stringBuilder = new StringBuilder();
			while (true)
			{
				char c = (char)m_binaryReader.ReadSByte();
				if (c == '\0')
				{
					break;
				}
				stringBuilder.Append(c);
			}
			header.Name = stringBuilder.ToString();
			if (header.Name.Length == 0)
			{
				throw new MetadataFormatException("Invalid stream name");
			}
			long num = m_root.GetImage().ResolveVirtualAddress(m_root.GetImage().CLIHeader.Metadata.VirtualAddress);
			long num2 = m_binaryReader.BaseStream.Position;
			if (header.Size != 0)
			{
				num2 -= num;
			}
			num2 += 3;
			num2 &= -4;
			if (header.Size != 0)
			{
				num2 += num;
			}
			m_binaryReader.BaseStream.Position = num2;
			header.Stream.Heap = MetadataHeap.HeapFactory(header.Stream);
		}

		public override void VisitGuidHeap(GuidHeap heap)
		{
			VisitHeap(heap);
		}

		public override void VisitStringsHeap(StringsHeap heap)
		{
			VisitHeap(heap);
			if (heap.Data.Length < 1 && heap.Data[0] != 0)
			{
				throw new MetadataFormatException("Malformed #Strings heap");
			}
			heap[0u] = string.Empty;
		}

		public override void VisitTablesHeap(TablesHeap heap)
		{
			VisitHeap(heap);
			heap.Tables = new TableCollection(heap);
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(heap.Data));
			try
			{
				heap.Reserved = binaryReader.ReadUInt32();
				heap.MajorVersion = binaryReader.ReadByte();
				heap.MinorVersion = binaryReader.ReadByte();
				heap.HeapSizes = binaryReader.ReadByte();
				heap.Reserved2 = binaryReader.ReadByte();
				heap.Valid = binaryReader.ReadInt64();
				heap.Sorted = binaryReader.ReadInt64();
			}
			finally
			{
				binaryReader.Close();
			}
		}

		public override void VisitBlobHeap(BlobHeap heap)
		{
			VisitHeap(heap);
		}

		public override void VisitUserStringsHeap(UserStringsHeap heap)
		{
			VisitHeap(heap);
		}

		private void VisitHeap(MetadataHeap heap)
		{
			long position = m_binaryReader.BaseStream.Position;
			m_binaryReader.BaseStream.Position = m_root.GetImage().ResolveVirtualAddress(m_root.GetImage().CLIHeader.Metadata.VirtualAddress) + heap.GetStream().Header.Offset;
			heap.Data = m_binaryReader.ReadBytes((int)heap.GetStream().Header.Size);
			m_binaryReader.BaseStream.Position = position;
		}

		private void SetHeapIndexSize(MetadataHeap heap, byte flag)
		{
			if (heap != null)
			{
				TablesHeap tablesHeap = m_root.Streams.TablesHeap;
				heap.IndexSize = (((tablesHeap.HeapSizes & flag) <= 0) ? 2 : 4);
			}
		}

		public override void TerminateMetadataRoot(MetadataRoot root)
		{
			SetHeapIndexSize(root.Streams.StringsHeap, 1);
			SetHeapIndexSize(root.Streams.GuidHeap, 2);
			SetHeapIndexSize(root.Streams.BlobHeap, 4);
			m_tableReader = new MetadataTableReader(this);
			root.Streams.TablesHeap.Tables.Accept(m_tableReader);
		}
	}
}
