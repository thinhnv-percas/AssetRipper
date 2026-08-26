using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;

namespace ICSharpCode.Decompiler.ILAst;

public class SimpleControlFlow
{
	private readonly Dictionary<ILLabel, int> labelGlobalRefCount = new Dictionary<ILLabel, int>();

	private readonly Dictionary<ILLabel, ILBasicBlock> labelToBasicBlock = new Dictionary<ILLabel, ILBasicBlock>();

	private readonly List<ILExpression> List_ILExpression = new List<ILExpression>();

	private readonly List<ILBasicBlock> List_ILBasicBlock = new List<ILBasicBlock>();

	private DecompilerContext context;

	private ICorLibTypes corLib;

	public SimpleControlFlow(DecompilerContext context, ILBlock method)
	{
		Initialize(context, method);
	}

	public void Initialize(DecompilerContext context, ILBlock method)
	{
		labelGlobalRefCount.Clear();
		labelToBasicBlock.Clear();
		this.context = context;
		corLib = context.CurrentMethod.Module.CorLibTypes;
		foreach (ILExpression item in method.GetSelfAndChildrenRecursive(List_ILExpression, (ILExpression e) => e.IsBranch()))
		{
			foreach (ILLabel branchTarget in item.GetBranchTargets())
			{
				labelGlobalRefCount[branchTarget] = labelGlobalRefCount.GetOrDefault(branchTarget) + 1;
			}
		}
		foreach (ILBasicBlock item2 in method.GetSelfAndChildrenRecursive(List_ILBasicBlock))
		{
			int index = 0;
			while (item2.GetNext(ref index) is ILLabel key)
			{
				labelToBasicBlock[key] = item2;
			}
		}
	}

