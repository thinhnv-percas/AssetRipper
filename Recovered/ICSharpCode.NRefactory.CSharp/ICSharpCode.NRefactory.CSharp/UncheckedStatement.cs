using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class UncheckedStatement : Statement
	{
		public static readonly TokenRole UncheckedKeywordRole = new TokenRole("unchecked");

		public CSharpTokenNode UncheckedToken => GetChildByRole(UncheckedKeywordRole);

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

		public UncheckedStatement()
		{
		}

		public UncheckedStatement(BlockStatement body)
		{
			AddChild(body, Roles.Body);
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitUncheckedStatement(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitUncheckedStatement(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitUncheckedStatement(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			UncheckedStatement uncheckedStatement = other as UncheckedStatement;
			if (uncheckedStatement != null)
			{
				return Body.DoMatch(uncheckedStatement.Body, match);
			}
			return false;
		}
	}
}
