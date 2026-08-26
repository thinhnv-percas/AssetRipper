using DevX.Cecil.Metadata;
using System;
using System.IO;
using System.Text;

namespace DevX.Cecil.Binary
{
	internal sealed class ImageReader : BaseImageVisitor
	{
		private MetadataReader m_mdReader;

		private BinaryReader m_binaryReader;

		private Image m_image;

		public MetadataReader MetadataReader => m_mdReader;

		public Image Image => m_image;

		private ImageReader(Image img, BinaryReader reader)
		{
			m_image = img;
			m_binaryReader = reader;
		}

		private static ImageReader Read(Image img, Stream stream)
		{
			ImageReader imageReader = new ImageReader(img, new BinaryReader(stream));
			img.Accept(imageReader);
			return imageReader;
		}

		public static ImageReader Read(string file)
		{
			if (file == null)
			{
				throw new ArgumentNullException("file");
			}
			FileInfo fileInfo = new FileInfo(file);
			if (!File.Exists(fileInfo.FullName))
			{
				throw new FileNotFoundException($"File '{fileInfo.FullName}' not found.", fileInfo.FullName);
			}
			FileStream fileStream = null;
			try
			{
				fileStream = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);
				return Read(new Image(fileInfo), fileStream);
				IL_0067:
				ImageReader result;
				return result;
			}
			catch (Exception inner)
			{
				fileStream?.Close();
				throw new BadImageFormatException("Invalid PE file", file, inner);
				IL_0086:
				ImageReader result;
				return result;
			}
		}

		public static ImageReader Read(byte[] image)
		{
			if (image == null)
			{
				throw new ArgumentNullException("image");
			}
			if (image.Length == 0)
			{
				throw new ArgumentException("Empty image array");
			}
			return Read(new Image(), new MemoryStream(image));
		}

		public static ImageReader Read(Stream stream)
		{
			if (stream == null)
			{
				throw new ArgumentNullException("stream");
			}
			if (!stream.CanRead)
			{
				throw new ArgumentException("Can not read from stream");
			}
			return Read(new Image(), stream);
		}

		public BinaryReader GetReader()
		{
			return m_binaryReader;
		}

		public override void VisitImage(Image img)
		{
			m_mdReader = new MetadataReader(this);
		}

		private void SetPositionToAddress(RVA address)
		{
			m_binaryReader.BaseStream.Position = m_image.ResolveVirtualAddress(address);
		}

		public override void VisitDOSHeader(DOSHeader header)
		{
			header.Start = m_binaryReader.ReadBytes(60);
			header.Lfanew = m_binaryReader.ReadUInt32();
			header.End = m_binaryReader.ReadBytes(64);
			m_binaryReader.BaseStream.Position = header.Lfanew;
			if (m_binaryReader.ReadUInt16() != 17744 || m_binaryReader.ReadUInt16() != 0)
			{
				throw new ImageFormatException("Invalid PE File Signature");
			}
		}

		public override void VisitPEFileHeader(PEFileHeader header)
		{
			header.Machine = m_binaryReader.ReadUInt16();
			header.NumberOfSections = m_binaryReader.ReadUInt16();
			header.TimeDateStamp = m_binaryReader.ReadUInt32();
			header.PointerToSymbolTable = m_binaryReader.ReadUInt32();
			header.NumberOfSymbols = m_binaryReader.ReadUInt32();
			header.OptionalHeaderSize = m_binaryReader.ReadUInt16();
			header.Characteristics = (ImageCharacteristics)m_binaryReader.ReadUInt16();
		}

		private ulong ReadIntOrLong()
		{
			return (!m_image.PEOptionalHeader.StandardFields.IsPE64) ? m_binaryReader.ReadUInt32() : m_binaryReader.ReadUInt64();
		}

		private RVA ReadRVA()
		{
			return m_binaryReader.ReadUInt32();
		}

		private DataDirectory ReadDataDirectory()
		{
			return new DataDirectory(ReadRVA(), m_binaryReader.ReadUInt32());
		}

