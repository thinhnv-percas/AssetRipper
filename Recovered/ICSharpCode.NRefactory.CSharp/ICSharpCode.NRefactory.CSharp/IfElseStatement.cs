using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class IfElseStatement : Statement
	{
		public static readonly TokenRole IfKeywordRole = new TokenRole("if");

		public static readonly Role<Expression> ConditionRole = Roles.Condition;

		public static readonly Role<Statement> TrueRole = new Role<Statement>("True", Statement.Null);

		public static readonly TokenRole ElseKeywordRole = new TokenRole("else");

		public static readonly Role<Statement> FalseRole = new Role<Statement>("False", Statement.Null);

		public CSharpTokenNode IfToken => GetChildByRole(IfKeywordRole);

		public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

		public Expression Condition
		{
			get
			{
				return GetChildByRole(ConditionRole);
			}
			set
			{
				SetChildByRole(ConditionRole, value);
			}
		}

		public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

		public Statement TrueStatement
		{
			get
			{
				return GetChildByRole(TrueRole);
			}
			set
			{
				SetChildByRole(TrueRole, value);
			}
		}

		public CSharpTokenNode ElseToken => GetChildByRole(ElseKeywordRole);

		public Statement FalseStatement
		{
			get
			{
				return GetChildByRole(FalseRole);
			}
			set
			{
				SetChildByRole(FalseRole, value);
			}
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitIfElseStatement(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitIfElseStatement(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitIfElseStatement(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			IfElseStatement ifElseStatement = other as IfElseStatement;
			if (ifElseStatement != null && Condition.DoMatch(ifElseStatement.Condition, match) && TrueStatement.DoMatch(ifElseStatement.TrueStatement, match))
			{
				return FalseStatement.DoMatch(ifElseStatement.FalseStatement, match);
			}
			return false;
		}

		public IfElseStatement()
		{
		}

		public IfElseStatement(Expression condition, Statement trueStatement, Statement falseStatement = null)
		{
			Condition = condition;
			TrueStatement = trueStatement;
			FalseStatement = falseStatement;
		}
	}
}
