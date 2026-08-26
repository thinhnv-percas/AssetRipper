using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class WhitespaceNode : AstNode
{
	private TextLocation startLocation;

	public override NodeType NodeType => NodeType.Whitespace;

	public string WhiteSpaceText { get; set; }

	public override TextLocation StartLocation => startLocation;

	public override TextLocation EndLocation => new TextLocation(startLocation.Line, startLocation.Column + WhiteSpaceText.Length);

	public WhitespaceNode(string whiteSpaceText)
		: this(whiteSpaceText, TextLocation.Empty)
	{
	}

	public WhitespaceNode(string whiteSpaceText, TextLocation startLocation)
	{
		WhiteSpaceText = WhiteSpaceText;
		this.startLocation = startLocation;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitWhitespace(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitWhitespace(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitWhitespace(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is WhitespaceNode whitespaceNode)
		{
			return whitespaceNode.WhiteSpaceText == WhiteSpaceText;
		}
		return false;
	}
}
