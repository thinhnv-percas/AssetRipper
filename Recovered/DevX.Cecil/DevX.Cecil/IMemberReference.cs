namespace DevX.Cecil
{
	public interface IMemberReference : IAnnotationProvider, IMetadataTokenProvider, IReflectionVisitable
	{
		string Name
		{
			get;
			set;
		}

		TypeReference DeclaringType
		{
			get;
		}
	}
}
