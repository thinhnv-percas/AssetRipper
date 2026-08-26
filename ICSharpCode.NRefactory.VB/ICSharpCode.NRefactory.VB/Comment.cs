using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB;

public class Comment : AstNode
{
	private TextLocation startLocation;

	private TextLocation endLocation;

	public bool IsDocumentationComment { get; set; }

	public bool StartsLine { get; set; }

	public string Content { get; set; }

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation => endLocation;

	public CommentReference[] References { get; set; }

	public Comment(string content, bool isDocumentation = false)
	{
		IsDocumentationComment = isDocumentation;
		Content = content;
	}

	public Comment(bool isDocumentation, TextLocation startLocation, TextLocation endLocation)
	{
		IsDocumentationComment = isDocumentation;
		this.startLocation = startLocation;
		this.endLocation = endLocation;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitComment(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is Comment comment && IsDocumentationComment == comment.IsDocumentationComment)
		{
			return AstNode.MatchString(Content, comment.Content);
		}
		return false;
	}
}
