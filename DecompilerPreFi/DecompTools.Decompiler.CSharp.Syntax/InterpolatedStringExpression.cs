using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class InterpolatedStringExpression : Expression
{
	public static readonly TokenRole OpenQuote = new TokenRole("$\"");

	public static readonly TokenRole CloseQuote = new TokenRole("\"");

	public AstNodeCollection<InterpolatedStringContent> Content => GetChildrenByRole(InterpolatedStringContent.Role);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitInterpolatedStringExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitInterpolatedStringExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitInterpolatedStringExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is InterpolatedStringExpression { IsNull: false } interpolatedStringExpression && Content.DoMatch(interpolatedStringExpression.Content, match);
	}
}
