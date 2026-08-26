using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class TextNode : AstNode
	{
		private TextLocation startLocation;

		private TextLocation endLocation;

		public override NodeType NodeType => NodeType.Whitespace;

		public string Text
		{
			get;
			set;
		}

		public override TextLocation StartLocation => startLocation;

		public override TextLocation EndLocation => endLocation;

		public TextNode(string text)
			: this(text, TextLocation.Empty, TextLocation.Empty)
		{
		}

		public TextNode(string text, TextLocation startLocation, TextLocation endLocation)
		{
			Text = text;
			this.startLocation = startLocation;
			this.endLocation = endLocation;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitText(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitText(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitText(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			TextNode textNode = other as TextNode;
			if (textNode != null)
			{
				return textNode.Text == Text;
			}
			return false;
		}
	}
}
