using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class TupleResolveResult : ResolveResult
{
	public ImmutableArray<ResolveResult> Elements { get; }

	public TupleResolveResult(ICompilation compilation, ImmutableArray<ResolveResult> elements, ImmutableArray<string> elementNames = default(ImmutableArray<string>), IModule valueTupleAssembly = null)
		: base(GetTupleType(compilation, elements, elementNames, valueTupleAssembly))
	{
		Elements = elements;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		return Elements;
	}

	private static IType GetTupleType(ICompilation compilation, ImmutableArray<ResolveResult> elements, ImmutableArray<string> elementNames, IModule valueTupleAssembly)
	{
		if (elements.Any((ResolveResult e) => e.Type.Kind == TypeKind.None || e.Type.Kind == TypeKind.Null))
		{
			return SpecialType.NoType;
		}
		return new TupleType(compilation, elements.Select((ResolveResult e) => e.Type).ToImmutableArray(), elementNames, valueTupleAssembly);
	}
}
