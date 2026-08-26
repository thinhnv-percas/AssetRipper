using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ExpressionStatement : Statement
{
	public Expression Expression
	{
		get
		{
			return GetChildByRole(Roles.Expression);
		}
		set
		{
			SetChildByRole(Roles.Expression, value);
		}
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitExpressionStatement(this, data);
	}

	public ExpressionStatement()
	{
	}

	public ExpressionStatement(Expression expression)
	{
		Expression = expression;
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ExpressionStatement expressionStatement)
		{
			return Expression.DoMatch(expressionStatement.Expression, match);
		}
		return false;
	}
}
