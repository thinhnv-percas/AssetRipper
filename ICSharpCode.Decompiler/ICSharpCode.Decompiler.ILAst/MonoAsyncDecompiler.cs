using System.Collections.Generic;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class MonoAsyncDecompiler : AsyncDecompiler
{
	private readonly List<ILExpression> expressionList = new List<ILExpression>();

	private readonly Dictionary<ILExpression, FieldDef> awaitExprInfos = new Dictionary<ILExpression, FieldDef>();

	private ILVariable cachedStateVar;

	private ILVariable disposeInFinallyVar;

	private ILLabel setResultAndExitLabel;

	private ILExpression resultExpr;

	private const int initialState = 0;

	private List<ILVariable> stateVariables;

	private static readonly UTF8String nameGetAwaiter = new UTF8String("GetAwaiter");

	private static readonly UTF8String nameget_IsCompleted = new UTF8String("get_IsCompleted");

	private readonly Dictionary<ILLabel, StateRange> stateRanges = new Dictionary<ILLabel, StateRange>();

	public override string CompilerName => "MonoCSharp";

	private MonoAsyncDecompiler(DecompilerContext context, AutoPropertyProvider autoPropertyProvider)
		: base(context, autoPropertyProvider)
	{
	}

	public static AsyncDecompiler TryCreateCore(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider)
	{
		MonoAsyncDecompiler monoAsyncDecompiler = new MonoAsyncDecompiler(context, autoPropertyProvider);
		if (!monoAsyncDecompiler.MatchTaskCreationPattern(method))
		{
			return null;
		}
		return monoAsyncDecompiler;
	}

	private bool MatchTaskCreationPattern(ILBlock method)
	{
		List<ILNode> body = method.Body;
		if (body.Count < 3)
		{
			return false;
		}
		if (!MatchStartCall(body[body.Count - 2], out var stateMachineVar))
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
		if (!InitializeFieldToParameterMap(body, body.Count - 3, stateMachineVar))
		{
			return false;
		}
		return true;
	}

	protected override void AnalyzeMoveNext(out ILMethodBody bodyInfo, out ILTryCatchBlock tryCatchBlock, out int finalState, out ILLabel exitLabel)
	{
		if (!AnalyzeMoveNextCore(out bodyInfo, out tryCatchBlock, out finalState, out exitLabel))
		{
			throw new SymbolicAnalysisFailedException();
		}
	}

	private bool AnalyzeMoveNextCore(out ILMethodBody bodyInfo, out ILTryCatchBlock tryCatchBlock, out int finalState, out ILLabel exitLabel)
	{
		bodyInfo = default(ILMethodBody);
		tryCatchBlock = null;
		finalState = -1;
		exitLabel = null;
		ILBlock iLBlock = CreateILAst(moveNextMethod);
		int num = 0;
		List<ILNode> body = iLBlock.Body;
		if (body.Count < 5)
		{
			return false;
		}
		if (!body[num++].Match(ILCode.Stloc, out cachedStateVar, out ILExpression arg))
		{
			return false;
		}
		if (!((ILNode)arg).Match(ILCode.Ldfld, out IField operand, out ILExpression arg2) || !arg2.MatchThis())
		{
			return false;
		}
		stateField = operand.ResolveFieldWithinSameModule();
		if (stateField?.DeclaringType != stateMachineType || stateField.FieldSig.GetFieldType().RemovePinnedAndModifiers().GetElementType() != ElementType.I4)
		{
			return false;
		}
		if (!body[num++].Match<IField>(ILCode.Stfld, out operand, out arg2, out var arg3) || !arg2.MatchThis() || !arg3.MatchLdcI4(-1))
		{
			return false;
		}
		if (operand.ResolveFieldWithinSameModule() != stateField)
		{
			return false;
		}
		if (body[num].Match(ILCode.Stloc, out ILVariable operand2, out arg3) && operand2.OriginalVariable != null && arg3.MatchLdcI4(0))
		{
			num++;
			disposeInFinallyVar = operand2;
		}
		if (body[num].Match(ILCode.Brtrue, out ILLabel operand3, out arg2))
		{
			if (!arg2.MatchLdloc(cachedStateVar))
			{
				return false;
			}
			num++;
		}
		int num2 = num;
		int num3 = body.Count - 1;
		if (num3 < num || !body[num3--].Match(ILCode.Ret))
		{
			return false;
		}
		if (num3 < num || (exitLabel = body[num3--] as ILLabel) == null)
		{
			return false;
		}
		if (operand3 != null && operand3 != exitLabel)
		{
			return false;
		}
		if (num3 < num || !MatchCallSetResult(body[num3--], out resultExpr, out var _))
		{
			return false;
		}
		if (num3 >= num && body[num3].Match<IField>(ILCode.Stfld, out operand, out arg2, out arg3) && arg2.MatchThis() && arg3.MatchLdcI4(-1) && operand.ResolveFieldWithinSameModule() == stateField)
		{
			num3--;
		}
		if (num3 >= num && body[num3] is ILLabel)
		{
			setResultAndExitLabel = body[num3--] as ILLabel;
		}
		if (num3 >= num)
		{
			tryCatchBlock = GetMainTryCatchBlock(body[num3]);
			if (tryCatchBlock != null)
			{
				num3--;
			}
		}
		if (tryCatchBlock != null)
		{
			if (num3 + 1 != num)
			{
				return false;
			}
			if (setResultAndExitLabel == null)
			{
				return false;
			}
			bodyInfo = new ILMethodBody(tryCatchBlock.TryBlock.Body);
		}
		else
		{
			if (num3 + 1 < num2)
			{
				return false;
			}
			bodyInfo = new ILMethodBody(body, num2, num3 + 1);
		}
		return true;
	}

	protected override List<ILNode> AnalyzeStateMachine(ILMethodBody bodyInfo)
	{
		List<ILNode> body = bodyInfo.Body;
		int startPosition = bodyInfo.StartPosition;
		int endPosition = bodyInfo.EndPosition;
		if (startPosition >= endPosition)
		{
			if (startPosition == endPosition)
			{
				return new List<ILNode>();
			}
			throw new SymbolicAnalysisFailedException();
		}
		MonoStateRangeAnalysis monoStateRangeAnalysis = new MonoStateRangeAnalysis(body[startPosition], StateRangeAnalysisMode.AsyncMoveNext, stateField, null, disposeInFinallyVar, cachedStateVar);
		int bodyLength = endPosition;
		int pos = monoStateRangeAnalysis.AssignStateRanges(body, startPosition, bodyLength);
		monoStateRangeAnalysis.EnsureLabelAtPos(body, ref pos, ref bodyLength);
		LabelRangeMapping mapping = monoStateRangeAnalysis.CreateLabelRangeMapping(body, pos, bodyLength);
		stateVariables = monoStateRangeAnalysis.StateVariables;
		List<ILNode> list = ConvertBody(body, pos, bodyLength, mapping);
		list.Insert(0, MakeGoTo(mapping, 0));
		if (setResultAndExitLabel != null)
		{
			list.Add(setResultAndExitLabel);
		}
		if (methodType == AsyncMethodType.TaskOfT)
		{
			list.Add(new ILExpression(ILCode.Ret, null, resultExpr));
		}
		else
		{
			list.Add(new ILExpression(ILCode.Ret, null));
		}
		SaveAwaiterFields(list);
		RemoveAsyncStepInfoState(0);
		return list;
	}

	private void SaveAwaiterFields(List<ILNode> newBody)
	{
		List<ILExpression> list = expressionList;
		foreach (ILBlock item2 in new ILBlock
		{
			Body = newBody
		}.GetSelfAndChildrenRecursive<ILBlock>())
		{
			List<ILNode> body = item2.Body;
			for (int i = 0; i < body.Count; i++)
			{
				if (body[i] is ILExpression item)
				{
					list.Add(item);
				}
			}
			while (list.Count > 0)
			{
				ILExpression iLExpression = list[list.Count - 1];
				list.RemoveAt(list.Count - 1);
				list.AddRange(iLExpression.Arguments);
				ILExpression iLExpression2 = MatchCallGetResult(iLExpression, isStatic: false, null);
				if (iLExpression2 != null)
				{
					iLExpression2.Code = ILCode.Ldsflda;
					iLExpression2.Arguments.Clear();
				}
			}
		}
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

	private List<ILNode> ConvertBody(List<ILNode> body, int startPos, int bodyLength, LabelRangeMapping mapping, bool keepMappings = false)
	{
		int count = mapping.Count;
		List<ILNode> list = new List<ILNode>();
		for (int i = startPos; i < bodyLength; i++)
		{
			ILNode iLNode = body[i];
			ILExpression iLExpression = iLNode as ILExpression;
			int operand2;
			ILVariable operand;
			switch (iLExpression?.Code ?? ((ILCode)(-1)))
			{
			case ILCode.Stfld:
			{
				FieldDef fieldDef = (iLExpression.Operand as IField).ResolveFieldWithinSameModule();
				if (fieldDef == null || fieldDef != stateField || !iLExpression.Arguments[0].MatchThis() || !((ILNode)iLExpression.Arguments[1]).Match(ILCode.Ldc_I4, out operand2))
				{
					break;
				}
				int count2 = list.Count;
				if (count2 < 2)
				{
					throw new SymbolicAnalysisFailedException();
				}
				AddYieldOffset(body, i, 1, operand2);
				if (!list[count2 - 2].Match<IField>(ILCode.Stfld, out var operand3, out var arg, out var arg2) || !arg.MatchThis())
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (arg2.Code != ILCode.Callvirt && arg2.Code != ILCode.Call)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (arg2.Arguments.Count != 1)
				{
					throw new SymbolicAnalysisFailedException();
				}
				ILExpression iLExpression3 = arg2.Arguments[0];
				if (context.CalculateILSpans)
				{
					iLExpression3.ILSpans.AddRange(arg.ILSpans);
					iLExpression3.ILSpans.AddRange(list[count2 - 2].ILSpans);
					iLExpression3.ILSpans.AddRange(arg2.ILSpans);
				}
				IMethod method = (IMethod)arg2.Operand;
				if (method.Name != nameGetAwaiter)
				{
					throw new SymbolicAnalysisFailedException();
				}
				FieldDef fieldDef2 = operand3.ResolveFieldWithinSameModule();
				if (fieldDef2?.DeclaringType != stateMachineType)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!list[count2 - 1].Match(ILCode.Brtrue, out ILLabel operand4, out ILExpression arg3))
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (arg3.Code != ILCode.Callvirt && arg3.Code != ILCode.Call)
				{
					throw new SymbolicAnalysisFailedException();
				}
				IMethod method2 = (IMethod)arg3.Operand;
				if (method2.Name != nameget_IsCompleted)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (!((ILNode)arg3.Arguments[0]).Match(ILCode.Ldflda, out IField operand5, out arg) || !arg.MatchThis() || operand5.ResolveFieldWithinSameModule() != fieldDef2)
				{
					throw new SymbolicAnalysisFailedException();
				}
				i++;
				if (body[i].Match(ILCode.Stloc, out operand, out ILExpression arg4))
				{
					if (operand != disposeInFinallyVar || !arg4.MatchLdcI4(1))
					{
						throw new SymbolicAnalysisFailedException();
					}
					i++;
				}
				if (i >= bodyLength)
				{
					throw new SymbolicAnalysisFailedException();
				}
				ILExpression node = MatchCallAwaitOnCompletedMethod(body[i++]);
				if (!((ILNode)node).Match(ILCode.Ldflda, out operand5, out arg) || !arg.MatchThis() || operand5.ResolveFieldWithinSameModule() != fieldDef2)
				{
					throw new SymbolicAnalysisFailedException();
				}
				if (i >= bodyLength || !body[i].Match(ILCode.Leave, out operand4) || operand4 != exitLabel)
				{
					throw new SymbolicAnalysisFailedException();
				}
				AddResumeLabel(operand4, operand2);
				ILExpression iLExpression4 = new ILExpression(ILCode.Await, null, iLExpression3);
				awaitExprInfos.Add(iLExpression4, fieldDef2);
				list[list.Count - 2] = iLExpression4;
				list[list.Count - 1] = MakeGoTo(mapping, operand2);
				continue;
			}
			case ILCode.Brtrue:
			{
				ILExpression iLExpression2 = iLExpression.Arguments[0];
				if (disposeInFinallyVar != null && iLExpression2.Code == ILCode.LogicNot && iLExpression2.Arguments[0].MatchLdloc(disposeInFinallyVar))
				{
					if (!body[i + 1].Match(ILCode.Endfinally))
					{
						throw new SymbolicAnalysisFailedException();
					}
					i++;
					continue;
				}
				break;
			}
			case ILCode.Stloc:
				operand = (ILVariable)iLExpression.Operand;
				if (operand == disposeInFinallyVar)
				{
					if (iLExpression.Arguments[0].MatchLdcI4(1))
					{
						continue;
					}
					throw new SymbolicAnalysisFailedException();
				}
				if (stateVariables.Contains(operand) && iLExpression.Arguments[0].MatchLdcI4(-3))
				{
					continue;
				}
				break;
			case ILCode.Switch:
			{
				ILExpression iLExpression2 = iLExpression.Arguments[0];
				if (iLExpression2.Code != ILCode.Sub || !((ILNode)iLExpression2.Arguments[0]).Match(ILCode.Ldloc, out operand) || !((ILNode)iLExpression2.Arguments[1]).Match(ILCode.Ldc_I4, out operand2) || !stateVariables.Contains(operand))
				{
					break;
				}
				ILLabel[] array = (ILLabel[])iLExpression.Operand;
				stateRanges.Clear();
				for (int j = 0; j < array.Length; j++)
				{
					int num = operand2 + j;
					ILLabel key = array[j];
					if (stateRanges.TryGetValue(key, out var value))
					{
						value.UnionWith(new StateRange(num, num));
						continue;
					}
					value = new StateRange(num, num);
					stateRanges.Add(key, value);
					mapping.Add(new KeyValuePair<ILLabel, StateRange>(key, value));
				}
				continue;
			}
			}
			if (iLExpression == null && iLNode is ILTryCatchBlock iLTryCatchBlock)
			{
				int count3 = mapping.Count;
				if (iLTryCatchBlock.TryBlock != null)
				{
					ConvertBody(ref iLTryCatchBlock.TryBlock.Body, mapping);
				}
				foreach (ILTryCatchBlock.CatchBlock catchBlock in iLTryCatchBlock.CatchBlocks)
				{
					ConvertBody(ref catchBlock.Body, mapping);
					if (catchBlock.FilterBlock != null)
					{
						ConvertBody(ref catchBlock.FilterBlock.Body, mapping);
					}
				}
				if (iLTryCatchBlock.FinallyBlock != null)
				{
					ConvertBody(ref iLTryCatchBlock.FinallyBlock.Body, mapping);
				}
				if (iLTryCatchBlock.FaultBlock != null)
				{
					ConvertBody(ref iLTryCatchBlock.FaultBlock.Body, mapping);
				}
				mapping.RemoveRange(count3, mapping.Count - count3);
			}
			list.Add(iLNode);
		}
		if (!keepMappings)
		{
			mapping.RemoveRange(count, mapping.Count - count);
		}
		return list;
	}

	private void ConvertBody(ref List<ILNode> body, LabelRangeMapping mapping)
	{
		body = ConvertBody(body, 0, body.Count, mapping, keepMappings: true);
	}

	protected override void Step2(ILBlock method)
	{
		foreach (ILBlock item in method.GetSelfAndChildrenRecursive<ILBlock>())
		{
			List<ILNode> body = item.Body;
			for (int i = 0; i < body.Count; i++)
			{
				if (!(body[i] is ILExpression { Code: ILCode.Await }))
				{
					continue;
				}
				int num = GetNextNonAwaitIndex(body, i);
				if (num < 0)
				{
					continue;
				}
				for (; i < num; i++)
				{
					ILExpression iLExpression2 = (ILExpression)body[i];
					if (awaitExprInfos.TryGetValue(iLExpression2, out var value) && UpdateExpression(expressionList, iLExpression2.Arguments[0], body[num] as ILExpression, value))
					{
						body.RemoveAt(i);
						i--;
						num--;
					}
				}
			}
		}
	}

	private static int GetNextNonAwaitIndex(List<ILNode> body, int i)
	{
		while (i < body.Count)
		{
			if (!(body[i] is ILExpression { Code: ILCode.Await }))
			{
				return i;
			}
			i++;
		}
		return -1;
	}

	private bool UpdateExpression(List<ILExpression> list, ILExpression newExpr, ILExpression target, FieldDef awaiterField)
	{
		if (target == null)
		{
			return false;
		}
		list.Clear();
		list.Add(target);
		while (list.Count > 0)
		{
			ILExpression iLExpression = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
			list.AddRange(iLExpression.Arguments);
			if (MatchCallGetResult(iLExpression, isStatic: true, awaiterField) != null)
			{
				iLExpression.Code = ILCode.Await;
				iLExpression.Operand = null;
				iLExpression.Arguments.Clear();
				iLExpression.Arguments.Add(newExpr);
				iLExpression.Prefixes = null;
				iLExpression.ExpectedType = null;
				iLExpression.InferredType = null;
				return true;
			}
		}
		return false;
	}

	private ILExpression MatchCallGetResult(ILExpression expr, bool isStatic, FieldDef requiredAwaiterField)
	{
		if (expr.Code != ILCode.Call)
		{
			return null;
		}
		if (expr.Arguments.Count != 1)
		{
			return null;
		}
		ILExpression iLExpression = expr.Arguments[0];
		IField operand;
		ILExpression arg;
		if (isStatic)
		{
			if (!((ILNode)iLExpression).Match(ILCode.Ldsflda, out operand))
			{
				return null;
			}
		}
		else if (!((ILNode)iLExpression).Match(ILCode.Ldflda, out operand, out arg) || !arg.MatchThis())
		{
			return null;
		}
		FieldDef fieldDef = operand.ResolveFieldWithinSameModule();
		if (requiredAwaiterField != null && requiredAwaiterField != fieldDef)
		{
			return null;
		}
		if (fieldDef?.DeclaringType != stateMachineType)
		{
			return null;
		}
		if (((expr.Operand is IMethod method) ? method.Name : null) != AsyncDecompiler.nameGetResult)
		{
			return null;
		}
		return iLExpression;
	}
}
