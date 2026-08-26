using Mono.Cecil;

namespace Unity.CecilTools.Extensions
{
	public static class TypeReferenceExtensions
	{
		public static string SafeNamespace(this TypeReference type)
		{
			if (type.IsGenericInstance)
			{
				return ((GenericInstanceType)type).ElementType.SafeNamespace();
			}
			if (type.IsNested)
			{
				return type.DeclaringType.SafeNamespace();
			}
			return type.Namespace;
		}

		public static bool IsAssignableTo(this TypeReference typeRef, string typeName)
		{
			try
			{
				if (typeRef.IsGenericInstance)
				{
					return ((GenericInstanceType)typeRef).ElementType.IsAssignableTo(typeName);
				}
				if (typeRef.FullName == typeName)
				{
					return true;
				}
				return typeRef.CheckedResolve().IsSubclassOf(typeName);
			}
			catch
			{
				return false;
			}
		}

		public static bool IsEnum(this TypeReference type)
		{
			if (type.IsValueType && !type.IsPrimitive)
			{
				return type.CheckedResolve().IsEnum;
			}
			return false;
		}

		public static bool IsStruct(this TypeReference type)
		{
			if (type.IsValueType && !type.IsPrimitive && !type.IsEnum())
			{
				return !_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A(type);
			}
			return false;
		}

		internal static bool _0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_000A(TypeReference _0020)
		{
			return _0020.FullName == "System.Decimal";
		}
	}
}
