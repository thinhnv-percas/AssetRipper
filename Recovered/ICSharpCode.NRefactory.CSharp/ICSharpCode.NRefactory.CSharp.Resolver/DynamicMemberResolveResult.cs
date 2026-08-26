using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;
using System.Globalization;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public class DynamicMemberResolveResult : ResolveResult
	{
		public readonly ResolveResult Target;

		public readonly string Member;

		public DynamicMemberResolveResult(ResolveResult target, string member)
			: base(SpecialType.Dynamic)
		{
			Target = target;
			Member = member;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "[Dynamic member '{0}']", new object[1]
			{
				Member
			});
		}

		public override IEnumerable<ResolveResult> GetChildResults()
		{
			return new ResolveResult[1]
			{
				Target
			};
		}
	}
}
