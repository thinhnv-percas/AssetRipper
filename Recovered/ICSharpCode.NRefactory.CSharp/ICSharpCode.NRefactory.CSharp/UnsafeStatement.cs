using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class UnsafeStatement : Statement
	{
		public static readonly TokenRole UnsafeKeywordRole = new TokenRole("unsafe");

		public CSharpTokenNode UnsafeToken => GetChildByRole(UnsafeKeywordRole);

		public BlockStatement Body
		{
			get
			{
				return GetChildByRole(Roles.Body);
			}
			set
			{
				SetChildByRole(Roles.Body, value);
			}
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitUnsafeStatement(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitUnsafeStatement(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitUnsafeStatement(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			UnsafeStatement unsafeStatement = other as UnsafeStatement;
			if (unsafeStatement != null)
			{
				return Body.DoMatch(unsafeStatement.Body, match);
			}
			return false;
		}
	}
}
