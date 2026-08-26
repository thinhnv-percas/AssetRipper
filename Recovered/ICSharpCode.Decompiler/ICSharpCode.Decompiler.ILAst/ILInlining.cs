using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public class ILInlining
	{
		private readonly ILBlock method;

		internal Dictionary<ILVariable, int> numStloc = new Dictionary<ILVariable, int>();

		internal Dictionary<ILVariable, int> numLdloc = new Dictionary<ILVariable, int>();

		internal Dictionary<ILVariable, int> numLdloca = new Dictionary<ILVariable, int>();

		public ILInlining(ILBlock method)
		{
			this.method = method;
			AnalyzeMethod();
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
			ILExpression iLExpression = node as ILExpression;
			if (iLExpression != null)
			{
				ILVariable iLVariable = iLExpression.Operand as ILVariable;
				if (iLVariable != null)
				{
					if (iLExpression.Code == ILCode.Stloc)
					{
						numStloc[iLVariable] = numStloc.GetOrDefault(iLVariable) + direction;
					}
					else if (iLExpression.Code == ILCode.Ldloc)
					{
						numLdloc[iLVariable] = numLdloc.GetOrDefault(iLVariable) + direction;
					}
					else
					{
						if (iLExpression.Code != ILCode.Ldloca)
						{
							throw new NotSupportedException(iLExpression.Code.ToString());
						}
						numLdloca[iLVariable] = numLdloca.GetOrDefault(iLVariable) + direction;
					}
				}
				foreach (ILExpression argument in iLExpression.Arguments)
				{
					AnalyzeNode(argument, direction);
				}
			}
			else
			{
				ILTryCatchBlock.CatchBlock catchBlock = node as ILTryCatchBlock.CatchBlock;
				if (catchBlock != null && catchBlock.ExceptionVariable != null)
				{
					numStloc[catchBlock.ExceptionVariable] = numStloc.GetOrDefault(catchBlock.ExceptionVariable) + direction;
				}
				foreach (ILNode child in node.GetChildren())
				{
					AnalyzeNode(child, direction);
				}
			}
		}

		public bool InlineAllVariables()
		{
			bool flag = false;
			ILInlining iLInlining = new ILInlining(method);
			foreach (ILBlock item in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				flag |= iLInlining.InlineAllInBlock(item);
			}
			return flag;
		}

		public bool InlineAllInBlock(ILBlock block)
		{
			bool flag = false;
			List<ILNode> body = block.Body;
			if (block is ILTryCatchBlock.CatchBlock && body.Count > 1)
			{
				ILVariable exceptionVariable = ((ILTryCatchBlock.CatchBlock)block).ExceptionVariable;
				ILExpression arg;
				if (exceptionVariable != null && exceptionVariable.IsGenerated && numLdloca.GetOrDefault(exceptionVariable) == 0 && numStloc.GetOrDefault(exceptionVariable) == 1 && numLdloc.GetOrDefault(exceptionVariable) == 1 && body[0].Match(ILCode.Stloc, out ILVariable operand, out arg) && arg.MatchLdloc(exceptionVariable))
				{
					body.RemoveAt(0);
					((ILTryCatchBlock.CatchBlock)block).ExceptionVariable = operand;
					flag = true;
				}
			}
			int num = 0;
			while (num < body.Count - 1)
			{
				if (body[num].Match(ILCode.Stloc, out ILVariable _, out ILExpression _) && InlineOneIfPossible(block.Body, num, aggressive: false))
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
				if (body[num].Match(ILCode.Stloc, out ILVariable _, out ILExpression _) && InlineOneIfPossible(bb.Body, num, aggressive: false))
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

		public int InlineInto(List<ILNode> body, int pos, bool aggressive)
		{
			if (pos >= body.Count)
			{
				return 0;
			}
			int num = 0;
			while (--pos >= 0)
			{
				ILExpression iLExpression = body[pos] as ILExpression;
				if (iLExpression == null || iLExpression.Code != ILCode.Stloc || !InlineOneIfPossible(body, pos, aggressive))
				{
					break;
				}
				num++;
			}
			return num;
		}

		public bool InlineIfPossible(List<ILNode> body, ref int pos)
		{
			if (InlineOneIfPossible(body, pos, aggressive: true))
			{
				pos -= InlineInto(body, pos, aggressive: false);
				return true;
			}
			return false;
		}

		public bool InlineOneIfPossible(List<ILNode> body, int pos, bool aggressive)
		{
			if (body[pos].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && !operand.IsPinned)
			{
				if (InlineIfPossible(operand, arg, body.ElementAtOrDefault(pos + 1), aggressive))
				{
					arg.ILRanges.AddRange(((ILExpression)body[pos]).ILRanges);
					body.RemoveAt(pos);
					return true;
				}
				if (numLdloc.GetOrDefault(operand) == 0 && numLdloca.GetOrDefault(operand) == 0)
				{
					if (arg.HasNoSideEffects())
					{
						AnalyzeNode(body[pos], -1);
						body.RemoveAt(pos);
						return true;
					}
					if (arg.CanBeExpressionStatement() && operand.IsGenerated)
					{
						arg.ILRanges.AddRange(((ILExpression)body[pos]).ILRanges);
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
			if (FindLoadInNext(next as ILExpression, v, inlinedExpression, out ILExpression parent, out int pos) == true)
			{
				if (orDefault == 0)
				{
					if (!IsGeneratedValueTypeTemporary((ILExpression)next, parent, pos, v, inlinedExpression))
					{
						return false;
					}
				}
				else if (!aggressive && !v.IsGenerated && !NonAggressiveInlineInto((ILExpression)next, parent, inlinedExpression))
				{
					return false;
				}
				inlinedExpression.ILRanges.AddRange(parent.Arguments[pos].ILRanges);
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
			if (pos == 0 && v.Type != null && v.Type.IsValueType)
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
				case ILCode.Ldelem_Any:
				case ILCode.Ldloc:
				case ILCode.Stloc:
				case ILCode.CompoundAssignment:
					return false;
				case ILCode.Ldfld:
				case ILCode.Stfld:
				case ILCode.Ldsfld:
				case ILCode.Stsfld:
				{
					FieldDefinition fieldDefinition = ((FieldReference)inlinedExpression.Operand).Resolve();
					if (fieldDefinition == null || !fieldDefinition.IsInitOnly)
					{
						return false;
					}
					break;
				}
				case ILCode.Call:
				case ILCode.CallGetter:
				{
					MethodReference methodReference = (MethodReference)inlinedExpression.Operand;
					if (methodReference.DeclaringType is ArrayType)
					{
						return false;
					}
					goto case ILCode.Callvirt;
				}
				case ILCode.Callvirt:
				case ILCode.CallvirtGetter:
				{
					MethodReference methodReference = (MethodReference)inlinedExpression.Operand;
					if (methodReference.Name == "get_Current" && methodReference.HasThis)
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
						MethodReference methodReference = (MethodReference)iLExpression.Operand;
						if (methodReference.Name == "get_Current" && methodReference.HasThis)
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
					return ((MethodReference)parent.Operand).HasThis;
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
				foreach (ILExpression item in expressionBeingMoved.GetSelfAndChildrenRecursive<ILExpression>())
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

		public void CopyPropagation()
		{
			foreach (ILBlock item in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				for (int i = 0; i < item.Body.Count; i++)
				{
					ILExpression arg;
					ILVariable operand;
					if (item.Body[i].Match(ILCode.Stloc, out operand, out arg) && !operand.IsParameter && numStloc.GetOrDefault(operand) == 1 && numLdloca.GetOrDefault(operand) == 0 && CanPerformCopyPropagation(arg, operand))
					{
						ILVariable[] array = new ILVariable[arg.Arguments.Count];
						for (int j = 0; j < array.Length; j++)
						{
							array[j] = new ILVariable
							{
								IsGenerated = true,
								Name = operand.Name + "_cp_" + j
							};
							item.Body.Insert(i++, new ILExpression(ILCode.Stloc, array[j], arg.Arguments[j]));
						}
						foreach (ILExpression item2 in method.GetSelfAndChildrenRecursive<ILExpression>())
						{
							if (item2.Code == ILCode.Ldloc && item2.Operand == operand)
							{
								item2.Code = arg.Code;
								item2.Operand = arg.Operand;
								for (int k = 0; k < array.Length; k++)
								{
									item2.Arguments.Add(new ILExpression(ILCode.Ldloc, array[k]));
								}
							}
						}
						item.Body.RemoveAt(i);
						if (array.Length != 0)
						{
							AnalyzeMethod();
						}
						InlineInto(item.Body, i, aggressive: false);
						i -= array.Length + 1;
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
				if (iLVariable.IsGenerated && copyVariable.IsGenerated && numLdloca.GetOrDefault(iLVariable) == 0)
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
}
