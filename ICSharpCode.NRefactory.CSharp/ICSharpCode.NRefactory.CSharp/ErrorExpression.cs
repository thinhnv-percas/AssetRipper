using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class ErrorExpression : Expression
{
	private TextLocation location;

	public override TextLocation StartLocation => location;

	public override TextLocation EndLocation => location;

	public string Error { get; private set; }

	public ErrorExpression()
	{
	}

	public ErrorExpression(TextLocation location)
	{
		this.location = location;
	}

	public ErrorExpression(string error)
	{
		Error = error;
	}

	public ErrorExpression(string error, TextLocation location)
	{
		this.location = location;
		Error = error;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitErrorNode(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitErrorNode(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitErrorNode(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		ErrorExpression errorExpression = other as ErrorExpression;
		return errorExpression != null;
	}
}
