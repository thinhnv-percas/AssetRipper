using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class NullReferenceExpression : Expression
{
	private TextLocation location;

	public override TextLocation StartLocation => location;

	public override TextLocation EndLocation => new TextLocation(location.Line, checked(location.Column + "null".Length));

	internal void SetStartLocation(TextLocation value)
	{
		ThrowIfFrozen();
		location = value;
	}

	public NullReferenceExpression()
	{
	}

	public NullReferenceExpression(TextLocation location)
	{
		this.location = location;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitNullReferenceExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitNullReferenceExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitNullReferenceExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		NullReferenceExpression nullReferenceExpression = other as NullReferenceExpression;
		return nullReferenceExpression != null;
	}
}
