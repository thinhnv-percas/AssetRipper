using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class InvocationResolveResult : MemberResolveResult
{
	public readonly IList<ResolveResult> Arguments;

	public readonly IList<ResolveResult> InitializerStatements;

	public new IParameterizedMember Member => (IParameterizedMember)base.Member;

	public InvocationResolveResult(ResolveResult targetResult, IParameterizedMember member, IList<ResolveResult> arguments = null, IList<ResolveResult> initializerStatements = null, IType returnTypeOverride = null)
		: base(targetResult, member, returnTypeOverride)
	{
		Arguments = arguments ?? EmptyList<ResolveResult>.Instance;
		InitializerStatements = initializerStatements ?? EmptyList<ResolveResult>.Instance;
	}

	public virtual IList<ResolveResult> GetArgumentsForCall()
	{
		return Arguments;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		return base.GetChildResults().Concat(Arguments).Concat(InitializerStatements);
	}
}
