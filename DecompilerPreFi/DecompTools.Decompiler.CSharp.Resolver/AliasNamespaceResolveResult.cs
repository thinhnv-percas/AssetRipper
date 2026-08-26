using DecompTools.Decompiler.Semantics;

namespace DecompTools.Decompiler.CSharp.Resolver;

public class AliasNamespaceResolveResult : NamespaceResolveResult
{
	public string Alias { get; private set; }

	public AliasNamespaceResolveResult(string alias, NamespaceResolveResult underlyingResult)
		: base(underlyingResult.Namespace)
	{
		Alias = alias;
	}
}
