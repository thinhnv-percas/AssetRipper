using System;

namespace DecompTools.Decompiler.TypeSystem;

public static class NullableType
{
	public static bool IsNullable(IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		return type.SkipModifiers() is ParameterizedType { TypeParameterCount: 1 } parameterizedType && parameterizedType.GenericType.IsKnownType(KnownTypeCode.NullableOfT);
	}

	public static bool IsNonNullableValueType(IType type)
	{
		return type.IsReferenceType == false && !IsNullable(type);
	}

	public static IType GetUnderlyingType(IType type)
	{
		if (type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (type.SkipModifiers() is ParameterizedType { TypeParameterCount: 1 } parameterizedType && parameterizedType.GenericType.IsKnownType(KnownTypeCode.NullableOfT))
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
		return new ParameterizedTypeReference(KnownTypeReference.Get(KnownTypeCode.NullableOfT), new ITypeReference[1] { elementType });
	}
}
