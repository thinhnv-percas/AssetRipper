using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class DoWhileStatement : Statement
	{
		public static readonly TokenRole DoKeywordRole = new TokenRole("do");

		public static readonly TokenRole WhileKeywordRole = new TokenRole("while");

		public CSharpTokenNode DoToken => GetChildByRole(DoKeywordRole);

		public Statement EmbeddedStatement
		{
			get
			{
				return GetChildByRole(Roles.EmbeddedStatement);
			}
			set
			{
				SetChildByRole(Roles.EmbeddedStatement, value);
			}
		}

		public CSharpTokenNode WhileToken => GetChildByRole(WhileKeywordRole);

		public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

		public Expression Condition
		{
			get
			{
				return GetChildByRole(Roles.Condition);
			}
			set
			{
				SetChildByRole(Roles.Condition, value);
			}
		}

		public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

		public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitDoWhileStatement(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitDoWhileStatement(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitDoWhileStatement(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			DoWhileStatement doWhileStatement = other as DoWhileStatement;
			if (doWhileStatement != null && EmbeddedStatement.DoMatch(doWhileStatement.EmbeddedStatement, match))
			{
				return Condition.DoMatch(doWhileStatement.Condition, match);
			}
			return false;
		}

		public DoWhileStatement()
		{
		}

		public DoWhileStatement(Expression condition, Statement embeddedStatement)
		{
			Condition = condition;
			EmbeddedStatement = embeddedStatement;
		}
	}
}
