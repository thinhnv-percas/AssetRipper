using Mon2.Collections.Generic;

namespace Mon2.Cecil;

public interface ICustomAttributeProvider : IMetadataTokenProvider
{
	Collection<CustomAttribute> CustomAttributes { get; }

	bool HasCustomAttributes { get; }
}
