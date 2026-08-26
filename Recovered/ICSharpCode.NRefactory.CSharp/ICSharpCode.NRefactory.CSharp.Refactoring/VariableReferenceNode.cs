using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Refactoring
{
	internal class VariableReferenceNode
	{
		public IList<AstNode> References
		{
			get;
			private set;
		}

		public IList<VariableReferenceNode> NextNodes
		{
			get;
			private set;
		}

		public IList<VariableReferenceNode> PreviousNodes
		{
			get;
			private set;
		}

		public VariableReferenceNode()
		{
			References = new List<AstNode>();
			NextNodes = new List<VariableReferenceNode>();
			PreviousNodes = new List<VariableReferenceNode>();
		}

		public void AddNextNode(VariableReferenceNode node)
		{
			if (node != null)
			{
				NextNodes.Add(node);
				node.PreviousNodes.Add(this);
			}
		}
	}
}