		public override void VisitNTSpecificFieldsHeader(PEOptionalHeader.NTSpecificFieldsHeader header)
		{
			header.ImageBase = ReadIntOrLong();
			header.SectionAlignment = m_binaryReader.ReadUInt32();
			header.FileAlignment = m_binaryReader.ReadUInt32();
			header.OSMajor = m_binaryReader.ReadUInt16();
			header.OSMinor = m_binaryReader.ReadUInt16();
			header.UserMajor = m_binaryReader.ReadUInt16();
			header.UserMinor = m_binaryReader.ReadUInt16();
			header.SubSysMajor = m_binaryReader.ReadUInt16();
			header.SubSysMinor = m_binaryReader.ReadUInt16();
			header.Reserved = m_binaryReader.ReadUInt32();
			header.ImageSize = m_binaryReader.ReadUInt32();
			header.HeaderSize = m_binaryReader.ReadUInt32();
			header.FileChecksum = m_binaryReader.ReadUInt32();
			header.SubSystem = (SubSystem)m_binaryReader.ReadUInt16();
			header.DLLFlags = m_binaryReader.ReadUInt16();
			header.StackReserveSize = ReadIntOrLong();
			header.StackCommitSize = ReadIntOrLong();
			header.HeapReserveSize = ReadIntOrLong();
			header.HeapCommitSize = ReadIntOrLong();
			header.LoaderFlags = m_binaryReader.ReadUInt32();
			header.NumberOfDataDir = m_binaryReader.ReadUInt32();
		}

		public override void VisitStandardFieldsHeader(PEOptionalHeader.StandardFieldsHeader header)
		{
			header.Magic = m_binaryReader.ReadUInt16();
			header.LMajor = m_binaryReader.ReadByte();
			header.LMinor = m_binaryReader.ReadByte();
			header.CodeSize = m_binaryReader.ReadUInt32();
			header.InitializedDataSize = m_binaryReader.ReadUInt32();
			header.UninitializedDataSize = m_binaryReader.ReadUInt32();
			header.EntryPointRVA = ReadRVA();
			header.BaseOfCode = ReadRVA();
			if (!header.IsPE64)
			{
				header.BaseOfData = ReadRVA();
			}
		}

		public override void VisitDataDirectoriesHeader(PEOptionalHeader.DataDirectoriesHeader header)
		{
			header.ExportTable = ReadDataDirectory();
			header.ImportTable = ReadDataDirectory();
			header.ResourceTable = ReadDataDirectory();
			header.ExceptionTable = ReadDataDirectory();
			header.CertificateTable = ReadDataDirectory();
			header.BaseRelocationTable = ReadDataDirectory();
			header.Debug = ReadDataDirectory();
			header.Copyright = ReadDataDirectory();
			header.GlobalPtr = ReadDataDirectory();
			header.TLSTable = ReadDataDirectory();
			header.LoadConfigTable = ReadDataDirectory();
			header.BoundImport = ReadDataDirectory();
			header.IAT = ReadDataDirectory();
			header.DelayImportDescriptor = ReadDataDirectory();
			header.CLIHeader = ReadDataDirectory();
			header.Reserved = ReadDataDirectory();
			if (header.CLIHeader != DataDirectory.Zero)
			{
				m_image.CLIHeader = new CLIHeader();
			}
			if (header.ExportTable != DataDirectory.Zero)
			{
				m_image.ExportTable = new ExportTable();
			}
		}

		public override void VisitSectionCollection(SectionCollection coll)
		{
			for (int i = 0; i < m_image.PEFileHeader.NumberOfSections; i++)
			{
				coll.Add(new Section());
			}
		}

		public override void VisitSection(Section sect)
		{
			char[] array = new char[8];
			int num = 0;
			while (num < 8)
			{
				char c = (char)m_binaryReader.ReadSByte();
				if (c == '\0')
				{
					m_binaryReader.BaseStream.Position += 8 - num - 1;
					break;
				}
				array[num++] = c;
			}
			sect.Name = ((num != 0) ? new string(array, 0, num) : string.Empty);
			if (sect.Name == ".text")
			{
				m_image.TextSection = sect;
			}
			sect.VirtualSize = m_binaryReader.ReadUInt32();
			sect.VirtualAddress = ReadRVA();
			sect.SizeOfRawData = m_binaryReader.ReadUInt32();
			sect.PointerToRawData = ReadRVA();
			sect.PointerToRelocations = ReadRVA();
			sect.PointerToLineNumbers = ReadRVA();
			sect.NumberOfRelocations = m_binaryReader.ReadUInt16();
			sect.NumberOfLineNumbers = m_binaryReader.ReadUInt16();
			sect.Characteristics = (SectionCharacteristics)m_binaryReader.ReadUInt32();
			long position = m_binaryReader.BaseStream.Position;
			m_binaryReader.BaseStream.Position = (uint)sect.PointerToRawData;
			sect.Data = m_binaryReader.ReadBytes((int)sect.SizeOfRawData);
			m_binaryReader.BaseStream.Position = position;
		}

