using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using dnlib.DotNet.Emit;

namespace ICSharpCode.Decompiler.FlowAnalysis;

public class ControlStructureDetector
{
	public static ControlStructure DetectStructure(ControlFlowGraph g, IEnumerable<ExceptionHandler> exceptionHandlers, CancellationToken cancellationToken)
	{
		ControlStructure controlStructure = new ControlStructure(new HashSet<ControlFlowNode>(g.Nodes), g.EntryPoint, ControlStructureType.Root);
		DetectExceptionHandling(controlStructure, g, exceptionHandlers);
		DetectLoops(g, controlStructure, cancellationToken);
		return controlStructure;
	}

	private static void DetectExceptionHandling(ControlStructure current, ControlFlowGraph g, IEnumerable<ExceptionHandler> exceptionHandlers)
	{
		foreach (ExceptionHandler eh in exceptionHandlers)
		{
			HashSet<ControlFlowNode> hashSet = FindNodes(current, eh.TryStart, eh.TryEnd);
			current.Nodes.ExceptWith(hashSet);
			ControlStructure controlStructure = new ControlStructure(hashSet, g.Nodes.Single((ControlFlowNode n) => n.Start.Value == eh.TryStart), ControlStructureType.Try);
			controlStructure.ExceptionHandler = eh;
			MoveControlStructures(current, controlStructure, eh.TryStart, eh.TryEnd);
			current.Children.Add(controlStructure);
			if (eh.FilterStart != null)
			{
				throw new NotSupportedException();
			}
			HashSet<ControlFlowNode> hashSet2 = FindNodes(current, eh.HandlerStart, eh.HandlerEnd);
			ControlFlowNode controlFlowNode = current.Nodes.Single((ControlFlowNode n) => n.ExceptionHandler == eh);
			hashSet2.Add(controlFlowNode);
			if (controlFlowNode.EndFinallyOrFaultNode != null)
			{
				hashSet2.Add(controlFlowNode.EndFinallyOrFaultNode);
			}
			current.Nodes.ExceptWith(hashSet2);
			ControlStructure controlStructure2 = new ControlStructure(hashSet2, controlFlowNode, ControlStructureType.Handler);
			controlStructure2.ExceptionHandler = eh;
			MoveControlStructures(current, controlStructure2, eh.HandlerStart, eh.HandlerEnd);
			current.Children.Add(controlStructure2);
		}
	}

	private static HashSet<ControlFlowNode> FindNodes(ControlStructure current, Instruction startInst, Instruction endInst)
	{
		HashSet<ControlFlowNode> hashSet = new HashSet<ControlFlowNode>();
		if (startInst == null || endInst == null)
		{
			return hashSet;
		}
		uint offset = startInst.Offset;
		uint offset2 = endInst.Offset;
		ControlFlowNode[] array = current.Nodes.ToArray();
		foreach (ControlFlowNode controlFlowNode in array)
		{
			if (controlFlowNode.Start != null && offset <= controlFlowNode.Start.Value.Offset && controlFlowNode.Start.Value.Offset < offset2)
			{
				hashSet.Add(controlFlowNode);
			}
		}
		return hashSet;
	}

	private static void MoveControlStructures(ControlStructure current, ControlStructure target, Instruction startInst, Instruction endInst)
	{
		if (startInst == null || endInst == null)
		{
			return;
		}
		for (int i = 0; i < current.Children.Count; i++)
		{
			ControlStructure controlStructure = current.Children[i];
			uint offset = startInst.Offset;
			uint? offset2 = controlStructure.EntryPoint.Offset;
			if (offset <= offset2.GetValueOrDefault() && offset2.HasValue && controlStructure.EntryPoint.Offset < endInst.Offset)
			{
				current.Children.RemoveAt(i--);
				target.Children.Add(controlStructure);
				target.AllNodes.UnionWith(controlStructure.AllNodes);
			}
		}
	}

	private static void DetectLoops(ControlFlowGraph g, ControlStructure current, CancellationToken cancellationToken)
	{
		if (!current.EntryPoint.IsReachable)
		{
			return;
		}
		g.ResetVisited();
		cancellationToken.ThrowIfCancellationRequested();
		FindLoops(current, current.EntryPoint);
		foreach (ControlStructure child in current.Children)
		{
			DetectLoops(g, child, cancellationToken);
		}
	}

	private static void FindLoops(ControlStructure current, ControlFlowNode node)
	{
		if (node.Visited)
		{
			return;
		}
		node.Visited = true;
		if (current.Nodes.Contains(node) && node.DominanceFrontier.Contains(node) && (node != current.EntryPoint || current.Type != ControlStructureType.Loop))
		{
			HashSet<ControlFlowNode> hashSet = new HashSet<ControlFlowNode>();
			FindLoopContents(current, hashSet, node, node);
			List<ControlStructure> list = new List<ControlStructure>();
			bool flag = false;
			foreach (ControlStructure child in current.Children)
			{
				if (child.AllNodes.IsSubsetOf(hashSet))
				{
					list.Add(child);
				}
				else if (child.AllNodes.Intersect(hashSet).Any())
				{
					flag = true;
				}
			}
			if (!flag)
			{
				current.Nodes.ExceptWith(hashSet);
				ControlStructure controlStructure = new ControlStructure(hashSet, node, ControlStructureType.Loop);
				foreach (ControlStructure item in list)
				{
					controlStructure.Children.Add(item);
					current.Children.Remove(item);
					controlStructure.Nodes.ExceptWith(item.AllNodes);
				}
				current.Children.Add(controlStructure);
			}
		}
		foreach (ControlFlowEdge item2 in node.Outgoing)
		{
			FindLoops(current, item2.Target);
		}
	}

	private static void FindLoopContents(ControlStructure current, HashSet<ControlFlowNode> loopContents, ControlFlowNode loopHead, ControlFlowNode node)
	{
		if (!current.AllNodes.Contains(node) || !loopHead.Dominates(node) || !loopContents.Add(node))
		{
			return;
		}
		foreach (ControlFlowEdge item in node.Incoming)
		{
			FindLoopContents(current, loopContents, loopHead, item.Source);
		}
	}
}
