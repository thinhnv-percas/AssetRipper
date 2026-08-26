using System.Collections;

namespace DevX.Cecil.Binary
{
	public class ResourceDirectoryTable : ResourceNode
	{
		private ArrayList m_entries;

		public uint Characteristics;

		public uint TimeDateStamp;

		public ushort MajorVersion;

		public ushort MinorVersion;

		public IList Entries => m_entries;

		public ResourceDirectoryTable(int offset)
			: base(offset)
		{
			m_entries = new ArrayList();
		}

		public ResourceDirectoryTable()
		{
			m_entries = new ArrayList();
		}
	}
}
