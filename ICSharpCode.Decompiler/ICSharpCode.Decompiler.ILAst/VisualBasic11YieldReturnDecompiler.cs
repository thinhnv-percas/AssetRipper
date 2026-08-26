using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal sealed class VisualBasic11YieldReturnDecompiler : YieldReturnDecompiler
{
	private FieldDef disposingField;

	private ILVariable doFinallyBodiesVar;

	private static readonly UTF8String nameCtor = new UTF8String(".ctor");

	private List<KeyValuePair<ILLabel, StateRange>> labels;

	private List<ILVariable> stateVariables;

	private ILVariable returnVariable;

	private ILLabel returnLabel;

	private ILLabel returnFalseLabel;

	private readonly Dictionary<ILLabel, StateRange> stateRanges = new Dictionary<ILLabel, StateRange>();

	private int tempLabelCounter;

	private readonly List<List<ILNode>> freeBodies = new List<List<ILNode>>();

	public override string CompilerName => "MicrosoftVisualBasic";

	private VisualBasic11YieldReturnDecompiler(DecompilerContext context, AutoPropertyProvider autoPropertyProvider)
		: base(context, autoPropertyProvider)
	{
	}

	public static YieldReturnDecompiler TryCreateCore(DecompilerContext context, ILBlock method, AutoPropertyProvider autoPropertyProvider)
	{
		VisualBasic11YieldReturnDecompiler visualBasic11YieldReturnDecompiler = new VisualBasic11YieldReturnDecompiler(context, autoPropertyProvider);
		if (!visualBasic11YieldReturnDecompiler.MatchEnumeratorCreationPattern(method))
		{
			return null;
		}
		visualBasic11YieldReturnDecompiler.enumeratorType = visualBasic11YieldReturnDecompiler.enumeratorCtor.DeclaringType;
		return visualBasic11YieldReturnDecompiler;
	}

	private bool MatchEnumeratorCreationPattern(ILBlock method)
	{
		List<ILNode> body = method.Body;
		if (body.Count < 3)
		{
			return false;
		}
		if (!body[0].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg))
		{
			return false;
		}
		if (!((ILNode)arg).Match(ILCode.Newobj, out IMethod operand2) || operand2.Name != nameCtor)
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
		if (!body[body.Count - 1].Match(ILCode.Ret, out ILExpression arg2) || !arg2.MatchLdloc(operand))
		{
			return false;
		}
		if (!body[body.Count - 2].Match<IField>(ILCode.Stfld, out var operand3, out arg2, out var arg3) || !arg2.MatchLdloc(operand))
		{
			return false;
		}
		if (!((ILNode)arg3).Match(ILCode.Ldc_I4, out int operand4) || (operand4 != -1 && operand4 != -2))
		{
			return false;
		}
		stateField = YieldReturnDecompiler.GetFieldDefinition(operand3);
		if (stateField.DeclaringType != enumeratorCtor.DeclaringType)
		{
			return false;
		}
		int i = 1;
		if (!InitializeFieldToParameterMap(method, operand, ref i, body.Count - 2))
		{
			return false;
		}
		return true;
	}

	protected override void AnalyzeDispose()
	{
		disposeMethod = MethodUtils.GetMethod_Dispose(enumeratorType).FirstOrDefault();
		ILBlock method = CreateILAst(disposeMethod);
		disposingField = FindDisposingField(method);
		if (disposingField?.DeclaringType != enumeratorType)
		{
			throw new SymbolicAnalysisFailedException();
		}
	}

	private static FieldDef FindDisposingField(ILBlock method)
	{
		List<ILNode> body = method.Body;
		if (body.Count == 0)
		{
			return null;
		}
		if (!body[0].Match<IField>(ILCode.Stfld, out var operand, out var arg, out var arg2) || !arg.MatchThis() || !arg2.MatchLdcI4(1))
		{
			return null;
		}
		return YieldReturnDecompiler.GetFieldDefinition(operand);
	}

	protected override void AnalyzeMoveNext()
	{
		MethodDef method = MethodUtils.GetMethod_MoveNext(enumeratorType).FirstOrDefault();
		ILBlock iLBlock = CreateILAst(method);
		iteratorMoveNextMethod = method;
		List<ILNode> body = iLBlock.Body;
		if (body.Count < 3)
		{
			throw new SymbolicAnalysisFailedException();
		}
		int num = 0;
		if (body[num].Match(ILCode.Stloc, out doFinallyBodiesVar, out ILExpression arg))
		{
			if (!arg.MatchLdcI4(1))
			{
				throw new SymbolicAnalysisFailedException();
			}
			num++;
		}
		if (!(body[num++] is ILTryCatchBlock iLTryCatchBlock))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (iLTryCatchBlock.FinallyBlock != null || iLTryCatchBlock.FaultBlock != null)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (iLTryCatchBlock.CatchBlocks.Count != 1)
		{
			throw new SymbolicAnalysisFailedException();
		}
		ILTryCatchBlock.CatchBlock catchBlock = iLTryCatchBlock.CatchBlocks[0];
		if (catchBlock.FilterBlock != null)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (catchBlock.ExceptionType?.FullName != "System.Exception")
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (catchBlock.Body.Count != 2)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!catchBlock.Body[0].Match<IField>(ILCode.Stfld, out var operand, out var arg2, out arg) || arg.Code != ILCode.Ldc_I4 || !arg2.MatchThis())
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (YieldReturnDecompiler.GetFieldDefinition(operand) != stateField)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!catchBlock.Body[1].Match(ILCode.Rethrow))
		{
			throw new SymbolicAnalysisFailedException();
		}
		ILVariable operand2 = null;
		if (num + 5 <= body.Count)
		{
			returnFalseLabel = body[num++] as ILLabel;
			if (returnFalseLabel == null)
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (!body[num++].Match<IField>(ILCode.Stfld, out operand, out arg2, out arg) || arg.Code != ILCode.Ldc_I4 || !arg2.MatchThis())
			{
				throw new SymbolicAnalysisFailedException();
			}
			if (body[num].Match(ILCode.Ret, out arg) && arg.MatchLdcI4(0))
			{
				num++;
			}
			else
			{
				if (!body[num].Match(ILCode.Stloc, out operand2, out arg) || !arg.MatchLdcI4(0))
				{
					throw new SymbolicAnalysisFailedException();
				}
				num++;
			}
		}
		returnLabel = body[num++] as ILLabel;
		if (returnLabel == null)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (num >= body.Count)
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!body[num++].Match(ILCode.Ret, out arg2))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (!((ILNode)arg2).Match(ILCode.Ldloc, out returnVariable))
		{
			throw new SymbolicAnalysisFailedException();
		}
		if (operand2 != null && operand2 != returnVariable)
		{
			throw new SymbolicAnalysisFailedException();
		}
		body = iLTryCatchBlock.TryBlock.Body;
		int bodyLength = body.Count;
		MicrosoftStateRangeAnalysis microsoftStateRangeAnalysis = new MicrosoftStateRangeAnalysis(body[0], StateRangeAnalysisMode.IteratorMoveNext, stateField);
		num = microsoftStateRangeAnalysis.AssignStateRanges(body, bodyLength);
		microsoftStateRangeAnalysis.EnsureLabelAtPos(body, ref num, ref bodyLength);
		labels = microsoftStateRangeAnalysis.CreateLabelRangeMapping(body, num, bodyLength);
		stateVariables = microsoftStateRangeAnalysis.StateVariables;
		ConvertBody(body, num, bodyLength);
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
			newBody.Add(MakeGoTo(labels, -1));
		}
		ConvertBodyCore(body, body, newBody, startPos, bodyLength);
		newBody.Add(CreateYieldBreak());
	}

	private List<ILNode> ConvertBodyCore(List<ILNode> origTopLevelBody, List<ILNode> body, List<ILNode> newBody, int startPos, int bodyLength)
	{
		int count = labels.Count;
		int state = -1;
		for (int i = startPos; i < bodyLength; i++)
		{
			ILExpression iLExpression = body[i] as ILExpression;
			ILVariable operand3;
			int operand5;
			ILLabel operand4;
			IField operand;
			ILExpression arg2;
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
					state = (int)iLExpression.Arguments[1].Operand;
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
				operand3 = (ILVariable)iLExpression.Operand;
				if (operand3 == returnVariable)
				{
					i++;
					if (!(body[i] is ILExpression { Code: ILCode.Leave } iLExpression3) || iLExpression.Arguments[0].Code != ILCode.Ldc_I4)
					{
						throw new SymbolicAnalysisFailedException();
					}
					if (iLExpression3.Operand != returnLabel)
					{
						throw new SymbolicAnalysisFailedException();
					}
					operand5 = (int)iLExpression.Arguments[0].Operand;
					switch (operand5)
					{
					case 0:
						newBody.Add(CreateYieldBreak());
						break;
					case 1:
						newBody.Add(MakeGoTo(labels, state));
						break;
					default:
						throw new SymbolicAnalysisFailedException();
					}
					continue;
				}
				if (operand3 == doFinallyBodiesVar)
				{
					continue;
				}
				ILExpression arg6;
				ILExpression arg7;
				if (i + 1 < bodyLength && iLExpression.Arguments[0].MatchLdloc(doFinallyBodiesVar))
				{
					if (body[i + 1].Match(ILCode.Brtrue, out operand4, out ILExpression arg4) && ((ILNode)arg4).Match(ILCode.LogicNot, out ILExpression arg5) && arg5.MatchLdloc(operand3))
					{
						i++;
						continue;
					}
				}
				else if (i + 1 < bodyLength && ((ILNode)iLExpression.Arguments[0]).Match(ILCode.Ldfld, out operand, out arg2) && arg2.MatchThis() && YieldReturnDecompiler.GetFieldDefinition(operand) == disposingField && body[i + 1].Match(ILCode.Brtrue, out operand4, out arg6) && ((ILNode)arg6).Match(ILCode.LogicNot, out arg7) && arg7.MatchLdloc(operand3))
				{
					i++;
					newBody.Add(new ILExpression(ILCode.Br, operand4));
					continue;
				}
				break;
			}
			case ILCode.Switch:
			{
				ILExpression iLExpression2 = iLExpression.Arguments[0];
				if (((ILNode)iLExpression2).Match(ILCode.Ldfld, out operand, out arg2) && arg2.MatchThis() && YieldReturnDecompiler.GetFieldDefinition(operand) == stateField)
				{
					operand5 = 0;
				}
				else if ((iLExpression2.Code != ILCode.Sub_Ovf && iLExpression2.Code != ILCode.Sub) || !((ILNode)iLExpression2.Arguments[0]).Match(ILCode.Ldfld, out operand, out arg2) || !arg2.MatchThis() || !((ILNode)iLExpression2.Arguments[1]).Match(ILCode.Ldc_I4, out operand5) || YieldReturnDecompiler.GetFieldDefinition(operand) != stateField)
				{
					continue;
				}
				ILLabel[] array = (ILLabel[])iLExpression.Operand;
				stateRanges.Clear();
				for (int j = 0; j < array.Length; j++)
				{
					int num = operand5 + j;
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
				StateRange stateRange = new StateRange(int.MinValue, operand5 - 1);
				stateRange.UnionWith(new StateRange(operand5 + array.Length, int.MaxValue));
				operand4 = body[i + 1] as ILLabel;
				if (operand4 == null)
				{
					operand4 = CreateTempLabel();
					body.Insert(i + 1, operand4);
					bodyLength++;
				}
				labels.Add(new KeyValuePair<ILLabel, StateRange>(operand4, stateRange));
				continue;
			}
			case ILCode.Leave:
				if (iLExpression.Operand == returnFalseLabel)
				{
					newBody.Add(CreateYieldBreak());
					continue;
				}
				break;
			case ILCode.Brtrue:
			{
				if (!((ILNode)iLExpression.Arguments[0]).Match(ILCode.LogicNot, out ILExpression arg))
				{
					break;
				}
				if (((ILNode)arg).Match(ILCode.Ldfld, out operand, out arg2) && arg2.MatchThis() && YieldReturnDecompiler.GetFieldDefinition(operand) == disposingField)
				{
					ILLabel operand2 = (ILLabel)iLExpression.Operand;
					if (i + 2 < bodyLength && body[i + 1].Match(ILCode.Stloc, out operand3, out ILExpression arg3) && operand3 == returnVariable && arg3.MatchLdcI4(0) && body[i + 2].Match(ILCode.Leave, out operand4) && operand4 == returnLabel)
					{
						i += 2;
					}
					newBody.Add(new ILExpression(ILCode.Br, operand2));
					continue;
				}
				if (doFinallyBodiesVar != null && arg.MatchLdloc(doFinallyBodiesVar))
				{
					continue;
				}
				break;
			}
			}
			if (iLExpression == null && body[i] is ILTryCatchBlock iLTryCatchBlock)
			{
				if (iLTryCatchBlock.TryBlock != null)
				{
					ConvertBodyCore(origTopLevelBody, ref iLTryCatchBlock.TryBlock.Body);
				}
				foreach (ILTryCatchBlock.CatchBlock catchBlock in iLTryCatchBlock.CatchBlocks)
				{
					ConvertBodyCore(origTopLevelBody, ref catchBlock.Body);
					if (catchBlock.FilterBlock != null)
					{
						ConvertBodyCore(origTopLevelBody, ref catchBlock.FilterBlock.Body);
					}
				}
				if (iLTryCatchBlock.FinallyBlock != null)
				{
					ConvertBodyCore(origTopLevelBody, ref iLTryCatchBlock.FinallyBlock.Body);
				}
				if (iLTryCatchBlock.FaultBlock != null)
				{
					ConvertBodyCore(origTopLevelBody, ref iLTryCatchBlock.FaultBlock.Body);
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
}
