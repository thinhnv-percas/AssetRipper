#define DEBUG
#define STEP
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

public class LoopDetection : IBlockTransform
{
	private BlockTransformContext context;

	private BlockContainer currentBlockContainer;

	private bool isSwitch;

	private SwitchDetection.LoopContext loopContext;

	private static readonly ControlFlowNode NoExitPoint = new ControlFlowNode();

	public void Run(Block block, BlockTransformContext context)
	{
		this.context = context;
		Debug.Assert(block.Parent == context.ControlFlowGraph.Container);
		currentBlockContainer = context.ControlFlowGraph.Container;
		if (block.Instructions.Last() is SwitchInstruction switchInst)
		{
			DetectSwitchBody(block, switchInst);
		}
		ControlFlowNode controlFlowNode = context.ControlFlowNode;
		Debug.Assert(controlFlowNode.UserData == block);
		Debug.Assert(!Enumerable.Any<ControlFlowNode>(TreeTraversal.PreOrder(controlFlowNode, (ControlFlowNode n) => n.DominatorTreeChildren), (Func<ControlFlowNode, bool>)((ControlFlowNode n) => n.Visited)));
		List<ControlFlowNode> list = null;
		foreach (ControlFlowNode predecessor in controlFlowNode.Predecessors)
		{
			if (controlFlowNode.Dominates(predecessor))
			{
				if (list == null)
				{
					list = new List<ControlFlowNode>();
					list.Add(controlFlowNode);
					controlFlowNode.Visited = true;
				}
				predecessor.TraversePreOrder((ControlFlowNode n) => n.Predecessors, list.Add);
			}
		}
		if (list == null)
		{
			return;
		}
		Block block2 = (Block)controlFlowNode.UserData;
		context.Step("Construct loop with head " + block2.Label, block2);
		IncludeNestedContainers(list);
		ExtendLoop(controlFlowNode, list, out var exitPoint);
		IncludeUnreachablePredecessors(list);
		list.Sort((ControlFlowNode a, ControlFlowNode b) => b.PostOrderNumber.CompareTo(a.PostOrderNumber));
		Debug.Assert(list[0] == controlFlowNode);
		foreach (ControlFlowNode item in list)
		{
			item.Visited = false;
			Debug.Assert(controlFlowNode.Dominates(item) || !item.IsReachable, "The loop body must be dominated by the loop head");
		}
		ConstructLoop(list, exitPoint);
	}

	private void IncludeNestedContainers(List<ControlFlowNode> loop)
	{
		for (int i = 0; i < loop.Count; i = checked(i + 1))
		{
			IncludeBlock((Block)loop[i].UserData);
		}
		void IncludeBlock(Block block)
		{
			foreach (BlockContainer item in Enumerable.OfType<BlockContainer>((IEnumerable)block.Instructions))
			{
				IncludeBlock(item.EntryPoint);
				for (int j = 1; j < item.Blocks.Count; j = checked(j + 1))
				{
					ControlFlowNode node = context.ControlFlowGraph.GetNode(item.Blocks[j]);
					Debug.Assert(loop[0].Dominates(node) || !node.IsReachable);
					if (!node.Visited)
					{
						node.Visited = true;
						loop.Add(node);
					}
				}
			}
		}
	}

	private void ExtendLoop(ControlFlowNode loopHead, List<ControlFlowNode> loop, out ControlFlowNode exitPoint)
	{
		exitPoint = FindExitPoint(loopHead, loop);
		Debug.Assert(!loop.Contains(exitPoint), "Cannot pick an exit point that is part of the natural loop");
		if (exitPoint != null)
		{
			ControlFlowNode ep = exitPoint;
			{
				foreach (ControlFlowNode item in TreeTraversal.PreOrder(loopHead, (ControlFlowNode n) => DominatorTreeChildren(n, ep)))
				{
					if (!item.Visited)
					{
						item.Visited = true;
						loop.Add(item);
					}
				}
				return;
			}
		}
		ExtendLoopHeuristic(loopHead, loop, loopHead);
	}

