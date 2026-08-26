using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class QueryFromClause : QueryClause
{
	public static readonly TokenRole FromKeywordRole = new TokenRole("from");

	public static readonly TokenRole InKeywordRole = new TokenRole("in");

	public CSharpTokenNode FromKeyword => GetChildByRole(FromKeywordRole);

	public AstType Type
	{
		get
		{
			return GetChildByRole(Roles.Type);
		}
		set
		{
			SetChildByRole(Roles.Type, value);
		}
	}

	public string Identifier
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, DecompTools.Decompiler.CSharp.Syntax.Identifier.Create(value));
		}
	}

	public Identifier IdentifierToken => GetChildByRole(Roles.Identifier);

	public CSharpTokenNode InKeyword => GetChildByRole(InKeywordRole);

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
		visitor.VisitQueryFromClause(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitQueryFromClause(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQueryFromClause(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is QueryFromClause queryFromClause && Type.DoMatch(queryFromClause.Type, match) && AstNode.MatchString(Identifier, queryFromClause.Identifier) && Expression.DoMatch(queryFromClause.Expression, match);
	}
}
