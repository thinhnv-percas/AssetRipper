using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Analysis
{
	public class ControlFlowNode
	{
		public readonly Statement PreviousStatement;

		public readonly Statement NextStatement;

		public readonly ControlFlowNodeType Type;

		public readonly List<ControlFlowEdge> Outgoing = new List<ControlFlowEdge>();

		public readonly List<ControlFlowEdge> Incoming = new List<ControlFlowEdge>();

		public ControlFlowNode(Statement previousStatement, Statement nextStatement, ControlFlowNodeType type)
		{
			if (previousStatement == null && nextStatement == null)
			{
				throw new ArgumentException("previousStatement and nextStatement must not be both null");
			}
			PreviousStatement = previousStatement;
			NextStatement = nextStatement;
			Type = type;
		}
	}
}
