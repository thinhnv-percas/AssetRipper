using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ThrowStatement : Statement
{
	public static readonly TokenRole ThrowKeywordRole = new TokenRole("throw");

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

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public ThrowStatement()
	{
	}

	public ThrowStatement(Expression expression)
	{
		AddChild(expression, Roles.Expression);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitThrowStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitThrowStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitThrowStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is ThrowStatement throwStatement && Expression.DoMatch(throwStatement.Expression, match);
	}
}
