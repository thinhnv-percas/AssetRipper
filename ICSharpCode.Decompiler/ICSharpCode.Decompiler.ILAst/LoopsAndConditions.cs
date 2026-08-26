using System.Collections.Generic;
using System.Linq;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.Decompiler.FlowAnalysis;

namespace ICSharpCode.Decompiler.ILAst;

public class LoopsAndConditions
{
	private readonly Dictionary<ILLabel, ControlFlowNode> labelToCfNode = new Dictionary<ILLabel, ControlFlowNode>();

	private DecompilerContext context;

	private uint nextLabelIndex;

	private readonly ControlFlowGraph cached_ControlFlowGraph = new ControlFlowGraph();

	public LoopsAndConditions(DecompilerContext context)
	{
		Initialize(context);
	}

	public void Initialize(DecompilerContext context)
	{
		this.context = context;
		labelToCfNode.Clear();
		nextLabelIndex = 0u;
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
		cached_ControlFlowGraph.Nodes.Clear();
		int num = 0;
		List<ControlFlowNode> nodes2 = cached_ControlFlowGraph.Nodes;
		ControlFlowNode controlFlowNode = new ControlFlowNode(num++, 0u, ControlFlowNodeType.EntryPoint);
		nodes2.Add(controlFlowNode);
		ControlFlowNode item = new ControlFlowNode(num++, null, ControlFlowNodeType.RegularExit);
		nodes2.Add(item);
		ControlFlowNode item2 = new ControlFlowNode(num++, null, ControlFlowNodeType.ExceptionalExit);
		nodes2.Add(item2);
		labelToCfNode.Clear();
		Dictionary<ILNode, ControlFlowNode> dictionary = new Dictionary<ILNode, ControlFlowNode>();
		List<ILLabel> list = null;
		foreach (ILBasicBlock node in nodes)
		{
			ControlFlowNode controlFlowNode2 = new ControlFlowNode(num++, null, ControlFlowNodeType.Normal);
			nodes2.Add(controlFlowNode2);
			dictionary[node] = controlFlowNode2;
			controlFlowNode2.UserData = node;
			foreach (ILLabel item5 in node.GetSelfAndChildrenRecursive(list ?? (list = new List<ILLabel>())))
			{
				labelToCfNode[item5] = controlFlowNode2;
			}
		}
		ControlFlowNode controlFlowNode3 = labelToCfNode[entryLabel];
		ControlFlowEdge item3 = new ControlFlowEdge(controlFlowNode, controlFlowNode3, JumpType.Normal);
		controlFlowNode.Outgoing.Add(item3);
		controlFlowNode3.Incoming.Add(item3);
		List<ILExpression> list2 = null;
		foreach (ILBasicBlock node2 in nodes)
		{
			ControlFlowNode controlFlowNode4 = dictionary[node2];
			foreach (ILLabel item6 in node2.GetSelfAndChildrenRecursive(list2 ?? (list2 = new List<ILExpression>()), (ILExpression e) => e.IsBranch()).SelectMany((ILExpression e) => e.GetBranchTargets()))
			{
				if (labelToCfNode.TryGetValue(item6, out var value) && (value != controlFlowNode4 || item6 == node2.Body.FirstOrDefault()))
				{
					ControlFlowEdge item4 = new ControlFlowEdge(controlFlowNode4, value, JumpType.Normal);
					controlFlowNode4.Outgoing.Add(item4);
					value.Incoming.Add(item4);
				}
			}
		}
		return cached_ControlFlowGraph;
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
				if (iLBasicBlock.MatchSingleAndBr<ILLabel>(ILCode.Brtrue, out var operand, out var arg, out var brLabel))
				{
					labelToCfNode.TryGetValue(operand, out var value);
					labelToCfNode.TryGetValue(brLabel, out var value2);
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
						labelToCfNode.TryGetValue(brLabel, out var value3);
						if (value3 != null)
						{
							HashSet<ControlFlowNode> second = FindDominatedNodes(scope, value3);
							IEnumerable<ControlFlowNode> other = from n in scope.Except(second)
								where node.Dominates(n)
								select n;
							hashSet.UnionWith(other);
						}
						ILNode[] array = iLBasicBlock.Body.RemoveTail(ILCode.Brtrue, ILCode.Br);
						ILWhileLoop iLWhileLoop;
						iLBasicBlock.Body.Add(iLWhileLoop = new ILWhileLoop
						{
							Condition = arg,
							BodyBlock = new ILBlock(CodeBracesRangeFlags.LoopBraces)
							{
								EntryGoto = new ILExpression(ILCode.Br, operand),
								Body = FindLoops(hashSet, node, excludeEntryPoint: false)
							}
						});
						if (context.CalculateILSpans)
						{
							iLWhileLoop.ILSpans.AddRange(array[0].ILSpans);
							array[1].AddSelfAndChildrenRecursiveILSpans(iLWhileLoop.ILSpans);
						}
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
								BodyBlock = new ILBlock(CodeBracesRangeFlags.LoopBraces)
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
				if (iLBasicBlock.MatchLastAndBr<ILLabel[]>(ILCode.Switch, out var operand, out var arg, out var brLabel))
				{
					ILSwitch iLSwitch = new ILSwitch
					{
						Condition = arg
					};
					ILNode[] array = iLBasicBlock.Body.RemoveTail(ILCode.Switch, ILCode.Br);
					if (context.CalculateILSpans)
					{
						iLSwitch.ILSpans.AddRange(array[0].ILSpans);
						array[1].AddSelfAndChildrenRecursiveILSpans(iLSwitch.ILSpans);
					}
					iLBasicBlock.Body.Add(iLSwitch);
					iLBasicBlock.Body.Add(new ILExpression(ILCode.Br, brLabel));
					list.Add(iLBasicBlock);
					scope.RemoveOrThrow(controlFlowNode);
					int operand2 = 0;
					if (((ILNode)iLSwitch.Condition).Match(ILCode.Sub, out List<ILExpression> args) && ((ILNode)args[1]).Match(ILCode.Ldc_I4, out operand2))
					{
						ILExpression condition = iLSwitch.Condition;
						iLSwitch.Condition = args[0];
						if (context.CalculateILSpans)
						{
							iLSwitch.Condition.ILSpans.AddRange(condition.ILSpans);
							for (int i = 1; i < args.Count; i++)
							{
								args[i].AddSelfAndChildrenRecursiveILSpans(iLSwitch.Condition.ILSpans);
							}
						}
					}
					ControlFlowNode value = null;
					labelToCfNode.TryGetValue(brLabel, out value);
					HashSet<ControlFlowNode> hashSet = new HashSet<ControlFlowNode>();
					if (value != null)
					{
						hashSet.UnionWith(value.DominanceFrontier.Except(new ControlFlowNode[1] { value }));
					}
					ILLabel[] array2 = operand;
					foreach (ILLabel key in array2)
					{
						labelToCfNode.TryGetValue(key, out var value2);
						if (value2 != null)
						{
							hashSet.UnionWith(value2.DominanceFrontier.Except(new ControlFlowNode[1] { value2 }));
						}
					}
					bool flag = false;
					for (int k = 0; k < operand.Length; k++)
					{
						ILLabel condLabel = operand[k];
						ILSwitch.CaseBlock caseBlock = iLSwitch.CaseBlocks.FirstOrDefault((ILSwitch.CaseBlock b) => b.EntryGoto.Operand == condLabel);
						if (caseBlock == null)
						{
							caseBlock = new ILSwitch.CaseBlock
							{
								Values = new List<int>(),
								EntryGoto = new ILExpression(ILCode.Br, condLabel)
							};
							iLSwitch.CaseBlocks.Add(caseBlock);
							if (!flag && condLabel == brLabel)
							{
								flag = true;
								iLBasicBlock.Body.RemoveTail(ILCode.Br);
								caseBlock.Values = null;
							}
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
						caseBlock.Values?.Add(k + operand2);
					}
					if (!flag && value != null && !hashSet.Contains(value))
					{
						HashSet<ControlFlowNode> hashSet3 = FindDominatedNodes(scope, value);
						if (hashSet3.Any())
						{
							ILSwitch.CaseBlock caseBlock2 = new ILSwitch.CaseBlock
							{
								EntryGoto = new ILExpression(ILCode.Br, brLabel)
							};
							iLSwitch.CaseBlocks.Add(caseBlock2);
							array = iLBasicBlock.Body.RemoveTail(ILCode.Br);
							if (context.CalculateILSpans)
							{
								array[0].AddSelfAndChildrenRecursiveILSpans(caseBlock2.ILSpans);
							}
							scope.ExceptWith(hashSet3);
							caseBlock2.Body.AddRange(FindConditions(hashSet3, value));
							caseBlock2.Body.Add(new ILBasicBlock
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
				if (iLBasicBlock.MatchLastAndBr<ILLabel>(ILCode.Brtrue, out var operand3, out var arg2, out var brLabel2))
				{
					ILLabel iLLabel = operand3;
					operand3 = brLabel2;
					brLabel2 = iLLabel;
					arg2 = new ILExpression(ILCode.LogicNot, null, arg2);
					ILCondition iLCondition = new ILCondition
					{
						Condition = arg2,
						TrueBlock = new ILBlock(CodeBracesRangeFlags.ConditionalBraces)
						{
							EntryGoto = new ILExpression(ILCode.Br, operand3)
						},
						FalseBlock = new ILBlock(CodeBracesRangeFlags.ConditionalBraces)
						{
							EntryGoto = new ILExpression(ILCode.Br, brLabel2)
						}
					};
					ILNode[] array3 = iLBasicBlock.Body.RemoveTail(ILCode.Brtrue, ILCode.Br);
					if (context.CalculateILSpans)
					{
						arg2.ILSpans.AddRange(array3[0].ILSpans);
						array3[1].AddSelfAndChildrenRecursiveILSpans(iLCondition.FalseBlock.ILSpans);
					}
					iLBasicBlock.Body.Add(iLCondition);
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
						iLCondition.TrueBlock.Body.AddRange(FindConditions(hashSet4, value4));
					}
					if (value5 != null && HasSingleEdgeEnteringBlock(value5))
					{
						HashSet<ControlFlowNode> hashSet5 = FindDominatedNodes(scope, value5);
						scope.ExceptWith(hashSet5);
						iLCondition.FalseBlock.Body.AddRange(FindConditions(hashSet5, value5));
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
				for (int i = 0; i < controlFlowNode.Outgoing.Count; i++)
				{
					hashSet.Add(controlFlowNode.Outgoing[i].Target);
				}
			}
		}
		return hashSet2;
	}

	private static HashSet<ControlFlowNode> FindLoopContent(HashSet<ControlFlowNode> scope, ControlFlowNode head)
	{
		HashSet<ControlFlowNode> hashSet = new HashSet<ControlFlowNode>();
		for (int i = 0; i < head.Incoming.Count; i++)
		{
			ControlFlowNode source = head.Incoming[i].Source;
			if (head.Dominates(source))
			{
				hashSet.Add(source);
			}
		}
		HashSet<ControlFlowNode> hashSet2 = new HashSet<ControlFlowNode>();
		while (hashSet.Count > 0)
		{
			ControlFlowNode controlFlowNode = hashSet.First();
			hashSet.Remove(controlFlowNode);
			if (scope.Contains(controlFlowNode) && head.Dominates(controlFlowNode) && hashSet2.Add(controlFlowNode))
			{
				for (int j = 0; j < controlFlowNode.Incoming.Count; j++)
				{
					hashSet.Add(controlFlowNode.Incoming[j].Source);
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
