using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class InterpolatedStringText : InterpolatedStringContent
{
	public string Text { get; set; }

	public InterpolatedStringText()
	{
	}

	public InterpolatedStringText(string text)
	{
		Text = text;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitInterpolatedStringText(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitInterpolatedStringText(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitInterpolatedStringText(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is InterpolatedStringText interpolatedStringText && interpolatedStringText.Text == Text;
	}
}
