using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ErrorExpression : Expression
{
	public TextLocation Location { get; set; }

	public override TextLocation StartLocation => Location;

	public override TextLocation EndLocation => Location;

	public string Error { get; private set; }

	public ErrorExpression()
	{
	}

	public ErrorExpression(string error)
	{
		AddChild(new Comment(error, CommentType.MultiLine), Roles.Comment);
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
