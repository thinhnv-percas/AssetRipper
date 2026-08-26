using DevX.Cecil.Binary;
using System;
using System.Collections;
using System.IO;
using System.Text;

namespace DevX.Cecil.Metadata
{
	internal sealed class MetadataWriter : BaseMetadataVisitor
	{
		private AssemblyDefinition m_assembly;

		private MetadataRoot m_root;

		private TargetRuntime m_runtime;

		private ImageWriter m_imgWriter;

		private MetadataTableWriter m_tableWriter;

		private MemoryBinaryWriter m_binaryWriter;

		private IDictionary m_stringCache;

		private MemoryBinaryWriter m_stringWriter;

		private IDictionary m_guidCache;

		private MemoryBinaryWriter m_guidWriter;

		private IDictionary m_usCache;

		private MemoryBinaryWriter m_usWriter;

		private IDictionary m_blobCache;

		private MemoryBinaryWriter m_blobWriter;

		private MemoryBinaryWriter m_tWriter;

		private MemoryBinaryWriter m_cilWriter;

		private MemoryBinaryWriter m_fieldDataWriter;

		private MemoryBinaryWriter m_resWriter;

		private uint m_mdStart;

		private uint m_mdSize;

		private uint m_resStart;

		private uint m_resSize;

		private uint m_snsStart;

		private uint m_snsSize;

		private uint m_debugHeaderStart;

		private uint m_imporTableStart;

		private uint m_entryPointToken;

		private RVA m_cursor = new RVA(8272u);

		public MemoryBinaryWriter CilWriter => m_cilWriter;

		public MemoryBinaryWriter StringWriter => m_stringWriter;

		public MemoryBinaryWriter GuidWriter => m_guidWriter;

		public MemoryBinaryWriter UserStringWriter => m_usWriter;

		public MemoryBinaryWriter BlobWriter => m_blobWriter;

		public uint DebugHeaderPosition => m_debugHeaderStart;

		public uint ImportTablePosition => m_imporTableStart;

		public uint EntryPointToken
		{
			get
			{
				return m_entryPointToken;
			}
			set
			{
				m_entryPointToken = value;
			}
		}

		public TargetRuntime TargetRuntime => m_runtime;

		public MetadataWriter(AssemblyDefinition asm, MetadataRoot root, AssemblyKind kind, TargetRuntime rt, BinaryWriter writer)
		{
			m_assembly = asm;
			m_root = root;
			m_runtime = rt;
			m_imgWriter = new ImageWriter(this, kind, writer);
			m_binaryWriter = m_imgWriter.GetTextWriter();
			m_stringCache = new Hashtable();
			m_stringWriter = new MemoryBinaryWriter(Encoding.UTF8);
			m_stringWriter.Write((byte)0);
			m_guidCache = new Hashtable();
			m_guidWriter = new MemoryBinaryWriter();
			m_usCache = new Hashtable();
			m_usWriter = new MemoryBinaryWriter(Encoding.Unicode);
			m_usWriter.Write((byte)0);
			m_blobCache = new Hashtable(ByteArrayEqualityComparer.Instance, ByteArrayEqualityComparer.Instance);
			m_blobWriter = new MemoryBinaryWriter();
			m_blobWriter.Write((byte)0);
			m_tWriter = new MemoryBinaryWriter();
			m_tableWriter = new MetadataTableWriter(this, m_tWriter);
			m_cilWriter = new MemoryBinaryWriter();
			m_fieldDataWriter = new MemoryBinaryWriter();
			m_resWriter = new MemoryBinaryWriter();
		}

		public MetadataRoot GetMetadataRoot()
		{
			return m_root;
		}

		public ImageWriter GetImageWriter()
		{
			return m_imgWriter;
		}

		public MemoryBinaryWriter GetWriter()
		{
			return m_binaryWriter;
		}

		public MetadataTableWriter GetTableVisitor()
		{
			return m_tableWriter;
		}

		public void AddData(int length)
		{
			m_cursor += (uint)new RVA((uint)length);
		}

		public RVA GetDataCursor()
		{
			return m_cursor;
		}

