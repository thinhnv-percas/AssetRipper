using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public abstract class QueryOperator : AstNode
{
	private sealed class NullQueryOperator : QueryOperator
	{
		public override bool IsNull => true;

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return default(S);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? true;
		}
	}

	public new static readonly QueryOperator Null = new NullQueryOperator();

	public static readonly Role<QueryOperator> QueryOperatorRole = new Role<QueryOperator>("QueryOperator", Null);
}
