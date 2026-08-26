using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class ThisResolveResult : ResolveResult
{
	private bool causesNonVirtualInvocation;

	public bool CausesNonVirtualInvocation => causesNonVirtualInvocation;

	public ThisResolveResult(IType type, bool causesNonVirtualInvocation = false)
		: base(type)
	{
		this.causesNonVirtualInvocation = causesNonVirtualInvocation;
	}
}
