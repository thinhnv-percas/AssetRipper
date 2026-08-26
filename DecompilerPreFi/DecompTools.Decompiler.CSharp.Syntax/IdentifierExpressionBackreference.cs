using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class IdentifierExpressionBackreference : Pattern
{
	private readonly string referencedGroupName;

	public string ReferencedGroupName => referencedGroupName;

	public IdentifierExpressionBackreference(string referencedGroupName)
	{
		if (referencedGroupName == null)
		{
			throw new ArgumentNullException("referencedGroupName");
		}
		this.referencedGroupName = referencedGroupName;
	}

	public override bool DoMatch(INode other, Match match)
	{
		if (!(other is IdentifierExpression identifierExpression) || Enumerable.Any<AstType>((IEnumerable<AstType>)identifierExpression.TypeArguments))
		{
			return false;
		}
		AstNode astNode = (AstNode)Enumerable.Last<INode>(match.Get(referencedGroupName));
		if (astNode == null)
		{
			return false;
		}
		return identifierExpression.Identifier == astNode.GetChildByRole(Roles.Identifier).Name;
	}
}
