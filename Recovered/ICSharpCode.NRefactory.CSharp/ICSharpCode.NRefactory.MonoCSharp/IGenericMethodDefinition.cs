namespace ICSharpCode.NRefactory.MonoCSharp
{
	public interface IGenericMethodDefinition : IMethodDefinition, IMemberDefinition
	{
		TypeParameterSpec[] TypeParameters
		{
			get;
		}

		int TypeParametersCount
		{
			get;
		}
	}
}
