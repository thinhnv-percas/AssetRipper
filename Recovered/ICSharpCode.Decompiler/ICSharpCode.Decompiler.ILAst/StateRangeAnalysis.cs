using Mono.Cecil;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.ILAst
{
	internal class StateRangeAnalysis
	{
		private readonly StateRangeAnalysisMode mode;

		private readonly FieldDefinition stateField;

		internal DefaultDictionary<ILNode, StateRange> ranges;

		private SymbolicEvaluationContext evalContext;

		internal Dictionary<MethodDefinition, StateRange> finallyMethodToStateRange;

		public StateRangeAnalysis(ILNode entryPoint, StateRangeAnalysisMode mode, FieldDefinition stateField, ILVariable cachedStateVar = null)
		{
			this.mode = mode;
			this.stateField = stateField;
			if (mode == StateRangeAnalysisMode.IteratorDispose)
			{
				finallyMethodToStateRange = new Dictionary<MethodDefinition, StateRange>();
			}
			ranges = new DefaultDictionary<ILNode, StateRange>((ILNode n) => new StateRange());
			ranges[entryPoint] = new StateRange(int.MinValue, int.MaxValue);
			evalContext = new SymbolicEvaluationContext(stateField);
			if (cachedStateVar != null)
			{
				evalContext.AddStateVariable(cachedStateVar);
			}
		}

		public int AssignStateRanges(List<ILNode> body, int bodyLength)
		{
			if (bodyLength == 0)
			{
				return 0;
			}
			for (int i = 0; i < bodyLength; i++)
			{
				StateRange stateRange = ranges[body[i]];
				stateRange.Simplify();
				if (body[i] is ILLabel)
				{
					ranges[body[i + 1]].UnionWith(stateRange);
					continue;
				}
				ILTryCatchBlock iLTryCatchBlock = body[i] as ILTryCatchBlock;
				if (iLTryCatchBlock != null)
				{
					if (mode == StateRangeAnalysisMode.IteratorDispose)
					{
						if (iLTryCatchBlock.CatchBlocks.Count != 0 || iLTryCatchBlock.FaultBlock != null || iLTryCatchBlock.FinallyBlock == null)
						{
							throw new SymbolicAnalysisFailedException();
						}
						ranges[iLTryCatchBlock.TryBlock].UnionWith(stateRange);
						if (iLTryCatchBlock.TryBlock.Body.Count != 0)
						{
							ranges[iLTryCatchBlock.TryBlock.Body[0]].UnionWith(stateRange);
							AssignStateRanges(iLTryCatchBlock.TryBlock.Body, iLTryCatchBlock.TryBlock.Body.Count);
						}
						continue;
					}
					if (mode == StateRangeAnalysisMode.AsyncMoveNext)
					{
						return i;
					}
					throw new SymbolicAnalysisFailedException();
				}
				ILExpression iLExpression = body[i] as ILExpression;
				if (iLExpression == null)
				{
					throw new SymbolicAnalysisFailedException();
				}
				ILCode code = iLExpression.Code;
				if (code <= ILCode.Br)
				{
					if (code <= ILCode.Call)
					{
						if (code == ILCode.Nop)
						{
							goto IL_038a;
						}
						if (code == ILCode.Call && mode == StateRangeAnalysisMode.IteratorDispose)
						{
							MethodDefinition methodDefinition = (iLExpression.Operand as MethodReference).ResolveWithinSameModule();
							if (methodDefinition == null || finallyMethodToStateRange.ContainsKey(methodDefinition))
							{
								throw new SymbolicAnalysisFailedException();
							}
							finallyMethodToStateRange.Add(methodDefinition, stateRange);
							continue;
						}
					}
					else
					{
						if (code == ILCode.Ret)
						{
							continue;
						}
						if (code == ILCode.Br)
						{
							goto IL_0258;
						}
					}
				}
				else if (code <= ILCode.Switch)
				{
					switch (code)
					{
					case ILCode.Switch:
					{
						SymbolicValue symbolicValue2 = evalContext.Eval(iLExpression.Arguments[0]);
						if (symbolicValue2.Type == SymbolicValueType.State)
						{
							ILLabel[] array = (ILLabel[])iLExpression.Operand;
							for (int j = 0; j < array.Length; j++)
							{
								int num = j - symbolicValue2.Constant;
								ranges[array[j]].UnionWith(stateRange, num, num);
							}
							StateRange stateRange4 = ranges[body[i + 1]];
							stateRange4.UnionWith(stateRange, int.MinValue, -1 - symbolicValue2.Constant);
							stateRange4.UnionWith(stateRange, array.Length - symbolicValue2.Constant, int.MaxValue);
							continue;
						}
						break;
					}
					case ILCode.Brtrue:
					{
						SymbolicValue symbolicValue = evalContext.Eval(iLExpression.Arguments[0]).AsBool();
						if (symbolicValue.Type == SymbolicValueType.StateEquals)
						{
							ranges[(ILLabel)iLExpression.Operand].UnionWith(stateRange, symbolicValue.Constant, symbolicValue.Constant);
							StateRange stateRange2 = ranges[body[i + 1]];
							stateRange2.UnionWith(stateRange, int.MinValue, symbolicValue.Constant - 1);
							stateRange2.UnionWith(stateRange, symbolicValue.Constant + 1, int.MaxValue);
							continue;
						}
						if (symbolicValue.Type == SymbolicValueType.StateInEquals)
						{
							ranges[body[i + 1]].UnionWith(stateRange, symbolicValue.Constant, symbolicValue.Constant);
							StateRange stateRange3 = ranges[(ILLabel)iLExpression.Operand];
							stateRange3.UnionWith(stateRange, int.MinValue, symbolicValue.Constant - 1);
							stateRange3.UnionWith(stateRange, symbolicValue.Constant + 1, int.MaxValue);
							continue;
						}
						break;
					}
					}
				}
				else
				{
					if (code == ILCode.Leave)
					{
						goto IL_0258;
					}
					if (code == ILCode.Stloc)
					{
						SymbolicValue symbolicValue3 = evalContext.Eval(iLExpression.Arguments[0]);
						if (symbolicValue3.Type == SymbolicValueType.State && symbolicValue3.Constant == 0)
						{
							evalContext.AddStateVariable((ILVariable)iLExpression.Operand);
							goto IL_038a;
						}
					}
				}
				if (mode == StateRangeAnalysisMode.IteratorDispose)
				{
					throw new SymbolicAnalysisFailedException();
				}
				return i;
				IL_038a:
				ranges[body[i + 1]].UnionWith(stateRange);
				continue;
				IL_0258:
				ranges[(ILLabel)iLExpression.Operand].UnionWith(stateRange);
			}
			return bodyLength;
		}

		public void EnsureLabelAtPos(List<ILNode> body, ref int pos, ref int bodyLength)
		{
			if (pos > 0 && body[pos - 1] is ILLabel)
			{
				pos--;
				return;
			}
			ILLabel iLLabel = new ILLabel();
			iLLabel.Name = "YieldReturnEntryPoint";
			ILExpression iLExpression = (pos == 1 && body.Count == 1) ? (body[0] as ILExpression) : null;
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
				ILLabel iLLabel = body[i] as ILLabel;
				if (iLLabel != null)
				{
					result.Add(new KeyValuePair<ILLabel, StateRange>(iLLabel, ranges[iLLabel]));
					continue;
				}
				ILTryCatchBlock iLTryCatchBlock = body[i] as ILTryCatchBlock;
				if (iLTryCatchBlock != null)
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
}
