using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ArrayInitializerExpression : Expression
{
	private sealed class NullArrayInitializerExpression : ArrayInitializerExpression
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

	public new static readonly ArrayInitializerExpression Null = new NullArrayInitializerExpression();

	public static readonly Role<ArrayInitializerExpression> InitializerRole = new Role<ArrayInitializerExpression>("Initializer", Null);

	public AstNodeCollection<Expression> Elements => GetChildrenByRole(Roles.Expression);

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitArrayInitializerExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ArrayInitializerExpression arrayInitializerExpression)
		{
			return Elements.DoMatch(arrayInitializerExpression.Elements, match);
		}
		return false;
	}
}
