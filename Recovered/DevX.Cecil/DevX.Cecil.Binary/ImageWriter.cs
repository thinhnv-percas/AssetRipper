using DevX.Cecil.Metadata;
using System.IO;
using System.Text;

namespace DevX.Cecil.Binary
{
	internal sealed class ImageWriter : BaseImageVisitor
	{
		private Image m_img;

		private AssemblyKind m_kind;

		private MetadataWriter m_mdWriter;

		private BinaryWriter m_binaryWriter;

		private Section m_textSect;

		private MemoryBinaryWriter m_textWriter;

		private Section m_relocSect;

		private MemoryBinaryWriter m_relocWriter;

		private Section m_rsrcSect;

		private MemoryBinaryWriter m_rsrcWriter;

		public ImageWriter(MetadataWriter writer, AssemblyKind kind, BinaryWriter bw)
		{
			m_mdWriter = writer;
			m_img = writer.GetMetadataRoot().GetImage();
			m_kind = kind;
			m_binaryWriter = bw;
			m_textWriter = new MemoryBinaryWriter();
			m_textWriter.BaseStream.Position = 80L;
			m_relocWriter = new MemoryBinaryWriter();
		}

		public Image GetImage()
		{
			return m_img;
		}

		public MemoryBinaryWriter GetTextWriter()
		{
			return m_textWriter;
		}

		public uint GetAligned(uint integer, uint alignWith)
		{
			return (integer + alignWith - 1) & ~(alignWith - 1);
		}

		public void Initialize()
		{
			Image img = m_img;
			ResourceWriter resourceWriter = null;
			uint sectionAlignment = img.PEOptionalHeader.NTSpecificFields.SectionAlignment;
			uint fileAlignment = img.PEOptionalHeader.NTSpecificFields.FileAlignment;
			m_textSect = img.TextSection;
			foreach (Section section3 in img.Sections)
			{
				if (section3.Name == ".reloc")
				{
					m_relocSect = section3;
				}
				else if (section3.Name == ".rsrc")
				{
					m_rsrcSect = section3;
					m_rsrcWriter = new MemoryBinaryWriter();
					resourceWriter = new ResourceWriter(img, m_rsrcSect, m_rsrcWriter);
					resourceWriter.Write();
				}
			}
			uint count = (uint)img.Sections.Count;
			img.PEFileHeader.NumberOfSections = (ushort)count;
			uint value = 12u;
			m_relocWriter.Write(0u);
			m_relocWriter.Write(value);
			m_relocWriter.Write((ushort)0);
			m_relocWriter.Write((ushort)0);
			m_textSect.VirtualSize = (uint)m_textWriter.BaseStream.Length;
			m_relocSect.VirtualSize = (uint)m_relocWriter.BaseStream.Length;
			if (m_rsrcSect != null)
			{
				m_rsrcSect.VirtualSize = (uint)m_rsrcWriter.BaseStream.Length;
			}
			uint num = 376 + 40 * count;
			uint integer = num;
			uint integer2 = sectionAlignment;
			uint num2 = 0u;
			foreach (Section section4 in img.Sections)
			{
				integer = GetAligned(integer, fileAlignment);
				integer2 = GetAligned(integer2, sectionAlignment);
				section4.PointerToRawData = new RVA(integer);
				section4.VirtualAddress = new RVA(integer2);
				section4.SizeOfRawData = GetAligned(section4.VirtualSize, fileAlignment);
				integer += section4.SizeOfRawData;
				integer2 += section4.SizeOfRawData;
				num2 += GetAligned(section4.SizeOfRawData, sectionAlignment);
			}
			if (m_textSect.VirtualAddress.Value != 8192)
			{
				throw new ImageFormatException("Wrong RVA for .text section");
			}
			resourceWriter?.Patch();
			img.PEOptionalHeader.StandardFields.CodeSize = GetAligned(m_textSect.SizeOfRawData, fileAlignment);
			img.PEOptionalHeader.StandardFields.InitializedDataSize = m_textSect.SizeOfRawData;
			if (m_rsrcSect != null)
			{
				img.PEOptionalHeader.StandardFields.InitializedDataSize += m_rsrcSect.SizeOfRawData;
			}
			img.PEOptionalHeader.StandardFields.BaseOfCode = m_textSect.VirtualAddress;
			img.PEOptionalHeader.StandardFields.BaseOfData = m_relocSect.VirtualAddress;
			num2 += num;
			img.PEOptionalHeader.NTSpecificFields.ImageSize = GetAligned(num2, sectionAlignment);
			img.PEOptionalHeader.DataDirectories.BaseRelocationTable = new DataDirectory(m_relocSect.VirtualAddress, m_relocSect.VirtualSize);
			if (m_rsrcSect != null)
			{
				img.PEOptionalHeader.DataDirectories.ResourceTable = new DataDirectory(m_rsrcSect.VirtualAddress, (uint)m_rsrcWriter.BaseStream.Length);
			}
			if (m_kind == AssemblyKind.Dll)
			{
				img.PEFileHeader.Characteristics = ImageCharacteristics.CILOnlyDll;
				img.HintNameTable.RuntimeMain = "_CorDllMain";
				img.PEOptionalHeader.NTSpecificFields.DLLFlags = 1024;
			}
			else
			{
				img.PEFileHeader.Characteristics = ImageCharacteristics.__flags;
				img.HintNameTable.RuntimeMain = "_CorExeMain";
			}
			switch (m_kind)
			{
			case AssemblyKind.Dll:
			case AssemblyKind.Console:
				img.PEOptionalHeader.NTSpecificFields.SubSystem = SubSystem.WindowsCui;
				break;
			case AssemblyKind.Windows:
				img.PEOptionalHeader.NTSpecificFields.SubSystem = SubSystem.WindowsGui;
				break;
			}
			RVA rVA = new RVA(img.TextSection.VirtualAddress + m_mdWriter.ImportTablePosition);
			img.PEOptionalHeader.DataDirectories.ImportTable = new DataDirectory(rVA, 87u);
			img.ImportTable.ImportLookupTable = new RVA((uint)rVA + 40);
			img.ImportLookupTable.HintNameRVA = (img.ImportAddressTable.HintNameTableRVA = new RVA((uint)img.ImportTable.ImportLookupTable + 20));
			img.ImportTable.Name = new RVA((uint)img.ImportLookupTable.HintNameRVA + 14);
		}

