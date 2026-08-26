namespace DevX.Cecil
{
	public interface IGenericInstance : IMetadataTokenProvider
	{
		GenericArgumentCollection GenericArguments
		{
			get;
		}

		bool HasGenericArguments
		{
			get;
		}
	}
}