		public uint AddString(string str)
		{
			if (str == null || str.Length == 0)
			{
				return 0u;
			}
			if (m_stringCache.Contains(str))
			{
				return (uint)m_stringCache[str];
			}
			uint num = (uint)m_stringWriter.BaseStream.Position;
			m_stringCache[str] = num;
			m_stringWriter.Write(Encoding.UTF8.GetBytes(str));
			m_stringWriter.Write('\0');
			return num;
		}

		public uint AddBlob(byte[] data)
		{
			if (data == null || data.Length == 0)
			{
				return 0u;
			}
			object obj = m_blobCache[data];
			if (obj != null)
			{
				return (uint)obj;
			}
			uint num = (uint)m_blobWriter.BaseStream.Position;
			m_blobCache[data] = num;
			Utilities.WriteCompressedInteger(m_blobWriter, data.Length);
			m_blobWriter.Write(data);
			return num;
		}

		public uint AddGuid(Guid g)
		{
			if (m_guidCache.Contains(g))
			{
				return (uint)m_guidCache[g];
			}
			uint num = (uint)m_guidWriter.BaseStream.Position;
			m_guidCache[g] = num;
			m_guidWriter.Write(g.ToByteArray());
			return num + 1;
		}

		public uint AddUserString(string str)
		{
			if (str == null)
			{
				return 0u;
			}
			if (m_usCache.Contains(str))
			{
				return (uint)m_usCache[str];
			}
			uint num = (uint)m_usWriter.BaseStream.Position;
			m_usCache[str] = num;
			byte[] bytes = Encoding.Unicode.GetBytes(str);
			Utilities.WriteCompressedInteger(m_usWriter, bytes.Length + 1);
			m_usWriter.Write(bytes);
			m_usWriter.Write((byte)(RequiresSpecialHandling(bytes) ? 1 : 0));
			return num;
		}

		private static bool RequiresSpecialHandling(byte[] chars)
		{
			for (int i = 0; i < chars.Length; i++)
			{
				byte b = chars[i];
				if (i % 2 == 1 && b != 0)
				{
					return true;
				}
				if (InRange(1, 8, b) || InRange(14, 31, b) || b == 39 || b == 45 || b == 127)
				{
					return true;
				}
			}
			return false;
		}

		private static bool InRange(int left, int right, int value)
		{
			return left <= value && value <= right;
		}

		private void CreateStream(string name)
		{
			MetadataStream metadataStream = new MetadataStream();
			metadataStream.Header.Name = name;
			metadataStream.Heap = MetadataHeap.HeapFactory(metadataStream);
			m_root.Streams.Add(metadataStream);
		}

		private void SetHeapSize(MetadataHeap heap, MemoryBinaryWriter data, byte flag)
		{
			if (data.BaseStream.Length > 65536)
			{
				m_root.Streams.TablesHeap.HeapSizes |= flag;
				heap.IndexSize = 4;
			}
			else
			{
				heap.IndexSize = 2;
			}
		}

		public uint AddResource(byte[] data)
		{
			uint result = (uint)m_resWriter.BaseStream.Position;
			m_resWriter.Write(data.Length);
			m_resWriter.Write(data);
			m_resWriter.QuadAlign();
			return result;
		}

		public void AddFieldInitData(byte[] data)
		{
			m_fieldDataWriter.Write(data);
			m_fieldDataWriter.QuadAlign();
		}

		private uint GetStrongNameSignatureSize()
		{
			if (m_assembly.Name.PublicKey != null)
			{
				int num = m_assembly.Name.PublicKey.Length;
				if (num > 32)
				{
					return (uint)(num - 32);
				}
			}
			return 128u;
		}

