using ICSharpCode.Decompiler.FlowAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.Decompiler.ILAst
{
	public class LoopsAndConditions
	{
		private Dictionary<ILLabel, ControlFlowNode> labelToCfNode = new Dictionary<ILLabel, ControlFlowNode>();

		private readonly DecompilerContext context;

		private uint nextLabelIndex;

		public LoopsAndConditions(DecompilerContext context)
		{
			this.context = context;
		}

		public void FindLoops(ILBlock block)
		{
			if (block.Body.Count > 0)
			{
				ControlFlowGraph controlFlowGraph = BuildGraph(block.Body, (ILLabel)block.EntryGoto.Operand);
				controlFlowGraph.ComputeDominance(context.CancellationToken);
				controlFlowGraph.ComputeDominanceFrontier();
				block.Body = FindLoops(new HashSet<ControlFlowNode>(controlFlowGraph.Nodes.Skip(3)), controlFlowGraph.EntryPoint, excludeEntryPoint: false);
			}
		}

		public void FindConditions(ILBlock block)
		{
			if (block.Body.Count > 0)
			{
				ControlFlowGraph controlFlowGraph = BuildGraph(block.Body, (ILLabel)block.EntryGoto.Operand);
				controlFlowGraph.ComputeDominance(context.CancellationToken);
				controlFlowGraph.ComputeDominanceFrontier();
				block.Body = FindConditions(new HashSet<ControlFlowNode>(controlFlowGraph.Nodes.Skip(3)), controlFlowGraph.EntryPoint);
			}
		}

		private ControlFlowGraph BuildGraph(List<ILNode> nodes, ILLabel entryLabel)
		{
			int num = 0;
			List<ControlFlowNode> list = new List<ControlFlowNode>();
			ControlFlowNode controlFlowNode = new ControlFlowNode(num++, 0, ControlFlowNodeType.EntryPoint);
			list.Add(controlFlowNode);
			ControlFlowNode item = new ControlFlowNode(num++, -1, ControlFlowNodeType.RegularExit);
			list.Add(item);
			ControlFlowNode item2 = new ControlFlowNode(num++, -1, ControlFlowNodeType.ExceptionalExit);
			list.Add(item2);
			labelToCfNode = new Dictionary<ILLabel, ControlFlowNode>();
			Dictionary<ILNode, ControlFlowNode> dictionary = new Dictionary<ILNode, ControlFlowNode>();
			foreach (ILBasicBlock node in nodes)
			{
				ControlFlowNode controlFlowNode2 = new ControlFlowNode(num++, -1, ControlFlowNodeType.Normal);
				list.Add(controlFlowNode2);
				dictionary[node] = controlFlowNode2;
				controlFlowNode2.UserData = node;
				foreach (ILLabel item5 in node.GetSelfAndChildrenRecursive<ILLabel>())
				{
					labelToCfNode[item5] = controlFlowNode2;
				}
			}
			ControlFlowNode controlFlowNode3 = labelToCfNode[entryLabel];
			ControlFlowEdge item3 = new ControlFlowEdge(controlFlowNode, controlFlowNode3, JumpType.Normal);
			controlFlowNode.Outgoing.Add(item3);
			controlFlowNode3.Incoming.Add(item3);
			foreach (ILBasicBlock node2 in nodes)
			{
				ControlFlowNode controlFlowNode4 = dictionary[node2];
				foreach (ILLabel item6 in node2.GetSelfAndChildrenRecursive((ILExpression e) => e.IsBranch()).SelectMany((ILExpression e) => e.GetBranchTargets()))
				{
					if (labelToCfNode.TryGetValue(item6, out ControlFlowNode value) && (value != controlFlowNode4 || item6 == node2.Body.FirstOrDefault()))
					{
						ControlFlowEdge item4 = new ControlFlowEdge(controlFlowNode4, value, JumpType.Normal);
						controlFlowNode4.Outgoing.Add(item4);
						value.Incoming.Add(item4);
					}
				}
			}
			return new ControlFlowGraph(list.ToArray());
		}

		private List<ILNode> FindLoops(HashSet<ControlFlowNode> scope, ControlFlowNode entryPoint, bool excludeEntryPoint)
		{
			List<ILNode> list = new List<ILNode>();
			scope = new HashSet<ControlFlowNode>(scope);
			Queue<ControlFlowNode> queue = new Queue<ControlFlowNode>();
			queue.Enqueue(entryPoint);
			while (queue.Count > 0)
			{
				ControlFlowNode node = queue.Dequeue();
				if (scope.Contains(node) && node.DominanceFrontier.Contains(node) && (node != entryPoint || !excludeEntryPoint))
				{
					HashSet<ControlFlowNode> hashSet = FindLoopContent(scope, node);
					ILBasicBlock iLBasicBlock = (ILBasicBlock)node.UserData;
					if (iLBasicBlock.MatchSingleAndBr(ILCode.Brtrue, out ILLabel operand, out ILExpression arg, out ILLabel brLabel))
					{
						labelToCfNode.TryGetValue(operand, out ControlFlowNode value);
						labelToCfNode.TryGetValue(brLabel, out ControlFlowNode value2);
						if ((!hashSet.Contains(value) && hashSet.Contains(value2)) || (hashSet.Contains(value) && !hashSet.Contains(value2)))
						{
							hashSet.RemoveOrThrow(node);
							scope.RemoveOrThrow(node);
							if (hashSet.Contains(value2) || value2 == node)
							{
								arg = new ILExpression(ILCode.LogicNot, null, arg);
								ILLabel iLLabel = operand;
								operand = brLabel;
								brLabel = iLLabel;
							}
							labelToCfNode.TryGetValue(brLabel, out ControlFlowNode value3);
							if (value3 != null)
							{
								HashSet<ControlFlowNode> second = FindDominatedNodes(scope, value3);
								IEnumerable<ControlFlowNode> other = from n in scope.Except(second)
									where node.Dominates(n)
									select n;
								hashSet.UnionWith(other);
							}
							iLBasicBlock.Body.RemoveTail(ILCode.Brtrue, ILCode.Br);
							iLBasicBlock.Body.Add(new ILWhileLoop
							{
								Condition = arg,
								BodyBlock = new ILBlock
								{
									EntryGoto = new ILExpression(ILCode.Br, operand),
									Body = FindLoops(hashSet, node, excludeEntryPoint: false)
								}
							});
							iLBasicBlock.Body.Add(new ILExpression(ILCode.Br, brLabel));
							list.Add(iLBasicBlock);
							scope.ExceptWith(hashSet);
						}
					}
					if (scope.Contains(node))
					{
						list.Add(new ILBasicBlock
						{
							Body = new List<ILNode>
							{
								new ILLabel
								{
									Name = "Loop_" + nextLabelIndex++
								},
								new ILWhileLoop
								{
									BodyBlock = new ILBlock
									{
										EntryGoto = new ILExpression(ILCode.Br, (ILLabel)iLBasicBlock.Body.First()),
										Body = FindLoops(hashSet, node, excludeEntryPoint: true)
									}
								}
							}
						});
						scope.ExceptWith(hashSet);
					}
				}
				foreach (ControlFlowNode dominatorTreeChild in node.DominatorTreeChildren)
				{
					queue.Enqueue(dominatorTreeChild);
				}
			}
			foreach (ControlFlowNode item in scope)
			{
				list.Add((ILNode)item.UserData);
			}
			scope.Clear();
			return list;
		}

		private List<ILNode> FindConditions(HashSet<ControlFlowNode> scope, ControlFlowNode entryNode)
		{
			List<ILNode> list = new List<ILNode>();
			scope = new HashSet<ControlFlowNode>(scope);
			Stack<ControlFlowNode> stack = new Stack<ControlFlowNode>();
			stack.Push(entryNode);
			while (stack.Count > 0)
			{
				ControlFlowNode controlFlowNode = stack.Pop();
				if (scope.Contains(controlFlowNode))
				{
					ILBasicBlock iLBasicBlock = (ILBasicBlock)controlFlowNode.UserData;
					if (iLBasicBlock.MatchLastAndBr(ILCode.Switch, out ILLabel[] operand, out ILExpression arg, out ILLabel brLabel))
					{
						ILSwitch iLSwitch = new ILSwitch
						{
							Condition = arg
						};
						iLBasicBlock.Body.RemoveTail(ILCode.Switch, ILCode.Br);
						iLBasicBlock.Body.Add(iLSwitch);
						iLBasicBlock.Body.Add(new ILExpression(ILCode.Br, brLabel));
						list.Add(iLBasicBlock);
						scope.RemoveOrThrow(controlFlowNode);
						int operand2 = 0;
						if (iLSwitch.Condition.Match(ILCode.Sub, out List<ILExpression> args) && args[1].Match(ILCode.Ldc_I4, out operand2))
						{
							iLSwitch.Condition = args[0];
						}
						ControlFlowNode value = null;
						labelToCfNode.TryGetValue(brLabel, out value);
						HashSet<ControlFlowNode> hashSet = new HashSet<ControlFlowNode>();
						if (value != null)
						{
							hashSet.UnionWith(value.DominanceFrontier.Except(new ControlFlowNode[1]
							{
								value
							}));
						}
						ILLabel[] array = operand;
						foreach (ILLabel key in array)
						{
							ControlFlowNode value2 = null;
							labelToCfNode.TryGetValue(key, out value2);
							if (value2 != null)
							{
								hashSet.UnionWith(value2.DominanceFrontier.Except(new ControlFlowNode[1]
								{
									value2
								}));
							}
						}
						for (int j = 0; j < operand.Length; j++)
						{
							ILLabel condLabel = operand[j];
							ILSwitch.CaseBlock caseBlock = iLSwitch.CaseBlocks.FirstOrDefault((ILSwitch.CaseBlock b) => b.EntryGoto.Operand == condLabel);
							if (caseBlock == null)
							{
								ILSwitch.CaseBlock caseBlock2 = new ILSwitch.CaseBlock();
								caseBlock2.Values = new List<int>();
								caseBlock2.EntryGoto = new ILExpression(ILCode.Br, condLabel);
								caseBlock = caseBlock2;
								iLSwitch.CaseBlocks.Add(caseBlock);
								ControlFlowNode value3 = null;
								labelToCfNode.TryGetValue(condLabel, out value3);
								if (value3 != null && !hashSet.Contains(value3))
								{
									HashSet<ControlFlowNode> hashSet2 = FindDominatedNodes(scope, value3);
									scope.ExceptWith(hashSet2);
									caseBlock.Body.AddRange(FindConditions(hashSet2, value3));
									caseBlock.Body.Add(new ILBasicBlock
									{
										Body = 
										{
											(ILNode)new ILLabel
											{
												Name = "SwitchBreak_" + nextLabelIndex++
											},
											(ILNode)new ILExpression(ILCode.LoopOrSwitchBreak, null)
										}
									});
								}
							}
							caseBlock.Values.Add(j + operand2);
						}
						if (value != null && !hashSet.Contains(value))
						{
							HashSet<ControlFlowNode> hashSet3 = FindDominatedNodes(scope, value);
							if (hashSet3.Any())
							{
								ILSwitch.CaseBlock caseBlock2 = new ILSwitch.CaseBlock();
								caseBlock2.EntryGoto = new ILExpression(ILCode.Br, brLabel);
								ILSwitch.CaseBlock caseBlock3 = caseBlock2;
								iLSwitch.CaseBlocks.Add(caseBlock3);
								iLBasicBlock.Body.RemoveTail(ILCode.Br);
								scope.ExceptWith(hashSet3);
								caseBlock3.Body.AddRange(FindConditions(hashSet3, value));
								caseBlock3.Body.Add(new ILBasicBlock
								{
									Body = 
									{
										(ILNode)new ILLabel
										{
											Name = "SwitchBreak_" + nextLabelIndex++
										},
										(ILNode)new ILExpression(ILCode.LoopOrSwitchBreak, null)
									}
								});
							}
						}
					}
					if (iLBasicBlock.MatchLastAndBr(ILCode.Brtrue, out ILLabel operand3, out ILExpression arg2, out ILLabel brLabel2))
					{
						ILLabel iLLabel = operand3;
						operand3 = brLabel2;
						brLabel2 = iLLabel;
						arg2 = new ILExpression(ILCode.LogicNot, null, arg2);
						ILCondition iLCondition = new ILCondition();
						iLCondition.Condition = arg2;
						iLCondition.TrueBlock = new ILBlock
						{
							EntryGoto = new ILExpression(ILCode.Br, operand3)
						};
						iLCondition.FalseBlock = new ILBlock
						{
							EntryGoto = new ILExpression(ILCode.Br, brLabel2)
						};
						ILCondition iLCondition2 = iLCondition;
						iLBasicBlock.Body.RemoveTail(ILCode.Brtrue, ILCode.Br);
						iLBasicBlock.Body.Add(iLCondition2);
						list.Add(iLBasicBlock);
						scope.RemoveOrThrow(controlFlowNode);
						ControlFlowNode value4 = null;
						labelToCfNode.TryGetValue(operand3, out value4);
						ControlFlowNode value5 = null;
						labelToCfNode.TryGetValue(brLabel2, out value5);
						if (value4 != null && HasSingleEdgeEnteringBlock(value4))
						{
							HashSet<ControlFlowNode> hashSet4 = FindDominatedNodes(scope, value4);
							scope.ExceptWith(hashSet4);
							iLCondition2.TrueBlock.Body.AddRange(FindConditions(hashSet4, value4));
						}
						if (value5 != null && HasSingleEdgeEnteringBlock(value5))
						{
							HashSet<ControlFlowNode> hashSet5 = FindDominatedNodes(scope, value5);
							scope.ExceptWith(hashSet5);
							iLCondition2.FalseBlock.Body.AddRange(FindConditions(hashSet5, value5));
						}
					}
					if (scope.Contains(controlFlowNode))
					{
						list.Add((ILNode)controlFlowNode.UserData);
						scope.Remove(controlFlowNode);
					}
				}
				for (int num = controlFlowNode.DominatorTreeChildren.Count - 1; num >= 0; num--)
				{
					stack.Push(controlFlowNode.DominatorTreeChildren[num]);
				}
			}
			foreach (ControlFlowNode item in scope)
			{
				list.Add((ILNode)item.UserData);
			}
			return list;
		}

		private static bool HasSingleEdgeEnteringBlock(ControlFlowNode node)
		{
			return node.Incoming.Count((ControlFlowEdge edge) => !node.Dominates(edge.Source)) == 1;
		}

		private static HashSet<ControlFlowNode> FindDominatedNodes(HashSet<ControlFlowNode> scope, ControlFlowNode head)
		{
			HashSet<ControlFlowNode> hashSet = new HashSet<ControlFlowNode>();
			HashSet<ControlFlowNode> hashSet2 = new HashSet<ControlFlowNode>();
			hashSet.Add(head);
			while (hashSet.Count > 0)
			{
				ControlFlowNode controlFlowNode = hashSet.First();
				hashSet.Remove(controlFlowNode);
				if (scope.Contains(controlFlowNode) && head.Dominates(controlFlowNode) && hashSet2.Add(controlFlowNode))
				{
					foreach (ControlFlowNode successor in controlFlowNode.Successors)
					{
						hashSet.Add(successor);
					}
				}
			}
			return hashSet2;
		}

		private static HashSet<ControlFlowNode> FindLoopContent(HashSet<ControlFlowNode> scope, ControlFlowNode head)
		{
			HashSet<ControlFlowNode> hashSet = new HashSet<ControlFlowNode>(from p in head.Predecessors
				where head.Dominates(p)
				select p);
			HashSet<ControlFlowNode> hashSet2 = new HashSet<ControlFlowNode>();
			while (hashSet.Count > 0)
			{
				ControlFlowNode controlFlowNode = hashSet.First();
				hashSet.Remove(controlFlowNode);
				if (scope.Contains(controlFlowNode) && head.Dominates(controlFlowNode) && hashSet2.Add(controlFlowNode))
				{
					foreach (ControlFlowNode predecessor in controlFlowNode.Predecessors)
					{
						hashSet.Add(predecessor);
					}
				}
			}
			if (scope.Contains(head))
			{
				hashSet2.Add(head);
			}
			return hashSet2;
		}
	}
}
