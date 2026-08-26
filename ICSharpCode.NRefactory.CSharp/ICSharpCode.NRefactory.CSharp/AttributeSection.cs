using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

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
			Identifier identifier = Identifier.Create(value);
			identifier.AddAnnotation(BoxedTextColor.Keyword);
			SetChildByRole(Roles.Identifier, identifier);
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
		if (pattern == null)
		{
			return null;
		}
		return new PatternPlaceholder(pattern);
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
		if (other is AttributeSection attributeSection && AstNode.MatchString(AttributeTarget, attributeSection.AttributeTarget))
		{
			return Attributes.DoMatch(attributeSection.Attributes, match);
		}
		return false;
	}

	public AttributeSection()
	{
	}

	public AttributeSection(Attribute attr)
	{
		Attributes.Add(attr);
	}
}
