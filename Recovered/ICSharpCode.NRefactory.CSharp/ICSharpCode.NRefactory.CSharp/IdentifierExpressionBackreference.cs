using ICSharpCode.NRefactory.PatternMatching;
using System;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp
{
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
			IdentifierExpression identifierExpression = other as IdentifierExpression;
			if (identifierExpression == null || identifierExpression.TypeArguments.Any())
			{
				return false;
			}
			AstNode astNode = (AstNode)match.Get(referencedGroupName).Last();
			if (astNode == null)
			{
				return false;
			}
			return identifierExpression.Identifier == astNode.GetChildByRole(Roles.Identifier).Name;
		}
	}
}
