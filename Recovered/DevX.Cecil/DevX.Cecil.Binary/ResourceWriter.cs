using System.Collections;
using System.Text;

namespace DevX.Cecil.Binary
{
	internal sealed class ResourceWriter
	{
		private Image m_img;

		private Section m_rsrc;

		private MemoryBinaryWriter m_writer;

		private ArrayList m_dataEntries;

		private ArrayList m_stringEntries;

		private long m_pos;

		public ResourceWriter(Image img, Section rsrc, MemoryBinaryWriter writer)
		{
			m_img = img;
			m_rsrc = rsrc;
			m_writer = writer;
			m_dataEntries = new ArrayList();
			m_stringEntries = new ArrayList();
		}

		public void Write()
		{
			if (m_img.ResourceDirectoryRoot != null)
			{
				ComputeOffset(m_img.ResourceDirectoryRoot);
				WriteResourceDirectoryTable(m_img.ResourceDirectoryRoot);
			}
		}

		public void Patch()
		{
			foreach (ResourceDataEntry dataEntry in m_dataEntries)
			{
				GotoOffset(dataEntry.Offset);
				m_writer.Write((uint)dataEntry.Data + m_rsrc.VirtualAddress);
				RestoreOffset();
			}
		}

		private void ComputeOffset(ResourceDirectoryTable root)
		{
			int num = 0;
			Queue queue = new Queue();
			queue.Enqueue(root);
			while (queue.Count > 0)
			{
				ResourceDirectoryTable resourceDirectoryTable = queue.Dequeue() as ResourceDirectoryTable;
				resourceDirectoryTable.Offset = num;
				num += 16;
				foreach (ResourceDirectoryEntry entry in resourceDirectoryTable.Entries)
				{
					entry.Offset = num;
					num += 8;
					if (entry.IdentifiedByName)
					{
						m_stringEntries.Add(entry.Name);
					}
					if (entry.Child is ResourceDirectoryTable)
					{
						queue.Enqueue(entry.Child);
					}
					else
					{
						m_dataEntries.Add(entry.Child);
					}
				}
			}
			foreach (ResourceDataEntry dataEntry in m_dataEntries)
			{
				dataEntry.Offset = num;
				num += 16;
			}
			foreach (ResourceDirectoryString stringEntry in m_stringEntries)
			{
				stringEntry.Offset = num;
				byte[] bytes = Encoding.Unicode.GetBytes(stringEntry.String);
				num += 2 + bytes.Length;
				num += 3;
				num &= -4;
			}
			foreach (ResourceDataEntry dataEntry2 in m_dataEntries)
			{
				dataEntry2.Data = (uint)num;
				num += dataEntry2.ResourceData.Length;
				num += 3;
				num &= -4;
			}
			m_writer.Write(new byte[num]);
		}

		private void WriteResourceDirectoryTable(ResourceDirectoryTable rdt)
		{
			GotoOffset(rdt.Offset);
			m_writer.Write(rdt.Characteristics);
			m_writer.Write(rdt.TimeDateStamp);
			m_writer.Write(rdt.MajorVersion);
			m_writer.Write(rdt.MinorVersion);
			ResourceDirectoryEntry[] entries = GetEntries(rdt, identifiedByName: true);
			ResourceDirectoryEntry[] entries2 = GetEntries(rdt, identifiedByName: false);
			m_writer.Write((ushort)entries.Length);
			m_writer.Write((ushort)entries2.Length);
			ResourceDirectoryEntry[] array = entries;
			foreach (ResourceDirectoryEntry rde in array)
			{
				WriteResourceDirectoryEntry(rde);
			}
			ResourceDirectoryEntry[] array2 = entries2;
			foreach (ResourceDirectoryEntry rde2 in array2)
			{
				WriteResourceDirectoryEntry(rde2);
			}
			RestoreOffset();
		}

		private ResourceDirectoryEntry[] GetEntries(ResourceDirectoryTable rdt, bool identifiedByName)
		{
			ArrayList arrayList = new ArrayList();
			foreach (ResourceDirectoryEntry entry in rdt.Entries)
			{
				if (entry.IdentifiedByName == identifiedByName)
				{
					arrayList.Add(entry);
				}
			}
			return arrayList.ToArray(typeof(ResourceDirectoryEntry)) as ResourceDirectoryEntry[];
		}

		private void WriteResourceDirectoryEntry(ResourceDirectoryEntry rde)
		{
			GotoOffset(rde.Offset);
			if (rde.IdentifiedByName)
			{
				m_writer.Write((uint)(rde.Name.Offset | int.MinValue));
				WriteResourceDirectoryString(rde.Name);
			}
			else
			{
				m_writer.Write((uint)rde.ID);
			}
			if (rde.Child is ResourceDirectoryTable)
			{
				m_writer.Write((uint)(rde.Child.Offset | int.MinValue));
				WriteResourceDirectoryTable(rde.Child as ResourceDirectoryTable);
			}
			else
			{
				m_writer.Write(rde.Child.Offset);
				WriteResourceDataEntry(rde.Child as ResourceDataEntry);
			}
			RestoreOffset();
		}

		private void WriteResourceDataEntry(ResourceDataEntry rde)
		{
			GotoOffset(rde.Offset);
			m_writer.Write(0);
			m_writer.Write((uint)rde.ResourceData.Length);
			m_writer.Write(rde.Codepage);
			m_writer.Write(rde.Reserved);
			m_writer.BaseStream.Position = (uint)rde.Data;
			m_writer.Write(rde.ResourceData);
			RestoreOffset();
		}

		private void WriteResourceDirectoryString(ResourceDirectoryString name)
		{
			GotoOffset(name.Offset);
			byte[] bytes = Encoding.Unicode.GetBytes(name.String);
			m_writer.Write((ushort)bytes.Length);
			m_writer.Write(bytes);
			RestoreOffset();
		}

		private void GotoOffset(int offset)
		{
			m_pos = m_writer.BaseStream.Position;
			m_writer.BaseStream.Position = offset;
		}

		private void RestoreOffset()
		{
			m_writer.BaseStream.Position = m_pos;
		}
	}
}
