using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class ArrayAccessResolveResult : ResolveResult
{
	public readonly ResolveResult Array;

	public readonly IList<ResolveResult> Indexes;

	public ArrayAccessResolveResult(IType elementType, ResolveResult array, IList<ResolveResult> indexes)
		: base(elementType)
	{
		if (array == null)
		{
			throw new ArgumentNullException("array");
		}
		if (indexes == null)
		{
			throw new ArgumentNullException("indexes");
		}
		Array = array;
		Indexes = indexes;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		return Enumerable.Concat<ResolveResult>((IEnumerable<ResolveResult>)new ResolveResult[1] { Array }, (IEnumerable<ResolveResult>)Indexes);
	}
}
