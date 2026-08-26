using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics
{
	public class AmbiguousMemberResolveResult : MemberResolveResult
	{
		public override bool IsError => true;

		public AmbiguousMemberResolveResult(ResolveResult targetResult, IMember member)
			: base(targetResult, member)
		{
		}
	}
}
