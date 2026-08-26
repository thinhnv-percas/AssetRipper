using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public class QueryOrdering : AstNode
	{
		public static readonly TokenRole AscendingKeywordRole = new TokenRole("ascending");

		public static readonly TokenRole DescendingKeywordRole = new TokenRole("descending");

		public override NodeType NodeType => NodeType.Unknown;

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

		public QueryOrderingDirection Direction
		{
			get;
			set;
		}

		public CSharpTokenNode DirectionToken
		{
			get
			{
				if (Direction != QueryOrderingDirection.Ascending)
				{
					return GetChildByRole(DescendingKeywordRole);
				}
				return GetChildByRole(AscendingKeywordRole);
			}
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitQueryOrdering(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitQueryOrdering(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitQueryOrdering(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			QueryOrdering queryOrdering = other as QueryOrdering;
			if (queryOrdering != null && Direction == queryOrdering.Direction)
			{
				return Expression.DoMatch(queryOrdering.Expression, match);
			}
			return false;
		}
	}
}