		public override void VisitDOSHeader(DOSHeader header)
		{
			m_binaryWriter.Write(header.Start);
			m_binaryWriter.Write(header.Lfanew);
			m_binaryWriter.Write(header.End);
			m_binaryWriter.Write((ushort)17744);
			m_binaryWriter.Write((ushort)0);
		}

		public override void VisitPEFileHeader(PEFileHeader header)
		{
			m_binaryWriter.Write(header.Machine);
			m_binaryWriter.Write(header.NumberOfSections);
			m_binaryWriter.Write(header.TimeDateStamp);
			m_binaryWriter.Write(header.PointerToSymbolTable);
			m_binaryWriter.Write(header.NumberOfSymbols);
			m_binaryWriter.Write(header.OptionalHeaderSize);
			m_binaryWriter.Write((ushort)header.Characteristics);
		}

		public override void VisitNTSpecificFieldsHeader(PEOptionalHeader.NTSpecificFieldsHeader header)
		{
			WriteIntOrLong(header.ImageBase);
			m_binaryWriter.Write(header.SectionAlignment);
			m_binaryWriter.Write(header.FileAlignment);
			m_binaryWriter.Write(header.OSMajor);
			m_binaryWriter.Write(header.OSMinor);
			m_binaryWriter.Write(header.UserMajor);
			m_binaryWriter.Write(header.UserMinor);
			m_binaryWriter.Write(header.SubSysMajor);
			m_binaryWriter.Write(header.SubSysMinor);
			m_binaryWriter.Write(header.Reserved);
			m_binaryWriter.Write(header.ImageSize);
			m_binaryWriter.Write(header.HeaderSize);
			m_binaryWriter.Write(header.FileChecksum);
			m_binaryWriter.Write((ushort)header.SubSystem);
			m_binaryWriter.Write(header.DLLFlags);
			WriteIntOrLong(header.StackReserveSize);
			WriteIntOrLong(header.StackCommitSize);
			WriteIntOrLong(header.HeapReserveSize);
			WriteIntOrLong(header.HeapCommitSize);
			m_binaryWriter.Write(header.LoaderFlags);
			m_binaryWriter.Write(header.NumberOfDataDir);
		}

		public override void VisitStandardFieldsHeader(PEOptionalHeader.StandardFieldsHeader header)
		{
			m_binaryWriter.Write(header.Magic);
			m_binaryWriter.Write(header.LMajor);
			m_binaryWriter.Write(header.LMinor);
			m_binaryWriter.Write(header.CodeSize);
			m_binaryWriter.Write(header.InitializedDataSize);
			m_binaryWriter.Write(header.UninitializedDataSize);
			m_binaryWriter.Write(header.EntryPointRVA.Value);
			m_binaryWriter.Write(header.BaseOfCode.Value);
			if (!header.IsPE64)
			{
				m_binaryWriter.Write(header.BaseOfData.Value);
			}
		}

