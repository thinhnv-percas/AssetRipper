using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst;

public class GotoRemoval
{
	private readonly Dictionary<ILNode, ILNode> parent = new Dictionary<ILNode, ILNode>();

	private readonly Dictionary<ILNode, ILNode> nextSibling = new Dictionary<ILNode, ILNode>();

	private readonly DecompilerContext context;

	public GotoRemoval(DecompilerContext context)
	{
		this.context = context;
	}

	public void Reset()
	{
		parent.Clear();
		nextSibling.Clear();
	}

	public static void RemoveGotos(DecompilerContext context, ILBlock method)
	{
		GotoRemoval gotoRemoval = context.Cache.GetGotoRemoval();
		try
		{
			gotoRemoval.RemoveGotosCore(method);
		}
		finally
		{
			context.Cache.Return(gotoRemoval);
		}
		RemoveRedundantCode(method, context);
	}

	private void RemoveGotosCore(ILBlock method)
	{
		parent[method] = null;
		foreach (ILNode item in method.GetSelfAndChildrenRecursive<ILNode>())
		{
			ILNode iLNode = null;
			foreach (ILNode child in item.GetChildren())
			{
				if (parent.ContainsKey(child))
				{
					throw new Exception("The following expression is linked from several locations: " + child.ToString());
				}
				parent[child] = item;
				if (iLNode != null)
				{
					nextSibling[iLNode] = child;
				}
				iLNode = child;
			}
			if (iLNode != null)
			{
				nextSibling[iLNode] = null;
			}
		}
		bool flag;
		do
		{
			flag = false;
			List<ILExpression> selfAndChildrenRecursive = method.GetSelfAndChildrenRecursive((ILExpression e) => e.Code == ILCode.Br || e.Code == ILCode.Leave);
			for (int num = selfAndChildrenRecursive.Count - 1; num >= 0; num--)
			{
				ILExpression gotoExpr = selfAndChildrenRecursive[num];
				flag |= TrySimplifyGoto(gotoExpr);
			}
		}
		while (flag);
	}

