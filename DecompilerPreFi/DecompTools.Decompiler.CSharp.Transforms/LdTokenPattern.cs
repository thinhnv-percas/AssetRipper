using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Transforms;

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
			return childNode.DoMatch(Enumerable.Single<Expression>((IEnumerable<Expression>)invocationExpression.Arguments), match);
		}
		return false;
	}

	public override string ToString()
	{
		return "ldtoken(...)";
	}
}
