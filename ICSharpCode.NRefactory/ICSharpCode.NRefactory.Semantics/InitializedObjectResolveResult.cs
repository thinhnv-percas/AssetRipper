using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class InitializedObjectResolveResult : ResolveResult
{
	public InitializedObjectResolveResult(IType type)
		: base(type)
	{
	}
}