	internal ControlFlowNode FindExitPoint(ControlFlowNode loopHead, IReadOnlyList<ControlFlowNode> naturalLoop)
	{
		if (!HasReachableExit(loopHead))
		{
			if (IsPossibleForeachLoop((Block)loopHead.UserData, out var exitBranch))
			{
				if (exitBranch != null)
				{
					ControlFlowNode controlFlowNode = loopHead.Successors.FirstOrDefault((ControlFlowNode n) => n.UserData == exitBranch.TargetBlock);
					if (controlFlowNode != null && loopHead.Dominates(controlFlowNode) && !context.ControlFlowGraph.HasReachableExit(controlFlowNode))
					{
						return controlFlowNode;
					}
				}
				return NoExitPoint;
			}
			ControlFlowNode exitPoint = null;
			int exitPointILOffset = -1;
			foreach (ControlFlowNode dominatorTreeChild in loopHead.DominatorTreeChildren)
			{
				PickExitPoint(dominatorTreeChild, ref exitPoint, ref exitPointILOffset);
			}
			return exitPoint;
		}
		ControlFlowNode[] cfg = context.ControlFlowGraph.cfg;
		ControlFlowNode[] array = PrepareReverseCFG(loopHead, out var exitNodeArity);
		ControlFlowNode controlFlowNode2 = array[loopHead.UserIndex];
		Debug.Assert(controlFlowNode2.IsReachable);
		foreach (ControlFlowNode item in naturalLoop)
		{
			ControlFlowNode controlFlowNode3 = array[item.UserIndex];
			if (controlFlowNode3.IsReachable)
			{
				controlFlowNode2 = Dominance.FindCommonDominator(controlFlowNode2, controlFlowNode3);
			}
		}
		while (controlFlowNode2.UserIndex >= 0)
		{
			ControlFlowNode controlFlowNode4 = cfg[controlFlowNode2.UserIndex];
			Debug.Assert(controlFlowNode4.Visited == Enumerable.Contains<ControlFlowNode>((IEnumerable<ControlFlowNode>)naturalLoop, controlFlowNode4));
			if (!controlFlowNode4.Visited && ValidateExitPoint(loopHead, controlFlowNode4))
			{
				return controlFlowNode4;
			}
			controlFlowNode2 = controlFlowNode2.ImmediateDominator;
		}
		if (exitNodeArity > 1)
		{
			return null;
		}
		if (exitNodeArity == 1 && isSwitch)
		{
			return Enumerable.Single<ControlFlowNode>(Enumerable.Distinct<ControlFlowNode>(loopContext.GetBreakTargets(loopHead)));
		}
		return NoExitPoint;
	}

	private bool ValidateExitPoint(ControlFlowNode loopHead, ControlFlowNode exitPoint)
	{
		ControlFlowGraph cfg = context.ControlFlowGraph;
		return IsValid(exitPoint);
		bool IsValid(ControlFlowNode node)
		{
			if (!cfg.HasReachableExit(node))
			{
				return true;
			}
			foreach (ControlFlowNode successor in node.Successors)
			{
				if (loopHead != successor && loopHead.Dominates(successor) && !exitPoint.Dominates(successor))
				{
					return false;
				}
			}
			foreach (ControlFlowNode dominatorTreeChild in node.DominatorTreeChildren)
			{
				if (!IsValid(dominatorTreeChild))
				{
					return false;
				}
			}
			return true;
		}
	}

	private bool HasReachableExit(ControlFlowNode node)
	{
		return isSwitch ? Enumerable.Any<ControlFlowNode>(loopContext.GetBreakTargets(node)) : context.ControlFlowGraph.HasReachableExit(node);
	}

