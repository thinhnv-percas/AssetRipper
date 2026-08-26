using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class OrderByQueryOperator : QueryOperator
{
	public AstNodeCollection<OrderExpression> Expressions => GetChildrenByRole(OrderExpression.OrderExpressionRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitOrderByQueryOperator(this, data);
	}
}
