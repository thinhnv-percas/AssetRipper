using Mon3.Collections.Generic;

namespace Mon3.Cecil;

public interface ISecurityDeclarationProvider : IMetadataTokenProvider
{
	bool HasSecurityDeclarations { get; }

	Collection<SecurityDeclaration> SecurityDeclarations { get; }
}
