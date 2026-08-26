using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class AttributeSection : AstNode
{
	private sealed class PatternPlaceholder : AttributeSection, INode
	{
		private readonly Pattern child;

		public override NodeType NodeType => NodeType.Pattern;

		public PatternPlaceholder(Pattern child)
		{
			this.child = child;
		}

		public override void AcceptVisitor(IAstVisitor visitor)
		{
			visitor.VisitPatternPlaceholder(this, child);
		}

		public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
		{
			return visitor.VisitPatternPlaceholder(this, child);
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

	public override NodeType NodeType => NodeType.Unknown;

	public CSharpTokenNode LBracketToken => GetChildByRole(Roles.LBracket);

	public string AttributeTarget
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, Identifier.Create(value));
		}
	}

	public Identifier AttributeTargetToken
	{
		get
		{
			return GetChildByRole(Roles.Identifier);
		}
		set
		{
			SetChildByRole(Roles.Identifier, value);
		}
	}

	public AstNodeCollection<Attribute> Attributes => GetChildrenByRole(Roles.Attribute);

	public CSharpTokenNode RBracketToken => GetChildByRole(Roles.RBracket);

	public static implicit operator AttributeSection(Pattern pattern)
	{
		return (pattern != null) ? new PatternPlaceholder(pattern) : null;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitAttributeSection(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitAttributeSection(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAttributeSection(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is AttributeSection attributeSection && AstNode.MatchString(AttributeTarget, attributeSection.AttributeTarget) && Attributes.DoMatch(attributeSection.Attributes, match);
	}

	public AttributeSection()
	{
	}

	public AttributeSection(Attribute attr)
	{
		Attributes.Add(attr);
	}
}
