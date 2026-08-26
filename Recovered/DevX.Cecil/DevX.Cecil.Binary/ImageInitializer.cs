using DevX.Cecil.Metadata;
using System;

namespace DevX.Cecil.Binary
{
	internal sealed class ImageInitializer : BaseImageVisitor
	{
		private Image m_image;

		private MetadataInitializer m_mdinit;

		public Image Image => m_image;

		public MetadataInitializer Metadata => m_mdinit;

		public ImageInitializer(Image image)
		{
			m_image = image;
			m_image.CLIHeader = new CLIHeader();
			m_mdinit = new MetadataInitializer(this);
		}

		public override void VisitDOSHeader(DOSHeader header)
		{
			header.SetDefaultValues();
		}

		public override void VisitPEOptionalHeader(PEOptionalHeader header)
		{
			header.SetDefaultValues();
		}

		public override void VisitPEFileHeader(PEFileHeader header)
		{
			header.SetDefaultValues();
			header.TimeDateStamp = TimeDateStampFromEpoch();
		}

		public override void VisitNTSpecificFieldsHeader(PEOptionalHeader.NTSpecificFieldsHeader header)
		{
			header.SetDefaultValues();
		}

		public override void VisitStandardFieldsHeader(PEOptionalHeader.StandardFieldsHeader header)
		{
			header.SetDefaultValues();
		}

		public override void VisitDataDirectoriesHeader(PEOptionalHeader.DataDirectoriesHeader header)
		{
			header.SetDefaultValues();
		}

		public override void VisitSectionCollection(SectionCollection coll)
		{
			Section section = new Section();
			section.Name = ".text";
			section.Characteristics = (SectionCharacteristics.ContainsCode | SectionCharacteristics.MemExecute | SectionCharacteristics.MemoryRead);
			m_image.TextSection = section;
			Section section2 = new Section();
			section2.Name = ".reloc";
			section2.Characteristics = (SectionCharacteristics.ContainsInitializedData | SectionCharacteristics.MemDiscardable | SectionCharacteristics.MemoryRead);
			coll.Add(section);
			coll.Add(section2);
		}

		public override void VisitSection(Section sect)
		{
			sect.SetDefaultValues();
		}

		public override void VisitDebugHeader(DebugHeader dh)
		{
			dh?.SetDefaultValues();
		}

		public override void VisitCLIHeader(CLIHeader header)
		{
			header.SetDefaultValues();
			m_image.MetadataRoot.Accept(m_mdinit);
		}

		public override void VisitImportTable(ImportTable it)
		{
			it.ImportAddressTable = new RVA(8192u);
		}

		public override void VisitHintNameTable(HintNameTable hnt)
		{
			hnt.Hint = 0;
			hnt.RuntimeLibrary = "mscoree.dll";
			hnt.EntryPoint = 9727;
			hnt.RVA = new RVA(4202496u);
		}

		public static uint TimeDateStampFromEpoch()
		{
			return (uint)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
		}
	}
}
