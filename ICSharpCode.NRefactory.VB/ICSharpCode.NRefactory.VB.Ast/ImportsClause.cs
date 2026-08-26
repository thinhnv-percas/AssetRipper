using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public abstract class ImportsClause : AstNode
{
	private class NullImportsClause : ImportsClause
	{
		public override bool IsNull => true;

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return other?.IsNull ?? false;
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return default(S);
		}
	}

	public new static readonly ImportsClause Null = new NullImportsClause();
}
