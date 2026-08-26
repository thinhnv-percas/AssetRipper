using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public class GotoRemoval
	{
		private Dictionary<ILNode, ILNode> parent = new Dictionary<ILNode, ILNode>();

		private Dictionary<ILNode, ILNode> nextSibling = new Dictionary<ILNode, ILNode>();

		public void RemoveGotos(ILBlock method)
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
				foreach (ILExpression item2 in method.GetSelfAndChildrenRecursive((ILExpression e) => (e.Code != ILCode.Br) ? (e.Code == ILCode.Leave) : true))
				{
					flag |= TrySimplifyGoto(item2);
				}
			}
			while (flag);
			RemoveRedundantCode(method);
		}

		public static void RemoveRedundantCode(ILBlock method)
		{
			HashSet<ILLabel> liveLabels = new HashSet<ILLabel>(method.GetSelfAndChildrenRecursive((ILExpression e) => e.IsBranch()).SelectMany((ILExpression e) => e.GetBranchTargets()));
			foreach (ILBlock item in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				item.Body = (from n in item.Body
					where !n.Match(ILCode.Nop) && ((n is ILLabel) ? liveLabels.Contains((ILLabel)n) : true)
					select n).ToList();
			}
			foreach (ILWhileLoop item2 in method.GetSelfAndChildrenRecursive<ILWhileLoop>())
			{
				List<ILNode> body = item2.BodyBlock.Body;
				if (body.Count > 0 && body.Last().Match(ILCode.LoopContinue))
				{
					body.RemoveAt(body.Count - 1);
				}
			}
			foreach (ILSwitch item3 in method.GetSelfAndChildrenRecursive<ILSwitch>())
			{
				foreach (ILSwitch.CaseBlock caseBlock2 in item3.CaseBlocks)
				{
					int count = caseBlock2.Body.Count;
					if (count >= 2 && caseBlock2.Body[count - 2].IsUnconditionalControlFlow() && caseBlock2.Body[count - 1].Match(ILCode.LoopOrSwitchBreak))
					{
						caseBlock2.Body.RemoveAt(count - 1);
					}
				}
				ILSwitch.CaseBlock caseBlock = item3.CaseBlocks.SingleOrDefault((ILSwitch.CaseBlock cb) => cb.Values == null);
				if (caseBlock == null || (caseBlock.Body.Count == 1 && caseBlock.Body.Single().Match(ILCode.LoopOrSwitchBreak)))
				{
					item3.CaseBlocks.RemoveAll((ILSwitch.CaseBlock b) => b.Body.Count == 1 && b.Body.Single().Match(ILCode.LoopOrSwitchBreak));
				}
			}
			if (method.Body.Count > 0 && method.Body.Last().Match(ILCode.Ret) && ((ILExpression)method.Body.Last()).Arguments.Count == 0)
			{
				method.Body.RemoveAt(method.Body.Count - 1);
			}
			bool flag = false;
			foreach (ILBlock item4 in method.GetSelfAndChildrenRecursive<ILBlock>())
			{
				int num = 0;
				while (num < item4.Body.Count - 1)
				{
					if (item4.Body[num].IsUnconditionalControlFlow() && item4.Body[num + 1].Match(ILCode.Ret))
					{
						flag = true;
						item4.Body.RemoveAt(num + 1);
					}
					else
					{
						num++;
					}
				}
			}
			if (flag)
			{
				new GotoRemoval().RemoveGotos(method);
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
			if (iLNode == Exit(gotoExpr, new HashSet<ILNode>
			{
				gotoExpr
			}))
			{
				gotoExpr.Code = ILCode.Nop;
				gotoExpr.Operand = null;
				if (iLNode is ILExpression)
				{
					((ILExpression)iLNode).ILRanges.AddRange(gotoExpr.ILRanges);
				}
				gotoExpr.ILRanges.Clear();
				return true;
			}
			ILNode iLNode2 = GetParents(gotoExpr).FirstOrDefault((ILNode n) => (!(n is ILWhileLoop)) ? (n is ILSwitch) : true);
			if (iLNode2 != null && iLNode == Exit(iLNode2, new HashSet<ILNode>
			{
				gotoExpr
			}))
			{
				gotoExpr.Code = ILCode.LoopOrSwitchBreak;
				gotoExpr.Operand = null;
				return true;
			}
			ILNode iLNode3 = GetParents(gotoExpr).FirstOrDefault((ILNode n) => n is ILWhileLoop);
			if (iLNode3 != null && iLNode == Enter(iLNode3, new HashSet<ILNode>
			{
				gotoExpr
			}))
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
			ILLabel iLLabel = node as ILLabel;
			if (iLLabel != null)
			{
				return Exit(iLLabel, visitedNodes);
			}
			ILExpression iLExpression = node as ILExpression;
			if (iLExpression != null)
			{
				if (iLExpression.Code == ILCode.Br || iLExpression.Code == ILCode.Leave)
				{
					ILLabel iLLabel2 = (ILLabel)iLExpression.Operand;
					if (GetParents(iLExpression).OfType<ILTryCatchBlock>().FirstOrDefault() == GetParents(iLLabel2).OfType<ILTryCatchBlock>().FirstOrDefault())
					{
						return Enter(iLLabel2, visitedNodes);
					}
					List<ILTryCatchBlock> list = GetParents(iLExpression).OfType<ILTryCatchBlock>().Reverse().ToList();
					List<ILTryCatchBlock> list2 = GetParents(iLLabel2).OfType<ILTryCatchBlock>().Reverse().ToList();
					int i;
					for (i = 0; i < list.Count && i < list2.Count && list[i] == list2[i]; i++)
					{
					}
					if (i == list2.Count)
					{
						return Enter(iLLabel2, visitedNodes);
					}
					ILTryCatchBlock iLTryCatchBlock = list2[i];
					ILTryCatchBlock iLTryCatchBlock2 = iLTryCatchBlock;
					while (iLTryCatchBlock2 != null)
					{
						foreach (ILNode item in iLTryCatchBlock2.TryBlock.Body)
						{
							if (item is ILLabel)
							{
								if (item == iLLabel2)
								{
									return iLTryCatchBlock;
								}
							}
							else if (!item.Match(ILCode.Nop))
							{
								iLTryCatchBlock2 = (item as ILTryCatchBlock);
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
					ILNode node2 = GetParents(iLExpression).First((ILNode n) => (!(n is ILWhileLoop)) ? (n is ILSwitch) : true);
					return Exit(node2, new HashSet<ILNode>
					{
						iLExpression
					});
				}
				if (iLExpression.Code == ILCode.LoopContinue)
				{
					ILNode node3 = GetParents(iLExpression).First((ILNode n) => n is ILWhileLoop);
					return Enter(node3, new HashSet<ILNode>
					{
						iLExpression
					});
				}
				return iLExpression;
			}
			ILBlock iLBlock = node as ILBlock;
			if (iLBlock != null)
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
			ILCondition iLCondition = node as ILCondition;
			if (iLCondition != null)
			{
				return iLCondition.Condition;
			}
			ILWhileLoop iLWhileLoop = node as ILWhileLoop;
			if (iLWhileLoop != null)
			{
				if (iLWhileLoop.Condition != null)
				{
					return iLWhileLoop.Condition;
				}
				return Enter(iLWhileLoop.BodyBlock, visitedNodes);
			}
			ILTryCatchBlock iLTryCatchBlock3 = node as ILTryCatchBlock;
			if (iLTryCatchBlock3 != null)
			{
				return iLTryCatchBlock3;
			}
			ILSwitch iLSwitch = node as ILSwitch;
			if (iLSwitch != null)
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
}
