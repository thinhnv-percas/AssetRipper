using Mon3.Collections.Generic;

namespace Mon3.Cecil;

public interface IMethodSignature : IMetadataTokenProvider
{
	bool HasThis { get; set; }

	bool ExplicitThis { get; set; }

	MethodCallingConvention CallingConvention { get; set; }

	bool HasParameters { get; }

	Collection<ParameterDefinition> Parameters { get; }

	TypeReference ReturnType { get; set; }

	MethodReturnType MethodReturnType { get; }
}
