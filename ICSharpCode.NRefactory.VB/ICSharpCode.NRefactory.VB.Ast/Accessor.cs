using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class Accessor : AttributedNode
{
	private sealed class NullAccessor : Accessor
	{
		public override bool IsNull => true;

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return default(S);
		}
	}

	public new static readonly Accessor Null = new NullAccessor();

	public BlockStatement Body
	{
		get
		{
			return GetChildByRole(Roles.Body);
		}
		set
		{
			SetChildByRole(Roles.Body, value);
		}
	}

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAccessor(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is Accessor { IsNull: false } accessor && MatchAttributesAndModifiers(accessor, match) && Body.DoMatch(accessor.Body, match))
		{
			return Parameters.DoMatch(accessor.Parameters, match);
		}
		return false;
	}
}
