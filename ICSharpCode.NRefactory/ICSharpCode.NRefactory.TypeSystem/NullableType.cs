using System;

namespace ICSharpCode.NRefactory.TypeSystem;

public static class NullableType
{
	public static bool IsNullable(IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type is ParameterizedType { TypeParameterCount: 1 } parameterizedType)
		{
			return parameterizedType.GetDefinition().KnownTypeCode == KnownTypeCode.NullableOfT;
		}
		return false;
	}

	public static bool IsNonNullableValueType(IType type)
	{
		if (type.IsReferenceType == false)
		{
			return !IsNullable(type);
		}
		return false;
	}

	public static IType GetUnderlyingType(IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type is ParameterizedType { TypeParameterCount: 1, FullName: "System.Nullable" } parameterizedType)
		{
			return parameterizedType.GetTypeArgument(0);
		}
		return type;
	}

	public static IType Create(ICompilation compilation, IType elementType)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (elementType == null)
		{
			throw new ArgumentNullException("elementType");
		}
		IType type = compilation.FindType(KnownTypeCode.NullableOfT);
		ITypeDefinition definition = type.GetDefinition();
		if (definition != null)
		{
			return new ParameterizedType(definition, new IType[1] { elementType });
		}
		return type;
	}

	public static ParameterizedTypeReference Create(ITypeReference elementType)
	{
		if (elementType == null)
		{
			throw new ArgumentNullException("elementType");
		}
		return new ParameterizedTypeReference(KnownTypeReference.NullableOfT, new ITypeReference[1] { elementType });
	}
}
