using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class ArraySpecifier : AstNode
	{
		public override NodeType NodeType => NodeType.Unknown;

		public CSharpTokenNode LBracketToken => GetChildByRole(Roles.LBracket);

		public int Dimensions
		{
			get
			{
				return 1 + GetChildrenByRole(Roles.Comma).Count;
			}
			set
			{
				int i;
				for (i = Dimensions; i > value; i--)
				{
					GetChildByRole(Roles.Comma).Remove();
				}
				for (; i < value; i++)
				{
					InsertChildBefore(GetChildByRole(Roles.Comma), new CSharpTokenNode(TextLocation.Empty, Roles.Comma), Roles.Comma);
				}
			}
		}

		public CSharpTokenNode RBracketToken => GetChildByRole(Roles.RBracket);

		public ArraySpecifier()
		{
		}

		public ArraySpecifier(int dimensions)
		{
			Dimensions = dimensions;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitArraySpecifier(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitArraySpecifier(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitArraySpecifier(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			ArraySpecifier arraySpecifier = other as ArraySpecifier;
			if (arraySpecifier != null)
			{
				return Dimensions == arraySpecifier.Dimensions;
			}
			return false;
		}

		public override string ToString(CSharpFormattingOptions formattingOptions)
		{
			return "[" + new string(',', Dimensions - 1) + "]";
		}
	}
}