	public bool SimplifyTernaryOperator(List<ILNode> body, ILBasicBlock head, int pos)
	{
		ILVariable operand = null;
		ILVariable operand2 = null;
		if (head.MatchLastAndBr<ILLabel>(ILCode.Brtrue, out var operand3, out var arg, out var brLabel) && labelGlobalRefCount[operand3] == 1 && labelGlobalRefCount[brLabel] == 1 && ((labelToBasicBlock[operand3].MatchSingleAndBr<ILVariable>(ILCode.Stloc, out operand, out var arg2, out var brLabel2) && labelToBasicBlock[brLabel].MatchSingleAndBr<ILVariable>(ILCode.Stloc, out operand2, out var arg3, out var brLabel3) && operand == operand2 && brLabel2 == brLabel3) || (labelToBasicBlock[operand3].MatchSingle<object>(ILCode.Ret, out var operand4, out arg2) && labelToBasicBlock[brLabel].MatchSingle<object>(ILCode.Ret, out operand4, out arg3))) && body.Contains(labelToBasicBlock[operand3]) && body.Contains(labelToBasicBlock[brLabel]))
		{
			bool flag = operand != null;
			ILCode iLCode = (flag ? ILCode.Stloc : ILCode.Ret);
			TypeSig a = (flag ? operand.Type : context.CurrentMethod.ReturnType);
			bool flag2 = a.GetElementType() == ElementType.Boolean;
			ILExpression iLExpression;
			if (flag2 && ((ILNode)arg2).Match(ILCode.Ldc_I4, out int operand5) && ((ILNode)arg3).Match(ILCode.Ldc_I4, out int operand6) && ((operand5 != 0 && operand6 == 0) || (operand5 == 0 && operand6 != 0)))
			{
				iLExpression = ((operand5 == 0) ? new ILExpression(ILCode.LogicNot, null, arg)
				{
					InferredType = corLib.Boolean
				} : arg);
			}
			else if ((flag2 || arg3.InferredType.GetElementType() == ElementType.Boolean) && ((ILNode)arg2).Match(ILCode.Ldc_I4, out operand5) && (operand5 == 0 || operand5 == 1))
			{
				iLExpression = ((operand5 == 0) ? MakeLeftAssociativeShortCircuit(ILCode.LogicAnd, new ILExpression(ILCode.LogicNot, null, arg), arg3) : MakeLeftAssociativeShortCircuit(ILCode.LogicOr, arg, arg3));
			}
			else if ((flag2 || arg2.InferredType.GetElementType() == ElementType.Boolean) && ((ILNode)arg3).Match(ILCode.Ldc_I4, out operand6) && (operand6 == 0 || operand6 == 1))
			{
				iLExpression = ((operand6 == 0) ? MakeLeftAssociativeShortCircuit(ILCode.LogicAnd, arg, arg2) : MakeLeftAssociativeShortCircuit(ILCode.LogicOr, new ILExpression(ILCode.LogicNot, null, arg), arg2));
			}
			else
			{
				switch (iLCode)
				{
				case ILCode.Ret:
					return false;
				case ILCode.Stloc:
					if (!operand.GeneratedByDecompiler)
					{
						return false;
					}
					break;
				}
				iLExpression = new ILExpression(ILCode.TernaryOp, null, arg, arg2, arg3);
			}
			ILNode[] array = head.Body.RemoveTail(ILCode.Brtrue, ILCode.Br);
			if (context.CalculateILSpans)
			{
				List<ILNode> result = new List<ILNode>();
				ILNode[] second = iLExpression.GetSelfAndChildrenRecursive(result).ToArray();
				foreach (ILNode item in labelToBasicBlock[operand3].GetSelfAndChildrenRecursive(result).Except(second))
				{
					long index = 0L;
					bool done = false;
					while (true)
					{
						ILSpan allILSpans = item.GetAllILSpans(ref index, ref done);
						if (done)
						{
							break;
						}
						iLExpression.ILSpans.Add(allILSpans);
					}
				}
				foreach (ILNode item2 in labelToBasicBlock[brLabel].GetSelfAndChildrenRecursive(result).Except(second))
				{
					long index2 = 0L;
					bool done2 = false;
					while (true)
					{
						ILSpan allILSpans2 = item2.GetAllILSpans(ref index2, ref done2);
						if (done2)
						{
							break;
						}
						iLExpression.ILSpans.Add(allILSpans2);
					}
				}
				iLExpression.ILSpans.AddRange(array[0].ILSpans);
				array[1].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
			}
			head.Body.Add(new ILExpression(iLCode, operand, iLExpression));
			if (flag)
			{
				head.Body.Add(new ILExpression(ILCode.Br, brLabel2));
			}
			body.RemoveOrThrow(labelToBasicBlock[operand3]);
			body.RemoveOrThrow(labelToBasicBlock[brLabel]);
			return true;
		}
		return false;
	}

	public bool SimplifyNullCoalescing(List<ILNode> body, ILBasicBlock head, int pos)
	{
		if (head.Body.Count >= 3 && head.Body[head.Body.Count - 3].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && ((ILNode)arg).Match(ILCode.Ldloc, out ILVariable operand2) && head.MatchLastAndBr<ILLabel>(ILCode.Brtrue, out var operand3, out var arg2, out var brLabel) && arg2.MatchLdloc(operand2) && labelToBasicBlock.TryGetValue(brLabel, out var value) && value.MatchSingleAndBr<ILVariable>(ILCode.Stloc, out var operand4, out var arg3, out var brLabel2) && operand == operand4 && operand3 == brLabel2 && labelGlobalRefCount.GetOrDefault(brLabel) == 1 && body.Contains(value))
		{
			ILNode[] array = head.Body.RemoveTail(ILCode.Stloc, ILCode.Brtrue, ILCode.Br);
			ILExpression iLExpression;
			ILExpression iLExpression2;
			head.Body.Add(iLExpression = new ILExpression(ILCode.Stloc, operand, iLExpression2 = new ILExpression(ILCode.NullCoalescing, null, arg, arg3)));
			head.Body.Add(new ILExpression(ILCode.Br, operand3));
			if (context.CalculateILSpans)
			{
				array[0].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
				array[1].AddSelfAndChildrenRecursiveILSpans(iLExpression2.ILSpans);
				array[2].AddSelfAndChildrenRecursiveILSpans(arg3.ILSpans);
				long index = 0L;
				bool done = false;
				while (true)
				{
					ILSpan allILSpans = value.GetAllILSpans(ref index, ref done);
					if (done)
					{
						break;
					}
					arg3.ILSpans.Add(allILSpans);
				}
				value.Body[0].AddSelfAndChildrenRecursiveILSpans(arg3.ILSpans);
				arg3.ILSpans.AddRange(value.Body[1].ILSpans);
				value.Body[2].AddSelfAndChildrenRecursiveILSpans(arg3.ILSpans);
			}
			body.RemoveOrThrow(labelToBasicBlock[brLabel]);
			return true;
		}
		return false;
	}

