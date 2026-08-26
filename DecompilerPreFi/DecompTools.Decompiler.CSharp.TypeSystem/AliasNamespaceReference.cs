using System;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.TypeSystem;

[Serializable]
public sealed class AliasNamespaceReference : TypeOrNamespaceReference, ISupportsInterning
{
	private readonly string identifier;

	public string Identifier => identifier;

	public AliasNamespaceReference(string identifier)
	{
		if (identifier == null)
		{
			throw new ArgumentNullException("identifier");
		}
		this.identifier = identifier;
	}

	public override ResolveResult Resolve(CSharpResolver resolver)
	{
		return resolver.ResolveAlias(identifier);
	}

	public override IType ResolveType(CSharpResolver resolver)
	{
		return SpecialType.NoType;
	}

	public override string ToString()
	{
		return identifier + "::";
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return identifier.GetHashCode();
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		return other is AliasNamespaceReference aliasNamespaceReference && identifier == aliasNamespaceReference.identifier;
	}
}
