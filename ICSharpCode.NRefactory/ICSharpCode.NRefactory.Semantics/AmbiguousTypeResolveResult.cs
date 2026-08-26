using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class AmbiguousTypeResolveResult : TypeResolveResult
{
	public override bool IsError => true;

	public AmbiguousTypeResolveResult(IType type)
		: base(type)
	{
	}
}
