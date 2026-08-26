using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class ArrayCreateResolveResult : ResolveResult
{
	public readonly IList<ResolveResult> SizeArguments;

	public readonly IList<ResolveResult> InitializerElements;

	public ArrayCreateResolveResult(IType arrayType, IList<ResolveResult> sizeArguments, IList<ResolveResult> initializerElements)
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
			return SizeArguments.Concat(InitializerElements);
		}
		return SizeArguments;
	}
}