		public override void VisitMetadataRoot(MetadataRoot root)
		{
			WriteMemStream(m_cilWriter);
			WriteMemStream(m_fieldDataWriter);
			m_resStart = (uint)m_binaryWriter.BaseStream.Position;
			WriteMemStream(m_resWriter);
			m_resSize = (uint)(m_binaryWriter.BaseStream.Position - m_resStart);
			if ((m_assembly.Name.Flags & AssemblyFlags.PublicKey) != 0)
			{
				m_snsStart = (uint)m_binaryWriter.BaseStream.Position;
				m_snsSize = GetStrongNameSignatureSize();
				m_binaryWriter.Write(new byte[m_snsSize]);
				m_binaryWriter.QuadAlign();
			}
			if (m_imgWriter.GetImage().DebugHeader != null)
			{
				m_debugHeaderStart = (uint)m_binaryWriter.BaseStream.Position;
				m_binaryWriter.Write(new byte[m_imgWriter.GetImage().DebugHeader.GetSize()]);
				m_binaryWriter.QuadAlign();
			}
			m_mdStart = (uint)m_binaryWriter.BaseStream.Position;
			if (m_stringWriter.BaseStream.Length > 1)
			{
				CreateStream("#Strings");
				SetHeapSize(root.Streams.StringsHeap, m_stringWriter, 1);
				m_stringWriter.QuadAlign();
			}
			if (m_guidWriter.BaseStream.Length > 0)
			{
				CreateStream("#GUID");
				SetHeapSize(root.Streams.GuidHeap, m_guidWriter, 2);
			}
			if (m_blobWriter.BaseStream.Length > 1)
			{
				CreateStream("#Blob");
				SetHeapSize(root.Streams.BlobHeap, m_blobWriter, 4);
				m_blobWriter.QuadAlign();
			}
			if (m_usWriter.BaseStream.Length > 2)
			{
				CreateStream("#US");
				m_usWriter.QuadAlign();
			}
			m_root.Header.MajorVersion = 1;
			m_root.Header.MinorVersion = 1;
			switch (m_runtime)
			{
			case TargetRuntime.NET_1_0:
				m_root.Header.Version = "v1.0.3705";
				break;
			case TargetRuntime.NET_1_1:
				m_root.Header.Version = "v1.1.4322";
				break;
			case TargetRuntime.NET_2_0:
				m_root.Header.Version = "v2.0.50727";
				break;
			case TargetRuntime.NET_4_0:
				m_root.Header.Version = "v4.0.20506";
				break;
			}
			m_root.Streams.TablesHeap.Tables.Accept(m_tableWriter);
			if (m_tWriter.BaseStream.Length == 0L)
			{
				m_root.Streams.Remove(m_root.Streams.TablesHeap.GetStream());
			}
		}

		public override void VisitMetadataRootHeader(MetadataRoot.MetadataRootHeader header)
		{
			m_binaryWriter.Write(header.Signature);
			m_binaryWriter.Write(header.MajorVersion);
			m_binaryWriter.Write(header.MinorVersion);
			m_binaryWriter.Write(header.Reserved);
			m_binaryWriter.Write((header.Version.Length + 3) & -4);
			m_binaryWriter.Write(Encoding.ASCII.GetBytes(header.Version));
			m_binaryWriter.QuadAlign();
			m_binaryWriter.Write(header.Flags);
			m_binaryWriter.Write((ushort)m_root.Streams.Count);
		}

		public override void VisitMetadataStreamCollection(MetadataStreamCollection streams)
		{
			foreach (MetadataStream stream in streams)
			{
				MetadataStream.MetadataStreamHeader header = stream.Header;
				header.Offset = (uint)m_binaryWriter.BaseStream.Position;
				m_binaryWriter.Write(header.Offset);
				string text = header.Name;
				uint num = 0u;
				MemoryBinaryWriter memoryBinaryWriter;
				switch (header.Name)
				{
				case "#~":
					memoryBinaryWriter = m_tWriter;
					num += 24;
					break;
				case "#Strings":
					text += "\0\0\0\0";
					memoryBinaryWriter = m_stringWriter;
					break;
				case "#GUID":
					memoryBinaryWriter = m_guidWriter;
					break;
				case "#Blob":
					memoryBinaryWriter = m_blobWriter;
					break;
				case "#US":
					memoryBinaryWriter = m_usWriter;
					break;
				default:
					throw new MetadataFormatException("Unknown stream kind");
				}
				num = (uint)((int)num + (int)((memoryBinaryWriter.BaseStream.Length + 3) & -4));
				m_binaryWriter.Write(num);
				m_binaryWriter.Write(Encoding.ASCII.GetBytes(text));
				m_binaryWriter.QuadAlign();
			}
		}

