using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class EmptyExpression : Expression
{
	private TextLocation location;

	public override TextLocation StartLocation => location;

	public override TextLocation EndLocation => location;

	public EmptyExpression()
	{
	}

	public EmptyExpression(TextLocation location)
	{
		this.location = location;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitEmptyExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		EmptyExpression emptyExpression = other as EmptyExpression;
		return emptyExpression != null;
	}
}