		public override void VisitImportAddressTable(ImportAddressTable iat)
		{
			if (!(m_image.PEOptionalHeader.DataDirectories.IAT.VirtualAddress == RVA.Zero))
			{
				SetPositionToAddress(m_image.PEOptionalHeader.DataDirectories.IAT.VirtualAddress);
				iat.HintNameTableRVA = ReadRVA();
			}
		}

		public override void VisitCLIHeader(CLIHeader header)
		{
			if (m_image.PEOptionalHeader.DataDirectories.Debug != DataDirectory.Zero)
			{
				m_image.DebugHeader = new DebugHeader();
				VisitDebugHeader(m_image.DebugHeader);
			}
			SetPositionToAddress(m_image.PEOptionalHeader.DataDirectories.CLIHeader.VirtualAddress);
			header.Cb = m_binaryReader.ReadUInt32();
			header.MajorRuntimeVersion = m_binaryReader.ReadUInt16();
			header.MinorRuntimeVersion = m_binaryReader.ReadUInt16();
			header.Metadata = ReadDataDirectory();
			header.Flags = (RuntimeImage)m_binaryReader.ReadUInt32();
			header.EntryPointToken = m_binaryReader.ReadUInt32();
			header.Resources = ReadDataDirectory();
			header.StrongNameSignature = ReadDataDirectory();
			header.CodeManagerTable = ReadDataDirectory();
			header.VTableFixups = ReadDataDirectory();
			header.ExportAddressTableJumps = ReadDataDirectory();
			header.ManagedNativeHeader = ReadDataDirectory();
			if (header.StrongNameSignature != DataDirectory.Zero)
			{
				SetPositionToAddress(header.StrongNameSignature.VirtualAddress);
				header.ImageHash = m_binaryReader.ReadBytes((int)header.StrongNameSignature.Size);
			}
			else
			{
				header.ImageHash = new byte[0];
			}
			SetPositionToAddress(m_image.CLIHeader.Metadata.VirtualAddress);
			m_image.MetadataRoot.Accept(m_mdReader);
		}

		public override void VisitDebugHeader(DebugHeader header)
		{
			if (!(m_image.PEOptionalHeader.DataDirectories.Debug == DataDirectory.Zero))
			{
				long position = m_binaryReader.BaseStream.Position;
				SetPositionToAddress(m_image.PEOptionalHeader.DataDirectories.Debug.VirtualAddress);
				header.Characteristics = m_binaryReader.ReadUInt32();
				header.TimeDateStamp = m_binaryReader.ReadUInt32();
				header.MajorVersion = m_binaryReader.ReadUInt16();
				header.MinorVersion = m_binaryReader.ReadUInt16();
				header.Type = (DebugStoreType)m_binaryReader.ReadUInt32();
				header.SizeOfData = m_binaryReader.ReadUInt32();
				header.AddressOfRawData = ReadRVA();
				header.PointerToRawData = m_binaryReader.ReadUInt32();
				m_binaryReader.BaseStream.Position = header.PointerToRawData;
				header.Magic = m_binaryReader.ReadUInt32();
				header.Signature = new Guid(m_binaryReader.ReadBytes(16));
				header.Age = m_binaryReader.ReadUInt32();
				header.FileName = ReadZeroTerminatedString();
				m_binaryReader.BaseStream.Position = position;
			}
		}

