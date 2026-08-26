using System.Collections.Generic;
using dnlib.DotNet;

namespace ICSharpCode.Decompiler.ILAst;

internal static class MonoStateMachineUtils
{
	public static ILVariable FindDisposeLocal(ILBlock ilMethod)
	{
		ILVariable iLVariable = null;
		foreach (ILTryCatchBlock item in ilMethod.GetSelfAndChildrenRecursive<ILTryCatchBlock>())
		{
			List<ILNode> list = item.FinallyBlock?.Body;
			if (list != null && list.Count >= 2 && list[0].Match(ILCode.Brtrue, out ILLabel _, out ILExpression arg) && list[1].Match(ILCode.Endfinally) && ((ILNode)arg).Match(ILCode.LogicNot, out ILExpression arg2) && ((ILNode)arg2).Match(ILCode.Ldloc, out ILVariable operand2) && !operand2.IsParameter && operand2.Type.GetElementType() == ElementType.Boolean && CheckDisposeLocalInTryBlock(item.TryBlock, operand2))
			{
				if (iLVariable == null)
				{
					iLVariable = operand2;
				}
				else if (iLVariable != operand2)
				{
					throw new SymbolicAnalysisFailedException();
				}
			}
		}
		return iLVariable;
	}

	private static bool CheckDisposeLocalInTryBlock(ILBlock tryBlock, ILVariable local)
	{
		int num = 0;
		List<ILNode> body = tryBlock.Body;
		for (int i = 0; i < body.Count; i++)
		{
			if (body[i].Match(ILCode.Stloc, out ILVariable operand, out ILExpression arg) && operand == local)
			{
				if (!arg.MatchLdcI4(1))
				{
					return false;
				}
				num++;
			}
		}
		return num >= 1;
	}
}