	public bool SimplifyShortCircuit(List<ILNode> body, ILBasicBlock head, int pos)
	{
		if (head.MatchLastAndBr<ILLabel>(ILCode.Brtrue, out var operand, out var arg, out var brLabel))
		{
			for (int i = 0; i < 2; i++)
			{
				ILLabel key = ((i == 0) ? operand : brLabel);
				ILLabel iLLabel = ((i == 0) ? brLabel : operand);
				bool flag = i == 1;
				ILBasicBlock iLBasicBlock = labelToBasicBlock[key];
				if (body.Contains(iLBasicBlock) && iLBasicBlock != head && labelGlobalRefCount[(ILLabel)iLBasicBlock.Body.First()] == 1 && iLBasicBlock.MatchSingleAndBr<ILLabel>(ILCode.Brtrue, out var operand2, out var arg2, out var brLabel2) && (iLLabel == brLabel2 || iLLabel == operand2))
				{
					ILExpression arg3 = ((iLLabel != brLabel2) ? MakeLeftAssociativeShortCircuit(ILCode.LogicOr, flag ? arg : new ILExpression(ILCode.LogicNot, null, arg), arg2) : MakeLeftAssociativeShortCircuit(ILCode.LogicAnd, flag ? new ILExpression(ILCode.LogicNot, null, arg) : arg, arg2));
					ILNode[] array = head.Body.RemoveTail(ILCode.Brtrue, ILCode.Br);
					if (context.CalculateILSpans)
					{
						arg2.ILSpans.AddRange(array[0].ILSpans);
						arg2.ILSpans.AddRange(iLBasicBlock.ILSpans);
						iLBasicBlock.Body[0].AddSelfAndChildrenRecursiveILSpans(arg2.ILSpans);
						arg2.ILSpans.AddRange(iLBasicBlock.Body[1].ILSpans);
					}
					head.Body.Add(new ILExpression(ILCode.Brtrue, operand2, arg3));
					ILExpression iLExpression;
					head.Body.Add(iLExpression = new ILExpression(ILCode.Br, brLabel2));
					if (context.CalculateILSpans)
					{
						iLBasicBlock.Body[2].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
						iLExpression.ILSpans.AddRange(iLBasicBlock.EndILSpans);
						array[1].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
					}
					body.RemoveOrThrow(iLBasicBlock);
					return true;
				}
			}
		}
		return false;
	}

