using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class EmptyStatement : Statement
{
	public TextLocation Location { get; set; }

	public override TextLocation StartLocation => Location;

	public override TextLocation EndLocation => new TextLocation(Location.Line, Location.Column + 1);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitEmptyStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitEmptyStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitEmptyStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		EmptyStatement emptyStatement = other as EmptyStatement;
		return emptyStatement != null;
	}
}
