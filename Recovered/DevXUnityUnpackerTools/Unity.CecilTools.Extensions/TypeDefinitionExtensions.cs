using Mono.Cecil;

namespace Unity.CecilTools.Extensions
{
	public static class TypeDefinitionExtensions
	{
		public static bool IsSubclassOf(this TypeDefinition type, string baseTypeName)
		{
			TypeReference baseType = type.BaseType;
			if (baseType == null)
			{
				return false;
			}
			if (baseType.FullName == baseTypeName)
			{
				return true;
			}
			return _0020_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020._0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_00602(baseType)?.IsSubclassOf(baseTypeName) ?? false;
		}
	}
}