		private string ReadZeroTerminatedString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (true)
			{
				byte b = m_binaryReader.ReadByte();
				if (b == 0)
				{
					break;
				}
				stringBuilder.Append((char)b);
			}
			return stringBuilder.ToString();
		}

		public override void VisitImportTable(ImportTable it)
		{
			if (!(m_image.PEOptionalHeader.DataDirectories.ImportTable.VirtualAddress == RVA.Zero))
			{
				SetPositionToAddress(m_image.PEOptionalHeader.DataDirectories.ImportTable.VirtualAddress);
				it.ImportLookupTable = ReadRVA();
				it.DateTimeStamp = m_binaryReader.ReadUInt32();
				it.ForwardChain = m_binaryReader.ReadUInt32();
				it.Name = ReadRVA();
				it.ImportAddressTable = ReadRVA();
			}
		}

		public override void VisitImportLookupTable(ImportLookupTable ilt)
		{
			if (!(m_image.ImportTable.ImportLookupTable == RVA.Zero))
			{
				SetPositionToAddress(m_image.ImportTable.ImportLookupTable);
				ilt.HintNameRVA = ReadRVA();
			}
		}

		public override void VisitHintNameTable(HintNameTable hnt)
		{
			if (!(m_image.ImportAddressTable.HintNameTableRVA == RVA.Zero) && ((int)(uint)m_image.ImportAddressTable.HintNameTableRVA & int.MinValue) == 0)
			{
				SetPositionToAddress(m_image.ImportAddressTable.HintNameTableRVA);
				hnt.Hint = m_binaryReader.ReadUInt16();
				byte[] array = m_binaryReader.ReadBytes(11);
				hnt.RuntimeMain = Encoding.ASCII.GetString(array, 0, array.Length);
				SetPositionToAddress(m_image.ImportTable.Name);
				array = m_binaryReader.ReadBytes(11);
				hnt.RuntimeLibrary = Encoding.ASCII.GetString(array, 0, array.Length);
				SetPositionToAddress(m_image.PEOptionalHeader.StandardFields.EntryPointRVA);
				hnt.EntryPoint = m_binaryReader.ReadUInt16();
				hnt.RVA = ReadRVA();
			}
		}

		public override void VisitExportTable(ExportTable et)
		{
			SetPositionToAddress(m_image.PEOptionalHeader.DataDirectories.ExportTable.VirtualAddress);
			et.Characteristics = m_binaryReader.ReadUInt32();
			et.TimeDateStamp = m_binaryReader.ReadUInt32();
			et.MajorVersion = m_binaryReader.ReadUInt16();
			et.MinorVersion = m_binaryReader.ReadUInt16();
			m_binaryReader.ReadUInt32();
			et.Base = m_binaryReader.ReadUInt32();
			et.NumberOfFunctions = m_binaryReader.ReadUInt32();
			et.NumberOfNames = m_binaryReader.ReadUInt32();
			et.AddressOfFunctions = m_binaryReader.ReadUInt32();
			et.AddressOfNames = m_binaryReader.ReadUInt32();
			et.AddressOfNameOrdinals = m_binaryReader.ReadUInt32();
			et.AddressesOfFunctions = ReadArrayOfRVA(et.AddressOfFunctions, et.NumberOfFunctions);
			et.AddressesOfNames = ReadArrayOfRVA(et.AddressOfNames, et.NumberOfNames);
			et.NameOrdinals = ReadArrayOfUInt16(et.AddressOfNameOrdinals, et.NumberOfNames);
			et.Names = new string[et.NumberOfFunctions];
			for (int i = 0; i < et.NumberOfFunctions; i++)
			{
				if (!(et.AddressesOfFunctions[i] == 0u))
				{
					et.Names[i] = ReadFunctionName(et, i);
				}
			}
		}

		private string ReadFunctionName(ExportTable et, int index)
		{
			for (int i = 0; i < et.NumberOfNames; i++)
			{
				if (et.NameOrdinals[i] == index)
				{
					SetPositionToAddress(et.AddressesOfNames[i]);
					return ReadZeroTerminatedString();
				}
			}
			return string.Empty;
		}

		private ushort[] ReadArrayOfUInt16(RVA position, uint length)
		{
			if (position == RVA.Zero)
			{
				return new ushort[0];
			}
			SetPositionToAddress(position);
			ushort[] array = new ushort[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = m_binaryReader.ReadUInt16();
			}
			return array;
		}

		private RVA[] ReadArrayOfRVA(RVA position, uint length)
		{
			if (position == RVA.Zero)
			{
				return new RVA[0];
			}
			SetPositionToAddress(position);
			RVA[] array = new RVA[length];
			for (int i = 0; i < length; i++)
			{
				array[i] = m_binaryReader.ReadUInt32();
			}
			return array;
		}

		public override void TerminateImage(Image img)
		{
			m_binaryReader.Close();
			try
			{
				ResourceReader resourceReader = new ResourceReader(img);
				img.ResourceDirectoryRoot = resourceReader.Read();
			}
			catch
			{
				img.ResourceDirectoryRoot = null;
			}
		}
	}
}