	public static void RemoveRedundantCode(ILBlock method, DecompilerContext context)
	{
		HashSet<ILLabel> hashSet = new HashSet<ILLabel>(method.GetSelfAndChildrenRecursive((ILExpression e) => e.IsBranch()).SelectMany((ILExpression e) => e.GetBranchTargets()));
		foreach (ILBlock item in method.GetSelfAndChildrenRecursive<ILBlock>())
		{
			List<ILNode> list = new List<ILNode>(item.Body.Count);
			for (int num = 0; num < item.Body.Count; num++)
			{
				ILNode iLNode = item.Body[num];
				if (iLNode.Match(ILCode.Nop))
				{
					if (context.CalculateILSpans)
					{
						Utils.NopMergeILSpans(item, list, num);
					}
				}
				else if (iLNode is ILLabel && !hashSet.Contains((ILLabel)iLNode))
				{
					if (context.CalculateILSpans)
					{
						Utils.LabelMergeILSpans(item, list, num);
					}
				}
				else
				{
					list.Add(iLNode);
				}
			}
			item.Body = list;
		}
		foreach (ILWhileLoop item2 in method.GetSelfAndChildrenRecursive<ILWhileLoop>())
		{
			List<ILNode> body = item2.BodyBlock.Body;
			if (body.Count > 0 && body.Last().Match(ILCode.LoopContinue))
			{
				if (context.CalculateILSpans)
				{
					body[body.Count - 1].AddSelfAndChildrenRecursiveILSpans(item2.EndILSpans);
				}
				body.RemoveAt(body.Count - 1);
			}
		}
		foreach (ILSwitch item3 in method.GetSelfAndChildrenRecursive<ILSwitch>())
		{
			foreach (ILSwitch.CaseBlock caseBlock3 in item3.CaseBlocks)
			{
				int count = caseBlock3.Body.Count;
				if (count >= 2 && caseBlock3.Body[count - 2].IsUnconditionalControlFlow() && caseBlock3.Body[count - 1].Match(ILCode.LoopOrSwitchBreak))
				{
					ILNode iLNode2 = caseBlock3.Body[count - 2];
					if (context.CalculateILSpans)
					{
						caseBlock3.Body[count - 1].AddSelfAndChildrenRecursiveILSpans(iLNode2.EndILSpans);
					}
					caseBlock3.Body.RemoveAt(count - 1);
				}
			}
			ILSwitch.CaseBlock caseBlock = item3.CaseBlocks.SingleOrDefault((ILSwitch.CaseBlock cb) => cb.Values == null);
			if (caseBlock != null && (caseBlock.Body.Count != 1 || !caseBlock.Body.Single().Match(ILCode.LoopOrSwitchBreak)))
			{
				continue;
			}
			for (int num2 = item3.CaseBlocks.Count - 1; num2 >= 0; num2--)
			{
				ILSwitch.CaseBlock caseBlock2 = item3.CaseBlocks[num2];
				if (caseBlock2.Body.Count == 1 && caseBlock2.Body.Single().Match(ILCode.LoopOrSwitchBreak))
				{
					if (context.CalculateILSpans)
					{
						caseBlock2.Body[0].AddSelfAndChildrenRecursiveILSpans(item3.EndILSpans);
					}
					item3.CaseBlocks.RemoveAt(num2);
				}
			}
		}
		if (method.Body.Count > 0 && method.Body.Last().Match(ILCode.Ret) && ((ILExpression)method.Body.Last()).Arguments.Count == 0)
		{
			if (context.CalculateILSpans)
			{
				method.Body[method.Body.Count - 1].AddSelfAndChildrenRecursiveILSpans(method.EndILSpans);
			}
			method.Body.RemoveAt(method.Body.Count - 1);
		}
		bool flag = false;
		foreach (ILBlock item4 in method.GetSelfAndChildrenRecursive<ILBlock>())
		{
			int num3 = 0;
			while (num3 < item4.Body.Count - 1)
			{
				if (item4.Body[num3].IsUnconditionalControlFlow() && item4.Body[num3 + 1].Match(ILCode.Ret))
				{
					flag = true;
					if (context.CalculateILSpans)
					{
						item4.Body[num3 + 1].AddSelfAndChildrenRecursiveILSpans(item4.EndILSpans);
					}
					item4.Body.RemoveAt(num3 + 1);
				}
				else
				{
					num3++;
				}
			}
		}
		if (flag)
		{
			RemoveGotos(context, method);
		}
	}

	private IEnumerable<ILNode> GetParents(ILNode node)
	{
		ILNode current = node;
		while (true)
		{
			current = parent[current];
			if (current == null)
			{
				break;
			}
			yield return current;
		}
	}

	private bool TrySimplifyGoto(ILExpression gotoExpr)
	{
		ILNode iLNode = Enter(gotoExpr, new HashSet<ILNode>());
		if (iLNode == null)
		{
			return false;
		}
		if (iLNode == Exit(gotoExpr, new HashSet<ILNode> { gotoExpr }))
		{
			gotoExpr.Code = ILCode.Nop;
			gotoExpr.Operand = null;
			return true;
		}
		ILNode iLNode2 = GetParents(gotoExpr).FirstOrDefault((ILNode n) => n is ILWhileLoop || n is ILSwitch);
		if (iLNode2 != null && iLNode == Exit(iLNode2, new HashSet<ILNode> { gotoExpr }))
		{
			gotoExpr.Code = ILCode.LoopOrSwitchBreak;
			gotoExpr.Operand = null;
			return true;
		}
		ILNode iLNode3 = GetParents(gotoExpr).FirstOrDefault((ILNode n) => n is ILWhileLoop);
		if (iLNode3 != null && iLNode == Enter(iLNode3, new HashSet<ILNode> { gotoExpr }))
		{
			gotoExpr.Code = ILCode.LoopContinue;
			gotoExpr.Operand = null;
			return true;
		}
		return false;
	}