	public bool SimplifyCustomShortCircuit(List<ILNode> body, ILBasicBlock head, int pos)
	{
		if (head.Body.Count < 3)
		{
			return false;
		}
		if (!head.Body[head.Body.Count - 3].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg))
		{
			return false;
		}
		if (!((ILNode)arg).Match(ILCode.Ldloc, out ILVariable operand2))
		{
			return false;
		}
		if (!head.MatchLastAndBr<ILLabel>(ILCode.Brtrue, out var operand3, out var arg2, out var brLabel))
		{
			return false;
		}
		if (labelGlobalRefCount[brLabel] > 1)
		{
			return false;
		}
		if (!((ILNode)arg2).Match(ILCode.Call, out IMethod operand4, out ILExpression arg3))
		{
			return false;
		}
		if (operand4.Name != "op_False" && operand4.Name != "op_True")
		{
			return false;
		}
		if (!arg3.MatchLdloc(operand2))
		{
			return false;
		}
		ILBasicBlock iLBasicBlock = labelToBasicBlock[brLabel];
		if (!iLBasicBlock.MatchSingleAndBr<ILVariable>(ILCode.Stloc, out var operand5, out var arg4, out var brLabel2))
		{
			return false;
		}
		if (operand5 != operand || operand3 != brLabel2)
		{
			return false;
		}
		if (!arg4.Match<IMethod>(ILCode.Call, out var operand6, out var arg5, out var arg6))
		{
			return false;
		}
		if (!arg5.MatchLdloc(operand2))
		{
			return false;
		}
		if (operand6.Name != "op_BitwiseAnd" && operand6.Name != "op_BitwiseOr")
		{
			return false;
		}
		ILCode iLCode = ((operand6.Name == "op_BitwiseAnd") ? ILCode.LogicAnd : ILCode.LogicOr);
		if (iLCode == ILCode.LogicAnd && operand4.Name != "op_False")
		{
			return false;
		}
		if (iLCode == ILCode.LogicOr && operand4.Name != "op_True")
		{
			return false;
		}
		ILExpression iLExpression = MakeLeftAssociativeShortCircuit(iLCode, arg3, arg6);
		iLExpression.Operand = operand6;
		ILNode[] array = head.Body.RemoveTail(ILCode.Stloc, ILCode.Brtrue, ILCode.Br);
		head.Body.Add(new ILExpression(ILCode.Stloc, operand, iLExpression));
		head.Body.Add(new ILExpression(ILCode.Br, operand3));
		body.Remove(iLBasicBlock);
		return true;
	}

	private ILExpression MakeLeftAssociativeShortCircuit(ILCode code, ILExpression left, ILExpression right)
	{
		if (right.Match(code))
		{
			ILExpression iLExpression = right;
			while (iLExpression.Arguments[0].Match(code))
			{
				iLExpression = iLExpression.Arguments[0];
			}
			if (context.CalculateILSpans)
			{
				iLExpression.Arguments[0].AddSelfAndChildrenRecursiveILSpans(iLExpression.ILSpans);
			}
			iLExpression.Arguments[0] = new ILExpression(code, null, left, iLExpression.Arguments[0])
			{
				InferredType = corLib.Boolean
			};
			return right;
		}
		return new ILExpression(code, null, left, right)
		{
			InferredType = corLib.Boolean
		};
	}

	public bool JoinBasicBlocks(List<ILNode> body, ILBasicBlock head, int pos)
	{
		if (!head.Body.ElementAtOrDefault(head.Body.Count - 2).IsConditionalControlFlow() && head.Body.Last().Match(ILCode.Br, out ILLabel operand) && labelGlobalRefCount[operand] == 1 && labelToBasicBlock.TryGetValue(operand, out var value) && body.Contains(value) && value.Body.First() == operand && !value.Body.OfType<ILTryCatchBlock>().Any())
		{
			ILNode[] array = head.Body.RemoveTail(ILCode.Br);
			if (context.CalculateILSpans)
			{
				array[0].AddSelfAndChildrenRecursiveILSpans(value.ILSpans);
				value.Body[0].AddSelfAndChildrenRecursiveILSpans(value.ILSpans);
			}
			value.Body.RemoveAt(0);
			if (context.CalculateILSpans)
			{
				if (head.Body.Count > 0)
				{
					head.Body[head.Body.Count - 1].EndILSpans.AddRange(value.ILSpans);
				}
				else
				{
					head.ILSpans.AddRange(value.ILSpans);
				}
				head.EndILSpans.AddRange(value.EndILSpans);
			}
			head.Body.AddRange(value.Body);
			body.RemoveOrThrow(value);
			return true;
		}
		return false;
	}
}
