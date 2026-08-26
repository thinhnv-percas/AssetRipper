using Mon2.Collections.Generic;

namespace Mon2.Cecil;

public interface IGenericInstance : IMetadataTokenProvider
{
	bool HasGenericArguments { get; }

	Collection<TypeReference> GenericArguments { get; }
}
