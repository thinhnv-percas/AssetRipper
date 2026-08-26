namespace DevX.Cecil.Binary
{
	public interface IBinaryVisitor
	{
		void VisitImage(Image img);

		void VisitDOSHeader(DOSHeader header);

		void VisitPEFileHeader(PEFileHeader header);

		void VisitPEOptionalHeader(PEOptionalHeader header);

		void VisitStandardFieldsHeader(PEOptionalHeader.StandardFieldsHeader header);

		void VisitNTSpecificFieldsHeader(PEOptionalHeader.NTSpecificFieldsHeader header);

		void VisitDataDirectoriesHeader(PEOptionalHeader.DataDirectoriesHeader header);

		void VisitSectionCollection(SectionCollection coll);

		void VisitSection(Section section);

		void VisitImportAddressTable(ImportAddressTable iat);

		void VisitDebugHeader(DebugHeader dh);

		void VisitCLIHeader(CLIHeader header);

		void VisitImportTable(ImportTable it);

		void VisitImportLookupTable(ImportLookupTable ilt);

		void VisitHintNameTable(HintNameTable hnt);

		void VisitExportTable(ExportTable et);

		void TerminateImage(Image img);
	}
}
