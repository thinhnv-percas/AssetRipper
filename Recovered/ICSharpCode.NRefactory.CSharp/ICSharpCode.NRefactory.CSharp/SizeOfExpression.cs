using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class SizeOfExpression : Expression
	{
		public static readonly TokenRole SizeofKeywordRole = new TokenRole("sizeof");

		public CSharpTokenNode SizeOfToken => GetChildByRole(SizeofKeywordRole);

		public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

		public AstType Type
		{
			get
			{
				return GetChildByRole(Roles.Type);
			}
			set
			{
				SetChildByRole(Roles.Type, value);
			}
		}

		public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

		public SizeOfExpression()
		{
		}

		public SizeOfExpression(AstType type)
		{
			AddChild(type, Roles.Type);
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitSizeOfExpression(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitSizeOfExpression(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitSizeOfExpression(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			SizeOfExpression sizeOfExpression = other as SizeOfExpression;
			if (sizeOfExpression != null)
			{
				return Type.DoMatch(sizeOfExpression.Type, match);
			}
			return false;
		}
	}
}
