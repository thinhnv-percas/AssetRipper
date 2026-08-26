namespace DevX.Cecil.Binary
{
	internal sealed class CopyImageVisitor : BaseImageVisitor
	{
		private Image m_newImage;

		private Image m_originalImage;

		public CopyImageVisitor(Image originalImage)
		{
			m_originalImage = originalImage;
		}

		public override void VisitImage(Image img)
		{
			m_newImage = img;
			if (m_originalImage.DebugHeader != null)
			{
				m_newImage.AddDebugHeader();
			}
			m_newImage.CLIHeader.Flags = m_originalImage.CLIHeader.Flags;
		}

		public override void VisitDebugHeader(DebugHeader dbgHeader)
		{
			DebugHeader debugHeader = m_originalImage.DebugHeader;
			dbgHeader.Age = debugHeader.Age;
			dbgHeader.Characteristics = debugHeader.Characteristics;
			dbgHeader.FileName = debugHeader.FileName;
			dbgHeader.Signature = debugHeader.Signature;
			dbgHeader.TimeDateStamp = ImageInitializer.TimeDateStampFromEpoch();
			dbgHeader.Type = debugHeader.Type;
		}

		public override void VisitSectionCollection(SectionCollection sections)
		{
			Section section = null;
			foreach (Section section4 in m_originalImage.Sections)
			{
				if (section4.Name == ".rsrc")
				{
					section = section4;
				}
			}
			if (section != null)
			{
				Section section3 = new Section();
				section3.Characteristics = section.Characteristics;
				section3.Name = section.Name;
				sections.Add(section3);
			}
		}

		public override void TerminateImage(Image img)
		{
			if (m_originalImage.ResourceDirectoryRoot != null)
			{
				m_newImage.ResourceDirectoryRoot = CloneResourceDirectoryTable(m_originalImage.ResourceDirectoryRoot);
			}
		}

		private ResourceDirectoryTable CloneResourceDirectoryTable(ResourceDirectoryTable old)
		{
			ResourceDirectoryTable resourceDirectoryTable = new ResourceDirectoryTable();
			foreach (ResourceDirectoryEntry entry in old.Entries)
			{
				resourceDirectoryTable.Entries.Add(CloneResourceDirectoryEntry(entry));
			}
			return resourceDirectoryTable;
		}

		private ResourceDirectoryEntry CloneResourceDirectoryEntry(ResourceDirectoryEntry old)
		{
			ResourceDirectoryEntry resourceDirectoryEntry = (!old.IdentifiedByName) ? new ResourceDirectoryEntry(old.ID) : new ResourceDirectoryEntry(old.Name);
			if (old.Child is ResourceDirectoryTable)
			{
				resourceDirectoryEntry.Child = CloneResourceDirectoryTable(old.Child as ResourceDirectoryTable);
			}
			else
			{
				resourceDirectoryEntry.Child = CloneResourceDataEntry(old.Child as ResourceDataEntry);
			}
			return resourceDirectoryEntry;
		}

		private ResourceDataEntry CloneResourceDataEntry(ResourceDataEntry old)
		{
			ResourceDataEntry resourceDataEntry = new ResourceDataEntry();
			resourceDataEntry.Size = old.Size;
			resourceDataEntry.Codepage = old.Codepage;
			resourceDataEntry.ResourceData = old.ResourceData;
			return resourceDataEntry;
		}
	}
}
