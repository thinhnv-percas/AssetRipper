using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class UncheckedExpression : Expression
{
	public static readonly TokenRole UncheckedKeywordRole = new TokenRole("unchecked");

	public CSharpTokenNode UncheckedToken => GetChildByRole(UncheckedKeywordRole);

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

	public UncheckedExpression()
	{
	}

	public UncheckedExpression(Expression expression)
	{
		AddChild(expression, Roles.Expression);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitUncheckedExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitUncheckedExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitUncheckedExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is UncheckedExpression uncheckedExpression && Expression.DoMatch(uncheckedExpression.Expression, match);
	}
}
