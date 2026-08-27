using Mono.Cecil;

namespace Unity.CecilTools.Extensions
{
	public static class TypeDefinitionExtensions_ExtHost
	{
	public static bool IsSubclassOf(this TypeDefinition type, string baseTypeName)
	{
		return TypeDefinitionExtensions.IsSubclassOf(type, baseTypeName);
	}
	}
}
