using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

public class ILInlining
{
	private ILBlock method;

	internal readonly Dictionary<ILVariable, int> numStloc = new Dictionary<ILVariable, int>();

	internal readonly Dictionary<ILVariable, int> numLdloc = new Dictionary<ILVariable, int>();

	internal readonly Dictionary<ILVariable, int> numLdloca = new Dictionary<ILVariable, int>();

	private readonly List<ILBlock> list_ILBlock = new List<ILBlock>();

	private readonly List<ILExpression> list_ILExpression = new List<ILExpression>();

	private readonly List<ILNode> list_ILNode = new List<ILNode>();

	private readonly DecompilerContext context;

	private ILInlining cached_ILInlining;

	public ILInlining(DecompilerContext context)
	{
		this.context = context;
	}

	public void Initialize(ILBlock method)
	{
		this.method = method;
		AnalyzeMethod();
	}

	public void Initialize(List<ILNode> body, int start, int count)
	{
		method = null;
		numStloc.Clear();
		numLdloc.Clear();
		numLdloca.Clear();
		for (int i = 0; i < count; i++)
		{
			AnalyzeNode(body[i + start]);
		}
	}

	private void AnalyzeMethod()
	{
		numStloc.Clear();
		numLdloc.Clear();
		numLdloca.Clear();
		AnalyzeNode(method);
	}

	private void AnalyzeNode(ILNode node, int direction = 1)
	{
		if (node is ILExpression iLExpression)
		{
			if (iLExpression.Operand is ILVariable key)
			{
				if (iLExpression.Code == ILCode.Stloc)
				{
					numStloc[key] = numStloc.GetOrDefault(key) + direction;
				}
				else if (iLExpression.Code == ILCode.Ldloc)
				{
					numLdloc[key] = numLdloc.GetOrDefault(key) + direction;
				}
				else
				{
					if (iLExpression.Code != ILCode.Ldloca)
					{
						throw new NotSupportedException(iLExpression.Code.ToString());
					}
					numLdloca[key] = numLdloca.GetOrDefault(key) + direction;
				}
			}
			{
				foreach (ILExpression argument in iLExpression.Arguments)
				{
					AnalyzeNode(argument, direction);
				}
				return;
			}
		}
		if (node is ILTryCatchBlock.CatchBlockBase { ExceptionVariable: not null } catchBlockBase)
		{
			numStloc[catchBlockBase.ExceptionVariable] = numStloc.GetOrDefault(catchBlockBase.ExceptionVariable) + direction;
		}
		foreach (ILNode child in node.GetChildren())
		{
			AnalyzeNode(child, direction);
		}
	}

	public bool InlineAllVariables()
	{
		bool flag = false;
		ILInlining iLInlining = GetILInlining(method);
		foreach (ILBlock item in method.GetSelfAndChildrenRecursive(list_ILBlock))
		{
			flag |= iLInlining.InlineAllInBlock(item);
		}
		return flag;
	}

	private ILInlining GetILInlining(ILBlock method)
	{
		if (cached_ILInlining == null)
		{
			cached_ILInlining = new ILInlining(context);
		}
		cached_ILInlining.Initialize(method);
		return cached_ILInlining;
	}

	public bool InlineAllInBlock(ILBlock block)
	{
		bool flag = false;
		List<ILNode> body = block.Body;
		if (block is ILTryCatchBlock.CatchBlockBase && body.Count > 1)
		{
			ILVariable exceptionVariable = ((ILTryCatchBlock.CatchBlockBase)block).ExceptionVariable;
			if (exceptionVariable != null && exceptionVariable.GeneratedByDecompiler && numLdloca.GetOrDefault(exceptionVariable) == 0 && numStloc.GetOrDefault(exceptionVariable) == 1 && numLdloc.GetOrDefault(exceptionVariable) == 1 && body[0].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && arg.MatchLdloc(exceptionVariable))
			{
				if (context.CalculateILSpans)
				{
					body[0].AddSelfAndChildrenRecursiveILSpans(((ILTryCatchBlock.CatchBlockBase)block).StlocILSpans);
				}
				body.RemoveAt(0);
				((ILTryCatchBlock.CatchBlockBase)block).ExceptionVariable = operand;
				flag = true;
			}
		}
		int num = 0;
		while (num < body.Count - 1)
		{
			if (body[num].Match(ILCode.Stloc, out ILVariable _, out ILExpression _) && InlineOneIfPossible(block, block.Body, num, aggressive: false))
			{
				flag = true;
				num = Math.Max(0, num - 1);
			}
			else
			{
				num++;
			}
		}
		foreach (ILBasicBlock item in body.OfType<ILBasicBlock>())
		{
			flag |= InlineAllInBasicBlock(item);
		}
		return flag;
	}

