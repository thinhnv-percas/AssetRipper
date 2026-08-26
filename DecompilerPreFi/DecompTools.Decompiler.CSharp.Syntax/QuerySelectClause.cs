using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class QuerySelectClause : QueryClause
{
	public static readonly TokenRole SelectKeywordRole = new TokenRole("select");

	public CSharpTokenNode SelectKeyword => GetChildByRole(SelectKeywordRole);

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
		visitor.VisitQuerySelectClause(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitQuerySelectClause(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQuerySelectClause(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is QuerySelectClause querySelectClause && Expression.DoMatch(querySelectClause.Expression, match);
	}
}
