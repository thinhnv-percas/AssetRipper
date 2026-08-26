using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class QueryExpression : Expression
{
	public AstNodeCollection<QueryOperator> QueryOperators => GetChildrenByRole(QueryOperator.QueryOperatorRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQueryExpression(this, data);
	}
}
