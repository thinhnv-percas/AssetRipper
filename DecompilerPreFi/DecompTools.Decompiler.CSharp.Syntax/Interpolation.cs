using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class Interpolation : InterpolatedStringContent
{
	public static readonly TokenRole LBrace = new TokenRole("{");

	public static readonly TokenRole RBrace = new TokenRole("}");

	public CSharpTokenNode LBraceToken => GetChildByRole(LBrace);

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

	public string Suffix { get; }

	public CSharpTokenNode RBraceToken => GetChildByRole(RBrace);

	public Interpolation()
	{
	}

	public Interpolation(Expression expression, string suffix = null)
	{
		Expression = expression;
		Suffix = suffix;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitInterpolation(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitInterpolation(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitInterpolation(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is Interpolation interpolation && Expression.DoMatch(interpolation.Expression, match);
	}
}
