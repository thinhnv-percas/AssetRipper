using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class MicrosoftAsyncDecompiler : AsyncDecompiler
{
	private ILVariable cachedStateVar;

	private int initialState;

	private ILLabel setResultAndExitLabel;

	private ILExpression resultExpr;

	private ILVariable resultVariable;

	private string compilerName;

	private static readonly UTF8String nameCtor = new UTF8String(".ctor");

	private ILVariable doFinallyBodies;

	public override string CompilerName => compilerName;

	private MicrosoftAsyncDecompiler(DecompilerContext context, AutoPropertyProvider autoPropertyProvider)
		: base(context, autoPropertyProvider)
	{
	}

	public static AsyncDecompiler TryCreateCore(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider)
	{
		MicrosoftAsyncDecompiler microsoftAsyncDecompiler = new MicrosoftAsyncDecompiler(context, autoPropertyProvider);
		if (!microsoftAsyncDecompiler.MatchTaskCreationPattern(method))
		{
			return null;
		}
		return microsoftAsyncDecompiler;
	}

	private bool MatchTaskCreationPattern(ILBlock method)
	{
		List<ILNode> body = method.Body;
		if (body.Count < 5)
		{
			return false;
		}
		if (IsPerhapsVisualBasicKickoffMethod(body[0] as ILExpression, out var stateMachineVar) && VisualBasicMatchTaskCreationPattern(body, stateMachineVar))
		{
			return true;
		}
		if (!MatchStartCall(body[body.Count - 2], out var stateMachineVar2, out var builderVar) || builderVar == null)
		{
			return false;
		}
		if (!MatchBuilderField(body[body.Count - 3], stateMachineVar2, builderVar))
		{
			return false;
		}
		if (!MatchReturnTask(body[body.Count - 1], stateMachineVar2))
		{
			return false;
		}
		if (!AsyncDecompiler.MatchStFld(body[body.Count - 4], stateMachineVar2, stateMachineTypeIsValueType, out stateField, out var expr))
		{
			return false;
		}
		if (!((ILNode)expr).Match(ILCode.Ldc_I4, out initialState))
		{
			return false;
		}
		if (initialState != -1)
		{
			return false;
		}
		if (!MatchCallCreate(body[body.Count - 5], stateMachineVar2))
		{
			return false;
		}
		if (!InitializeFieldToParameterMap(body, body.Count - 5, stateMachineVar2))
		{
			return false;
		}
		return true;
	}

	private bool VisualBasicMatchTaskCreationPattern(List<ILNode> body, ILVariable vbStateMachineVar)
	{
		if (!MatchStartCall(body[body.Count - 2], out var stateMachineVar) || vbStateMachineVar != stateMachineVar)
		{
			return false;
		}
		if (!MatchCallCreate(body[body.Count - 3], stateMachineVar))
		{
			return false;
		}
		if (!MatchReturnTask(body[body.Count - 1], stateMachineVar))
		{
			return false;
		}
		if (!AsyncDecompiler.MatchStFld(body[body.Count - 4], stateMachineVar, stateMachineTypeIsValueType, out stateField, out var expr))
		{
			return false;
		}
		if (!((ILNode)expr).Match(ILCode.Ldc_I4, out initialState))
		{
			return false;
		}
		if (initialState != -1)
		{
			return false;
		}
		if (!InitializeFieldToParameterMap(body, 1, body.Count - 4, stateMachineVar))
		{
			return false;
		}
		return true;
	}

	private bool IsPerhapsVisualBasicKickoffMethod(ILExpression expr, out ILVariable stateMachineVar)
	{
		if (((ILNode)expr).Match(ILCode.Initobj, out ITypeDefOrRef _, out ILExpression arg))
		{
			return ((ILNode)arg).Match(ILCode.Ldloca, out stateMachineVar);
		}
		if (((ILNode)expr).Match(ILCode.Stloc, out stateMachineVar, out ILExpression arg2))
		{
			if (((ILNode)arg2).Match(ILCode.Newobj, out IMethod operand2))
			{
				return operand2.Name == nameCtor;
			}
			return false;
		}
		return false;
	}

	private bool MatchBuilderField(ILNode expr, ILVariable stateMachineVar, ILVariable builderVar)
	{
		if (!expr.MatchStloc(builderVar, out var expr2))
		{
			return false;
		}
		if (!((ILNode)expr2).Match(ILCode.Ldfld, out IField operand, out ILExpression arg))
		{
			return false;
		}
		if (!arg.MatchLdloca(stateMachineVar) && !arg.MatchLdloc(stateMachineVar))
		{
			return false;
		}
		builderField = operand.ResolveFieldWithinSameModule();
		return builderField != null;
	}

	protected override void AnalyzeMoveNext(out ILMethodBody bodyInfo, out ILTryCatchBlock tryCatchBlock, out int finalState, out ILLabel exitLabel)
	{
		ILBlock iLBlock = CreateILAst(moveNextMethod);
		if (moveNextMethod.DeclaringType.Name.StartsWith("VB$StateMachine_"))
		{
			compilerName = "MicrosoftVisualBasic";
		}
		else
		{
			compilerName = "MicrosoftCSharp";
		}
		List<ILNode> body = iLBlock.Body;
		if (body.Count < 5)
		{
			throw new SymbolicAnalysisFailedException();
		}
		int num = 0;
		if (body[num].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && arg.MatchLdcI4(1))
		{
			doFinallyBodies = operand;
			num++;
		}
		if (body[num].Match(ILCode.Stloc, out operand, out ILExpression arg2) && ((ILNode)arg2).Match(ILCode.Ldfld, out IField operand2, out ILExpression arg3) && operand2.ResolveFieldWithinSameModule() == stateField && arg3.MatchThis())
		{
			cachedStateVar = operand;
			num++;
		}
		if (body[num].Match(ILCode.Stloc, out operand, out ILExpression arg4) && ((ILNode)arg4).Match(ILCode.Ldfld, out IField operand3, out ILExpression arg5) && arg5.MatchThis())
		{
			FieldDef fieldDef = operand3.ResolveFieldWithinSameModule();
			if (fieldDef?.DeclaringType == stateMachineType && fieldDef.FieldType.RemovePinnedAndModifiers().Resolve() == context.CurrentType && variableMap.TryGetParameter(fieldDef, out var parameter) && parameter.IsParameter && parameter.OriginalParameter.IsHiddenThisParameter)
			{
				cachedThisVar = operand;
				num++;
			}
		}
		tryCatchBlock = GetMainTryCatchBlock(body[num++]);
		if (tryCatchBlock == null)
		{
			throw new SymbolicAnalysisFailedException();
		}
		setResultAndExitLabel = body[num++] as ILLabel;
		if (setResultAndExitLabel == null)
		{
			throw new SymbolicAnalysisFailedException();
		}
		bool flag = false;
		ILExpression obj = body[num] as ILExpression;
		ILVariable operand4;
		if (obj != null && obj.Code == ILCode.Ret)
		{
			flag = true;
			finalState = -2;
		}
		else if (body[num].Match(ILCode.Stloc, out operand4, out arg))
		{
			if (!((ILNode)arg).Match(ILCode.Ldc_I4, out finalState) || finalState >= -1)
			{
				throw new SymbolicAnalysisFailedException();
			}
			num++;
			if (!body[num++].Match(ILCode.Stloc, out operand, out ILExpression arg6) || !arg6.MatchLdloc(operand4) || operand != cachedStateVar)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!body[num++].Match<IField>(ILCode.Stfld, out var operand5, out var arg7, out arg6) || !arg7.MatchThis() || !arg6.MatchLdloc(operand4))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (operand5.ResolveFieldWithinSameModule() != stateField)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}
		else if (!MatchStateAssignment(body[num++], out finalState))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!flag)
		{
			if (!MatchCallSetResult(body[num++], out resultExpr, out resultVariable))
			{
				throw new SymbolicAnalysisFailedException();
			}
			exitLabel = body[num++] as ILLabel;
			if (exitLabel == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}
		else
		{
			exitLabel = setResultAndExitLabel;
		}
		bodyInfo = new ILMethodBody(tryCatchBlock.TryBlock.Body);
	}

	private bool MatchRoslynStateAssignment(List<ILNode> block, int index, out int stateID)
	{
		stateID = 0;
		if (index < 0)
		{
			return false;
		}
		if (!block[index].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) || !((ILNode)arg).Match(ILCode.Ldc_I4, out stateID))
		{
			return false;
		}
		if (!block[index + 1].MatchStloc(cachedStateVar, out var expr) || !expr.MatchLdloc(operand))
		{
			return false;
		}
		if (block[index + 2].Match<IField>(ILCode.Stfld, out var operand2, out var arg2, out expr))
		{
			if (operand2.ResolveFieldWithinSameModule() == stateField && arg2.MatchThis())
			{
				return expr.MatchLdloc(operand);
			}
			return false;
		}
		return false;
	}

	protected override List<ILNode> AnalyzeStateMachine(ILMethodBody bodyInfo)
	{
		List<ILNode> body = bodyInfo.Body;
		int num = bodyInfo.StartPosition;
		int endPosition = bodyInfo.EndPosition;
		if (num >= endPosition)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (DetectDoFinallyBodies(body, num))
		{
			num++;
			if (num >= endPosition)
			{
				throw new SymbolicAnalysisFailedException();
			}
		}
		StateRangeAnalysis stateRangeAnalysis = new MicrosoftStateRangeAnalysis(body[num], StateRangeAnalysisMode.AsyncMoveNext, stateField, cachedStateVar);
		int bodyLength = endPosition;
		int pos = stateRangeAnalysis.AssignStateRanges(body, num, bodyLength);
		stateRangeAnalysis.EnsureLabelAtPos(body, ref pos, ref bodyLength);
		LabelRangeMapping mapping = CreateLabelRangeMapping(stateRangeAnalysis, body, pos, bodyLength);
		List<ILNode> list = ConvertBody(body, pos, bodyLength, mapping);
		list.Insert(0, MakeGoTo(mapping, initialState));
		list.Add(setResultAndExitLabel);
		if (methodType == AsyncMethodType.TaskOfT)
		{
			list.Add(new ILExpression(ILCode.Ret, null, resultExpr));
		}
		else
		{
			list.Add(new ILExpression(ILCode.Ret, null));
		}
		return list;
	}

	private bool DetectDoFinallyBodies(List<ILNode> body, int startPos)
	{
		if (!body[startPos].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) || (resultVariable != null && operand == resultVariable))
		{
			return false;
		}
		if (!((ILNode)arg).Match(ILCode.Ldc_I4, out int operand2) || operand2 != 1)
		{
			return false;
		}
		doFinallyBodies = operand;
		return true;
	}

	private ILExpression MakeGoTo(LabelRangeMapping mapping, int state)
	{
		for (int num = mapping.Count - 1; num >= 0; num--)
		{
			KeyValuePair<ILLabel, StateRange> keyValuePair = mapping[num];
			if (keyValuePair.Value.Contains(state))
			{
				return new ILExpression(ILCode.Br, keyValuePair.Key);
			}
		}
		throw new SymbolicAnalysisFailedException();
	}

	private bool TryAddStateRanges(List<ILNode> body, ref int pos, int bodyLength, LabelRangeMapping mapping)
	{
		MicrosoftStateRangeAnalysis microsoftStateRangeAnalysis = new MicrosoftStateRangeAnalysis(body[pos], StateRangeAnalysisMode.AsyncMoveNext, stateField, cachedStateVar);
		int num = microsoftStateRangeAnalysis.AssignStateRanges(body, pos, bodyLength);
		if (num == pos)
		{
			return false;
		}
		LabelRangeMapping collection = CreateLabelRangeMapping(microsoftStateRangeAnalysis, body, num, bodyLength);
		mapping.AddRange(collection);
		pos = num - 1;
		return true;
	}

	private List<ILNode> ConvertBody(List<ILNode> body, int startPos, int bodyLength, LabelRangeMapping mapping)
	{
		int count = mapping.Count;
		List<ILNode> list = new List<ILNode>();
		for (int i = startPos; i < bodyLength; i++)
		{
			ILNode iLNode = body[i];
			ILExpression iLExpression = iLNode as ILExpression;
			ILExpression arg;
			switch (iLExpression?.Code ?? ((ILCode)(-1)))
			{
			case ILCode.Stloc:
			{
				if ((VerifyLoadStateField(iLExpression.Arguments[0]) && TryAddStateRanges(body, ref i, bodyLength, mapping)) || iLExpression.Operand == doFinallyBodies)
				{
					continue;
				}
				if (i + 3 < bodyLength && iLExpression.Arguments[0].MatchLdcI4(-1) && body[i + 1].Match(ILCode.Stloc, out ILVariable _, out arg) && arg.MatchLdloc(iLExpression.Operand as ILVariable) && body[i + 3].Match(ILCode.Leave, out ILLabel operand3) && operand3 == exitLabel && body[i + 2].Match<IField>(ILCode.Stfld, out var _, out var arg2, out arg) && arg2.MatchThis() && arg.MatchLdloc(iLExpression.Operand as ILVariable))
				{
					i += 3;
					continue;
				}
				break;
			}
			case ILCode.Switch:
				if (TryAddStateRanges(body, ref i, bodyLength, mapping))
				{
					continue;
				}
				break;
			case ILCode.Brtrue:
			{
				if (((ILNode)iLExpression).Match(ILCode.Brtrue, out ILLabel _, out ILExpression arg3) && MatchLogicNot(arg3, out var arg4) && arg4.MatchLdloc(doFinallyBodies))
				{
					continue;
				}
				break;
			}
			case ILCode.Stfld:
			{
				if (iLExpression.Arguments[0].MatchThis() && iLExpression.Arguments[1].MatchLdcI4(-1) && i + 1 < bodyLength && body[i + 1].Match(ILCode.Leave, out ILLabel operand) && operand == exitLabel && (iLExpression.Operand as IField).ResolveFieldWithinSameModule() == stateField)
				{
					i++;
					continue;
				}
				if (doFinallyBodies != null && ((ILNode)iLExpression.Arguments[0]).Match(ILCode.LogicNot, out arg) && arg.MatchLdloc(doFinallyBodies))
				{
					continue;
				}
				break;
			}
			case ILCode.Leave:
				if (iLExpression.Operand == exitLabel)
				{
					HandleAwait(list, out var awaiterVar, out var _, out var targetStateID);
					MarkAsGeneratedVariable(awaiterVar);
					list.Add(new ILExpression(ILCode.Await, null, new ILExpression(ILCode.Ldloca, awaiterVar)));
					list.Add(MakeGoTo(mapping, targetStateID));
					continue;
				}
				break;
			}
			if (iLNode is ILTryCatchBlock iLTryCatchBlock)
			{
				List<ILNode> body2 = iLTryCatchBlock.TryBlock.Body;
				if (body2.Count == 0)
				{
					throw new SymbolicAnalysisFailedException();
				}
				MicrosoftStateRangeAnalysis microsoftStateRangeAnalysis = new MicrosoftStateRangeAnalysis(body2[0], StateRangeAnalysisMode.AsyncMoveNext, stateField, cachedStateVar);
				int bodyLength2 = body2.Count;
				int pos = microsoftStateRangeAnalysis.AssignStateRanges(body2, bodyLength2);
				microsoftStateRangeAnalysis.EnsureLabelAtPos(body2, ref pos, ref bodyLength2);
				LabelRangeMapping mapping2 = CreateLabelRangeMapping(microsoftStateRangeAnalysis, body2, pos, bodyLength2);
				List<ILNode> list2 = ConvertBody(body2, pos, bodyLength2, mapping2);
				list2.Insert(0, MakeGoTo(mapping2, initialState));
				if (pos > 0 && body2.FirstOrDefault() is ILLabel)
				{
					list2.Insert(0, body2.First());
				}
				iLTryCatchBlock.TryBlock.Body = list2;
				if (iLTryCatchBlock.FinallyBlock != null)
				{
					iLTryCatchBlock.FinallyBlock.Body = ConvertFinally(iLTryCatchBlock.FinallyBlock.Body);
				}
				list.Add(iLTryCatchBlock);
			}
			else
			{
				list.Add(iLNode);
			}
		}
		mapping.RemoveRange(count, mapping.Count - count);
		return list;
	}

	private bool VerifyLoadStateField(ILExpression expr)
	{
		if (!((ILNode)expr).Match(ILCode.Ldfld, out IField operand, out ILExpression arg))
		{
			return false;
		}
		if (arg.MatchThis())
		{
			return operand.ResolveFieldWithinSameModule() == stateField;
		}
		return false;
	}

	private List<ILNode> ConvertFinally(List<ILNode> body)
	{
		if (body.Count == 0)
		{
			return body;
		}
		ILLabel operand2;
		if (body[0].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg))
		{
			ILExpression arg2;
			if (operand == doFinallyBodies)
			{
				body.RemoveAt(0);
			}
			else if (arg.MatchLdloc(doFinallyBodies) && body[1].Match(ILCode.Brtrue, out operand2, out arg2) && MatchLogicNot(arg2, out arg) && arg.MatchLdloc(operand))
			{
				body.RemoveRange(0, 2);
			}
		}
		if (body[0].Match(ILCode.Brtrue, out operand2, out ILExpression arg3) && ((ILNode)arg3).Match(ILCode.Cge, out List<ILExpression> args) && args.Count == 2 && args[1].MatchLdcI4(0) && args[0].MatchLdloc(cachedStateVar))
		{
			body.RemoveAt(0);
		}
		if (body[0].Match(ILCode.Brtrue, out operand2, out ILExpression arg4) && MatchLogicNot(arg4, out var arg5))
		{
			if (arg5.MatchLdloc(doFinallyBodies))
			{
				body.RemoveAt(0);
			}
			else if (arg5.Code == ILCode.Clt && arg5.Arguments[0].MatchLdloc(cachedStateVar) && arg5.Arguments[1].MatchLdcI4(0))
			{
				body.RemoveAt(0);
			}
		}
		return body;
	}

	private bool MatchLogicNot(ILExpression expr, out ILExpression arg)
	{
		if (expr.Match<object>(ILCode.Ceq, out var _, out arg, out var arg2))
		{
			if (((ILNode)arg2).Match(ILCode.Ldc_I4, out int operand2))
			{
				return operand2 == 0;
			}
			return false;
		}
		return ((ILNode)expr).Match(ILCode.LogicNot, out arg);
	}

	private void HandleAwait(List<ILNode> newBody, out ILVariable awaiterVar, out FieldDef awaiterField, out int targetStateID)
	{
		if (doFinallyBodies != null && newBody.LastOrDefault().MatchStloc(doFinallyBodies, out var expr))
		{
			if (!((ILNode)expr).Match(ILCode.Ldc_I4, out int operand) || operand != 0)
			{
				throw new SymbolicAnalysisFailedException();
			}
			newBody.RemoveAt(newBody.Count - 1);
		}
		ILNode expr2 = newBody.LastOrDefault();
		newBody.RemoveAt(newBody.Count - 1);
		ILExpression node = MatchCallAwaitOnCompletedMethod(expr2);
		if (!((ILNode)node).Match(ILCode.Ldloca, out awaiterVar))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!stateMachineTypeIsValueType)
		{
			if (newBody.Count < 2)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!newBody.LastOrDefault().Match(ILCode.Stloc, out ILVariable operand2, out ILExpression arg))
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!((ILNode)arg).Match(ILCode.Ldloc, out operand2))
			{
				throw new SymbolicAnalysisFailedException();
			}
			newBody.RemoveAt(newBody.Count - 1);
		}
		if (!newBody.LastOrDefault().Match<IField>(ILCode.Stfld, out var operand3, out var arg2, out var arg3))
		{
			throw new SymbolicAnalysisFailedException();
		}
		newBody.RemoveAt(newBody.Count - 1);
		awaiterField = operand3.ResolveFieldWithinSameModule();
		if (awaiterField == null || !arg2.MatchThis() || !arg3.MatchLdloc(awaiterVar))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (MatchStateAssignment(newBody.LastOrDefault(), out targetStateID))
		{
			AddYieldOffset(newBody, newBody.Count - 1, 1, targetStateID);
			newBody.RemoveAt(newBody.Count - 1);
		}
		else if (MatchRoslynStateAssignment(newBody, newBody.Count - 3, out targetStateID))
		{
			AddYieldOffset(newBody, newBody.Count - 3, 3, targetStateID);
			newBody.RemoveRange(newBody.Count - 3, 3);
		}
	}

	protected override void Step2(ILBlock method)
	{
		Step2Core(method.Body);
	}

	private void Step2Core(List<ILNode> body)
	{
		for (int i = 0; i < body.Count; i++)
		{
			if (body[i] is ILTryCatchBlock iLTryCatchBlock)
			{
				Step2Core(iLTryCatchBlock.TryBlock.Body);
			}
			else
			{
				Step2Core(body, ref i);
			}
		}
	}

	private bool Step2Core(List<ILNode> body, ref int currPos)
	{
		int num = currPos;
		if (!body[num].Match(ILCode.Await, out ILExpression arg))
		{
			return false;
		}
		if (!((ILNode)arg).Match(ILCode.Ldloca, out ILVariable operand))
		{
			return false;
		}
		ILVariable operand2;
		ILExpression arg2;
		while (num >= 1 && body[num - 1].Match(ILCode.Stloc, out operand2, out arg2))
		{
			num--;
		}
		if (num < 2 || !body[num - 2].MatchStloc(operand, out var expr))
		{
			return false;
		}
		if (!((ILNode)expr).Match(ILCode.Call, out IMethod operand3, out ILExpression arg3) && !((ILNode)expr).Match(ILCode.Callvirt, out operand3, out arg3))
		{
			return false;
		}
		ILExpression iLExpression = null;
		if (arg3.Code == ILCode.AddressOf)
		{
			iLExpression = arg3;
			arg3 = arg3.Arguments[0];
		}
		if (num < 1 || !body[num - 1].Match(ILCode.Brtrue, out ILLabel operand4, out ILExpression _))
		{
			return false;
		}
		int num2 = body.IndexOf(operand4);
		if (num2 < num)
		{
			return false;
		}
		for (int i = num + 1; i < num2; i++)
		{
			if (!(body[i] is ILExpression { Code: var code }))
			{
				return false;
			}
			switch (code)
			{
			case ILCode.Stfld:
			case ILCode.Stloc:
			case ILCode.Initobj:
			case ILCode.Await:
				continue;
			}
			return false;
		}
		if (num2 + 1 >= body.Count)
		{
			return false;
		}
		ILExpression iLExpression3 = body[num2 + 1] as ILExpression;
		ILExpression iLExpression4 = null;
		bool flag = ((ILNode)iLExpression3).Match(ILCode.Stloc, out ILVariable _, out ILExpression arg5) && IsGetResult(arg5.Operand);
		if (!flag)
		{
			if (arg5 == null)
			{
				arg5 = iLExpression3;
			}
			while (!IsGetResult(arg5.Operand))
			{
				ILCode code2 = arg5.Code;
				if ((uint)(code2 - 39) > 1u && code2 != ILCode.Callvirt && (uint)(code2 - 247) > 5u)
				{
					return false;
				}
				if (arg5.Arguments.Count == 0)
				{
					return false;
				}
				iLExpression4 = arg5;
				arg5 = arg5.Arguments[0];
			}
		}
		if (!IsGetResult(arg5.Operand))
		{
			return false;
		}
		num -= 2;
		if (context.CalculateILSpans)
		{
			arg3.ILSpans.AddRange(body[num].ILSpans);
			arg3.ILSpans.AddRange(expr.ILSpans);
			if (iLExpression != null)
			{
				arg3.ILSpans.AddRange(iLExpression.ILSpans);
			}
		}
		body.RemoveRange(num, num2 - num);
		num++;
		if (flag)
		{
			iLExpression3.Arguments[0] = new ILExpression(ILCode.Await, null, arg3);
		}
		else if (iLExpression4 != null)
		{
			if (context.CalculateILSpans)
			{
				arg3.ILSpans.AddRange(iLExpression4.Arguments[0].GetSelfAndChildrenRecursiveILSpans());
			}
			iLExpression4.Arguments[0] = new ILExpression(ILCode.Await, null, arg3);
		}
		else
		{
			body[num] = new ILExpression(ILCode.Await, null, arg3);
		}
		if (IsVariableReset(body.ElementAtOrDefault(num + 1), operand))
		{
			body.RemoveAt(num + 1);
		}
		currPos = num;
		return true;
	}

	private static bool IsGetResult(object operand)
	{
		if (operand is IMethod { IsField: false } method)
		{
			return method.Name == AsyncDecompiler.nameGetResult;
		}
		return false;
	}

	private static bool IsVariableReset(ILNode expr, ILVariable variable)
	{
		if (expr.Match(ILCode.Initobj, out object _, out ILExpression arg))
		{
			return arg.MatchLdloca(variable);
		}
		return false;
	}
}
