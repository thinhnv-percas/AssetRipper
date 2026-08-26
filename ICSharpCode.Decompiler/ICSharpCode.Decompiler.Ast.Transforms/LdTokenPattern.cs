using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast.Transforms;

internal sealed class LdTokenPattern : Pattern
{
	private AnyNode childNode;

	public LdTokenPattern(string groupName)
	{
		childNode = new AnyNode(groupName);
	}

	public override bool DoMatch(INode other, Match match)
	{
		if (other is InvocationExpression invocationExpression && invocationExpression.Annotation<LdTokenAnnotation>() != null && invocationExpression.Arguments.Count == 1)
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