	private IEnumerable<ControlFlowNode> DominatorTreeChildren(ControlFlowNode n, ControlFlowNode exitPoint)
	{
		return Enumerable.Where<ControlFlowNode>((IEnumerable<ControlFlowNode>)n.DominatorTreeChildren, (Func<ControlFlowNode, bool>)((ControlFlowNode c) => c != exitPoint && (!isSwitch || !loopContext.MatchContinue(c))));
	}

	private void PickExitPoint(ControlFlowNode node, ref ControlFlowNode exitPoint, ref int exitPointILOffset)
	{
		if (isSwitch && loopContext.MatchContinue(node))
		{
			return;
		}
		Block block = (Block)node.UserData;
		if (block.StartILOffset > exitPointILOffset && !HasReachableExit(node) && ((Block)node.UserData).Parent == currentBlockContainer)
		{
			exitPoint = node;
			exitPointILOffset = block.StartILOffset;
			return;
		}
		foreach (ControlFlowNode dominatorTreeChild in node.DominatorTreeChildren)
		{
			PickExitPoint(dominatorTreeChild, ref exitPoint, ref exitPointILOffset);
		}
	}

	private ControlFlowNode[] PrepareReverseCFG(ControlFlowNode loopHead, out int exitNodeArity)
	{
		ControlFlowNode[] cfg = context.ControlFlowGraph.cfg;
		checked
		{
			ControlFlowNode[] array = new ControlFlowNode[cfg.Length + 1];
			for (int i = 0; i < cfg.Length; i++)
			{
				array[i] = new ControlFlowNode
				{
					UserIndex = i,
					UserData = cfg[i].UserData
				};
			}
			ControlFlowNode controlFlowNode = null;
			bool flag = false;
			ControlFlowNode controlFlowNode2 = new ControlFlowNode
			{
				UserIndex = -1
			};
			array[cfg.Length] = controlFlowNode2;
			for (int j = 0; j < cfg.Length; j++)
			{
				if (!loopHead.Dominates(cfg[j]) || (isSwitch && cfg[j] != loopHead && loopContext.MatchContinue(cfg[j])))
				{
					continue;
				}
				foreach (ControlFlowNode successor in cfg[j].Successors)
				{
					if (isSwitch && loopContext.MatchContinue(successor, 1))
					{
						continue;
					}
					if (loopHead.Dominates(successor))
					{
						array[successor.UserIndex].AddEdgeTo(array[j]);
						continue;
					}
					if (controlFlowNode == null)
					{
						controlFlowNode = successor;
					}
					if (controlFlowNode != successor)
					{
						flag = true;
					}
					controlFlowNode2.AddEdgeTo(array[j]);
				}
				if (context.ControlFlowGraph.HasDirectExitOutOfContainer(cfg[j]))
				{
					controlFlowNode2.AddEdgeTo(array[j]);
				}
			}
			if (flag)
			{
				exitNodeArity = 2;
			}
			else if (controlFlowNode != null)
			{
				exitNodeArity = 1;
			}
			else
			{
				exitNodeArity = 0;
			}
			Dominance.ComputeDominance(controlFlowNode2, context.CancellationToken);
			return array;
		}
	}

	private static bool IsPossibleForeachLoop(Block loopHead, out Branch exitBranch)
	{
		exitBranch = null;
		BlockContainer blockContainer = (BlockContainer)loopHead.Parent;
		if (blockContainer.SlotInfo != TryInstruction.TryBlockSlot || !(blockContainer.Parent is TryFinally))
		{
			return false;
		}
		if (loopHead.Instructions.Count != 2)
		{
			return false;
		}
		if (!loopHead.Instructions[0].MatchIfInstruction(out var condition, out var trueInst))
		{
			return false;
		}
		ILInstruction b = loopHead.Instructions[1];
		ILInstruction arg;
		while (condition.MatchLogicNot(out arg))
		{
			condition = arg;
			ExtensionMethods.Swap(ref trueInst, ref b);
		}
		if (!(condition is CallInstruction callInstruction) || !(callInstruction.Method.Name == "MoveNext"))
		{
			return false;
		}
		if (callInstruction.Arguments.Count != 1 || !callInstruction.Arguments[0].MatchLdLocRef(out var _))
		{
			return false;
		}
		exitBranch = b as Branch;
		Block block = blockContainer.EntryPoint;
		Block targetBlock;
		while (block.IncomingEdgeCount == 1 && block.Instructions.Count == 1 && block.Instructions[0].MatchBranch(out targetBlock))
		{
			block = targetBlock;
		}
		return block == loopHead;
	}

