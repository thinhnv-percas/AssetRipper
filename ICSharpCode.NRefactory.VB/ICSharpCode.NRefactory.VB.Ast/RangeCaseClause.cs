using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class RangeCaseClause : CaseClause
{
	public static readonly Role<Expression> ToExpressionRole = ForStatement.ToExpressionRole;

	public Expression ToExpression
	{
		get
		{
			return GetChildByRole(ToExpressionRole);
		}
		set
		{
			SetChildByRole(ToExpressionRole, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitRangeCaseClause(this, data);
	}
}
