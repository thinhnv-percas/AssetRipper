using ICSharpCode.NRefactory.Semantics;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public class AliasNamespaceResolveResult : NamespaceResolveResult
{
	public string Alias { get; private set; }

	public AliasNamespaceResolveResult(string alias, NamespaceResolveResult underlyingResult)
		: base(underlyingResult.Namespace)
	{
		Alias = alias;
	}
}