	private ILNode Enter(ILNode node, HashSet<ILNode> visitedNodes)
	{
		if (node == null)
		{
			throw new ArgumentNullException();
		}
		if (!visitedNodes.Add(node))
		{
			return null;
		}
		if (node is ILLabel node2)
		{
			return Exit(node2, visitedNodes);
		}
		if (node is ILExpression iLExpression)
		{
			if (iLExpression.Code == ILCode.Br || iLExpression.Code == ILCode.Leave)
			{
				ILLabel iLLabel = (ILLabel)iLExpression.Operand;
				if (GetParents(iLExpression).OfType<ILTryCatchBlock>().FirstOrDefault() == GetParents(iLLabel).OfType<ILTryCatchBlock>().FirstOrDefault())
				{
					return Enter(iLLabel, visitedNodes);
				}
				List<ILTryCatchBlock> list = GetParents(iLExpression).OfType<ILTryCatchBlock>().Reverse().ToList();
				List<ILTryCatchBlock> list2 = GetParents(iLLabel).OfType<ILTryCatchBlock>().Reverse().ToList();
				int i;
				for (i = 0; i < list.Count && i < list2.Count && list[i] == list2[i]; i++)
				{
				}
				if (i == list2.Count)
				{
					return Enter(iLLabel, visitedNodes);
				}
				ILTryCatchBlock iLTryCatchBlock = list2[i];
				ILTryCatchBlock iLTryCatchBlock2 = iLTryCatchBlock;
				while (iLTryCatchBlock2 != null)
				{
					foreach (ILNode item in iLTryCatchBlock2.TryBlock.Body)
					{
						if (item is ILLabel)
						{
							if (item == iLLabel)
							{
								return iLTryCatchBlock;
							}
						}
						else if (!item.Match(ILCode.Nop))
						{
							iLTryCatchBlock2 = item as ILTryCatchBlock;
							break;
						}
					}
				}
				return null;
			}
			if (iLExpression.Code == ILCode.Nop)
			{
				return Exit(iLExpression, visitedNodes);
			}
			if (iLExpression.Code == ILCode.LoopOrSwitchBreak)
			{
				ILNode node3 = GetParents(iLExpression).First((ILNode n) => n is ILWhileLoop || n is ILSwitch);
				return Exit(node3, new HashSet<ILNode> { iLExpression });
			}
			if (iLExpression.Code == ILCode.LoopContinue)
			{
				ILNode node4 = GetParents(iLExpression).First((ILNode n) => n is ILWhileLoop);
				return Enter(node4, new HashSet<ILNode> { iLExpression });
			}
			return iLExpression;
		}
		if (node is ILBlock iLBlock)
		{
			if (iLBlock.EntryGoto != null)
			{
				return Enter(iLBlock.EntryGoto, visitedNodes);
			}
			if (iLBlock.Body.Count > 0)
			{
				return Enter(iLBlock.Body[0], visitedNodes);
			}
			return Exit(iLBlock, visitedNodes);
		}
		if (node is ILCondition iLCondition)
		{
			return iLCondition.Condition;
		}
		if (node is ILWhileLoop iLWhileLoop)
		{
			if (iLWhileLoop.Condition != null)
			{
				return iLWhileLoop.Condition;
			}
			return Enter(iLWhileLoop.BodyBlock, visitedNodes);
		}
		if (node is ILTryCatchBlock result)
		{
			return result;
		}
		if (node is ILSwitch iLSwitch)
		{
			return iLSwitch.Condition;
		}
		throw new NotSupportedException(node.GetType().ToString());
	}

	private ILNode Exit(ILNode node, HashSet<ILNode> visitedNodes)
	{
		if (node == null)
		{
			throw new ArgumentNullException();
		}
		ILNode iLNode = parent[node];
		if (iLNode == null)
		{
			return null;
		}
		if (iLNode is ILBlock)
		{
			ILNode iLNode2 = nextSibling[node];
			if (iLNode2 != null)
			{
				return Enter(iLNode2, visitedNodes);
			}
			return Exit(iLNode, visitedNodes);
		}
		if (iLNode is ILCondition)
		{
			return Exit(iLNode, visitedNodes);
		}
		if (iLNode is ILTryCatchBlock)
		{
			return Exit(iLNode, visitedNodes);
		}
		if (iLNode is ILSwitch)
		{
			return null;
		}
		if (iLNode is ILWhileLoop)
		{
			return Enter(iLNode, visitedNodes);
		}
		throw new NotSupportedException(iLNode.GetType().ToString());
	}
}
