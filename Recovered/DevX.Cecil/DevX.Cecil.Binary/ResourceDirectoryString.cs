namespace DevX.Cecil.Binary
{
	public class ResourceDirectoryString : ResourceNode
	{
		public string String;

		public ResourceDirectoryString(string str)
		{
			String = str;
		}

		public ResourceDirectoryString(string str, int offset)
			: base(offset)
		{
			String = str;
		}
	}
}