	public bool InlineAllInBasicBlock(ILBasicBlock bb)
	{
		bool result = false;
		List<ILNode> body = bb.Body;
		int num = 0;
		while (num < body.Count)
		{
			if (body[num].Match(ILCode.Stloc, out ILVariable _, out ILExpression _) && InlineOneIfPossible(bb, bb.Body, num, aggressive: false))
			{
				result = true;
				num = Math.Max(0, num - 1);
			}
			else
			{
				num++;
			}
		}
		return result;
	}

	public int InlineInto(ILBlockBase block, List<ILNode> body, int pos, bool aggressive)
	{
		if (pos >= body.Count)
		{
			return 0;
		}
		int num = 0;
		while (--pos >= 0 && body[pos] is ILExpression { Code: ILCode.Stloc } && InlineOneIfPossible(block, body, pos, aggressive))
		{
			num++;
		}
		return num;
	}

	public bool InlineIfPossible(ILBlockBase block, List<ILNode> body, ref int pos)
	{
		if (InlineOneIfPossible(block, body, pos, aggressive: true))
		{
			pos -= InlineInto(block, body, pos, aggressive: false);
			return true;
		}
		return false;
	}

	public bool InlineOneIfPossible(ILBlockBase block, List<ILNode> body, int pos, bool aggressive)
	{
		if (body[pos].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && !operand.IsPinned)
		{
			if (InlineIfPossible(operand, arg, body.ElementAtOrDefault(pos + 1), aggressive))
			{
				if (context.CalculateILSpans)
				{
					arg.ILSpans.AddRange(body[pos].ILSpans);
				}
				body.RemoveAt(pos);
				return true;
			}
			if (numLdloc.GetOrDefault(operand) == 0 && numLdloca.GetOrDefault(operand) == 0)
			{
				if (arg.HasNoSideEffects())
				{
					AnalyzeNode(body[pos], -1);
					if (context.CalculateILSpans)
					{
						Utils.AddILSpans(block, body, pos);
					}
					body.RemoveAt(pos);
					return true;
				}
				if (arg.CanBeExpressionStatement() && operand.GeneratedByDecompiler)
				{
					if (context.CalculateILSpans)
					{
						arg.ILSpans.AddRange(body[pos].ILSpans);
					}
					body[pos] = arg;
					return true;
				}
			}
		}
		return false;
	}

	private bool InlineIfPossible(ILVariable v, ILExpression inlinedExpression, ILNode next, bool aggressive)
	{
		if (numStloc.GetOrDefault(v) != 1)
		{
			return false;
		}
		int orDefault = numLdloc.GetOrDefault(v);
		if (orDefault > 1 || orDefault + numLdloca.GetOrDefault(v) != 1)
		{
			return false;
		}
		if (next is ILCondition)
		{
			next = ((ILCondition)next).Condition;
		}
		else if (next is ILWhileLoop)
		{
			next = ((ILWhileLoop)next).Condition;
		}
		if (FindLoadInNext(next as ILExpression, v, inlinedExpression, out var parent, out var pos) == true)
		{
			if (orDefault == 0)
			{
				if (!IsGeneratedValueTypeTemporary((ILExpression)next, parent, pos, v, inlinedExpression))
				{
					return false;
				}
			}
			else if (!aggressive && !v.GeneratedByDecompiler && !NonAggressiveInlineInto((ILExpression)next, parent, inlinedExpression))
			{
				return false;
			}
			if (context.CalculateILSpans)
			{
				parent.Arguments[pos].AddSelfAndChildrenRecursiveILSpans(inlinedExpression.ILSpans);
			}
			if (orDefault == 0)
			{
				parent.Arguments[pos] = new ILExpression(ILCode.AddressOf, null, inlinedExpression);
			}
			else
			{
				parent.Arguments[pos] = inlinedExpression;
			}
			return true;
		}
		return false;
	}

