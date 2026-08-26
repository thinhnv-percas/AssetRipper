using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class ArrayCreateResolveResult : ResolveResult
{
	public readonly IReadOnlyList<ResolveResult> SizeArguments;

	public readonly IReadOnlyList<ResolveResult> InitializerElements;

	public ArrayCreateResolveResult(IType arrayType, IReadOnlyList<ResolveResult> sizeArguments, IReadOnlyList<ResolveResult> initializerElements)
		: base(arrayType)
	{
		if (sizeArguments == null)
		{
			throw new ArgumentNullException("sizeArguments");
		}
		SizeArguments = sizeArguments;
		InitializerElements = initializerElements;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		if (InitializerElements != null)
		{
			return Enumerable.Concat<ResolveResult>((IEnumerable<ResolveResult>)SizeArguments, (IEnumerable<ResolveResult>)InitializerElements);
		}
		return SizeArguments;
	}
}
