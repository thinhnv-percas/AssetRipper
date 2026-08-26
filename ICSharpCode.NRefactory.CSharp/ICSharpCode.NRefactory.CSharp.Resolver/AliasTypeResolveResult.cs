using ICSharpCode.NRefactory.Semantics;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public class AliasTypeResolveResult : TypeResolveResult
{
	public string Alias { get; private set; }

	public AliasTypeResolveResult(string alias, TypeResolveResult underlyingResult)
		: base(underlyingResult.Type)
	{
		Alias = alias;
	}
}
