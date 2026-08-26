using Mono.Cecil;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public class SimpleControlFlow
	{
		private Dictionary<ILLabel, int> labelGlobalRefCount = new Dictionary<ILLabel, int>();

		private Dictionary<ILLabel, ILBasicBlock> labelToBasicBlock = new Dictionary<ILLabel, ILBasicBlock>();

		private DecompilerContext context;

		private TypeSystem typeSystem;

		public SimpleControlFlow(DecompilerContext context, ILBlock method)
		{
			this.context = context;
			typeSystem = context.CurrentMethod.Module.TypeSystem;
			foreach (ILLabel item in method.GetSelfAndChildrenRecursive((ILExpression e) => e.IsBranch()).SelectMany((ILExpression e) => e.GetBranchTargets()))
			{
				labelGlobalRefCount[item] = labelGlobalRefCount.GetOrDefault(item) + 1;
			}
			foreach (ILBasicBlock item2 in method.GetSelfAndChildrenRecursive<ILBasicBlock>())
			{
				foreach (ILLabel item3 in item2.GetChildren().OfType<ILLabel>())
				{
					labelToBasicBlock[item3] = item2;
				}
			}
		}

		public bool SimplifyTernaryOperator(List<ILNode> body, ILBasicBlock head, int pos)
		{
			ILVariable operand = null;
			ILVariable operand2 = null;
			ILLabel brLabel;
			ILLabel operand3;
			ILLabel brLabel2;
			ILLabel brLabel3;
			if (head.MatchLastAndBr(ILCode.Brtrue, out operand3, out ILExpression arg, out brLabel) && labelGlobalRefCount[operand3] == 1 && labelGlobalRefCount[brLabel] == 1 && ((labelToBasicBlock[operand3].MatchSingleAndBr(ILCode.Stloc, out operand, out ILExpression arg2, out brLabel2) && labelToBasicBlock[brLabel].MatchSingleAndBr(ILCode.Stloc, out operand2, out ILExpression arg3, out brLabel3) && operand == operand2 && brLabel2 == brLabel3) || (labelToBasicBlock[operand3].MatchSingle(ILCode.Ret, out object operand4, out arg2) && labelToBasicBlock[brLabel].MatchSingle(ILCode.Ret, out operand4, out arg3))) && body.Contains(labelToBasicBlock[operand3]) && body.Contains(labelToBasicBlock[brLabel]))
			{
				bool flag = operand != null;
				ILCode iLCode = flag ? ILCode.Stloc : ILCode.Ret;
				bool flag2 = TypeAnalysis.IsBoolean(flag ? operand.Type : context.CurrentMethod.ReturnType);
				int operand5;
				int operand6;
				ILExpression iLExpression;
				if (flag2 && arg2.Match(ILCode.Ldc_I4, out operand5) && arg3.Match(ILCode.Ldc_I4, out operand6) && ((operand5 != 0 && operand6 == 0) || (operand5 == 0 && operand6 != 0)))
				{
					iLExpression = ((operand5 == 0) ? new ILExpression(ILCode.LogicNot, null, arg)
					{
						InferredType = typeSystem.Boolean
					} : arg);
				}
				else if ((flag2 || TypeAnalysis.IsBoolean(arg3.InferredType)) && arg2.Match(ILCode.Ldc_I4, out operand5) && (operand5 == 0 || operand5 == 1))
				{
					iLExpression = ((operand5 == 0) ? MakeLeftAssociativeShortCircuit(ILCode.LogicAnd, new ILExpression(ILCode.LogicNot, null, arg), arg3) : MakeLeftAssociativeShortCircuit(ILCode.LogicOr, arg, arg3));
				}
				else if ((flag2 || TypeAnalysis.IsBoolean(arg2.InferredType)) && arg3.Match(ILCode.Ldc_I4, out operand6) && (operand6 == 0 || operand6 == 1))
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
						if (!operand.IsGenerated)
						{
							return false;
						}
						break;
					}
					iLExpression = new ILExpression(ILCode.TernaryOp, null, arg, arg2, arg3);
				}
				head.Body.RemoveTail(ILCode.Brtrue, ILCode.Br);
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
			ILBasicBlock value;
			ILLabel brLabel;
			ILLabel operand3;
			ILLabel brLabel2;
			ILVariable operand;
			ILVariable operand4;
			ILExpression arg2;
			ILVariable operand2;
			if (head.Body.Count >= 3 && head.Body[head.Body.Count - 3].Match(ILCode.Stloc, out operand, out ILExpression arg) && arg.Match(ILCode.Ldloc, out operand2) && head.MatchLastAndBr(ILCode.Brtrue, out operand3, out arg2, out brLabel) && arg2.MatchLdloc(operand2) && labelToBasicBlock.TryGetValue(brLabel, out value) && value.MatchSingleAndBr(ILCode.Stloc, out operand4, out ILExpression arg3, out brLabel2) && operand == operand4 && operand3 == brLabel2 && labelGlobalRefCount.GetOrDefault(brLabel) == 1 && body.Contains(value))
			{
				head.Body.RemoveTail(ILCode.Stloc, ILCode.Brtrue, ILCode.Br);
				head.Body.Add(new ILExpression(ILCode.Stloc, operand, new ILExpression(ILCode.NullCoalescing, null, arg, arg3)));
				head.Body.Add(new ILExpression(ILCode.Br, operand3));
				body.RemoveOrThrow(labelToBasicBlock[brLabel]);
				return true;
			}
			return false;
		}

		public bool SimplifyShortCircuit(List<ILNode> body, ILBasicBlock head, int pos)
		{
			if (head.MatchLastAndBr(ILCode.Brtrue, out ILLabel operand, out ILExpression arg, out ILLabel brLabel))
			{
				for (int i = 0; i < 2; i++)
				{
					ILLabel key = (i == 0) ? operand : brLabel;
					ILLabel iLLabel = (i == 0) ? brLabel : operand;
					bool flag = i == 1;
					ILBasicBlock iLBasicBlock = labelToBasicBlock[key];
					ILLabel brLabel2;
					ILLabel operand2;
					if (body.Contains(iLBasicBlock) && iLBasicBlock != head && labelGlobalRefCount[(ILLabel)iLBasicBlock.Body.First()] == 1 && iLBasicBlock.MatchSingleAndBr(ILCode.Brtrue, out operand2, out ILExpression arg2, out brLabel2) && (iLLabel == brLabel2 || iLLabel == operand2))
					{
						ILExpression iLExpression = (iLLabel != brLabel2) ? MakeLeftAssociativeShortCircuit(ILCode.LogicOr, flag ? arg : new ILExpression(ILCode.LogicNot, null, arg), arg2) : MakeLeftAssociativeShortCircuit(ILCode.LogicAnd, flag ? new ILExpression(ILCode.LogicNot, null, arg) : arg, arg2);
						head.Body.RemoveTail(ILCode.Brtrue, ILCode.Br);
						head.Body.Add(new ILExpression(ILCode.Brtrue, operand2, iLExpression));
						head.Body.Add(new ILExpression(ILCode.Br, brLabel2));
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
			if (!arg.Match(ILCode.Ldloc, out ILVariable operand2))
			{
				return false;
			}
			if (!head.MatchLastAndBr(ILCode.Brtrue, out ILLabel operand3, out ILExpression arg2, out ILLabel brLabel))
			{
				return false;
			}
			if (labelGlobalRefCount[brLabel] > 1)
			{
				return false;
			}
			if (!arg2.Match(ILCode.Call, out MethodReference operand4, out ILExpression arg3))
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
			if (!iLBasicBlock.MatchSingleAndBr(ILCode.Stloc, out ILVariable operand5, out ILExpression arg4, out ILLabel brLabel2))
			{
				return false;
			}
			if (operand5 != operand || operand3 != brLabel2)
			{
				return false;
			}
			if (!arg4.Match(ILCode.Call, out MethodReference operand6, out ILExpression arg5, out ILExpression arg6))
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
			ILCode iLCode = (operand6.Name == "op_BitwiseAnd") ? ILCode.LogicAnd : ILCode.LogicOr;
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
			head.Body.RemoveTail(ILCode.Stloc, ILCode.Brtrue, ILCode.Br);
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
				iLExpression.Arguments[0] = new ILExpression(code, null, left, iLExpression.Arguments[0])
				{
					InferredType = typeSystem.Boolean
				};
				return right;
			}
			return new ILExpression(code, null, left, right)
			{
				InferredType = typeSystem.Boolean
			};
		}

		public bool JoinBasicBlocks(List<ILNode> body, ILBasicBlock head, int pos)
		{
			ILBasicBlock value;
			ILLabel operand;
			if (!head.Body.ElementAtOrDefault(head.Body.Count - 2).IsConditionalControlFlow() && head.Body.Last().Match(ILCode.Br, out operand) && labelGlobalRefCount[operand] == 1 && labelToBasicBlock.TryGetValue(operand, out value) && body.Contains(value) && value.Body.First() == operand && !value.Body.OfType<ILTryCatchBlock>().Any())
			{
				head.Body.RemoveTail(ILCode.Br);
				value.Body.RemoveAt(0);
				head.Body.AddRange(value.Body);
				body.RemoveOrThrow(value);
				return true;
			}
			return false;
		}
	}
}
