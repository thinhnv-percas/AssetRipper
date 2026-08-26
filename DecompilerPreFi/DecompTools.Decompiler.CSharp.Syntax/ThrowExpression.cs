using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ThrowExpression : Expression
{
	public static readonly TokenRole ThrowKeywordRole = ThrowStatement.ThrowKeywordRole;

	public CSharpTokenNode ThrowToken => GetChildByRole(ThrowKeywordRole);

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

	public ThrowExpression()
	{
	}

	public ThrowExpression(Expression expression)
	{
		AddChild(expression, Roles.Expression);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitThrowExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitThrowExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitThrowExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is ThrowExpression throwExpression && Expression.DoMatch(throwExpression.Expression, match);
	}
}
