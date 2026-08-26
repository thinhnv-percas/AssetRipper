using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ParenthesizedExpression : Expression
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

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ParenthesizedExpression parenthesizedExpression)
		{
			return Expression.DoMatch(parenthesizedExpression.Expression, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitParenthesizedExpression(this, data);
	}
}
