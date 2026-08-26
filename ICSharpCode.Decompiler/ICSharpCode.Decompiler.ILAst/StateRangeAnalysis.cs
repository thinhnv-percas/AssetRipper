using System.Collections.Generic;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal abstract class StateRangeAnalysis
{
	protected readonly StateRangeAnalysisMode mode;

	protected readonly FieldDef stateField;

	internal readonly DefaultDictionary<ILNode, StateRange> ranges;

	protected readonly SymbolicEvaluationContext evalContext;

	public List<ILVariable> StateVariables => evalContext.StateVariables;

	protected StateRangeAnalysis(ILNode entryPoint, StateRangeAnalysisMode mode, FieldDef stateField, ILVariable cachedStateVar)
	{
		this.mode = mode;
		this.stateField = stateField;
		ranges = new DefaultDictionary<ILNode, StateRange>((ILNode n) => new StateRange());
		ranges[entryPoint] = new StateRange(int.MinValue, int.MaxValue);
		evalContext = new SymbolicEvaluationContext(stateField);
		if (cachedStateVar != null)
		{
			evalContext.AddStateVariable(cachedStateVar);
		}
	}

	protected virtual int? AssignStateRanges(List<ILNode> body, int i, ILExpression expr, StateRange nodeRange)
	{
		ILCode code = expr.Code;
		if (code <= ILCode.Br)
		{
			if (code == ILCode.Nop)
			{
				goto IL_0373;
			}
			if (code == ILCode.Ret)
			{
				goto IL_03e7;
			}
			if (code == ILCode.Br)
			{
				goto IL_0106;
			}
		}
		else if (code <= ILCode.Switch)
		{
			if (code == ILCode.Brtrue)
			{
				SymbolicValue symbolicValue = evalContext.Eval(expr.Arguments[0]).AsBool();
				if (symbolicValue.Type == SymbolicValueType.StateEquals)
				{
					ranges[(ILLabel)expr.Operand].UnionWith(nodeRange, symbolicValue.Constant, symbolicValue.Constant);
					StateRange stateRange = ranges[body[i + 1]];
					stateRange.UnionWith(nodeRange, int.MinValue, symbolicValue.Constant - 1);
					stateRange.UnionWith(nodeRange, symbolicValue.Constant + 1, int.MaxValue);
				}
				else if (symbolicValue.Type == SymbolicValueType.StateInEquals)
				{
					ranges[body[i + 1]].UnionWith(nodeRange, symbolicValue.Constant, symbolicValue.Constant);
					StateRange stateRange2 = ranges[(ILLabel)expr.Operand];
					stateRange2.UnionWith(nodeRange, int.MinValue, symbolicValue.Constant - 1);
					stateRange2.UnionWith(nodeRange, symbolicValue.Constant + 1, int.MaxValue);
				}
				else if (symbolicValue.Type == SymbolicValueType.StateIsInRange)
				{
					ranges[(ILLabel)expr.Operand].UnionWith(nodeRange, symbolicValue.Constant, symbolicValue.Constant2);
					StateRange stateRange = ranges[body[i + 1]];
					if (symbolicValue.Constant != int.MinValue)
					{
						stateRange.UnionWith(nodeRange, int.MinValue, symbolicValue.Constant - 1);
					}
					if (symbolicValue.Constant2 != int.MaxValue)
					{
						stateRange.UnionWith(nodeRange, symbolicValue.Constant2 + 1, int.MaxValue);
					}
				}
				else
				{
					if (symbolicValue.Type != SymbolicValueType.StateIsNotInRange)
					{
						goto IL_03d1;
					}
					if (symbolicValue.Constant != int.MinValue)
					{
						ranges[(ILLabel)expr.Operand].UnionWith(nodeRange, int.MinValue, symbolicValue.Constant - 1);
					}
					if (symbolicValue.Constant2 != int.MaxValue)
					{
						ranges[(ILLabel)expr.Operand].UnionWith(nodeRange, symbolicValue.Constant2 + 1, int.MaxValue);
					}
					StateRange stateRange = ranges[body[i + 1]];
					stateRange.UnionWith(nodeRange, symbolicValue.Constant, symbolicValue.Constant2);
				}
				goto IL_03e7;
			}
			if (code == ILCode.Switch)
			{
				SymbolicValue symbolicValue = evalContext.Eval(expr.Arguments[0]);
				if (symbolicValue.Type == SymbolicValueType.State)
				{
					ILLabel[] array = (ILLabel[])expr.Operand;
					for (int j = 0; j < array.Length; j++)
					{
						int num = j - symbolicValue.Constant;
						ranges[array[j]].UnionWith(nodeRange, num, num);
					}
					StateRange stateRange = ranges[body[i + 1]];
					stateRange.UnionWith(nodeRange, int.MinValue, -1 - symbolicValue.Constant);
					stateRange.UnionWith(nodeRange, array.Length - symbolicValue.Constant, int.MaxValue);
					goto IL_03e7;
				}
			}
		}
		else
		{
			if (code == ILCode.Leave)
			{
				goto IL_0106;
			}
			if (code == ILCode.Stloc)
			{
				SymbolicValue symbolicValue = evalContext.Eval(expr.Arguments[0]);
				if (symbolicValue.Type == SymbolicValueType.State && symbolicValue.Constant == 0)
				{
					evalContext.AddStateVariable((ILVariable)expr.Operand);
					goto IL_0373;
				}
			}
		}
		goto IL_03d1;
		IL_03e7:
		return null;
		IL_03d1:
		if (mode == StateRangeAnalysisMode.IteratorDispose)
		{
			throw new SymbolicAnalysisFailedException();
		}
		return i;
		IL_0106:
		ranges[(ILLabel)expr.Operand].UnionWith(nodeRange);
		goto IL_03e7;
		IL_0373:
		ranges[body[i + 1]].UnionWith(nodeRange);
		goto IL_03e7;
	}

	protected virtual int? AssignStateRanges(List<ILNode> body, int i, StateRange nodeRange, ILLabel label)
	{
		ranges[body[i + 1]].UnionWith(nodeRange);
		return null;
	}

	protected virtual int? AssignStateRanges(List<ILNode> body, int i, StateRange nodeRange, ILTryCatchBlock tryFinally)
	{
		if (mode == StateRangeAnalysisMode.IteratorDispose)
		{
			if (tryFinally.CatchBlocks.Count != 0 || tryFinally.FaultBlock != null || tryFinally.FinallyBlock == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
			ranges[tryFinally.TryBlock].UnionWith(nodeRange);
			if (tryFinally.TryBlock.Body.Count != 0)
			{
				ranges[tryFinally.TryBlock.Body[0]].UnionWith(nodeRange);
				AssignStateRanges(tryFinally.TryBlock.Body, tryFinally.TryBlock.Body.Count);
			}
			return null;
		}
		if (mode == StateRangeAnalysisMode.AsyncMoveNext)
		{
			return i;
		}
		throw new SymbolicAnalysisFailedException();
	}

	public int AssignStateRanges(List<ILNode> body, int bodyEnd)
	{
		return AssignStateRanges(body, 0, bodyEnd);
	}

	public int AssignStateRanges(List<ILNode> body, int bodyStart, int bodyEnd)
	{
		if (bodyEnd == 0)
		{
			return 0;
		}
		for (int i = bodyStart; i < bodyEnd; i++)
		{
			StateRange stateRange = ranges[body[i]];
			stateRange.Simplify();
			int? num;
			if (body[i] is ILLabel label)
			{
				num = AssignStateRanges(body, i, stateRange, label);
				if (num.HasValue)
				{
					return num.Value;
				}
				continue;
			}
			if (body[i] is ILTryCatchBlock tryFinally)
			{
				num = AssignStateRanges(body, i, stateRange, tryFinally);
				if (num.HasValue)
				{
					return num.Value;
				}
				continue;
			}
			if (!(body[i] is ILExpression expr))
			{
				throw new SymbolicAnalysisFailedException();
			}
			num = AssignStateRanges(body, i, expr, stateRange);
			if (num.HasValue)
			{
				return num.Value;
			}
		}
		return bodyEnd;
	}

	public void EnsureLabelAtPos(List<ILNode> body, ref int pos, ref int bodyLength)
	{
		if (pos >= body.Count)
		{
			pos = body.Count - 1;
		}
		if (pos > 0 && body[pos - 1] is ILLabel)
		{
			pos--;
		}
		else if (!(body[pos] is ILLabel))
		{
			ILLabel iLLabel = new ILLabel();
			iLLabel.Name = "YieldReturnEntryPoint";
			ILExpression iLExpression = ((pos == 1 && body.Count == 1) ? (body[0] as ILExpression) : null);
			if (iLExpression != null && iLExpression.Code == ILCode.Leave && iLExpression.Operand is ILLabel)
			{
				ranges[iLLabel] = ranges[(ILLabel)iLExpression.Operand];
				pos = 0;
			}
			else
			{
				ranges[iLLabel] = ranges[body[pos]];
			}
			body.Insert(pos, iLLabel);
			bodyLength++;
		}
	}

	public LabelRangeMapping CreateLabelRangeMapping(List<ILNode> body, int pos, int bodyLength)
	{
		LabelRangeMapping result = new LabelRangeMapping();
		CreateLabelRangeMapping(body, pos, bodyLength, result, onlyInitialLabels: false);
		return result;
	}

	private void CreateLabelRangeMapping(List<ILNode> body, int pos, int bodyLength, LabelRangeMapping result, bool onlyInitialLabels)
	{
		for (int i = pos; i < bodyLength; i++)
		{
			if (body[i] is ILLabel key)
			{
				result.Add(new KeyValuePair<ILLabel, StateRange>(key, ranges[key]));
			}
			else if (body[i] is ILTryCatchBlock iLTryCatchBlock)
			{
				CreateLabelRangeMapping(iLTryCatchBlock.TryBlock.Body, 0, iLTryCatchBlock.TryBlock.Body.Count, result, onlyInitialLabels: true);
			}
			else if (onlyInitialLabels)
			{
				break;
			}
		}
	}
}
