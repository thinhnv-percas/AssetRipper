namespace DevX.Cecil
{
	public interface IMemberDefinition : IAnnotationProvider, ICustomAttributeProvider, IMemberReference, IMetadataTokenProvider, IReflectionVisitable
	{
		new TypeDefinition DeclaringType
		{
			get;
			set;
		}

		bool IsSpecialName
		{
			get;
			set;
		}

		bool IsRuntimeSpecialName
		{
			get;
			set;
		}
	}
}
