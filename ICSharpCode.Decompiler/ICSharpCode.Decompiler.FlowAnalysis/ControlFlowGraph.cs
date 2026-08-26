using System;
using System.Collections.Generic;
using System.Threading;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.Decompiler.FlowAnalysis;

public sealed class ControlFlowGraph
{
	private readonly List<ControlFlowNode> nodes;

	private readonly HashSet<ControlFlowNode> FindCommonDominator_path1 = new HashSet<ControlFlowNode>();

	public ControlFlowNode EntryPoint => nodes[0];

	public ControlFlowNode RegularExit => nodes[1];

	public ControlFlowNode ExceptionalExit => nodes[2];

	public List<ControlFlowNode> Nodes => nodes;

	internal ControlFlowGraph()
	{
		nodes = new List<ControlFlowNode>();
	}

	public GraphVizGraph ExportGraph()
	{
		GraphVizGraph graphVizGraph = new GraphVizGraph();
		foreach (ControlFlowNode node in nodes)
		{
			graphVizGraph.AddNode(new GraphVizNode(node.BlockIndex)
			{
				label = node.ToString(),
				shape = "box"
			});
		}
		foreach (ControlFlowNode node2 in nodes)
		{
			foreach (ControlFlowEdge item in node2.Outgoing)
			{
				GraphVizEdge graphVizEdge = new GraphVizEdge(item.Source.BlockIndex, item.Target.BlockIndex);
				switch (item.Type)
				{
				case JumpType.LeaveTry:
				case JumpType.EndFinally:
					graphVizEdge.color = "red";
					break;
				default:
					graphVizEdge.color = "gray";
					break;
				case JumpType.Normal:
					break;
				}
				graphVizGraph.AddEdge(graphVizEdge);
			}
			if (node2.ImmediateDominator != null)
			{
				graphVizGraph.AddEdge(new GraphVizEdge(node2.ImmediateDominator.BlockIndex, node2.BlockIndex)
				{
					color = "green",
					constraint = false
				});
			}
		}
		return graphVizGraph;
	}

	public void ResetVisited()
	{
		foreach (ControlFlowNode node in nodes)
		{
			node.Visited = false;
		}
	}

	public void ComputeDominance(CancellationToken cancellationToken = default(CancellationToken))
	{
		EntryPoint.ImmediateDominator = EntryPoint;
		bool changed = true;
		while (changed)
		{
			changed = false;
			ResetVisited();
			cancellationToken.ThrowIfCancellationRequested();
			EntryPoint.TraversePreOrder((ControlFlowNode b) => b.Successors, delegate(ControlFlowNode b)
			{
				if (b != EntryPoint)
				{
					ControlFlowNode controlFlowNode = null;
					for (int i = 0; i < b.Incoming.Count; i++)
					{
						ControlFlowNode source = b.Incoming[i].Source;
						if (source.Visited && source != b)
						{
							controlFlowNode = source;
							break;
						}
					}
					if (controlFlowNode == null)
					{
						throw new InvalidOperationException();
					}
					for (int j = 0; j < b.Incoming.Count; j++)
					{
						ControlFlowNode source2 = b.Incoming[j].Source;
						if (source2 != b && source2.ImmediateDominator != null)
						{
							controlFlowNode = FindCommonDominator(source2, controlFlowNode);
						}
					}
					if (b.ImmediateDominator != controlFlowNode)
					{
						b.ImmediateDominator = controlFlowNode;
						changed = true;
					}
				}
			});
		}
		EntryPoint.ImmediateDominator = null;
		foreach (ControlFlowNode node in nodes)
		{
			if (node.ImmediateDominator != null)
			{
				node.ImmediateDominator.DominatorTreeChildren.Add(node);
			}
		}
	}

	private ControlFlowNode FindCommonDominator(ControlFlowNode b1, ControlFlowNode b2)
	{
		FindCommonDominator_path1.Clear();
		while (b1 != null && FindCommonDominator_path1.Add(b1))
		{
			b1 = b1.ImmediateDominator;
		}
		while (b2 != null)
		{
			if (FindCommonDominator_path1.Contains(b2))
			{
				return b2;
			}
			b2 = b2.ImmediateDominator;
		}
		throw new Exception("No common dominator found!");
	}

	public void ComputeDominanceFrontier()
	{
		ResetVisited();
		EntryPoint.TraversePostOrder((ControlFlowNode b) => b.DominatorTreeChildren, delegate(ControlFlowNode n)
		{
			n.DominanceFrontier = new HashSet<ControlFlowNode>();
			for (int i = 0; i < n.Outgoing.Count; i++)
			{
				ControlFlowNode target = n.Outgoing[i].Target;
				if (target.ImmediateDominator != n)
				{
					n.DominanceFrontier.Add(target);
				}
			}
			foreach (ControlFlowNode dominatorTreeChild in n.DominatorTreeChildren)
			{
				foreach (ControlFlowNode item in dominatorTreeChild.DominanceFrontier)
				{
					if (item.ImmediateDominator != n)
					{
						n.DominanceFrontier.Add(item);
					}
				}
			}
		});
	}
}
