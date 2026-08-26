#define DEBUG
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.FlowAnalysis;

public static class Dominance
{
	public static void ComputeDominance(ControlFlowNode entryPoint, CancellationToken cancellationToken = default(CancellationToken))
	{
		List<ControlFlowNode> list = new List<ControlFlowNode>();
		entryPoint.TraversePostOrder((ControlFlowNode n) => n.Successors, list.Add);
		Debug.Assert(list.Last() == entryPoint);
		checked
		{
			for (int num = 0; num < list.Count; num++)
			{
				list[num].PostOrderNumber = num;
			}
			entryPoint.ImmediateDominator = entryPoint;
			bool flag;
			do
			{
				flag = false;
				cancellationToken.ThrowIfCancellationRequested();
				for (int num2 = list.Count - 2; num2 >= 0; num2--)
				{
					ControlFlowNode controlFlowNode = list[num2];
					ControlFlowNode controlFlowNode2 = null;
					foreach (ControlFlowNode predecessor in controlFlowNode.Predecessors)
					{
						if (predecessor.ImmediateDominator != null)
						{
							controlFlowNode2 = ((controlFlowNode2 != null) ? FindCommonDominator(predecessor, controlFlowNode2) : predecessor);
						}
					}
					Debug.Assert(controlFlowNode2 != null);
					if (controlFlowNode2 != controlFlowNode.ImmediateDominator)
					{
						controlFlowNode.ImmediateDominator = controlFlowNode2;
						flag = true;
					}
				}
			}
			while (flag);
			foreach (ControlFlowNode item in list)
			{
				if (item.ImmediateDominator != null)
				{
					item.DominatorTreeChildren = new List<ControlFlowNode>();
				}
			}
			entryPoint.ImmediateDominator = null;
			foreach (ControlFlowNode item2 in list)
			{
				if (item2.ImmediateDominator != null)
				{
					item2.ImmediateDominator.DominatorTreeChildren.Add(item2);
				}
				item2.Visited = false;
			}
		}
	}

	public static ControlFlowNode FindCommonDominator(ControlFlowNode a, ControlFlowNode b)
	{
		while (a != b)
		{
			while (a.PostOrderNumber < b.PostOrderNumber)
			{
				a = a.ImmediateDominator;
			}
			while (b.PostOrderNumber < a.PostOrderNumber)
			{
				b = b.ImmediateDominator;
			}
		}
		return a;
	}

	public static BitSet MarkNodesWithReachableExits(ControlFlowNode[] cfg)
	{
		for (int i = 0; i < cfg.Length; i = checked(i + 1))
		{
			Debug.Assert(cfg[i].UserIndex == i);
		}
		BitSet bitSet = new BitSet(cfg.Length);
		foreach (ControlFlowNode controlFlowNode in cfg)
		{
			if (!controlFlowNode.IsReachable || (controlFlowNode.Predecessors.Count < 2 && (controlFlowNode.Predecessors.Count < 1 || controlFlowNode.ImmediateDominator != null)))
			{
				continue;
			}
			foreach (ControlFlowNode predecessor in controlFlowNode.Predecessors)
			{
				ControlFlowNode controlFlowNode2 = predecessor;
				while (controlFlowNode2 != controlFlowNode.ImmediateDominator && controlFlowNode2 != controlFlowNode && controlFlowNode2 != null)
				{
					bitSet.Set(controlFlowNode2.UserIndex);
					controlFlowNode2 = controlFlowNode2.ImmediateDominator;
				}
			}
		}
		return bitSet;
	}
}
