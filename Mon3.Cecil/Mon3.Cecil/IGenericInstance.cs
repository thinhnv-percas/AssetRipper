using Mon3.Collections.Generic;

namespace Mon3.Cecil;

public interface IGenericInstance : IMetadataTokenProvider
{
	bool HasGenericArguments { get; }

	Collection<TypeReference> GenericArguments { get; }
}
