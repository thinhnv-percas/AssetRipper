namespace DevX.Cecil
{
	public interface IRequireResolving
	{
		byte[] Blob
		{
			get;
		}

		bool Resolved
		{
			get;
		}

		bool Resolve();
	}
}
