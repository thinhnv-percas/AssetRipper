using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;
using System.Linq;

namespace ICSharpCode.Decompiler.Ast.Transforms
{
	internal sealed class LdTokenPattern : Pattern
	{
		private AnyNode childNode;

		public LdTokenPattern(string groupName)
		{
			childNode = new AnyNode(groupName);
		}

		public override bool DoMatch(INode other, Match match)
		{
			InvocationExpression invocationExpression = other as InvocationExpression;
			if (invocationExpression != null && invocationExpression.Annotation<LdTokenAnnotation>() != null && invocationExpression.Arguments.Count == 1)
			{
				return childNode.DoMatch(invocationExpression.Arguments.Single(), match);
			}
			return false;
		}

		public override string ToString()
		{
			return "ldtoken(...)";
		}
	}
}
