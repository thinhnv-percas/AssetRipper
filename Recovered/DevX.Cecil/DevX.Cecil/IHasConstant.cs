namespace DevX.Cecil
{
	public interface IHasConstant : IMetadataTokenProvider
	{
		bool HasConstant
		{
			get;
		}

		object Constant
		{
			get;
			set;
		}
	}
}
