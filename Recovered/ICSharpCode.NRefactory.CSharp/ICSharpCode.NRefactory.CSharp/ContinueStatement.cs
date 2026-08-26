using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class ContinueStatement : Statement
	{
		public static readonly TokenRole ContinueKeywordRole = new TokenRole("continue");

		public CSharpTokenNode ContinueToken => GetChildByRole(ContinueKeywordRole);

		public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitContinueStatement(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitContinueStatement(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitContinueStatement(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other is ContinueStatement;
		}
	}
}
