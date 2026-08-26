using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class MonoYieldReturnDecompiler : YieldReturnDecompiler
{
	private FieldDef disposingField;

	private List<ILVariable> stateVariables;

	private ILLabel returnFalseLabel;

	private ILLabel returnTrueLabel;

	private List<KeyValuePair<ILLabel, StateRange>> labels;

	private ILVariable disposeInFinallyVar;

	private readonly Dictionary<ILLabel, StateRange> stateRanges = new Dictionary<ILLabel, StateRange>();

	private readonly List<List<ILNode>> freeBodies = new List<List<ILNode>>();

	private int labelCounter;

	public override string CompilerName => "MonoCSharp";

	private MonoYieldReturnDecompiler(DecompilerContext context, AutoPropertyProvider autoPropertyProvider)
		: base(context, autoPropertyProvider)
	{
	}

	public static YieldReturnDecompiler TryCreateCore(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider)
	{
		MonoYieldReturnDecompiler monoYieldReturnDecompiler = new MonoYieldReturnDecompiler(context, autoPropertyProvider);
		if (!monoYieldReturnDecompiler.MatchEnumeratorCreationPattern(method))
		{
			return null;
		}
		monoYieldReturnDecompiler.enumeratorType = monoYieldReturnDecompiler.enumeratorCtor.DeclaringType;
		return monoYieldReturnDecompiler;
	}

	private bool MatchEnumeratorCreationPattern(ILBlock method)
	{
		List<ILNode> body = method.Body;
		if (body.Count == 0)
		{
			return false;
		}
		int num = 0;
		ILExpression arg;
		ILVariable operand;
		if (body.Count == 1)
		{
			if (!body[num].Match(ILCode.Ret, out arg))
			{
				return false;
			}
			operand = null;
		}
		else if (!body[num].Match(ILCode.Stloc, out operand, out arg))
		{
			return false;
		}
		if (!((ILNode)arg).Match(ILCode.Newobj, out IMethod operand2))
		{
			return false;
		}
		enumeratorCtor = YieldReturnDecompiler.GetMethodDefinition(operand2);
		if (enumeratorCtor == null || enumeratorCtor.DeclaringType.DeclaringType != context.CurrentType)
		{
			return false;
		}
		if (!YieldReturnDecompiler.IsCompilerGeneratorEnumerator(enumeratorCtor.DeclaringType))
		{
			return false;
		}
		if (method.Body.Count == 1)
		{
			return true;
		}
		num++;
		if (!InitializeFieldToParameterMap(method, operand, ref num))
		{
			return false;
		}
		if (body[num].Match(ILCode.Stloc, out ILVariable operand3, out ILExpression arg2))
		{
			if (!arg2.MatchLdloc(operand))
			{
				return false;
			}
			num++;
			if (!body[num++].Match<IField>(ILCode.Stfld, out var operand4, out arg2, out var arg3))
			{
				return false;
			}
			if (!arg2.MatchLdloc(operand3))
			{
				return false;
			}
			FieldDef fieldDefinition = YieldReturnDecompiler.GetFieldDefinition(operand4);
			if (fieldDefinition == null || fieldDefinition.DeclaringType != enumeratorCtor.DeclaringType)
			{
				return false;
			}
			if (!arg3.MatchLdcI4(-2))
			{
				return false;
			}
			stateField = fieldDefinition;
		}
		else
		{
			operand3 = operand;
		}
		if (!body[num].Match(ILCode.Ret, out arg2))
		{
			return false;
		}
		return arg2.MatchLdloc(operand3);
	}

	protected override void AnalyzeCtor()
	{
		ILBlock iLBlock = CreateILAst(enumeratorCtor);
		List<ILNode> body = iLBlock.Body;
		if (body.Count != 2)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!body[0].Match(ILCode.Call, out IMethod operand, out ILExpression arg))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!arg.MatchThis())
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (operand.Name != ".ctor")
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!body[1].Match(ILCode.Ret))
		{
			throw new SymbolicAnalysisFailedException();
		}
	}

	private void InitializeDisposeMethod(ILBlock method)
	{
		FieldDef fieldDef = null;
		foreach (ILNode item in method.Body)
		{
			if (!(item is ILExpression { Code: not ILCode.Switch } iLExpression))
			{
				break;
			}
			if (!iLExpression.Match<IField>(ILCode.Stfld, out var operand, out var arg, out var arg2) || !arg.MatchThis() || !((ILNode)arg2).Match(ILCode.Ldc_I4, out int operand2))
			{
				continue;
			}
			FieldDef fieldDefinition = YieldReturnDecompiler.GetFieldDefinition(operand);
			if (fieldDefinition?.DeclaringType != enumeratorType)
			{
				continue;
			}
			if (variableMap.TryGetParameter(fieldDefinition, out var _))
			{
				break;
			}
			if (operand2 == -1)
			{
				if (fieldDefinition.FieldSig.Type.ElementType != ElementType.I4)
				{
					continue;
				}
				if (fieldDef != null)
				{
					throw new SymbolicAnalysisFailedException();
				}
				fieldDef = fieldDefinition;
			}
			else
			{
				if (operand2 != 1 || fieldDefinition.FieldSig.Type.ElementType != ElementType.Boolean)
				{
					continue;
				}
				if (disposingField != null)
				{
					throw new SymbolicAnalysisFailedException();
				}
				disposingField = fieldDefinition;
			}
			if (fieldDef != null && disposingField != null)
			{
				break;
			}
		}
		if (stateField != null && fieldDef != null && stateField != fieldDef)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (fieldDef != null)
		{
			stateField = fieldDef;
		}
	}

	protected override void AnalyzeDispose()
	{
		disposeMethod = MethodUtils.GetMethod_Dispose(enumeratorType).FirstOrDefault();
		ILBlock method = CreateILAst(disposeMethod);
		InitializeDisposeMethod(method);
	}

	protected override void AnalyzeMoveNext()
	{
		MethodDef method = MethodUtils.GetMethod_MoveNext(enumeratorType).FirstOrDefault();
		ILBlock iLBlock = CreateILAst(method);
		iteratorMoveNextMethod = method;
		List<ILNode> body = iLBlock.Body;
		if (body.Count == 0)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (stateField == null)
		{
			if (2 >= body.Count || !body[1].Match(ILCode.Stfld, out IField operand, out List<ILExpression> args) || args.Count != 2 || !args[0].MatchThis() || !args[1].MatchLdcI4(-1))
			{
				throw new SymbolicAnalysisFailedException();
			}
			FieldDef fieldDefinition = YieldReturnDecompiler.GetFieldDefinition(operand);
			if (fieldDefinition?.DeclaringType != enumeratorType)
			{
				throw new SymbolicAnalysisFailedException();
			}
			stateField = fieldDefinition;
		}
		disposeInFinallyVar = MonoStateMachineUtils.FindDisposeLocal(iLBlock);
		if (!FindReturnLabels(body, out var bodyLength, out returnFalseLabel, out returnTrueLabel))
		{
			throw new SymbolicAnalysisFailedException();
		}
		MonoStateRangeAnalysis monoStateRangeAnalysis = new MonoStateRangeAnalysis(body[0], StateRangeAnalysisMode.IteratorMoveNext, stateField, disposingField, disposeInFinallyVar);
		int pos = monoStateRangeAnalysis.AssignStateRanges(body, bodyLength);
		monoStateRangeAnalysis.EnsureLabelAtPos(body, ref pos, ref bodyLength);
		labels = monoStateRangeAnalysis.CreateLabelRangeMapping(body, pos, bodyLength);
		stateVariables = monoStateRangeAnalysis.StateVariables;
		ConvertBody(body, pos, bodyLength);
	}

	private bool FindReturnLabels(List<ILNode> body, out int bodyLength, out ILLabel retZeroLabel, out ILLabel retOneLabel)
	{
		bodyLength = 0;
		retZeroLabel = null;
		retOneLabel = null;
		int num = body.Count - 2;
		if (!GetReturnValueLabel(body, num, out var lbl, out var val))
		{
			return false;
		}
		switch (val)
		{
		case 0:
			retZeroLabel = lbl;
			bodyLength = num;
			return true;
		case 1:
			retOneLabel = lbl;
			num -= 2;
			if (!GetReturnValueLabel(body, num, out lbl, out val))
			{
				return false;
			}
			if (val != 0)
			{
				return false;
			}
			retZeroLabel = lbl;
			bodyLength = num;
			return true;
		default:
			return false;
		}
	}

	private bool GetReturnValueLabel(List<ILNode> body, int pos, out ILLabel lbl, out int val)
	{
		lbl = null;
		val = 0;
		if (pos < 0)
		{
			return false;
		}
		lbl = body[pos] as ILLabel;
		if (lbl == null)
		{
			return false;
		}
		if (body[pos + 1].Match(ILCode.Ret, out ILExpression arg))
		{
			return ((ILNode)arg).Match(ILCode.Ldc_I4, out val);
		}
		return false;
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
		ConvertBodyCore(body, newBody, startPos, bodyLength);
		newBody.Add(CreateYieldBreak());
	}

	private List<ILNode> ConvertBodyCore(List<ILNode> body, List<ILNode> newBody, int startPos, int bodyLength)
	{
		int count = labels.Count;
		int state = -1;
		for (int i = startPos; i < bodyLength; i++)
		{
			ILExpression iLExpression = body[i] as ILExpression;
			int operand;
			ILVariable operand2;
			switch (iLExpression?.Code ?? ((ILCode)(-1)))
			{
			case ILCode.Stfld:
			{
				FieldDef fieldDef = (iLExpression.Operand as IField).ResolveFieldWithinSameModule();
				if (fieldDef != null)
				{
					if (fieldDef == currentField && iLExpression.Arguments[0].MatchThis())
					{
						newBody.Add(CreateYieldReturn(iLExpression));
						continue;
					}
					if (fieldDef == stateField && iLExpression.Arguments[0].MatchThis() && ((ILNode)iLExpression.Arguments[1]).Match(ILCode.Ldc_I4, out operand))
					{
						state = operand;
						continue;
					}
				}
				break;
			}
			case ILCode.Brtrue:
			{
				ILExpression iLExpression2 = iLExpression.Arguments[0];
				if (iLExpression2.Code == ILCode.Ldfld && (iLExpression2.Operand as IField).ResolveFieldWithinSameModule() == disposingField && iLExpression2.Arguments[0].MatchThis())
				{
					continue;
				}
				if (disposeInFinallyVar != null && iLExpression2.Code == ILCode.LogicNot && iLExpression2.Arguments[0].MatchLdloc(disposeInFinallyVar))
				{
					if (!body[i + 1].Match(ILCode.Endfinally))
					{
						throw new SymbolicAnalysisFailedException();
					}
					i++;
					continue;
				}
				ILLabel iLLabel = (ILLabel)iLExpression.Operand;
				if (iLLabel == returnFalseLabel || iLLabel == returnTrueLabel)
				{
					ILLabel iLLabel2 = CreateLabel();
					ILLabel item = (ILLabel)(iLExpression.Operand = CreateLabel());
					newBody.Add(iLExpression);
					newBody.Add(new ILExpression(ILCode.Br, iLLabel2));
					newBody.Add(item);
					if (iLLabel == returnFalseLabel)
					{
						newBody.Add(CreateYieldBreak());
					}
					else
					{
						newBody.Add(MakeGoTo(labels, state));
					}
					newBody.Add(iLLabel2);
					continue;
				}
				break;
			}
			case ILCode.Br:
			case ILCode.Leave:
			{
				ILLabel iLLabel = (ILLabel)iLExpression.Operand;
				if (iLLabel == returnFalseLabel)
				{
					newBody.Add(CreateYieldBreak());
					continue;
				}
				if (iLLabel == returnTrueLabel)
				{
					newBody.Add(MakeGoTo(labels, state));
					state = -1;
					continue;
				}
				break;
			}
			case ILCode.Stloc:
				operand2 = (ILVariable)iLExpression.Operand;
				if (operand2 == disposeInFinallyVar)
				{
					if (iLExpression.Arguments[0].MatchLdcI4(1))
					{
						continue;
					}
					throw new SymbolicAnalysisFailedException();
				}
				if (stateVariables.Contains(operand2) && iLExpression.Arguments[0].MatchLdcI4(-3))
				{
					continue;
				}
				break;
			case ILCode.Switch:
			{
				ILExpression iLExpression2 = iLExpression.Arguments[0];
				if (iLExpression2.Code != ILCode.Sub || !((ILNode)iLExpression2.Arguments[0]).Match(ILCode.Ldloc, out operand2) || !((ILNode)iLExpression2.Arguments[1]).Match(ILCode.Ldc_I4, out operand) || !stateVariables.Contains(operand2))
				{
					break;
				}
				ILLabel[] array = (ILLabel[])iLExpression.Operand;
				stateRanges.Clear();
				for (int j = 0; j < array.Length; j++)
				{
					int num = operand + j;
					ILLabel key = array[j];
					if (stateRanges.TryGetValue(key, out var value))
					{
						value.UnionWith(new StateRange(num, num));
						continue;
					}
					value = new StateRange(num, num);
					stateRanges.Add(key, value);
					labels.Add(new KeyValuePair<ILLabel, StateRange>(key, value));
				}
				continue;
			}
			case ILCode.Call:
			{
				if (iLExpression.Arguments.Count != 1 || !iLExpression.Arguments[0].MatchThis())
				{
					break;
				}
				MethodDef methodDef = (iLExpression.Operand as IMethod).ResolveMethodWithinSameModule();
				if (methodDef != disposeMethod && methodDef?.DeclaringType == enumeratorType)
				{
					if (methodDef.IsStatic || methodDef.MethodSig.GetRetType().RemovePinnedAndModifiers().GetElementType() != ElementType.Void)
					{
						throw new SymbolicAnalysisFailedException();
					}
					ILBlock iLBlock = ConvertFinallyBlock(methodDef);
					newBody.AddRange(iLBlock.Body);
					continue;
				}
				break;
			}
			}
			if (iLExpression == null && body[i] is ILTryCatchBlock iLTryCatchBlock)
			{
				if (iLTryCatchBlock.TryBlock != null)
				{
					ConvertBodyCore(ref iLTryCatchBlock.TryBlock.Body);
				}
				foreach (ILTryCatchBlock.CatchBlock catchBlock in iLTryCatchBlock.CatchBlocks)
				{
					ConvertBodyCore(ref catchBlock.Body);
					if (catchBlock.FilterBlock != null)
					{
						ConvertBodyCore(ref catchBlock.FilterBlock.Body);
					}
				}
				if (iLTryCatchBlock.FinallyBlock != null)
				{
					ConvertBodyCore(ref iLTryCatchBlock.FinallyBlock.Body);
				}
				if (iLTryCatchBlock.FaultBlock != null)
				{
					ConvertBodyCore(ref iLTryCatchBlock.FaultBlock.Body);
				}
			}
			newBody.Add(body[i]);
		}
		labels.RemoveRange(count, labels.Count - count);
		return newBody;
	}

	private void ConvertBodyCore(ref List<ILNode> body)
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
		ConvertBodyCore(body, list, 0, body.Count);
		body.Clear();
		freeBodies.Add(body);
		body = list;
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
		ILLabel iLLabel = CreateLabel();
		iLBlock.Body.Add(iLLabel);
		foreach (ILExpression item in iLBlock.GetSelfAndChildrenRecursive<ILExpression>())
		{
			if (item.Code == ILCode.Ret)
			{
				item.Code = ILCode.Br;
				item.Operand = iLLabel;
			}
		}
		return iLBlock;
	}

	private ILLabel CreateLabel()
	{
		return new ILLabel
		{
			Name = "__tmp_lbl_" + labelCounter++
		};
	}
}
