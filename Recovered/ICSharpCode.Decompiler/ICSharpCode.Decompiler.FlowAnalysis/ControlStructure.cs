using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;

namespace ICSharpCode.Decompiler.FlowAnalysis
{
	public class ControlStructure
	{
		public readonly ControlStructureType Type;

		public readonly List<ControlStructure> Children = new List<ControlStructure>();

		public readonly HashSet<ControlFlowNode> Nodes;

		public readonly HashSet<ControlFlowNode> AllNodes;

		public readonly ControlFlowNode EntryPoint;

		public ExceptionHandler ExceptionHandler;

		public ControlStructure(HashSet<ControlFlowNode> nodes, ControlFlowNode entryPoint, ControlStructureType type)
		{
			if (nodes == null)
			{
				throw new ArgumentNullException("nodes");
			}
			Nodes = nodes;
			EntryPoint = entryPoint;
			Type = type;
			AllNodes = new HashSet<ControlFlowNode>(nodes);
		}
	}
}
