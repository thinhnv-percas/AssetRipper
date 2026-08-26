using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

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

	public QueryOrderingDirection Direction { get; set; }

	public CSharpTokenNode DirectionToken => (Direction == QueryOrderingDirection.Ascending) ? GetChildByRole(AscendingKeywordRole) : GetChildByRole(DescendingKeywordRole);

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
		return other is QueryOrdering queryOrdering && Direction == queryOrdering.Direction && Expression.DoMatch(queryOrdering.Expression, match);
	}
}