	private bool IsGeneratedValueTypeTemporary(ILExpression next, ILExpression parent, int pos, ILVariable v, ILExpression inlinedExpression)
	{
		if (pos == 0 && v.Type != null && DnlibExtensions.IsValueType(v.Type))
		{
			switch (inlinedExpression.Code)
			{
			case ILCode.Ldind_Ref:
			case ILCode.Ldobj:
			case ILCode.Ldelem_I1:
			case ILCode.Ldelem_U1:
			case ILCode.Ldelem_I2:
			case ILCode.Ldelem_U2:
			case ILCode.Ldelem_I4:
			case ILCode.Ldelem_U4:
			case ILCode.Ldelem_I8:
			case ILCode.Ldelem_I:
			case ILCode.Ldelem_R4:
			case ILCode.Ldelem_R8:
			case ILCode.Ldelem_Ref:
			case ILCode.Ldelem:
			case ILCode.Ldloc:
			case ILCode.Stloc:
			case ILCode.CompoundAssignment:
				return false;
			case ILCode.Ldfld:
			case ILCode.Stfld:
			case ILCode.Ldsfld:
			case ILCode.Stsfld:
			{
				FieldDef fieldDef = ((IField)inlinedExpression.Operand).Resolve();
				if (fieldDef == null || !fieldDef.IsInitOnly)
				{
					return false;
				}
				break;
			}
			case ILCode.Call:
			case ILCode.CallGetter:
			{
				IMethod method = (IMethod)inlinedExpression.Operand;
				TypeSpec obj = method.DeclaringType as TypeSpec;
				if (obj != null && obj.TypeSig.RemovePinnedAndModifiers()?.IsSingleOrMultiDimensionalArray == true)
				{
					return false;
				}
				goto case ILCode.Callvirt;
			}
			case ILCode.Callvirt:
			case ILCode.CallvirtGetter:
			{
				IMethod method = (IMethod)inlinedExpression.Operand;
				if (method.Name == "get_Current" && method.MethodSig != null && method.MethodSig.HasThis)
				{
					return false;
				}
				break;
			}
			case ILCode.Castclass:
			case ILCode.Unbox_Any:
			{
				ILExpression iLExpression = inlinedExpression.Arguments[0];
				if (iLExpression.Code == ILCode.CallGetter || iLExpression.Code == ILCode.CallvirtGetter || iLExpression.Code == ILCode.Call || iLExpression.Code == ILCode.Callvirt)
				{
					IMethod method = (IMethod)iLExpression.Operand;
					if (method.Name == "get_Current" && method.MethodSig != null && method.MethodSig.HasThis)
					{
						return false;
					}
				}
				break;
			}
			}
			switch (parent.Code)
			{
			case ILCode.Call:
			case ILCode.Callvirt:
			case ILCode.CallGetter:
			case ILCode.CallvirtGetter:
			case ILCode.CallSetter:
			case ILCode.CallvirtSetter:
			case ILCode.CallReadOnlySetter:
			{
				IMethod obj2 = parent.Operand as IMethod;
				if (obj2 == null)
				{
					return false;
				}
				return obj2.MethodSig?.HasThis == true;
			}
			case ILCode.Ldfld:
			case ILCode.Ldflda:
			case ILCode.Stfld:
			case ILCode.Await:
				return true;
			}
		}
		return false;
	}

	private bool NonAggressiveInlineInto(ILExpression next, ILExpression parent, ILExpression inlinedExpression)
	{
		if (inlinedExpression.Code == ILCode.DefaultValue)
		{
			return true;
		}
		switch (next.Code)
		{
		case ILCode.Ret:
		case ILCode.Brtrue:
			return parent == next;
		case ILCode.Switch:
			if (parent != next)
			{
				if (parent.Code == ILCode.Sub)
				{
					return parent == next.Arguments[0];
				}
				return false;
			}
			return true;
		default:
			return false;
		}
	}

	public bool CanInlineInto(ILExpression expr, ILVariable v, ILExpression expressionBeingMoved)
	{
		ILExpression parent;
		int pos;
		return FindLoadInNext(expr, v, expressionBeingMoved, out parent, out pos) == true;
	}

	private bool? FindLoadInNext(ILExpression expr, ILVariable v, ILExpression expressionBeingMoved, out ILExpression parent, out int pos)
	{
		parent = null;
		pos = 0;
		if (expr == null)
		{
			return false;
		}
		for (int i = 0; i < expr.Arguments.Count; i++)
		{
			if (i == 1 && (expr.Code == ILCode.LogicAnd || expr.Code == ILCode.LogicOr || expr.Code == ILCode.TernaryOp || expr.Code == ILCode.NullCoalescing))
			{
				return false;
			}
			ILExpression iLExpression = expr.Arguments[i];
			if ((iLExpression.Code == ILCode.Ldloc || iLExpression.Code == ILCode.Ldloca) && iLExpression.Operand == v)
			{
				parent = expr;
				pos = i;
				return true;
			}
			bool? result = FindLoadInNext(iLExpression, v, expressionBeingMoved, out parent, out pos);
			if (result.HasValue)
			{
				return result;
			}
		}
		if (IsSafeForInlineOver(expr, expressionBeingMoved))
		{
			return null;
		}
		return false;
	}

