using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class QueryLetClause : QueryClause
{
	public static readonly TokenRole LetKeywordRole = new TokenRole("let");

	public CSharpTokenNode LetKeyword => GetChildByRole(LetKeywordRole);

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

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitQueryLetClause(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitQueryLetClause(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQueryLetClause(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is QueryLetClause queryLetClause && AstNode.MatchString(Identifier, queryLetClause.Identifier))
		{
			return Expression.DoMatch(queryLetClause.Expression, match);
		}
		return false;
	}
}
