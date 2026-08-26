using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class AmbiguousMemberResolveResult : MemberResolveResult
{
	public override bool IsError => true;

	public AmbiguousMemberResolveResult(ResolveResult targetResult, IMember member)
		: base(targetResult, member)
	{
	}
}
