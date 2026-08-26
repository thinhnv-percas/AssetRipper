using System;
using System.Collections.Generic;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.TypeSystem;

[Serializable]
public sealed class SimpleTypeOrNamespaceReference : TypeOrNamespaceReference, ISupportsInterning
{
	private readonly string identifier;

	private readonly IList<ITypeReference> typeArguments;

	private readonly NameLookupMode lookupMode;

	public string Identifier => identifier;

	public IList<ITypeReference> TypeArguments => typeArguments;

	public NameLookupMode LookupMode => lookupMode;

	public SimpleTypeOrNamespaceReference(string identifier, IList<ITypeReference> typeArguments, NameLookupMode lookupMode = NameLookupMode.Type)
	{
		if (identifier == null)
		{
			throw new ArgumentNullException("identifier");
		}
		this.identifier = identifier;
		this.typeArguments = typeArguments ?? EmptyList<ITypeReference>.Instance;
		this.lookupMode = lookupMode;
	}

	public SimpleTypeOrNamespaceReference AddSuffix(string suffix)
	{
		return new SimpleTypeOrNamespaceReference(identifier + suffix, typeArguments, lookupMode);
	}

	public override ResolveResult Resolve(CSharpResolver resolver)
	{
		IReadOnlyList<IType> readOnlyList = typeArguments.Resolve(resolver.CurrentTypeResolveContext);
		return resolver.LookupSimpleNameOrTypeName(identifier, readOnlyList, lookupMode);
	}

	public override IType ResolveType(CSharpResolver resolver)
	{
		IType result;
		if (!(Resolve(resolver) is TypeResolveResult typeResolveResult))
		{
			IType type = new UnknownType(null, identifier, typeArguments.Count);
			result = type;
		}
		else
		{
			result = typeResolveResult.Type;
		}
		return result;
	}

	public override string ToString()
	{
		if (typeArguments.Count == 0)
		{
			return identifier;
		}
		return identifier + "<" + string.Join(",", typeArguments) + ">";
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		int num = 0;
		num += 1000000021 * identifier.GetHashCode();
		num += 1000000033 * typeArguments.GetHashCode();
		return num + 1000000087 * (int)lookupMode;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		return other is SimpleTypeOrNamespaceReference simpleTypeOrNamespaceReference && identifier == simpleTypeOrNamespaceReference.identifier && typeArguments == simpleTypeOrNamespaceReference.typeArguments && lookupMode == simpleTypeOrNamespaceReference.lookupMode;
	}
}