	private void ExtendLoopHeuristic(ControlFlowNode loopHead, List<ControlFlowNode> loop, ControlFlowNode candidate)
	{
		Debug.Assert(candidate.Visited == loop.Contains(candidate));
		if (!candidate.Visited)
		{
			List<ControlFlowNode> list = new List<ControlFlowNode>();
			candidate.TraversePreOrder((ControlFlowNode n) => n.Predecessors, list.Add);
			HashSet<ControlFlowNode> val = Enumerable.Where<ControlFlowNode>(Enumerable.SelectMany<ControlFlowNode, ControlFlowNode>((IEnumerable<ControlFlowNode>)list, (Func<ControlFlowNode, IEnumerable<ControlFlowNode>>)((ControlFlowNode n) => n.Successors)), (Func<ControlFlowNode, bool>)((ControlFlowNode n) => !n.Visited)).ToHashSet();
			foreach (ControlFlowNode item in list)
			{
				item.Visited = false;
			}
			int num = Enumerable.Count<ControlFlowNode>((IEnumerable<ControlFlowNode>)list, (Func<ControlFlowNode, bool>)IsExitPoint);
			int num2 = Enumerable.Count<ControlFlowNode>((IEnumerable<ControlFlowNode>)val, (Func<ControlFlowNode, bool>)((ControlFlowNode n) => !IsExitPoint(n)));
			if (num > num2)
			{
				candidate.TraversePreOrder((ControlFlowNode n) => n.Predecessors, loop.Add);
			}
		}
		foreach (ControlFlowNode dominatorTreeChild in candidate.DominatorTreeChildren)
		{
			ExtendLoopHeuristic(loopHead, loop, dominatorTreeChild);
		}
	}

	private bool IsExitPoint(ControlFlowNode node)
	{
		if (node.Visited)
		{
			return false;
		}
		foreach (ControlFlowNode predecessor in node.Predecessors)
		{
			if (predecessor.Visited)
			{
				return true;
			}
		}
		return false;
	}

	private void IncludeUnreachablePredecessors(List<ControlFlowNode> loop)
	{
		for (int i = 1; i < loop.Count; i = checked(i + 1))
		{
			Debug.Assert(loop[i].Visited);
			foreach (ControlFlowNode predecessor in loop[i].Predecessors)
			{
				if (!predecessor.Visited)
				{
					if (predecessor.IsReachable)
					{
						Debug.Fail("All jumps into the loop body should go through the entry point");
						continue;
					}
					predecessor.Visited = true;
					loop.Add(predecessor);
				}
			}
		}
	}

	private void ConstructLoop(List<ControlFlowNode> loop, ControlFlowNode exitPoint)
	{
		Block block = (Block)loop[0].UserData;
		Block block2 = (Block)(exitPoint?.UserData);
		BlockContainer blockContainer = new BlockContainer(ContainerKind.Loop);
		Block block3 = new Block();
		blockContainer.Blocks.Add(block3);
		block3.Instructions.ReplaceList(block.Instructions);
		block3.AddILRange(block);
		block.Instructions.ReplaceList(new BlockContainer[1] { blockContainer });
		if (block2 != null)
		{
			block.Instructions.Add(new Branch(block2));
		}
		blockContainer.AddILRange(block3);
		MoveBlocksIntoContainer(loop, blockContainer);
		foreach (Branch item in Enumerable.OfType<Branch>((IEnumerable)blockContainer.Descendants))
		{
			if (item.TargetBlock == block)
			{
				item.TargetBlock = block3;
			}
			else if (item.TargetBlock == block2)
			{
				item.ReplaceWith(new Leave(blockContainer).WithILRange(item));
			}
		}
	}

