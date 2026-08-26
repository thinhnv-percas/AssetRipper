using System;
using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem;

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
		return SpecialType.UnknownType;
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
		if (other is AliasNamespaceReference aliasNamespaceReference)
		{
			return identifier == aliasNamespaceReference.identifier;
		}
		return false;
	}
}