		private void WriteIntOrLong(ulong value)
		{
			if (m_img.PEOptionalHeader.StandardFields.IsPE64)
			{
				m_binaryWriter.Write(value);
			}
			else
			{
				m_binaryWriter.Write((uint)value);
			}
		}

		public override void VisitDataDirectoriesHeader(PEOptionalHeader.DataDirectoriesHeader header)
		{
			m_binaryWriter.Write(header.ExportTable.VirtualAddress);
			m_binaryWriter.Write(header.ExportTable.Size);
			m_binaryWriter.Write(header.ImportTable.VirtualAddress);
			m_binaryWriter.Write(header.ImportTable.Size);
			m_binaryWriter.Write(header.ResourceTable.VirtualAddress);
			m_binaryWriter.Write(header.ResourceTable.Size);
			m_binaryWriter.Write(header.ExceptionTable.VirtualAddress);
			m_binaryWriter.Write(header.ExceptionTable.Size);
			m_binaryWriter.Write(header.CertificateTable.VirtualAddress);
			m_binaryWriter.Write(header.CertificateTable.Size);
			m_binaryWriter.Write(header.BaseRelocationTable.VirtualAddress);
			m_binaryWriter.Write(header.BaseRelocationTable.Size);
			m_binaryWriter.Write(header.Debug.VirtualAddress);
			m_binaryWriter.Write(header.Debug.Size);
			m_binaryWriter.Write(header.Copyright.VirtualAddress);
			m_binaryWriter.Write(header.Copyright.Size);
			m_binaryWriter.Write(header.GlobalPtr.VirtualAddress);
			m_binaryWriter.Write(header.GlobalPtr.Size);
			m_binaryWriter.Write(header.TLSTable.VirtualAddress);
			m_binaryWriter.Write(header.TLSTable.Size);
			m_binaryWriter.Write(header.LoadConfigTable.VirtualAddress);
			m_binaryWriter.Write(header.LoadConfigTable.Size);
			m_binaryWriter.Write(header.BoundImport.VirtualAddress);
			m_binaryWriter.Write(header.BoundImport.Size);
			m_binaryWriter.Write(header.IAT.VirtualAddress);
			m_binaryWriter.Write(header.IAT.Size);
			m_binaryWriter.Write(header.DelayImportDescriptor.VirtualAddress);
			m_binaryWriter.Write(header.DelayImportDescriptor.Size);
			m_binaryWriter.Write(header.CLIHeader.VirtualAddress);
			m_binaryWriter.Write(header.CLIHeader.Size);
			m_binaryWriter.Write(header.Reserved.VirtualAddress);
			m_binaryWriter.Write(header.Reserved.Size);
		}

		public override void VisitSection(Section sect)
		{
			m_binaryWriter.Write(Encoding.ASCII.GetBytes(sect.Name));
			int num = 8 - sect.Name.Length;
			for (int i = 0; i < num; i++)
			{
				m_binaryWriter.Write((byte)0);
			}
			m_binaryWriter.Write(sect.VirtualSize);
			m_binaryWriter.Write(sect.VirtualAddress.Value);
			m_binaryWriter.Write(sect.SizeOfRawData);
			m_binaryWriter.Write(sect.PointerToRawData.Value);
			m_binaryWriter.Write(sect.PointerToRelocations.Value);
			m_binaryWriter.Write(sect.PointerToLineNumbers.Value);
			m_binaryWriter.Write(sect.NumberOfRelocations);
			m_binaryWriter.Write(sect.NumberOfLineNumbers);
			m_binaryWriter.Write((uint)sect.Characteristics);
		}

		public override void VisitImportAddressTable(ImportAddressTable iat)
		{
			m_textWriter.BaseStream.Position = 0L;
			m_textWriter.Write(iat.HintNameTableRVA.Value);
			m_textWriter.Write(new byte[4]);
		}