	private void MoveBlocksIntoContainer(List<ControlFlowNode> loop, BlockContainer loopContainer)
	{
		checked
		{
			for (int i = 1; i < loop.Count; i++)
			{
				Block block = (Block)loop[i].UserData;
				if (block.Parent == currentBlockContainer)
				{
					Debug.Assert(block.ChildIndex != 0);
					int childIndex = block.ChildIndex;
					loopContainer.Blocks.Add(block);
					currentBlockContainer.Blocks.SwapRemoveAt(childIndex);
				}
			}
			for (int j = 1; j < loop.Count; j++)
			{
				Block block2 = (Block)loop[j].UserData;
				Debug.Assert(block2.IsDescendantOf(loopContainer));
			}
		}
	}

	private void DetectSwitchBody(Block block, SwitchInstruction switchInst)
	{
		Debug.Assert(block.Instructions.Last() == switchInst);
		ControlFlowNode controlFlowNode = context.ControlFlowNode;
		Debug.Assert(controlFlowNode.UserData == block);
		Debug.Assert(!Enumerable.Any<ControlFlowNode>(TreeTraversal.PreOrder(controlFlowNode, (ControlFlowNode n) => n.DominatorTreeChildren), (Func<ControlFlowNode, bool>)((ControlFlowNode n) => n.Visited)));
		isSwitch = true;
		loopContext = new SwitchDetection.LoopContext(context.ControlFlowGraph, controlFlowNode);
		List<ControlFlowNode> list = new List<ControlFlowNode>();
		list.Add(controlFlowNode);
		controlFlowNode.Visited = true;
		ExtendLoop(controlFlowNode, list, out var exitPoint);
		if (exitPoint != null && controlFlowNode.Dominates(exitPoint) && exitPoint.Predecessors.Count == 1 && !HasReachableExit(exitPoint))
		{
			list.AddRange(TreeTraversal.PreOrder(exitPoint, (ControlFlowNode p) => p.DominatorTreeChildren));
			foreach (ControlFlowNode item in list)
			{
				item.Visited = true;
			}
			exitPoint = null;
		}
		IncludeUnreachablePredecessors(list);
		context.Step("Create BlockContainer for switch", switchInst);
		list.Sort((ControlFlowNode a, ControlFlowNode b) => b.PostOrderNumber.CompareTo(a.PostOrderNumber));
		Debug.Assert(list[0] == controlFlowNode);
		foreach (ControlFlowNode item2 in list)
		{
			item2.Visited = false;
			Debug.Assert(controlFlowNode.Dominates(item2) || !item2.IsReachable, "The switch body must be dominated by the switch head");
		}
		BlockContainer blockContainer = new BlockContainer(ContainerKind.Switch);
		Block block2 = new Block();
		block2.AddILRange(switchInst);
		blockContainer.Blocks.Add(block2);
		block2.Instructions.Add(switchInst);
		block.Instructions[checked(block.Instructions.Count - 1)] = blockContainer;
		Block block3 = (Block)(exitPoint?.UserData);
		if (block3 != null)
		{
			block.Instructions.Add(new Branch(block3));
		}
		blockContainer.AddILRange(block2);
		MoveBlocksIntoContainer(list, blockContainer);
		foreach (Branch item3 in Enumerable.OfType<Branch>((IEnumerable)blockContainer.Descendants))
		{
			if (item3.TargetBlock == block3)
			{
				item3.ReplaceWith(new Leave(blockContainer).WithILRange(item3));
			}
		}
		isSwitch = false;
	}
}