		private void WriteMemStream(MemoryBinaryWriter writer)
		{
			m_binaryWriter.Write(writer);
			m_binaryWriter.QuadAlign();
		}

		private void PatchStreamHeaderOffset(MetadataHeap heap)
		{
			long position = m_binaryWriter.BaseStream.Position;
			m_binaryWriter.BaseStream.Position = heap.GetStream().Header.Offset;
			m_binaryWriter.Write((uint)(position - m_mdStart));
			m_binaryWriter.BaseStream.Position = position;
		}

		public override void VisitGuidHeap(GuidHeap heap)
		{
			PatchStreamHeaderOffset(heap);
			WriteMemStream(m_guidWriter);
		}

		public override void VisitStringsHeap(StringsHeap heap)
		{
			PatchStreamHeaderOffset(heap);
			WriteMemStream(m_stringWriter);
		}

		public override void VisitTablesHeap(TablesHeap heap)
		{
			PatchStreamHeaderOffset(heap);
			m_binaryWriter.Write(heap.Reserved);
			switch (m_runtime)
			{
			case TargetRuntime.NET_1_0:
			case TargetRuntime.NET_1_1:
				heap.MajorVersion = 1;
				heap.MinorVersion = 0;
				break;
			case TargetRuntime.NET_2_0:
			case TargetRuntime.NET_4_0:
				heap.MajorVersion = 2;
				heap.MinorVersion = 0;
				break;
			}
			m_binaryWriter.Write(heap.MajorVersion);
			m_binaryWriter.Write(heap.MinorVersion);
			m_binaryWriter.Write(heap.HeapSizes);
			m_binaryWriter.Write(heap.Reserved2);
			m_binaryWriter.Write(heap.Valid);
			m_binaryWriter.Write(heap.Sorted);
			WriteMemStream(m_tWriter);
		}

		public override void VisitBlobHeap(BlobHeap heap)
		{
			PatchStreamHeaderOffset(heap);
			WriteMemStream(m_blobWriter);
		}

		public override void VisitUserStringsHeap(UserStringsHeap heap)
		{
			PatchStreamHeaderOffset(heap);
			WriteMemStream(m_usWriter);
		}

		private void PatchHeader()
		{
			Image image = m_imgWriter.GetImage();
			image.CLIHeader.EntryPointToken = m_entryPointToken;
			if ((m_assembly.Name.Flags & AssemblyFlags.PublicKey) == AssemblyFlags.SideBySideCompatible)
			{
				image.CLIHeader.Flags &= ~RuntimeImage.StrongNameSigned;
			}
			if (m_mdSize != 0)
			{
				image.CLIHeader.Metadata = new DataDirectory(image.TextSection.VirtualAddress + m_mdStart, m_imporTableStart - m_mdStart);
			}
			if (m_resSize != 0)
			{
				image.CLIHeader.Resources = new DataDirectory(image.TextSection.VirtualAddress + m_resStart, m_resSize);
			}
			if (m_snsStart != 0)
			{
				image.CLIHeader.StrongNameSignature = new DataDirectory(image.TextSection.VirtualAddress + m_snsStart, m_snsSize);
			}
			if (m_debugHeaderStart != 0)
			{
				image.PEOptionalHeader.DataDirectories.Debug = new DataDirectory(image.TextSection.VirtualAddress + m_debugHeaderStart, 28u);
			}
		}

		public override void TerminateMetadataRoot(MetadataRoot root)
		{
			m_mdSize = (uint)(m_binaryWriter.BaseStream.Position - m_mdStart);
			m_imporTableStart = (uint)m_binaryWriter.BaseStream.Position;
			m_binaryWriter.Write(new byte[96]);
			m_imgWriter.Initialize();
			PatchHeader();
			root.GetImage().Accept(m_imgWriter);
		}
	}
}
