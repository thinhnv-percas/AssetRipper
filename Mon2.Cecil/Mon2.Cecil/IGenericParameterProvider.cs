using Mon2.Collections.Generic;

namespace Mon2.Cecil;

public interface IGenericParameterProvider : IMetadataTokenProvider
{
	bool HasGenericParameters { get; }

	bool IsDefinition { get; }

	ModuleDefinition Module { get; }

	Collection<GenericParameter> GenericParameters { get; }

	GenericParameterType GenericParameterType { get; }
}
