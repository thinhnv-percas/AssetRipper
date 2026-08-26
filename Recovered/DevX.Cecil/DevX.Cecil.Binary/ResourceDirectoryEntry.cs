namespace DevX.Cecil.Binary
{
	public class ResourceDirectoryEntry : ResourceNode
	{
		private bool m_idByName;

		public int ID;

		public ResourceDirectoryString Name;

		public ResourceNode Child;

		public bool IdentifiedByName => m_idByName;

		public ResourceDirectoryEntry(ResourceDirectoryString name)
		{
			Name = name;
			m_idByName = true;
		}

		public ResourceDirectoryEntry(ResourceDirectoryString name, int offset)
			: base(offset)
		{
			Name = name;
			m_idByName = true;
		}

		public ResourceDirectoryEntry(int id)
		{
			ID = id;
		}

		public ResourceDirectoryEntry(int id, int offset)
			: base(offset)
		{
			ID = id;
		}
	}
}
