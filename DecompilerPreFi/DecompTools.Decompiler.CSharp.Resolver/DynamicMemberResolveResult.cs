using System.Collections.Generic;
using System.Globalization;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Resolver;

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
		return string.Format(CultureInfo.InvariantCulture, "[Dynamic member '{0}']", Member);
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		return new ResolveResult[1] { Target };
	}
}
