using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecompTools.Decompiler.TypeSystem;

[Serializable]
public sealed class ParameterizedTypeReference : ITypeReference, ISupportsInterning
{
	private readonly ITypeReference genericType;

	private readonly ITypeReference[] typeArguments;

	public ITypeReference GenericType => genericType;

	public IReadOnlyList<ITypeReference> TypeArguments => typeArguments;

	public ParameterizedTypeReference(ITypeReference genericType, IEnumerable<ITypeReference> typeArguments)
	{
		if (genericType == null)
		{
			throw new ArgumentNullException("genericType");
		}
		if (typeArguments == null)
		{
			throw new ArgumentNullException("typeArguments");
		}
		this.genericType = genericType;
		this.typeArguments = Enumerable.ToArray<ITypeReference>(typeArguments);
		for (int i = 0; i < this.typeArguments.Length; i = checked(i + 1))
		{
			if (this.typeArguments[i] == null)
			{
				throw new ArgumentNullException("typeArguments[" + i + "]");
			}
		}
	}

	public IType Resolve(ITypeResolveContext context)
	{
		IType type = genericType.Resolve(context);
		int typeParameterCount = type.TypeParameterCount;
		if (typeParameterCount == 0)
		{
			return type;
		}
		IType[] array = new IType[typeParameterCount];
		for (int i = 0; i < array.Length; i = checked(i + 1))
		{
			if (i < typeArguments.Length)
			{
				array[i] = typeArguments[i].Resolve(context);
			}
			else
			{
				array[i] = SpecialType.UnknownType;
			}
		}
		return new ParameterizedType(type, array);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder(genericType.ToString());
		stringBuilder.Append('[');
		for (int i = 0; i < typeArguments.Length; i = checked(i + 1))
		{
			if (i > 0)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append('[');
			stringBuilder.Append(typeArguments[i].ToString());
			stringBuilder.Append(']');
		}
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		int num = genericType.GetHashCode();
		ITypeReference[] array = typeArguments;
		foreach (ITypeReference typeReference in array)
		{
			num *= 27;
			num += typeReference.GetHashCode();
		}
		return num;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		if (other is ParameterizedTypeReference parameterizedTypeReference && genericType == parameterizedTypeReference.genericType && typeArguments.Length == parameterizedTypeReference.typeArguments.Length)
		{
			for (int i = 0; i < typeArguments.Length; i = checked(i + 1))
			{
				if (typeArguments[i] != parameterizedTypeReference.typeArguments[i])
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}
}
