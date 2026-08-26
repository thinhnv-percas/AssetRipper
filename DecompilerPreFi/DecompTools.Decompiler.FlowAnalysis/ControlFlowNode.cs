using System;
using System.Collections.Generic;
using System.Diagnostics;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.FlowAnalysis;

[DebuggerDisplay("CFG UserIndex={UserIndex}, UserData={UserData}")]
public class ControlFlowNode
{
	public int UserIndex;

	public object UserData;

	public bool Visited;

	public int PostOrderNumber;

	public readonly List<ControlFlowNode> Predecessors = new List<ControlFlowNode>();

	public readonly List<ControlFlowNode> Successors = new List<ControlFlowNode>();

	public bool IsReachable => DominatorTreeChildren != null;

	public ControlFlowNode ImmediateDominator { get; internal set; }

	public List<ControlFlowNode> DominatorTreeChildren { get; internal set; }

	public void AddEdgeTo(ControlFlowNode target)
	{
		Successors.Add(target);
		target.Predecessors.Add(this);
	}

	public void TraversePreOrder(Func<ControlFlowNode, IEnumerable<ControlFlowNode>> children, Action<ControlFlowNode> visitAction)
	{
		if (Visited)
		{
			return;
		}
		Visited = true;
		visitAction(this);
		foreach (ControlFlowNode item in children(this))
		{
			item.TraversePreOrder(children, visitAction);
		}
	}

	public void TraversePostOrder(Func<ControlFlowNode, IEnumerable<ControlFlowNode>> children, Action<ControlFlowNode> visitAction)
	{
		if (Visited)
		{
			return;
		}
		Visited = true;
		foreach (ControlFlowNode item in children(this))
		{
			item.TraversePostOrder(children, visitAction);
		}
		visitAction(this);
	}

	public bool Dominates(ControlFlowNode node)
	{
		for (ControlFlowNode controlFlowNode = node; controlFlowNode != null; controlFlowNode = controlFlowNode.ImmediateDominator)
		{
			if (controlFlowNode == this)
			{
				return true;
			}
		}
		return false;
	}

	internal static GraphVizGraph ExportGraph(IReadOnlyList<ControlFlowNode> nodes, Func<ControlFlowNode, string> labelFunc = null)
	{
		if (labelFunc == null)
		{
			labelFunc = (ControlFlowNode node) => (node.UserData is Block block) ? block.Label : node.UserData?.ToString();
		}
		GraphVizGraph graphVizGraph = new GraphVizGraph();
		GraphVizNode[] array = new GraphVizNode[nodes.Count];
		for (int num = 0; num < array.Length; num = checked(num + 1))
		{
			array[num] = new GraphVizNode(nodes[num].UserIndex);
			array[num].shape = "box";
			array[num].label = labelFunc(nodes[num]);
			graphVizGraph.AddNode(array[num]);
		}
		foreach (ControlFlowNode node in nodes)
		{
			foreach (ControlFlowNode successor in node.Successors)
			{
				graphVizGraph.AddEdge(new GraphVizEdge(node.UserIndex, successor.UserIndex));
			}
			if (node.ImmediateDominator != null)
			{
				graphVizGraph.AddEdge(new GraphVizEdge(node.ImmediateDominator.UserIndex, node.UserIndex)
				{
					color = "green"
				});
			}
		}
		return graphVizGraph;
	}
}
