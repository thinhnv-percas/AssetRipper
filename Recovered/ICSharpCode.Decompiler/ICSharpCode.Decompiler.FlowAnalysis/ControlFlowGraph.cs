using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	public sealed class ControlFlowGraph
	{
		private readonly ReadOnlyCollection<ControlFlowNode> nodes;

		public ControlFlowNode EntryPoint => nodes[0];

		public ControlFlowNode RegularExit => nodes[1];

		public ControlFlowNode ExceptionalExit => nodes[2];

		public ReadOnlyCollection<ControlFlowNode> Nodes => nodes;

		internal ControlFlowGraph(ControlFlowNode[] nodes)
		{
			this.nodes = new ReadOnlyCollection<ControlFlowNode>(nodes);
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
						ControlFlowNode controlFlowNode = b.Predecessors.First((ControlFlowNode block) => block.Visited && block != b);
						foreach (ControlFlowNode predecessor in b.Predecessors)
						{
							if (predecessor != b && predecessor.ImmediateDominator != null)
							{
								controlFlowNode = FindCommonDominator(predecessor, controlFlowNode);
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

		private static ControlFlowNode FindCommonDominator(ControlFlowNode b1, ControlFlowNode b2)
		{
			HashSet<ControlFlowNode> hashSet = new HashSet<ControlFlowNode>();
			while (b1 != null && hashSet.Add(b1))
			{
				b1 = b1.ImmediateDominator;
			}
			while (b2 != null)
			{
				if (hashSet.Contains(b2))
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
				foreach (ControlFlowNode successor in n.Successors)
				{
					if (successor.ImmediateDominator != n)
					{
						n.DominanceFrontier.Add(successor);
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
}
