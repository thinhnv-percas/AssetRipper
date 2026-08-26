using Mon3.Collections.Generic;

namespace Mon3.Cecil;

public interface ICustomAttribute
{
	TypeReference AttributeType { get; }

	bool HasFields { get; }

	bool HasProperties { get; }

	bool HasConstructorArguments { get; }

	Collection<CustomAttributeNamedArgument> Fields { get; }

	Collection<CustomAttributeNamedArgument> Properties { get; }

	Collection<CustomAttributeArgument> ConstructorArguments { get; }
}
