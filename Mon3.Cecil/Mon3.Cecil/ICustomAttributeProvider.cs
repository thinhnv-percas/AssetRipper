using Mon3.Collections.Generic;

namespace Mon3.Cecil;

public interface ICustomAttributeProvider : IMetadataTokenProvider
{
	Collection<CustomAttribute> CustomAttributes { get; }

	bool HasCustomAttributes { get; }
}
