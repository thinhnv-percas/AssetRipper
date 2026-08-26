using System;
using System.Collections.Generic;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.TypeSystem;

[Serializable]
public sealed class MemberTypeOrNamespaceReference : TypeOrNamespaceReference, ISupportsInterning
{
	private readonly TypeOrNamespaceReference target;

	private readonly string identifier;

	private readonly IList<ITypeReference> typeArguments;

	private readonly NameLookupMode lookupMode;

	public string Identifier => identifier;

	public TypeOrNamespaceReference Target => target;

	public IList<ITypeReference> TypeArguments => typeArguments;

	public NameLookupMode LookupMode => lookupMode;

	public MemberTypeOrNamespaceReference(TypeOrNamespaceReference target, string identifier, IList<ITypeReference> typeArguments, NameLookupMode lookupMode = NameLookupMode.Type)
	{
		if (target == null)
		{
			throw new ArgumentNullException("target");
		}
		if (identifier == null)
		{
			throw new ArgumentNullException("identifier");
		}
		this.target = target;
		this.identifier = identifier;
		this.typeArguments = typeArguments ?? EmptyList<ITypeReference>.Instance;
		this.lookupMode = lookupMode;
	}

	public MemberTypeOrNamespaceReference AddSuffix(string suffix)
	{
		return new MemberTypeOrNamespaceReference(target, identifier + suffix, typeArguments, lookupMode);
	}

	public override ResolveResult Resolve(CSharpResolver resolver)
	{
		ResolveResult resolveResult = target.Resolve(resolver);
		if (resolveResult.IsError)
		{
			return resolveResult;
		}
		IReadOnlyList<IType> readOnlyList = typeArguments.Resolve(resolver.CurrentTypeResolveContext);
		return resolver.ResolveMemberAccess(resolveResult, identifier, readOnlyList, lookupMode);
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
			return target.ToString() + "." + identifier;
		}
		return target.ToString() + "." + identifier + "<" + string.Join(",", typeArguments) + ">";
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		int num = 0;
		num += 1000000007 * target.GetHashCode();
		num += 1000000033 * identifier.GetHashCode();
		num += 1000000087 * typeArguments.GetHashCode();
		return num + 1000000021 * (int)lookupMode;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		return other is MemberTypeOrNamespaceReference memberTypeOrNamespaceReference && target == memberTypeOrNamespaceReference.target && identifier == memberTypeOrNamespaceReference.identifier && typeArguments == memberTypeOrNamespaceReference.typeArguments && lookupMode == memberTypeOrNamespaceReference.lookupMode;
	}
}
