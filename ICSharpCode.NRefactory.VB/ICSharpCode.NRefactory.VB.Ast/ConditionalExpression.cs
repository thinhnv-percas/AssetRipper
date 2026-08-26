using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ConditionalExpression : Expression
{
	public static readonly Role<Expression> ConditionExpressionRole = new Role<Expression>("ConditionExpressionRole", Expression.Null);

	public static readonly Role<Expression> TrueExpressionRole = new Role<Expression>("TrueExpressionRole", Expression.Null);

	public static readonly Role<Expression> FalseExpressionRole = new Role<Expression>("FalseExpressionRole", Expression.Null);

	public VBTokenNode IfToken => GetChildByRole(Roles.Keyword);

	public Expression ConditionExpression
	{
		get
		{
			return GetChildByRole(ConditionExpressionRole);
		}
		set
		{
			SetChildByRole(ConditionExpressionRole, value);
		}
	}

	public Expression TrueExpression
	{
		get
		{
			return GetChildByRole(TrueExpressionRole);
		}
		set
		{
			SetChildByRole(TrueExpressionRole, value);
		}
	}

	public Expression FalseExpression
	{
		get
		{
			return GetChildByRole(FalseExpressionRole);
		}
		set
		{
			SetChildByRole(FalseExpressionRole, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitConditionalExpression(this, data);
	}
}
