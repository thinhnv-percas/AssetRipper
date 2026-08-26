namespace DevX.Cecil.Binary
{
	public abstract class BaseImageVisitor : IBinaryVisitor
	{
		public virtual void VisitImage(Image img)
		{
		}

		public virtual void VisitDOSHeader(DOSHeader header)
		{
		}

		public virtual void VisitPEFileHeader(PEFileHeader header)
		{
		}

		public virtual void VisitPEOptionalHeader(PEOptionalHeader header)
		{
		}

		public virtual void VisitStandardFieldsHeader(PEOptionalHeader.StandardFieldsHeader header)
		{
		}

		public virtual void VisitNTSpecificFieldsHeader(PEOptionalHeader.NTSpecificFieldsHeader header)
		{
		}

		public virtual void VisitDataDirectoriesHeader(PEOptionalHeader.DataDirectoriesHeader header)
		{
		}

		public virtual void VisitSectionCollection(SectionCollection coll)
		{
		}

		public virtual void VisitSection(Section section)
		{
		}

		public virtual void VisitImportAddressTable(ImportAddressTable iat)
		{
		}

		public virtual void VisitDebugHeader(DebugHeader dh)
		{
		}

		public virtual void VisitCLIHeader(CLIHeader header)
		{
		}

		public virtual void VisitImportTable(ImportTable it)
		{
		}

		public virtual void VisitImportLookupTable(ImportLookupTable ilt)
		{
		}

		public virtual void VisitHintNameTable(HintNameTable hnt)
		{
		}

		public virtual void VisitExportTable(ExportTable et)
		{
		}

		public virtual void TerminateImage(Image img)
		{
		}
	}
}
