using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class Comment : AstNode
	{
		private CommentType commentType;

		private bool startsLine;

		private string content;

		private TextLocation startLocation;

		private TextLocation endLocation;

		public override NodeType NodeType => NodeType.Whitespace;

		public CommentType CommentType
		{
			get
			{
				return commentType;
			}
			set
			{
				ThrowIfFrozen();
				commentType = value;
			}
		}

		public bool IsDocumentation
		{
			get
			{
				if (commentType != CommentType.Documentation)
				{
					return commentType == CommentType.MultiLineDocumentation;
				}
				return true;
			}
		}

		public bool StartsLine
		{
			get
			{
				return startsLine;
			}
			set
			{
				ThrowIfFrozen();
				startsLine = value;
			}
		}

		public string Content
		{
			get
			{
				return content;
			}
			set
			{
				ThrowIfFrozen();
				content = value;
			}
		}

		public override TextLocation StartLocation => startLocation;

		public override TextLocation EndLocation => endLocation;

		public Comment(string content, CommentType type = CommentType.SingleLine)
		{
			CommentType = type;
			Content = content;
		}

		public Comment(CommentType commentType, TextLocation startLocation, TextLocation endLocation)
		{
			CommentType = commentType;
			this.startLocation = startLocation;
			this.endLocation = endLocation;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitComment(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitComment(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitComment(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			Comment comment = other as Comment;
			if (comment != null && CommentType == comment.CommentType)
			{
				return AstNode.MatchString(Content, comment.Content);
			}
			return false;
		}
	}
}
