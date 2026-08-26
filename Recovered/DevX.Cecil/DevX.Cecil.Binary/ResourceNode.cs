namespace DevX.Cecil.Binary
{
	public abstract class ResourceNode
	{
		public int Offset;

		internal ResourceNode(int offset)
		{
			Offset = offset;
		}

		internal ResourceNode()
		{
		}
	}
}
