namespace DevX.Cecil
{
	public interface IGenericParameterProvider : IMetadataTokenProvider
	{
		GenericParameterCollection GenericParameters
		{
			get;
		}

		bool HasGenericParameters
		{
			get;
		}
	}
}
