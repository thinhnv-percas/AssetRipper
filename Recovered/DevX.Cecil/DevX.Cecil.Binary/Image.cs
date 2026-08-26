using DevX.Cecil.Metadata;
using System;
using System.IO;

namespace DevX.Cecil.Binary
{
	public sealed class Image : IBinaryVisitable
	{
		private DOSHeader m_dosHeader;

		private PEFileHeader m_peFileHeader;

		private PEOptionalHeader m_peOptionalHeader;

		private SectionCollection m_sections;

		private Section m_textSection;

		private ImportAddressTable m_importAddressTable;

		private CLIHeader m_cliHeader;

		private ImportTable m_importTable;

		private ImportLookupTable m_importLookupTable;

		private HintNameTable m_hintNameTable;

		private ExportTable m_exportTable;

		private DebugHeader m_debugHeader;

		private MetadataRoot m_mdRoot;

		private ResourceDirectoryTable m_rsrcRoot;

		private FileInfo m_img;

		public DOSHeader DOSHeader => m_dosHeader;

		public PEFileHeader PEFileHeader => m_peFileHeader;

		public PEOptionalHeader PEOptionalHeader => m_peOptionalHeader;

		public SectionCollection Sections => m_sections;

		public Section TextSection
		{
			get
			{
				return m_textSection;
			}
			set
			{
				m_textSection = value;
			}
		}

		public ImportAddressTable ImportAddressTable => m_importAddressTable;

		public CLIHeader CLIHeader
		{
			get
			{
				return m_cliHeader;
			}
			set
			{
				m_cliHeader = value;
			}
		}

		public DebugHeader DebugHeader
		{
			get
			{
				return m_debugHeader;
			}
			set
			{
				m_debugHeader = value;
			}
		}

		public MetadataRoot MetadataRoot => m_mdRoot;

		public ImportTable ImportTable => m_importTable;

		public ImportLookupTable ImportLookupTable => m_importLookupTable;

		public HintNameTable HintNameTable => m_hintNameTable;

		public ExportTable ExportTable
		{
			get
			{
				return m_exportTable;
			}
			set
			{
				m_exportTable = value;
			}
		}

		internal ResourceDirectoryTable ResourceDirectoryRoot
		{
			get
			{
				return m_rsrcRoot;
			}
			set
			{
				m_rsrcRoot = value;
			}
		}

		public FileInfo FileInformation => m_img;

		internal Image()
		{
			m_dosHeader = new DOSHeader();
			m_peFileHeader = new PEFileHeader();
			m_peOptionalHeader = new PEOptionalHeader();
			m_sections = new SectionCollection();
			m_importAddressTable = new ImportAddressTable();
			m_importTable = new ImportTable();
			m_importLookupTable = new ImportLookupTable();
			m_hintNameTable = new HintNameTable();
			m_mdRoot = new MetadataRoot(this);
		}

		internal Image(FileInfo img)
			: this()
		{
			m_img = img;
		}

		public long ResolveVirtualAddress(RVA rva)
		{
			foreach (Section section in Sections)
			{
				if (rva >= section.VirtualAddress && rva < section.VirtualAddress + section.SizeOfRawData)
				{
					return (uint)(rva + section.PointerToRawData - section.VirtualAddress);
				}
			}
			throw new ArgumentOutOfRangeException("Cannot map the rva to any section");
		}

		internal Section GetSectionAtVirtualAddress(RVA rva)
		{
			foreach (Section section in Sections)
			{
				if (rva >= section.VirtualAddress && rva < section.VirtualAddress + section.SizeOfRawData)
				{
					return section;
				}
			}
			return null;
		}

		public BinaryReader GetReaderAtVirtualAddress(RVA rva)
		{
			Section sectionAtVirtualAddress = GetSectionAtVirtualAddress(rva);
			if (sectionAtVirtualAddress == null)
			{
				return null;
			}
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(sectionAtVirtualAddress.Data));
			binaryReader.BaseStream.Position = (uint)(rva - sectionAtVirtualAddress.VirtualAddress);
			return binaryReader;
		}

		public void AddDebugHeader()
		{
			m_debugHeader = new DebugHeader();
			m_debugHeader.SetDefaultValues();
		}

		internal void SetFileInfo(FileInfo file)
		{
			m_img = file;
		}

		public void Accept(IBinaryVisitor visitor)
		{
			visitor.VisitImage(this);
			m_dosHeader.Accept(visitor);
			m_peFileHeader.Accept(visitor);
			m_peOptionalHeader.Accept(visitor);
			m_sections.Accept(visitor);
			m_importAddressTable.Accept(visitor);
			AcceptIfNotNull(m_cliHeader, visitor);
			AcceptIfNotNull(m_debugHeader, visitor);
			m_importTable.Accept(visitor);
			m_importLookupTable.Accept(visitor);
			m_hintNameTable.Accept(visitor);
			AcceptIfNotNull(m_exportTable, visitor);
			visitor.TerminateImage(this);
		}

		private static void AcceptIfNotNull(IBinaryVisitable visitable, IBinaryVisitor visitor)
		{
			visitable?.Accept(visitor);
		}

		public static Image CreateImage()
		{
			Image image = new Image();
			ImageInitializer visitor = new ImageInitializer(image);
			image.Accept(visitor);
			return image;
		}

		public static Image GetImage(string file)
		{
			return ImageReader.Read(file).Image;
		}

		public static Image GetImage(byte[] image)
		{
			return ImageReader.Read(image).Image;
		}

		public static Image GetImage(Stream stream)
		{
			return ImageReader.Read(stream).Image;
		}
	}
}
