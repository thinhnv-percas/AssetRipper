using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class CheckedExpression : Expression
	{
		public static readonly TokenRole CheckedKeywordRole = new TokenRole("checked");

		public CSharpTokenNode CheckedToken => GetChildByRole(CheckedKeywordRole);

		public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

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

		public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

		public CheckedExpression()
		{
		}

		public CheckedExpression(Expression expression)
		{
			AddChild(expression, Roles.Expression);
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitCheckedExpression(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitCheckedExpression(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitCheckedExpression(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			CheckedExpression checkedExpression = other as CheckedExpression;
			if (checkedExpression != null)
			{
				return Expression.DoMatch(checkedExpression.Expression, match);
			}
			return false;
		}
	}
}
