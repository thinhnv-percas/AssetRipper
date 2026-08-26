using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public sealed class NestedTypeReference : ITypeReference, ISymbolReference, ISupportsInterning
{
	private readonly ITypeReference declaringTypeRef;

	private readonly string name;

	private readonly int additionalTypeParameterCount;

	public ITypeReference DeclaringTypeReference => declaringTypeRef;

	public string Name => name;

	public int AdditionalTypeParameterCount => additionalTypeParameterCount;

	public NestedTypeReference(ITypeReference declaringTypeRef, string name, int additionalTypeParameterCount)
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
	}

	public IType Resolve(ITypeResolveContext context)
	{
		if (declaringTypeRef.Resolve(context) is ITypeDefinition { TypeParameterCount: var typeParameterCount } typeDefinition)
		{
			foreach (ITypeDefinition nestedType in typeDefinition.NestedTypes)
			{
				if (((INamedElement)nestedType).Name == name && nestedType.TypeParameterCount == typeParameterCount + additionalTypeParameterCount)
				{
					return nestedType;
				}
			}
		}
		return new UnknownType(null, name, additionalTypeParameterCount);
	}

	ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
	{
		IType type = Resolve(context);
		if (type is ITypeDefinition)
		{
			return (ISymbol)type;
		}
		return null;
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
		if (other is NestedTypeReference nestedTypeReference && declaringTypeRef == nestedTypeReference.declaringTypeRef && name == nestedTypeReference.name)
		{
			return additionalTypeParameterCount == nestedTypeReference.additionalTypeParameterCount;
		}
		return false;
	}
}