	private bool IsSafeForInlineOver(ILExpression expr, ILExpression expressionBeingMoved)
	{
		switch (expr.Code)
		{
		case ILCode.Ldloc:
		{
			ILVariable iLVariable = (ILVariable)expr.Operand;
			if (numLdloca.GetOrDefault(iLVariable) != 0)
			{
				return false;
			}
			foreach (ILExpression item in expressionBeingMoved.GetSelfAndChildrenRecursive(list_ILExpression))
			{
				if (item.Code == ILCode.Stloc && item.Operand == iLVariable)
				{
					return false;
				}
			}
			return true;
		}
		case ILCode.Ldflda:
		case ILCode.Ldsflda:
		case ILCode.Ldelema:
		case ILCode.Ldloca:
		case ILCode.AddressOf:
		case ILCode.ValueOf:
		case ILCode.NullableOf:
			foreach (ILExpression argument in expr.Arguments)
			{
				if (!IsSafeForInlineOver(argument, expressionBeingMoved))
				{
					return false;
				}
			}
			return true;
		default:
			return expr.HasNoSideEffects();
		}
	}

	public void CopyPropagation(List<ILNode> newList)
	{
		List<ILNode> list = newList;
		method.GetSelfAndChildrenRecursive(newList);
		bool flag = false;
		foreach (ILNode @new in newList)
		{
			if (!(@new is ILBlock iLBlock))
			{
				continue;
			}
			for (int i = 0; i < iLBlock.Body.Count; i++)
			{
				if (!iLBlock.Body[i].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) || operand.IsParameter || operand.OriginalVariable?.Type.RemovePinnedAndModifiers() is ByRefSig || numStloc.GetOrDefault(operand) != 1 || numLdloca.GetOrDefault(operand) != 0 || !CanPerformCopyPropagation(arg, operand))
				{
					continue;
				}
				ILVariable[] array = new ILVariable[arg.Arguments.Count];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = new ILVariable(operand.Name + "_cp_" + j)
					{
						GeneratedByDecompiler = true
					};
					iLBlock.Body.Insert(i++, new ILExpression(ILCode.Stloc, array[j], arg.Arguments[j]));
					flag = true;
				}
				foreach (ILNode item in list)
				{
					if (item is ILExpression { Code: ILCode.Ldloc } iLExpression && iLExpression.Operand == operand)
					{
						iLExpression.Code = arg.Code;
						iLExpression.Operand = arg.Operand;
						for (int k = 0; k < array.Length; k++)
						{
							iLExpression.Arguments.Add(new ILExpression(ILCode.Ldloc, array[k]));
						}
					}
				}
				if (context.CalculateILSpans)
				{
					Utils.AddILSpans(iLBlock, iLBlock.Body, i, iLBlock.Body[i].ILSpans);
					Utils.AddILSpans(iLBlock, iLBlock.Body, i, arg.ILSpans);
				}
				iLBlock.Body.RemoveAt(i);
				if (array.Length != 0)
				{
					AnalyzeMethod();
				}
				InlineInto(iLBlock, iLBlock.Body, i, aggressive: false);
				i -= array.Length + 1;
				if (flag)
				{
					flag = false;
					list = method.GetSelfAndChildrenRecursive((list != newList) ? list : (list = list_ILNode));
				}
			}
		}
	}

	private bool CanPerformCopyPropagation(ILExpression expr, ILVariable copyVariable)
	{
		switch (expr.Code)
		{
		case ILCode.Ldflda:
		case ILCode.Ldsflda:
		case ILCode.Ldelema:
		case ILCode.Ldloca:
			return true;
		case ILCode.Ldloc:
		{
			ILVariable iLVariable = (ILVariable)expr.Operand;
			if (iLVariable.IsParameter)
			{
				if (numLdloca.GetOrDefault(iLVariable) == 0)
				{
					return numStloc.GetOrDefault(iLVariable) == 0;
				}
				return false;
			}
			if (iLVariable.GeneratedByDecompiler && copyVariable.GeneratedByDecompiler && numLdloca.GetOrDefault(iLVariable) == 0)
			{
				return numStloc.GetOrDefault(iLVariable) == 1;
			}
			return false;
		}
		default:
			return false;
		}
	}
}
