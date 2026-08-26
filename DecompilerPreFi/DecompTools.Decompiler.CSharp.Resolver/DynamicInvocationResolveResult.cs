using System.Collections.Generic;
using System.Globalization;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Resolver;

public class DynamicInvocationResolveResult : ResolveResult
{
	public readonly ResolveResult Target;

	public readonly DynamicInvocationType InvocationType;

	public readonly IList<ResolveResult> Arguments;

	public readonly IList<ResolveResult> InitializerStatements;

	public DynamicInvocationResolveResult(ResolveResult target, DynamicInvocationType invocationType, IList<ResolveResult> arguments, IList<ResolveResult> initializerStatements = null)
		: base(SpecialType.Dynamic)
	{
		Target = target;
		InvocationType = invocationType;
		Arguments = arguments ?? EmptyList<ResolveResult>.Instance;
		InitializerStatements = initializerStatements ?? EmptyList<ResolveResult>.Instance;
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[Dynamic invocation ]");
	}
}
