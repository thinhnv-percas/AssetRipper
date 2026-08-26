using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class QueryExpression : Expression
{
	private sealed class NullQueryExpression : QueryExpression
	{
		public override bool IsNull => true;

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitNullNode(this);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitNullNode(this);
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitNullNode(this, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	public static readonly Role<QueryClause> ClauseRole = new Role<QueryClause>("Clause");

	public new static readonly QueryExpression Null = new NullQueryExpression();

	public AstNodeCollection<QueryClause> Clauses => GetChildrenByRole(ClauseRole);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitQueryExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitQueryExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitQueryExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is QueryExpression { IsNull: false } queryExpression && Clauses.DoMatch(queryExpression.Clauses, match);
	}
}
