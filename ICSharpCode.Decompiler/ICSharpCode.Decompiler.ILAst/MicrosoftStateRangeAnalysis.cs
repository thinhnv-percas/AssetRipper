using System.Collections.Generic;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class MicrosoftStateRangeAnalysis : StateRangeAnalysis
{
	internal readonly Dictionary<MethodDef, StateRange> finallyMethodToStateRange;

	public MicrosoftStateRangeAnalysis(ILNode entryPoint, StateRangeAnalysisMode mode, FieldDef stateField, ILVariable cachedStateVar = null)
		: base(entryPoint, mode, stateField, cachedStateVar)
	{
		if (mode == StateRangeAnalysisMode.IteratorDispose)
		{
			finallyMethodToStateRange = new Dictionary<MethodDef, StateRange>();
		}
	}

	protected override int? AssignStateRanges(List<ILNode> body, int i, StateRange nodeRange, ILTryCatchBlock tryFinally)
	{
		if (mode == StateRangeAnalysisMode.IteratorMoveNext)
		{
			return i;
		}
		return base.AssignStateRanges(body, i, nodeRange, tryFinally);
	}

	protected override int? AssignStateRanges(List<ILNode> body, int i, ILExpression expr, StateRange nodeRange)
	{
		if (expr.Code == ILCode.Call && mode == StateRangeAnalysisMode.IteratorDispose)
		{
			MethodDef methodDef = (expr.Operand as IMethod).ResolveMethodWithinSameModule();
			if (methodDef == null || finallyMethodToStateRange.ContainsKey(methodDef))
			{
				throw new SymbolicAnalysisFailedException();
			}
			finallyMethodToStateRange.Add(methodDef, nodeRange);
			return null;
		}
		return base.AssignStateRanges(body, i, expr, nodeRange);
	}
}
