using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class JoinCondition : AstNode
{
	public static readonly Role<JoinCondition> JoinConditionRole = new Role<JoinCondition>("JoinCondition");

	public static readonly Role<Expression> LeftExpressionRole = BinaryOperatorExpression.LeftExpressionRole;

	public static readonly Role<Expression> RightExpressionRole = BinaryOperatorExpression.RightExpressionRole;

	public Expression Left
	{
		get
		{
			return GetChildByRole(LeftExpressionRole);
		}
		set
		{
			SetChildByRole(LeftExpressionRole, value);
		}
	}

	public Expression Right
	{
		get
		{
			return GetChildByRole(RightExpressionRole);
		}
		set
		{
			SetChildByRole(RightExpressionRole, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitJoinCondition(this, data);
	}
}
