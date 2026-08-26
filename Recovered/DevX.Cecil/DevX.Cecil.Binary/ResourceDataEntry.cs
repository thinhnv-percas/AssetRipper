namespace DevX.Cecil.Binary
{
	public class ResourceDataEntry : ResourceNode
	{
		public RVA Data;

		public uint Size;

		public uint Codepage;

		public uint Reserved;

		public byte[] ResourceData;

		public ResourceDataEntry(int offset)
			: base(offset)
		{
		}

		public ResourceDataEntry()
		{
		}
	}
}
