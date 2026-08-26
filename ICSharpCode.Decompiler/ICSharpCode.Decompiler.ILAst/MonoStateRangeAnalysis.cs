using System.Collections.Generic;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class MonoStateRangeAnalysis : StateRangeAnalysis
{
	private readonly FieldDef disposingField;

	private readonly ILVariable disposeInFinallyVar;

	private bool seenSwitch;

	public MonoStateRangeAnalysis(ILNode entryPoint, StateRangeAnalysisMode mode, FieldDef stateField, FieldDef disposingField, ILVariable disposeInFinallyVar, ILVariable cachedStateVar = null)
		: base(entryPoint, mode, stateField, cachedStateVar)
	{
		this.disposingField = disposingField;
		this.disposeInFinallyVar = disposeInFinallyVar;
	}

	protected override int? AssignStateRanges(List<ILNode> body, int i, ILExpression expr, StateRange nodeRange)
	{
		switch (expr.Code)
		{
		case ILCode.Switch:
			seenSwitch = true;
			break;
		case ILCode.Stfld:
		{
			if (MatchStoreField(expr, out var field, out var _) && (field == disposingField || field == stateField))
			{
				ranges[body[i + 1]].UnionWith(nodeRange);
				return null;
			}
			break;
		}
		case ILCode.Brtrue:
		{
			ILExpression iLExpression = expr.Arguments[0];
			if (iLExpression.Code == ILCode.Ldfld && iLExpression.Arguments[0].MatchThis() && (iLExpression.Operand as IField).ResolveFieldWithinSameModule() == disposingField)
			{
				ranges[body[i + 1]].UnionWith(nodeRange);
				return null;
			}
			break;
		}
		case ILCode.Stloc:
			if (expr.Operand == disposeInFinallyVar && expr.Arguments[0].MatchLdcI4(0))
			{
				ranges[body[i + 1]].UnionWith(nodeRange);
				return null;
			}
			break;
		}
		return base.AssignStateRanges(body, i, expr, nodeRange);
	}

	protected override int? AssignStateRanges(List<ILNode> body, int i, StateRange nodeRange, ILTryCatchBlock tryFinally)
	{
		return i;
	}

	protected override int? AssignStateRanges(List<ILNode> body, int i, StateRange nodeRange, ILLabel label)
	{
		if (seenSwitch && mode == StateRangeAnalysisMode.IteratorMoveNext)
		{
			ranges[body[i + 1]].UnionWith(nodeRange);
			return i + 1;
		}
		return base.AssignStateRanges(body, i, nodeRange, label);
	}

	private bool MatchStoreField(ILExpression expr, out FieldDef field, out int value)
	{
		field = null;
		value = 0;
		if (!expr.Match<IField>(ILCode.Stfld, out var operand, out var arg, out var arg2))
		{
			return false;
		}
		if (!arg.MatchThis())
		{
			return false;
		}
		if (!((ILNode)arg2).Match(ILCode.Ldc_I4, out value))
		{
			return false;
		}
		field = operand.ResolveFieldWithinSameModule();
		return field != null;
	}
}