		public override void VisitCLIHeader(CLIHeader header)
		{
			m_textWriter.Write(header.Cb);
			if (m_mdWriter.TargetRuntime >= TargetRuntime.NET_2_0)
			{
				m_textWriter.Write((ushort)2);
				m_textWriter.Write((ushort)5);
			}
			else
			{
				m_textWriter.Write((ushort)2);
				m_textWriter.Write((ushort)0);
			}
			m_textWriter.Write(header.Metadata.VirtualAddress);
			m_textWriter.Write(header.Metadata.Size);
			m_textWriter.Write((uint)header.Flags);
			m_textWriter.Write(header.EntryPointToken);
			m_textWriter.Write(header.Resources.VirtualAddress);
			m_textWriter.Write(header.Resources.Size);
			m_textWriter.Write(header.StrongNameSignature.VirtualAddress);
			m_textWriter.Write(header.StrongNameSignature.Size);
			m_textWriter.Write(header.CodeManagerTable.VirtualAddress);
			m_textWriter.Write(header.CodeManagerTable.Size);
			m_textWriter.Write(header.VTableFixups.VirtualAddress);
			m_textWriter.Write(header.VTableFixups.Size);
			m_textWriter.Write(header.ExportAddressTableJumps.VirtualAddress);
			m_textWriter.Write(header.ExportAddressTableJumps.Size);
			m_textWriter.Write(header.ManagedNativeHeader.VirtualAddress);
			m_textWriter.Write(header.ManagedNativeHeader.Size);
		}

		public override void VisitDebugHeader(DebugHeader header)
		{
			m_textWriter.BaseStream.Position = m_mdWriter.DebugHeaderPosition;
			uint num = 28u;
			header.AddressOfRawData = m_img.TextSection.VirtualAddress + m_mdWriter.DebugHeaderPosition + num;
			header.PointerToRawData = 512 + m_mdWriter.DebugHeaderPosition + num;
			header.SizeOfData = (uint)(24 + header.FileName.Length + 1);
			m_textWriter.Write(header.Characteristics);
			m_textWriter.Write(header.TimeDateStamp);
			m_textWriter.Write(header.MajorVersion);
			m_textWriter.Write(header.MinorVersion);
			m_textWriter.Write((uint)header.Type);
			m_textWriter.Write(header.SizeOfData);
			m_textWriter.Write(header.AddressOfRawData.Value);
			m_textWriter.Write(header.PointerToRawData);
			m_textWriter.Write(header.Magic);
			m_textWriter.Write(header.Signature.ToByteArray());
			m_textWriter.Write(header.Age);
			m_textWriter.Write(Encoding.ASCII.GetBytes(header.FileName));
			m_textWriter.Write((byte)0);
		}

		public override void VisitImportTable(ImportTable it)
		{
			m_textWriter.BaseStream.Position = m_mdWriter.ImportTablePosition;
			m_textWriter.Write(it.ImportLookupTable.Value);
			m_textWriter.Write(it.DateTimeStamp);
			m_textWriter.Write(it.ForwardChain);
			m_textWriter.Write(it.Name.Value);
			m_textWriter.Write(it.ImportAddressTable.Value);
			m_textWriter.Write(new byte[20]);
		}

		public override void VisitImportLookupTable(ImportLookupTable ilt)
		{
			m_textWriter.Write(ilt.HintNameRVA.Value);
			m_textWriter.Write(new byte[16]);
		}

		public override void VisitHintNameTable(HintNameTable hnt)
		{
			m_textWriter.Write(hnt.Hint);
			m_textWriter.Write(Encoding.ASCII.GetBytes(hnt.RuntimeMain));
			m_textWriter.Write('\0');
			m_textWriter.Write(Encoding.ASCII.GetBytes(hnt.RuntimeLibrary));
			m_textWriter.Write('\0');
			m_textWriter.Write(new byte[4]);
			RVA rVA = m_img.TextSection.VirtualAddress + (uint)m_textWriter.BaseStream.Position;
			long position = m_binaryWriter.BaseStream.Position;
			m_binaryWriter.BaseStream.Position = 168L;
			m_binaryWriter.Write(rVA.Value);
			m_binaryWriter.BaseStream.Position = position;
			uint num = (rVA.Value + 2) % 4096u;
			uint value = rVA.Value + 2 - num;
			m_relocWriter.BaseStream.Position = 0L;
			m_relocWriter.Write(value);
			m_relocWriter.BaseStream.Position = 8L;
			m_relocWriter.Write((ushort)(0x3000 | num));
			m_textWriter.Write(hnt.EntryPoint);
			m_textWriter.Write(hnt.RVA);
		}

		public override void TerminateImage(Image img)
		{
			m_binaryWriter.BaseStream.Position = 512L;
			WriteSection(m_textSect, m_textWriter);
			WriteSection(m_relocSect, m_relocWriter);
			if (m_rsrcSect != null)
			{
				WriteSection(m_rsrcSect, m_rsrcWriter);
			}
		}

		private void WriteSection(Section sect, MemoryBinaryWriter sectWriter)
		{
			sectWriter.MemoryStream.WriteTo(m_binaryWriter.BaseStream);
			m_binaryWriter.Write(new byte[sect.SizeOfRawData - sectWriter.BaseStream.Length]);
		}
	}
}
