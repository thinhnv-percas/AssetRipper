using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class QueryGroupClause : QueryClause
	{
		public static readonly TokenRole GroupKeywordRole = new TokenRole("group");

		public static readonly Role<Expression> ProjectionRole = new Role<Expression>("Projection", Expression.Null);

		public static readonly TokenRole ByKeywordRole = new TokenRole("by");

		public static readonly Role<Expression> KeyRole = new Role<Expression>("Key", Expression.Null);

		public CSharpTokenNode GroupKeyword => GetChildByRole(GroupKeywordRole);

		public Expression Projection
		{
			get
			{
				return GetChildByRole(ProjectionRole);
			}
			set
			{
				SetChildByRole(ProjectionRole, value);
			}
		}

		public CSharpTokenNode ByKeyword => GetChildByRole(ByKeywordRole);

		public Expression Key
		{
			get
			{
				return GetChildByRole(KeyRole);
			}
			set
			{
				SetChildByRole(KeyRole, value);
			}
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitQueryGroupClause(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitQueryGroupClause(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitQueryGroupClause(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			QueryGroupClause queryGroupClause = other as QueryGroupClause;
			if (queryGroupClause != null && Projection.DoMatch(queryGroupClause.Projection, match))
			{
				return Key.DoMatch(queryGroupClause.Key, match);
			}
			return false;
		}
	}
}
