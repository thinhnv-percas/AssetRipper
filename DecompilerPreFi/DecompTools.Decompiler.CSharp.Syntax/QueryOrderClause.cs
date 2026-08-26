using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class QueryOrderClause : QueryClause
{
	public static readonly TokenRole OrderbyKeywordRole = new TokenRole("orderby");

	public static readonly Role<QueryOrdering> OrderingRole = new Role<QueryOrdering>("Ordering");

	public CSharpTokenNode OrderbyToken => GetChildByRole(OrderbyKeywordRole);

	public AstNodeCollection<QueryOrdering> Orderings => GetChildrenByRole(OrderingRole);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitQueryOrderClause(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitQueryOrderClause(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQueryOrderClause(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is QueryOrderClause queryOrderClause && Orderings.DoMatch(queryOrderClause.Orderings, match);
	}
}
