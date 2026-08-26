using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class Attribute : AstNode
{
	private sealed class PatternPlaceholder : Attribute, INode
	{
		private readonly Pattern child;

		public PatternPlaceholder(Pattern child)
		{
			this.child = child;
		}

		public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
		{
			return visitor.VisitPatternPlaceholder(this, child, data);
		}

		protected internal override bool DoMatch(AstNode other, Match match)
		{
			return child.DoMatch(other, match);
		}

		bool INode.DoMatchCollection(Role role, INode pos, Match match, BacktrackingInfo backtrackingInfo)
		{
			return child.DoMatchCollection(role, pos, match, backtrackingInfo);
		}
	}

	public static readonly Role<Attribute> AttributeRole = new Role<Attribute>("Attribute");

	public static readonly Role<VBTokenNode> TargetRole = new Role<VBTokenNode>("Target", VBTokenNode.Null);

	public AttributeTarget Target { get; set; }

	public VBTokenNode TargetKeyword
	{
		get
		{
			return GetChildByRole(TargetRole);
		}
		set
		{
			SetChildByRole(TargetRole, value);
		}
	}

	public VBTokenNode ColonToken => GetChildByRole(Roles.StatementTerminator);

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

	public VBTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNodeCollection<Expression> Arguments => GetChildrenByRole(Roles.Argument);

	public VBTokenNode RParToken => GetChildByRole(Roles.RPar);

	public static implicit operator Attribute(Pattern pattern)
	{
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAttribute(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is Attribute attribute && attribute.Target == Target && attribute.TargetKeyword.DoMatch(TargetKeyword, match) && attribute.Type.DoMatch(Type, match))
		{
			return attribute.Arguments.DoMatch(Arguments, match);
		}
		return false;
	}
}
