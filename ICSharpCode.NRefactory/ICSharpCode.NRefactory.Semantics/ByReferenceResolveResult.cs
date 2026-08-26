using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class ByReferenceResolveResult : ResolveResult
{
	public readonly ResolveResult ElementResult;

	public bool IsIn { get; private set; }

	public bool IsOut { get; private set; }

	public bool IsRef { get; private set; }

	public IType ElementType => ((ByReferenceType)base.Type).ElementType;

	public ByReferenceResolveResult(ResolveResult elementResult, bool isIn, bool isRef, bool isOut)
		: this(elementResult.Type, isIn, isRef, isOut)
	{
		ElementResult = elementResult;
	}

	public ByReferenceResolveResult(IType elementType, bool isIn, bool isRef, bool isOut)
		: base(new ByReferenceType(elementType))
	{
		IsIn = isIn;
		IsRef = isRef;
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
