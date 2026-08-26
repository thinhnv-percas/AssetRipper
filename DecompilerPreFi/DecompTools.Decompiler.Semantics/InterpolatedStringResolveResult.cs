using System.Collections.Generic;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class InterpolatedStringResolveResult : ResolveResult
{
	public readonly string FormatString;

	public readonly ResolveResult[] Arguments;

	public InterpolatedStringResolveResult(IType stringType, string formatString, params ResolveResult[] arguments)
		: base(stringType)
	{
		FormatString = formatString;
		Arguments = arguments;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		return Arguments;
	}
}
