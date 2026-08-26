using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class QueryWhereClause : QueryClause
{
	public static readonly TokenRole WhereKeywordRole = new TokenRole("where");

	public CSharpTokenNode WhereKeyword => GetChildByRole(WhereKeywordRole);

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

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitQueryWhereClause(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitQueryWhereClause(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQueryWhereClause(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is QueryWhereClause queryWhereClause)
		{
			return Condition.DoMatch(queryWhereClause.Condition, match);
		}
		return false;
	}
}
