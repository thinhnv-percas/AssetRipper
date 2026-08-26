using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class ThisReferenceExpression : Expression
{
	public TextLocation Location { get; set; }

	public override TextLocation StartLocation => Location;

	public override TextLocation EndLocation => new TextLocation(Location.Line, Location.Column + "this".Length);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitThisReferenceExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitThisReferenceExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitThisReferenceExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		ThisReferenceExpression thisReferenceExpression = other as ThisReferenceExpression;
		return thisReferenceExpression != null;
	}
}
