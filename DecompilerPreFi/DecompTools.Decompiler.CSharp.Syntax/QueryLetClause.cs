using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

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
			SetChildByRole(Roles.Identifier, DecompTools.Decompiler.CSharp.Syntax.Identifier.Create(value));
		}
	}

	public Identifier IdentifierToken => GetChildByRole(Roles.Identifier);

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
		return other is QueryLetClause queryLetClause && AstNode.MatchString(Identifier, queryLetClause.Identifier) && Expression.DoMatch(queryLetClause.Expression, match);
	}
}
