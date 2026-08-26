using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class ByReferenceResolveResult : ResolveResult
{
	public readonly ResolveResult ElementResult;

	public bool IsOut { get; private set; }

	public bool IsRef => !IsOut;

	public IType ElementType => ((ByReferenceType)base.Type).ElementType;

	public ByReferenceResolveResult(ResolveResult elementResult, bool isOut)
		: this(elementResult.Type, isOut)
	{
		ElementResult = elementResult;
	}

	public ByReferenceResolveResult(IType elementType, bool isOut)
		: base(new ByReferenceType(elementType))
	{
		IsOut = isOut;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		if (ElementResult != null)
		{
			return new ResolveResult[1] { ElementResult };
		}
		return Enumerable.Empty<ResolveResult>();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[{0} {1} {2}]", GetType().Name, IsOut ? "out" : "ref", ElementType);
	}
}
