using System;
using System.IO;
using System.Text;

namespace DevX.Cecil.Binary
{
	internal sealed class ResourceReader
	{
		private Image m_img;

		private Section m_rsrc;

		private BinaryReader m_reader;

		public ResourceReader(Image img)
		{
			m_img = img;
		}

		public ResourceDirectoryTable Read()
		{
			m_rsrc = GetResourceSection();
			if (m_rsrc == null)
			{
				return null;
			}
			m_reader = new BinaryReader(new MemoryStream(m_rsrc.Data));
			return ReadDirectoryTable();
		}

		private Section GetResourceSection()
		{
			foreach (Section section in m_img.Sections)
			{
				if (section.Name == ".rsrc")
				{
					return section;
				}
			}
			return null;
		}

		private int GetOffset()
		{
			return (int)m_reader.BaseStream.Position;
		}

		private ResourceDirectoryTable ReadDirectoryTable()
		{
			ResourceDirectoryTable resourceDirectoryTable = new ResourceDirectoryTable(GetOffset());
			resourceDirectoryTable.Characteristics = m_reader.ReadUInt32();
			resourceDirectoryTable.TimeDateStamp = m_reader.ReadUInt32();
			resourceDirectoryTable.MajorVersion = m_reader.ReadUInt16();
			resourceDirectoryTable.MinorVersion = m_reader.ReadUInt16();
			ushort num = m_reader.ReadUInt16();
			ushort num2 = m_reader.ReadUInt16();
			for (int i = 0; i < num; i++)
			{
				resourceDirectoryTable.Entries.Add(ReadDirectoryEntry());
			}
			for (int j = 0; j < num2; j++)
			{
				resourceDirectoryTable.Entries.Add(ReadDirectoryEntry());
			}
			return resourceDirectoryTable;
		}

		private ResourceDirectoryEntry ReadDirectoryEntry()
		{
			uint num = m_reader.ReadUInt32();
			uint num2 = m_reader.ReadUInt32();
			ResourceDirectoryEntry resourceDirectoryEntry = (((int)num & int.MinValue) == 0) ? new ResourceDirectoryEntry((int)(num & int.MaxValue), GetOffset()) : new ResourceDirectoryEntry(ReadDirectoryString((int)(num & int.MaxValue)), GetOffset());
			long position = m_reader.BaseStream.Position;
			m_reader.BaseStream.Position = (num2 & int.MaxValue);
			if (((int)num2 & int.MinValue) != 0)
			{
				resourceDirectoryEntry.Child = ReadDirectoryTable();
			}
			else
			{
				resourceDirectoryEntry.Child = ReadDataEntry();
			}
			m_reader.BaseStream.Position = position;
			return resourceDirectoryEntry;
		}

		private ResourceDirectoryString ReadDirectoryString(int offset)
		{
			long position = m_reader.BaseStream.Position;
			m_reader.BaseStream.Position = offset;
			byte[] array = m_reader.ReadBytes(m_reader.ReadUInt16());
			ResourceDirectoryString result = new ResourceDirectoryString(Encoding.Unicode.GetString(array, 0, array.Length), GetOffset());
			m_reader.BaseStream.Position = position;
			return result;
		}

		private ResourceNode ReadDataEntry()
		{
			ResourceDataEntry resourceDataEntry = new ResourceDataEntry(GetOffset());
			resourceDataEntry.Data = m_reader.ReadUInt32();
			resourceDataEntry.Size = m_reader.ReadUInt32();
			resourceDataEntry.Codepage = m_reader.ReadUInt32();
			resourceDataEntry.Reserved = m_reader.ReadUInt32();
			Section sectionAtVirtualAddress = m_img.GetSectionAtVirtualAddress(resourceDataEntry.Data);
			byte[] array = new byte[resourceDataEntry.Size];
			Buffer.BlockCopy(sectionAtVirtualAddress.Data, (int)(uint)(resourceDataEntry.Data - sectionAtVirtualAddress.VirtualAddress), array, 0, (int)resourceDataEntry.Size);
			resourceDataEntry.ResourceData = array;
			return resourceDataEntry;
		}
	}
}
