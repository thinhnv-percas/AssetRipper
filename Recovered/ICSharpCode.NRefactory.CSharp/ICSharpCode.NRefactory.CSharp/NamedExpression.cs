using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class NamedExpression : Expression
	{
		public string Name
		{
			get
			{
				return GetChildByRole(Roles.Identifier).Name;
			}
			set
			{
				SetChildByRole(Roles.Identifier, Identifier.Create(value));
			}
		}

		public Identifier NameToken
		{
			get
			{
				return GetChildByRole(Roles.Identifier);
			}
			set
			{
				SetChildByRole(Roles.Identifier, value);
			}
		}

		public CSharpTokenNode AssignToken => GetChildByRole(Roles.Assign);

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

		public NamedExpression()
		{
		}

		public NamedExpression(string name, Expression expression)
		{
			Name = name;
			Expression = expression;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNamedExpression(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNamedExpression(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNamedExpression(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			NamedExpression namedExpression = other as NamedExpression;
			if (namedExpression != null && AstNode.MatchString(Name, namedExpression.Name))
			{
				return Expression.DoMatch(namedExpression.Expression, match);
			}
			return false;
		}
	}
}
