using Mon3.Collections.Generic;

namespace Mon3.Cecil;

public interface IGenericParameterProvider : IMetadataTokenProvider
{
	bool HasGenericParameters { get; }

	bool IsDefinition { get; }

	ModuleDefinition Module { get; }

	Collection<GenericParameter> GenericParameters { get; }

	GenericParameterType GenericParameterType { get; }
}
