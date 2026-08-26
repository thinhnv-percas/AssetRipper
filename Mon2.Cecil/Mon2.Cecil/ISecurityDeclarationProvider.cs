using Mon2.Collections.Generic;

namespace Mon2.Cecil;

public interface ISecurityDeclarationProvider : IMetadataTokenProvider
{
	bool HasSecurityDeclarations { get; }

	Collection<SecurityDeclaration> SecurityDeclarations { get; }
}
