using System;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

[Serializable]
public sealed class NestedTypeReference : ITypeReference, ISupportsInterning
{
	private readonly ITypeReference declaringTypeRef;

	private readonly string name;

	private readonly int additionalTypeParameterCount;

	private readonly bool? isReferenceType;

	public ITypeReference DeclaringTypeReference => declaringTypeRef;

	public string Name => name;

	public int AdditionalTypeParameterCount => additionalTypeParameterCount;

	public NestedTypeReference(ITypeReference declaringTypeRef, string name, int additionalTypeParameterCount, bool? isReferenceType = null)
	{
		if (declaringTypeRef == null)
		{
			throw new ArgumentNullException("declaringTypeRef");
		}
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		this.declaringTypeRef = declaringTypeRef;
		this.name = name;
		this.additionalTypeParameterCount = additionalTypeParameterCount;
		this.isReferenceType = isReferenceType;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		if (declaringTypeRef.Resolve(context) is ITypeDefinition { TypeParameterCount: var typeParameterCount } typeDefinition)
		{
			foreach (ITypeDefinition nestedType in typeDefinition.NestedTypes)
			{
				if (((INamedElement)nestedType).Name == name && nestedType.TypeParameterCount == checked(typeParameterCount + additionalTypeParameterCount))
				{
					return nestedType;
				}
			}
		}
		return new UnknownType(null, name, additionalTypeParameterCount);
	}

	public override string ToString()
	{
		if (additionalTypeParameterCount == 0)
		{
			return string.Concat(declaringTypeRef, "+", name);
		}
		return string.Concat(declaringTypeRef, "+", name, "`", additionalTypeParameterCount);
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return declaringTypeRef.GetHashCode() ^ name.GetHashCode() ^ additionalTypeParameterCount;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		return other is NestedTypeReference nestedTypeReference && declaringTypeRef == nestedTypeReference.declaringTypeRef && name == nestedTypeReference.name && additionalTypeParameterCount == nestedTypeReference.additionalTypeParameterCount && isReferenceType == nestedTypeReference.isReferenceType;
	}
}
