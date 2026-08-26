#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using DecompTools.Decompiler.FlowAnalysis;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL.ControlFlow;

public class ControlFlowGraph
{
	private readonly BlockContainer container;

	internal readonly ControlFlowNode[] cfg;

	private readonly Dictionary<Block, ControlFlowNode> dict = new Dictionary<Block, ControlFlowNode>();

	private readonly BitSet nodeHasDirectExitOutOfContainer;

	private readonly BitSet nodeHasReachableExit;

	public BlockContainer Container => container;

	public ControlFlowGraph(BlockContainer container, CancellationToken cancellationToken = default(CancellationToken))
	{
		this.container = container;
		cfg = new ControlFlowNode[container.Blocks.Count];
		nodeHasDirectExitOutOfContainer = new BitSet(cfg.Length);
		for (int i = 0; i < cfg.Length; i = checked(i + 1))
		{
			Block block = container.Blocks[i];
			cfg[i] = new ControlFlowNode
			{
				UserIndex = i,
				UserData = block
			};
			dict.Add(block, cfg[i]);
		}
		CreateEdges(cancellationToken);
		Dominance.ComputeDominance(cfg[0], cancellationToken);
		nodeHasReachableExit = Dominance.MarkNodesWithReachableExits(cfg);
		nodeHasReachableExit.UnionWith(FindNodesWithExitsOutOfContainer());
	}

	private void CreateEdges(CancellationToken cancellationToken)
	{
		for (int i = 0; i < container.Blocks.Count; i = checked(i + 1))
		{
			cancellationToken.ThrowIfCancellationRequested();
			Block block = container.Blocks[i];
			ControlFlowNode controlFlowNode = cfg[i];
			foreach (ILInstruction descendant in block.Descendants)
			{
				if (descendant is Branch branch)
				{
					if (branch.TargetBlock.Parent == container)
					{
						controlFlowNode.AddEdgeTo(cfg[container.Blocks.IndexOf(branch.TargetBlock)]);
					}
					else if (!branch.TargetBlock.IsDescendantOf(container))
					{
						nodeHasDirectExitOutOfContainer.Set(i);
					}
				}
				else if (descendant is Leave leave && !leave.TargetContainer.IsDescendantOf(block) && !leave.IsLeavingFunction)
				{
					nodeHasDirectExitOutOfContainer.Set(i);
				}
			}
		}
	}

	private BitSet FindNodesWithExitsOutOfContainer()
	{
		BitSet bitSet = new BitSet(cfg.Length);
		ControlFlowNode[] array = cfg;
		foreach (ControlFlowNode controlFlowNode in array)
		{
			if (!bitSet[controlFlowNode.UserIndex] && nodeHasDirectExitOutOfContainer[controlFlowNode.UserIndex])
			{
				ControlFlowNode controlFlowNode2 = controlFlowNode;
				while (controlFlowNode2 != null && !bitSet[controlFlowNode2.UserIndex])
				{
					bitSet.Set(controlFlowNode2.UserIndex);
					controlFlowNode2 = controlFlowNode2.ImmediateDominator;
				}
			}
		}
		return bitSet;
	}

	public ControlFlowNode GetNode(Block block)
	{
		return dict[block];
	}

	public bool HasReachableExit(ControlFlowNode node)
	{
		Debug.Assert(cfg[node.UserIndex] == node);
		return nodeHasReachableExit[node.UserIndex];
	}

	public bool HasDirectExitOutOfContainer(ControlFlowNode node)
	{
		Debug.Assert(cfg[node.UserIndex] == node);
		return nodeHasDirectExitOutOfContainer[node.UserIndex];
	}
}
