namespace DevX.Cecil
{
	public interface IMethodSignature
	{
		bool HasParameters
		{
			get;
		}

		bool HasThis
		{
			get;
			set;
		}

		bool ExplicitThis
		{
			get;
			set;
		}

		MethodCallingConvention CallingConvention
		{
			get;
			set;
		}

		ParameterDefinitionCollection Parameters
		{
			get;
		}

		MethodReturnType ReturnType
		{
			get;
		}

		int GetSentinel();
	}
}
