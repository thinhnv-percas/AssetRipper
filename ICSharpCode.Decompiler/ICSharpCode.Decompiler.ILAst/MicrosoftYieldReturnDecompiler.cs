using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class MicrosoftYieldReturnDecompiler : YieldReturnDecompiler
{
	private struct SetState
	{
		public readonly int NewBodyPos;

		public readonly int NewState;

		public SetState(int newBodyPos, int newState)
		{
			NewBodyPos = newBodyPos;
			NewState = newState;
		}
	}

	private string compilerName;

	private MethodDef methodMoveNext;

	private HashSet<int> vbFinalizerStates;

	private Dictionary<MethodDef, StateRange> finallyMethodToStateRange;

	private ILVariable returnVariable;

	private ILLabel returnLabel;

	private ILLabel returnFalseLabel;

	private List<KeyValuePair<ILLabel, StateRange>> labels;

	private List<ILVariable> stateVariables;

	private List<int> finallyMethodIndexes;

	private readonly Dictionary<ILLabel, StateRange> stateRanges = new Dictionary<ILLabel, StateRange>();

	private int tempLabelCounter;

	private readonly List<List<ILNode>> freeBodies = new List<List<ILNode>>();

	public override string CompilerName => compilerName;

	private MicrosoftYieldReturnDecompiler(DecompilerContext context, AutoPropertyProvider autoPropertyProvider)
		: base(context, autoPropertyProvider)
	{
	}

	public static YieldReturnDecompiler TryCreateCore(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider)
	{
		MicrosoftYieldReturnDecompiler microsoftYieldReturnDecompiler = new MicrosoftYieldReturnDecompiler(context, autoPropertyProvider);
		if (!microsoftYieldReturnDecompiler.MatchEnumeratorCreationPattern(method))
		{
			return null;
		}
		microsoftYieldReturnDecompiler.enumeratorType = microsoftYieldReturnDecompiler.enumeratorCtor.DeclaringType;
		return microsoftYieldReturnDecompiler;
	}

	private bool MatchEnumeratorCreationPattern(ILBlock method)
	{
		List<ILNode> body = method.Body;
		if (body.Count == 0)
		{
			return false;
		}
		ILExpression arg;
		if (body.Count == 1)
		{
			if (body[0].Match(ILCode.Ret, out arg))
			{
				return MatchEnumeratorCreationNewObj(arg, out enumeratorCtor);
			}
			return false;
		}
		if (!body[0].Match(ILCode.Stloc, out ILVariable operand, out arg))
		{
			return false;
		}
		if (!MatchEnumeratorCreationNewObj(arg, out enumeratorCtor))
		{
			return false;
		}
		int i = 1;
		if (!InitializeFieldToParameterMap(method, operand, ref i))
		{
			return false;
		}
		if (i < body.Count && body[i].Match(ILCode.Stloc, out ILVariable operand2, out ILExpression arg2))
		{
			if (arg2.Code != ILCode.Ldloc || arg2.Operand != operand)
			{
				return false;
			}
			i++;
		}
		else
		{
			operand2 = operand;
		}
		if (i < body.Count && body[i].Match(ILCode.Ret, out ILExpression arg3) && arg3.Code == ILCode.Ldloc && arg3.Operand == operand2)
		{
			return true;
		}
		return false;
	}

	private bool MatchEnumeratorCreationNewObj(ILExpression expr, out MethodDef ctor)
	{
		ctor = null;
		if (expr.Code != ILCode.Newobj || expr.Arguments.Count != 1)
		{
			return false;
		}
		if (expr.Arguments[0].Code != ILCode.Ldc_I4)
		{
			return false;
		}
		int num = (int)expr.Arguments[0].Operand;
		if (num != -2 && num != 0)
		{
			return false;
		}
		ctor = YieldReturnDecompiler.GetMethodDefinition(expr.Operand as IMethod);
		if (ctor == null || ctor.DeclaringType.DeclaringType != context.CurrentType)
		{
			return false;
		}
		return YieldReturnDecompiler.IsCompilerGeneratorEnumerator(ctor.DeclaringType);
	}

	protected override void AnalyzeCtor()
	{
		ILBlock iLBlock = CreateILAst(enumeratorCtor);
		foreach (ILNode item in iLBlock.Body)
		{
			if (item.Match<IField>(ILCode.Stfld, out var operand, out var arg, out var arg2) && arg.MatchThis() && ((ILNode)arg2).Match(ILCode.Ldloc, out ILVariable operand2) && operand2.IsParameter && operand2.OriginalParameter.MethodSigIndex == 0)
			{
				stateField = YieldReturnDecompiler.GetFieldDefinition(operand);
				break;
			}
		}
		if (stateField == null)
		{
			throw new SymbolicAnalysisFailedException();
		}
	}

	protected override void AnalyzeDispose()
	{
		disposeMethod = MethodUtils.GetMethod_Dispose(enumeratorType).FirstOrDefault();
		ILBlock iLBlock = CreateILAst(disposeMethod);
		methodMoveNext = MethodUtils.GetMethod_MoveNext(enumeratorType).FirstOrDefault();
		if (IsVisualBasicDispose(iLBlock, methodMoveNext))
		{
			finallyMethodToStateRange = new Dictionary<MethodDef, StateRange>();
			vbFinalizerStates = new HashSet<int>();
			{
				foreach (ILNode item in iLBlock.Body)
				{
					ILExpression node = item as ILExpression;
					if (node.Match<IField>(ILCode.Stfld, out var operand, out var arg, out var arg2) && arg.MatchThis() && ((ILNode)arg2).Match(ILCode.Ldc_I4, out int operand2) && YieldReturnDecompiler.GetFieldDefinition(operand) == stateField)
					{
						vbFinalizerStates.Add(operand2);
					}
				}
				return;
			}
		}
		MicrosoftStateRangeAnalysis microsoftStateRangeAnalysis = new MicrosoftStateRangeAnalysis(iLBlock.Body[0], StateRangeAnalysisMode.IteratorDispose, stateField);
		microsoftStateRangeAnalysis.AssignStateRanges(iLBlock.Body, iLBlock.Body.Count);
		finallyMethodToStateRange = microsoftStateRangeAnalysis.finallyMethodToStateRange;
		foreach (ILTryCatchBlock item2 in iLBlock.GetSelfAndChildrenRecursive<ILTryCatchBlock>())
		{
			StateRange value = microsoftStateRangeAnalysis.ranges[item2.TryBlock.Body[0]];
			List<ILNode> body = item2.FinallyBlock.Body;
			if (body.Count != 2)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!(body[0] is ILExpression { Code: ILCode.Call } iLExpression) || iLExpression.Arguments.Count != 1)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!iLExpression.Arguments[0].MatchThis())
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!body[1].Match(ILCode.Endfinally))
			{
				throw new SymbolicAnalysisFailedException();
			}
			MethodDef methodDefinition = YieldReturnDecompiler.GetMethodDefinition(iLExpression.Operand as IMethod);
			if (methodDefinition == null || finallyMethodToStateRange.ContainsKey(methodDefinition))
			{
				throw new SymbolicAnalysisFailedException();
			}
			finallyMethodToStateRange.Add(methodDefinition, value);
		}
	}

	private static bool IsVisualBasicDispose(ILBlock method, MethodDef moveNextMethod)
	{
		foreach (ILNode item in method.Body)
		{
			if (item.Match(ILCode.Call, out IMethod operand, out ILExpression arg) && arg.MatchThis() && YieldReturnDecompiler.GetMethodDefinition(operand) == moveNextMethod)
			{
				return true;
			}
		}
		return false;
	}

	protected override void AnalyzeMoveNext()
	{
		ILBlock iLBlock = CreateILAst(methodMoveNext);
		iteratorMoveNextMethod = methodMoveNext;
		if (methodMoveNext.DeclaringType.Name.StartsWith("VB$StateMachine_"))
		{
			compilerName = "MicrosoftVisualBasic";
		}
		else
		{
			compilerName = "MicrosoftCSharp";
		}
		if (iLBlock.Body.Count == 0)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!iLBlock.Body.Last().Match(ILCode.Ret, out ILExpression arg))
		{
			List<ILNode> body = iLBlock.Body;
			ILExpression arg2 = null;
			ILExpression iLExpression = null;
			ILExpression iLExpression2 = null;
			for (int i = 0; i < body.Count; i++)
			{
				if (body[i].Match(ILCode.Ret, out arg2))
				{
					if (iLExpression2 == null && arg2.Code == ILCode.Ldc_I4 && (int)arg2.Operand == 0)
					{
						iLExpression2 = arg2;
					}
					else if (arg2.Match(ILCode.Ldloc))
					{
						iLExpression = arg2;
						break;
					}
				}
			}
			arg = iLExpression ?? iLExpression2;
			if (arg == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}
		if (arg.Code == ILCode.Ldloc)
		{
			returnVariable = (ILVariable)arg.Operand;
			returnLabel = iLBlock.Body.ElementAtOrDefault(iLBlock.Body.Count - 2) as ILLabel;
			if (returnLabel == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}
		else
		{
			returnVariable = null;
			returnLabel = null;
			if (arg.Code != ILCode.Ldc_I4 || (int)arg.Operand != 0)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}
		List<ILNode> body2;
		int bodyLength;
		if (iLBlock.Body[0] is ILTryCatchBlock iLTryCatchBlock)
		{
			if (returnVariable == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (iLTryCatchBlock.CatchBlocks.Count != 0 || iLTryCatchBlock.FinallyBlock != null || iLTryCatchBlock.FaultBlock == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
			ILBlock faultBlock = iLTryCatchBlock.FaultBlock;
			if (faultBlock.Body.Count != 2)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!faultBlock.Body[0].Match(ILCode.Call, out IMethod operand, out ILExpression arg3))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (YieldReturnDecompiler.GetMethodDefinition(operand) != disposeMethod || !arg3.MatchThis())
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!faultBlock.Body[1].Match(ILCode.Endfinally))
			{
				throw new SymbolicAnalysisFailedException();
			}
			body2 = iLTryCatchBlock.TryBlock.Body;
			bodyLength = body2.Count;
		}
		else
		{
			body2 = iLBlock.Body;
			bodyLength = ((!(body2[body2.Count - 1] is ILExpression { Code: ILCode.Ret })) ? body2.Count : ((returnVariable != null) ? (body2.Count - 2) : (body2.Count - 1)));
		}
		if (returnVariable != null)
		{
			int num = bodyLength;
			if (body2.ElementAtOrDefault(bodyLength - 1) is ILExpression iLExpression4 && (iLExpression4.Code == ILCode.Br || iLExpression4.Code == ILCode.Leave) && iLExpression4.Operand == returnLabel)
			{
				bodyLength--;
			}
			ILExpression iLExpression5 = body2.ElementAtOrDefault(bodyLength - 1) as ILExpression;
			if ((iLExpression5 != null && iLExpression5.Code == ILCode.Stloc && iLExpression5.Operand == returnVariable) || ((ILNode)iLExpression5).Match(ILCode.Ret, out ILExpression _))
			{
				if (iLExpression5.Arguments[0].Code != ILCode.Ldc_I4 || (int)iLExpression5.Arguments[0].Operand != 0)
				{
					throw new SymbolicAnalysisFailedException();
				}
				bodyLength--;
			}
			else if (iLExpression5 == null || iLExpression5.Code != ILCode.Throw)
			{
				bodyLength = num;
			}
		}
		returnFalseLabel = body2.ElementAtOrDefault(bodyLength - 1) as ILLabel;
		if (body2.Count > 1 && body2[1].Match(ILCode.Stloc, out ILVariable operand2, out ILExpression arg5) && ((ILNode)arg5).Match(ILCode.Ldfld, out IField operand3, out ILExpression arg6) && arg6.MatchThis())
		{
			FieldDef fieldDef = operand3.ResolveFieldWithinSameModule();
			if (fieldDef?.DeclaringType == enumeratorType && fieldDef.FieldType.RemovePinnedAndModifiers().Resolve() == context.CurrentType && variableMap.TryGetParameter(fieldDef, out var parameter) && parameter.IsParameter && parameter.OriginalParameter.IsHiddenThisParameter)
			{
				cachedThisVar = operand2;
				body2.RemoveAt(1);
				bodyLength--;
			}
		}
		MicrosoftStateRangeAnalysis microsoftStateRangeAnalysis = new MicrosoftStateRangeAnalysis(body2[0], StateRangeAnalysisMode.IteratorMoveNext, stateField);
		int pos = microsoftStateRangeAnalysis.AssignStateRanges(body2, bodyLength);
		microsoftStateRangeAnalysis.EnsureLabelAtPos(body2, ref pos, ref bodyLength);
		labels = microsoftStateRangeAnalysis.CreateLabelRangeMapping(body2, pos, bodyLength);
		stateVariables = microsoftStateRangeAnalysis.StateVariables;
		ConvertBody(body2, pos, bodyLength);
	}

	private ILExpression CreateYieldReturn(ILExpression stExpr)
	{
		ILExpression iLExpression = stExpr.Arguments[1];
		if (context.CalculateILSpans)
		{
			iLExpression.ILSpans.AddRange(stExpr.ILSpans);
			iLExpression.ILSpans.AddRange(stExpr.Arguments[0].GetSelfAndChildrenRecursiveILSpans());
		}
		return new ILExpression(ILCode.YieldReturn, null, iLExpression);
	}

	private ILExpression CreateYieldBreak()
	{
		return new ILExpression(ILCode.YieldBreak, null);
	}

	private void ConvertBody(List<ILNode> body, int startPos, int bodyLength)
	{
		newBody = new List<ILNode>();
		if (startPos != bodyLength)
		{
			newBody.Add(MakeGoTo(labels, 0));
		}
		ConvertBodyCore(body, body, newBody, startPos, bodyLength);
		newBody.Add(CreateYieldBreak());
	}

	private List<ILNode> ConvertBodyCore(List<ILNode> origTopLevelBody, List<ILNode> body, List<ILNode> newBody, int startPos, int bodyLength)
	{
		int count = labels.Count;
		List<SetState> list = new List<SetState>();
		List<MethodDef> list2 = new List<MethodDef>();
		int num = -1;
		for (int i = startPos; i < bodyLength; i++)
		{
			ILExpression iLExpression = body[i] as ILExpression;
			ILVariable operand;
			int operand2;
			switch (iLExpression?.Code ?? ((ILCode)(-1)))
			{
			case ILCode.Stfld:
			{
				if (!iLExpression.Arguments[0].MatchThis())
				{
					break;
				}
				FieldDef fieldDefinition;
				if ((fieldDefinition = YieldReturnDecompiler.GetFieldDefinition(iLExpression.Operand as IField)) == stateField)
				{
					if (iLExpression.Arguments[1].Code != ILCode.Ldc_I4)
					{
						throw new SymbolicAnalysisFailedException();
					}
					num = (int)iLExpression.Arguments[1].Operand;
					list.Add(new SetState(newBody.Count, num));
				}
				else if (fieldDefinition == currentField)
				{
					newBody.Add(CreateYieldReturn(iLExpression));
				}
				else
				{
					newBody.Add(body[i]);
				}
				continue;
			}
			case ILCode.Stloc:
			{
				operand = (ILVariable)iLExpression.Operand;
				if (iLExpression.Operand == returnVariable)
				{
					if (!(body.ElementAtOrDefault(++i) is ILExpression iLExpression2) || (iLExpression2.Code != ILCode.Br && iLExpression2.Code != ILCode.Leave) || iLExpression.Arguments[0].Code != ILCode.Ldc_I4)
					{
						throw new SymbolicAnalysisFailedException();
					}
					if (iLExpression2.Operand != returnLabel)
					{
						UpdateFinallyMethodIndex(origTopLevelBody, iLExpression2, ref finallyMethodIndexes);
						newBody.Add(CreateYieldBreak());
						continue;
					}
					operand2 = (int)iLExpression.Arguments[0].Operand;
					switch (operand2)
					{
					case 0:
						newBody.Add(CreateYieldBreak());
						break;
					case 1:
						newBody.Add(MakeGoTo(labels, num));
						break;
					default:
						throw new SymbolicAnalysisFailedException();
					}
					continue;
				}
				if (((ILNode)iLExpression.Arguments[0]).Match(ILCode.Ldc_I4, out operand2) && i + 2 <= bodyLength && operand.GeneratedByDecompiler && body[i + 1].Match(ILCode.Stloc, out ILVariable operand3, out ILExpression arg) && arg.MatchLdloc(operand) && stateVariables.Contains(operand3) && body[i + 2].Match<IField>(ILCode.Stfld, out var operand4, out arg, out var arg2) && arg2.MatchLdloc(operand) && arg.MatchThis() && YieldReturnDecompiler.GetFieldDefinition(operand4) == stateField)
				{
					num = operand2;
					list.Add(new SetState(newBody.Count, num));
					i += 2;
					continue;
				}
				break;
			}
			case ILCode.Brtrue:
				if (i == 0 && vbFinalizerStates != null)
				{
					MicrosoftStateRangeAnalysis microsoftStateRangeAnalysis = new MicrosoftStateRangeAnalysis(body[i], StateRangeAnalysisMode.IteratorMoveNext, stateField, stateVariables.FirstOrDefault());
					int pos = microsoftStateRangeAnalysis.AssignStateRanges(body, i, bodyLength);
					if (pos != i)
					{
						microsoftStateRangeAnalysis.EnsureLabelAtPos(body, ref pos, ref bodyLength);
						LabelRangeMapping collection = microsoftStateRangeAnalysis.CreateLabelRangeMapping(body, i, bodyLength);
						labels.AddRange(collection);
						i = pos - 1;
						continue;
					}
				}
				if (iLExpression.Arguments[0].Code == ILCode.Cge)
				{
					ILExpression iLExpression4 = iLExpression.Arguments[0];
					if (((ILNode)iLExpression4.Arguments[0]).Match(ILCode.Ldloc, out operand) && stateVariables.Contains(operand) && iLExpression4.Arguments[1].MatchLdcI4(0))
					{
						continue;
					}
				}
				break;
			case ILCode.Switch:
			{
				ILExpression iLExpression5 = iLExpression.Arguments[0];
				if ((iLExpression5.Code != ILCode.Sub && iLExpression5.Code != ILCode.Sub_Ovf) || !((ILNode)iLExpression5.Arguments[0]).Match(ILCode.Ldloc, out operand) || !((ILNode)iLExpression5.Arguments[1]).Match(ILCode.Ldc_I4, out operand2) || !stateVariables.Contains(operand))
				{
					break;
				}
				ILLabel[] array = (ILLabel[])iLExpression.Operand;
				stateRanges.Clear();
				for (int num3 = 0; num3 < array.Length; num3++)
				{
					int num4 = operand2 + num3;
					ILLabel key = array[num3];
					if (stateRanges.TryGetValue(key, out var value))
					{
						value.UnionWith(new StateRange(num4, num4));
						continue;
					}
					value = new StateRange(num4, num4);
					stateRanges.Add(key, value);
					labels.Add(new KeyValuePair<ILLabel, StateRange>(key, value));
				}
				StateRange stateRange2 = new StateRange(int.MinValue, operand2 - 1);
				stateRange2.UnionWith(new StateRange(operand2 + array.Length, int.MaxValue));
				ILLabel iLLabel2 = body[i + 1] as ILLabel;
				if (iLLabel2 == null)
				{
					iLLabel2 = CreateTempLabel();
					body.Insert(i + 1, iLLabel2);
					bodyLength++;
				}
				labels.Add(new KeyValuePair<ILLabel, StateRange>(iLLabel2, stateRange2));
				continue;
			}
			case ILCode.Ret:
				if (iLExpression.Arguments.Count != 1 || iLExpression.Arguments[0].Code != ILCode.Ldc_I4)
				{
					throw new SymbolicAnalysisFailedException();
				}
				operand2 = (int)iLExpression.Arguments[0].Operand;
				switch (operand2)
				{
				case 0:
					newBody.Add(CreateYieldBreak());
					break;
				case 1:
					newBody.Add(MakeGoTo(labels, num));
					break;
				default:
					throw new SymbolicAnalysisFailedException();
				}
				continue;
			case ILCode.Call:
			{
				if (iLExpression.Arguments.Count != 1 || !iLExpression.Arguments[0].MatchThis())
				{
					break;
				}
				MethodDef methodDefinition = YieldReturnDecompiler.GetMethodDefinition(iLExpression.Operand as IMethod);
				if (methodDefinition == null)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (methodDefinition == disposeMethod)
				{
					if (!(body.ElementAtOrDefault(++i) is ILExpression iLExpression3) || (iLExpression3.Code != ILCode.Br && iLExpression3.Code != ILCode.Leave) || iLExpression3.Operand != returnFalseLabel)
					{
						throw new SymbolicAnalysisFailedException();
					}
					newBody.Add(CreateYieldBreak());
				}
				else
				{
					if (!finallyMethodToStateRange.TryGetValue(methodDefinition, out var stateRange))
					{
						continue;
					}
					bool flag = list2.Contains(methodDefinition);
					if (!flag)
					{
						list2.Add(methodDefinition);
					}
					List<int> list3 = finallyMethodIndexes;
					if (list3 != null && list3.Contains(i - 1))
					{
						i++;
					}
					if (!flag)
					{
						int num2 = list.FindIndex((SetState ss) => stateRange.Contains(ss.NewState));
						if (num2 < 0)
						{
							throw new SymbolicAnalysisFailedException();
						}
						ILBlock iLBlock = ConvertFinallyBlock(methodDefinition);
						if (iLBlock.Body.Count != 1 || !iLBlock.Body[0].Match(ILCode.Endfinally))
						{
							ILLabel iLLabel = new ILLabel();
							iLLabel.Name = "JumpOutOfTryFinally" + list[num2].NewState;
							newBody.Add(new ILExpression(ILCode.Leave, iLLabel));
							SetState setState = list[num2];
							list.RemoveRange(num2, list.Count - num2);
							ILTryCatchBlock iLTryCatchBlock = new ILTryCatchBlock();
							iLTryCatchBlock.TryBlock = new ILBlock(newBody.GetRange(setState.NewBodyPos, newBody.Count - setState.NewBodyPos), CodeBracesRangeFlags.TryBraces);
							newBody.RemoveRange(setState.NewBodyPos, newBody.Count - setState.NewBodyPos);
							iLTryCatchBlock.CatchBlocks = new List<ILTryCatchBlock.CatchBlock>();
							iLTryCatchBlock.FinallyBlock = iLBlock;
							newBody.Add(iLTryCatchBlock);
							newBody.Add(iLLabel);
						}
					}
				}
				continue;
			}
			case ILCode.Br:
			case ILCode.Leave:
				if (iLExpression.Operand == returnFalseLabel && origTopLevelBody != body)
				{
					newBody.Add(CreateYieldBreak());
					continue;
				}
				break;
			}
			if (iLExpression == null)
			{
				ILLabel lbl;
				if (body[i] is ILTryCatchBlock iLTryCatchBlock2)
				{
					if (iLTryCatchBlock2.TryBlock != null)
					{
						ConvertBodyCore(origTopLevelBody, ref iLTryCatchBlock2.TryBlock.Body);
					}
					foreach (ILTryCatchBlock.CatchBlock catchBlock in iLTryCatchBlock2.CatchBlocks)
					{
						ConvertBodyCore(origTopLevelBody, ref catchBlock.Body);
						if (catchBlock.FilterBlock != null)
						{
							ConvertBodyCore(origTopLevelBody, ref catchBlock.FilterBlock.Body);
						}
					}
					if (iLTryCatchBlock2.FinallyBlock != null)
					{
						ConvertBodyCore(origTopLevelBody, ref iLTryCatchBlock2.FinallyBlock.Body);
					}
					if (iLTryCatchBlock2.FaultBlock != null)
					{
						ConvertBodyCore(origTopLevelBody, ref iLTryCatchBlock2.FaultBlock.Body);
					}
				}
				else if (vbFinalizerStates != null && (lbl = body[i] as ILLabel) != null)
				{
					int? num5 = labels.LastOrDefault((KeyValuePair<ILLabel, StateRange> a) => a.Key == lbl && a.Value.TryGetSingleState().HasValue).Value?.TryGetSingleState();
					if (num5.HasValue && vbFinalizerStates.Contains(num5.Value))
					{
						if (body[i + 1].Match(ILCode.Br, out ILLabel operand5))
						{
							labels.Add(new KeyValuePair<ILLabel, StateRange>(operand5, new StateRange(num5.Value, num5.Value)));
							i++;
							continue;
						}
						if (i + 5 > bodyLength)
						{
							throw new SymbolicAnalysisFailedException();
						}
						if (!body[i + 1].Match(ILCode.Stloc, out ILVariable operand6, out ILExpression arg3) || !arg3.MatchLdcI4(-1))
						{
							throw new SymbolicAnalysisFailedException();
						}
						if (!body[i + 2].Match(ILCode.Stloc, out operand, out ILExpression arg4) || !arg4.MatchLdloc(operand6) || !stateVariables.Contains(operand))
						{
							throw new SymbolicAnalysisFailedException();
						}
						if (!body[i + 3].Match<IField>(ILCode.Stfld, out var operand7, out var arg5, out arg4) || !arg5.MatchThis() || !arg4.MatchLdloc(operand6))
						{
							throw new SymbolicAnalysisFailedException();
						}
						if (YieldReturnDecompiler.GetFieldDefinition(operand7) != stateField)
						{
							throw new SymbolicAnalysisFailedException();
						}
						if (!body[i + 4].Match(ILCode.Stloc, out operand, out arg3) || !arg3.MatchLdcI4(1) || operand != returnVariable)
						{
							throw new SymbolicAnalysisFailedException();
						}
						if (!body[i + 5].Match(ILCode.Leave, out ILLabel operand8) || operand8 != returnLabel)
						{
							throw new SymbolicAnalysisFailedException();
						}
						i += 5;
						continue;
					}
				}
			}
			newBody.Add(body[i]);
		}
		labels.RemoveRange(count, labels.Count - count);
		return newBody;
	}

	private ILLabel CreateTempLabel()
	{
		return new ILLabel
		{
			Name = "__tmp_lbl_iter" + tempLabelCounter++
		};
	}

	private void ConvertBodyCore(List<ILNode> origTopLevelBody, ref List<ILNode> body)
	{
		List<ILNode> list;
		if (freeBodies.Count > 0)
		{
			list = freeBodies[freeBodies.Count - 1];
			freeBodies.RemoveAt(freeBodies.Count - 1);
		}
		else
		{
			list = new List<ILNode>();
		}
		ConvertBodyCore(origTopLevelBody, body, list, 0, body.Count);
		body.Clear();
		freeBodies.Add(body);
		body = list;
	}

	private void UpdateFinallyMethodIndex(List<ILNode> body, ILExpression br, ref List<int> finallyMethodIndexes)
	{
		while (br.Operand != returnLabel)
		{
			int num = body.IndexOf((ILNode)br.Operand);
			MethodDef methodDefinition;
			if (num < 0 || !(body[num] is ILLabel) || num + 2 >= body.Count || !body[num + 1].Match(ILCode.Call, out IMethod operand, out ILExpression arg) || !arg.MatchThis() || (methodDefinition = YieldReturnDecompiler.GetMethodDefinition(operand)) == null || !finallyMethodToStateRange.ContainsKey(methodDefinition))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (finallyMethodIndexes == null)
			{
				finallyMethodIndexes = new List<int> { num };
			}
			else if (!finallyMethodIndexes.Contains(num))
			{
				finallyMethodIndexes.Add(num);
			}
			br = body[num + 2] as ILExpression;
			if (br == null || (br.Code != ILCode.Br && br.Code != ILCode.Leave))
			{
				throw new SymbolicAnalysisFailedException();
			}
		}
	}

	private ILExpression MakeGoTo(ILLabel targetLabel)
	{
		if (targetLabel == returnFalseLabel)
		{
			return CreateYieldBreak();
		}
		return new ILExpression(ILCode.Br, targetLabel);
	}

	private ILExpression MakeGoTo(List<KeyValuePair<ILLabel, StateRange>> labels, int state)
	{
		for (int num = labels.Count - 1; num >= 0; num--)
		{
			KeyValuePair<ILLabel, StateRange> keyValuePair = labels[num];
			if (keyValuePair.Value.Contains(state))
			{
				return MakeGoTo(keyValuePair.Key);
			}
		}
		throw new SymbolicAnalysisFailedException();
	}

	private ILBlock ConvertFinallyBlock(MethodDef finallyMethod)
	{
		ILBlock iLBlock = CreateILAst(finallyMethod);
		if (iLBlock.Body.Count > 0 && iLBlock.Body[0].Match(ILCode.Stfld, out IField operand, out List<ILExpression> args) && YieldReturnDecompiler.GetFieldDefinition(operand) == stateField && args[0].MatchThis())
		{
			iLBlock.Body.RemoveAt(0);
		}
		foreach (ILExpression item in iLBlock.GetSelfAndChildrenRecursive<ILExpression>())
		{
			if (item.Code == ILCode.Ret)
			{
				item.Code = ILCode.Endfinally;
			}
		}
		return iLBlock;
	}
}
