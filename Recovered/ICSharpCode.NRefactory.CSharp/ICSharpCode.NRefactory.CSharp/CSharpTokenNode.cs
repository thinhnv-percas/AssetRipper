using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CSharpTokenNode : AstNode
	{
		private class NullCSharpTokenNode : CSharpTokenNode
		{
			public override bool IsNull => true;

			public NullCSharpTokenNode()
				: base(TextLocation.Empty, null)
			{
			}

			public override void AcceptVisitor(IAstVisitor visitor)
			{
				visitor.VisitNullNode(this);
			}

			public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
			{
				return visitor.VisitNullNode(this);
			}

			public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
			{
				return visitor.VisitNullNode(this, data);
			}

			protected internal override bool DoMatch(AstNode other, Match match)
			{
				return other?.IsNull ?? true;
			}
		}

		public new static readonly CSharpTokenNode Null = new NullCSharpTokenNode();

		private TextLocation startLocation;

		public override NodeType NodeType => NodeType.Token;

		public override TextLocation StartLocation => startLocation;

		private int TokenLength => TokenRole.TokenLengths[(int)(flags >> 10)];

		public override TextLocation EndLocation => new TextLocation(StartLocation.Line, StartLocation.Column + TokenLength);

		public CSharpTokenNode(TextLocation location, TokenRole role)
		{
			startLocation = location;
			if (role != null)
			{
				flags |= role.TokenIndex << 10;
			}
		}

		public override string ToString(CSharpFormattingOptions formattingOptions)
		{
			return TokenRole.Tokens[(int)(flags >> 10)];
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitCSharpTokenNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitCSharpTokenNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitCSharpTokenNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			CSharpTokenNode cSharpTokenNode = other as CSharpTokenNode;
			if (cSharpTokenNode != null && !cSharpTokenNode.IsNull)
			{
				return !(cSharpTokenNode is CSharpModifierToken);
			}
			return false;
		}
	}
}
