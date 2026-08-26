using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class ExpressionStatement : Statement
	{
		public Expression Expression
		{
			get
			{
				return GetChildByRole(Roles.Expression);
			}
			set
			{
				SetChildByRole(Roles.Expression, value);
			}
		}

		public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitExpressionStatement(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitExpressionStatement(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitExpressionStatement(this, data);
		}

		public ExpressionStatement()
		{
		}

		public ExpressionStatement(Expression expression)
		{
			Expression = expression;
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			ExpressionStatement expressionStatement = other as ExpressionStatement;
			if (expressionStatement != null)
			{
				return Expression.DoMatch(expressionStatement.Expression, match);
			}
			return false;
		}
	}
}
