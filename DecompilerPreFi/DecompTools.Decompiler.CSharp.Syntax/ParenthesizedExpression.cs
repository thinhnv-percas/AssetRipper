using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ParenthesizedExpression : Expression
{
	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

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

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public ParenthesizedExpression()
	{
	}

	public ParenthesizedExpression(Expression expr)
	{
		Expression = expr;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitParenthesizedExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitParenthesizedExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitParenthesizedExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is ParenthesizedExpression parenthesizedExpression && Expression.DoMatch(parenthesizedExpression.Expression, match);
	}

	public static bool ActsAsParenthesizedExpression(AstNode expression)
	{
		return expression is ParenthesizedExpression || expression is CheckedExpression || expression is UncheckedExpression;
	}

	public static Expression UnpackParenthesizedExpression(Expression expr)
	{
		while (ActsAsParenthesizedExpression(expr))
		{
			expr = expr.GetChildByRole(Roles.Expression);
		}
		return expr;
	}
}
