using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class QueryContinuationClause : QueryClause
{
	public static readonly Role<QueryExpression> PrecedingQueryRole = new Role<QueryExpression>("PrecedingQuery", QueryExpression.Null);

	public static readonly TokenRole IntoKeywordRole = new TokenRole("into");

	public QueryExpression PrecedingQuery
	{
		get
		{
			return GetChildByRole(PrecedingQueryRole);
		}
		set
		{
			SetChildByRole(PrecedingQueryRole, value);
		}
	}

	public CSharpTokenNode IntoKeyword => GetChildByRole(IntoKeywordRole);

	public string Identifier
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, ICSharpCode.NRefactory.CSharp.Identifier.Create(value));
		}
	}

	public Identifier IdentifierToken
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

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitQueryContinuationClause(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitQueryContinuationClause(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQueryContinuationClause(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is QueryContinuationClause queryContinuationClause && AstNode.MatchString(Identifier, queryContinuationClause.Identifier))
		{
			return PrecedingQuery.DoMatch(queryContinuationClause.PrecedingQuery, match);
		}
		return false;
	}
}
