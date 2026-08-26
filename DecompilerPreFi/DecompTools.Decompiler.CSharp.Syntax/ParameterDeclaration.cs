using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ParameterDeclaration : AstNode
{
	private sealed class PatternPlaceholder : ParameterDeclaration, INode
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

	public static readonly Role<AttributeSection> AttributeRole = EntityDeclaration.AttributeRole;

	public static readonly TokenRole RefModifierRole = new TokenRole("ref");

	public static readonly TokenRole OutModifierRole = new TokenRole("out");

	public static readonly TokenRole ParamsModifierRole = new TokenRole("params");

	public static readonly TokenRole ThisModifierRole = new TokenRole("this");

	public static readonly TokenRole InModifierRole = new TokenRole("in");

	private ParameterModifier parameterModifier;

	public override NodeType NodeType => NodeType.Unknown;

	public AstNodeCollection<AttributeSection> Attributes => GetChildrenByRole(AttributeRole);

	public ParameterModifier ParameterModifier
	{
		get
		{
			return parameterModifier;
		}
		set
		{
			ThrowIfFrozen();
			parameterModifier = value;
		}
	}

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

	public string Name
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

	public Identifier NameToken
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

	public CSharpTokenNode AssignToken => GetChildByRole(Roles.Assign);

	public Expression DefaultExpression
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

	public static implicit operator ParameterDeclaration(Pattern pattern)
	{
		return (pattern != null) ? new PatternPlaceholder(pattern) : null;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitParameterDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitParameterDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitParameterDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is ParameterDeclaration parameterDeclaration && Attributes.DoMatch(parameterDeclaration.Attributes, match) && ParameterModifier == parameterDeclaration.ParameterModifier && Type.DoMatch(parameterDeclaration.Type, match) && AstNode.MatchString(Name, parameterDeclaration.Name) && DefaultExpression.DoMatch(parameterDeclaration.DefaultExpression, match);
	}

	public ParameterDeclaration()
	{
	}

	public ParameterDeclaration(AstType type, string name, ParameterModifier modifier = ParameterModifier.None)
	{
		Type = type;
		Name = name;
		ParameterModifier = modifier;
	}

	public ParameterDeclaration(string name, ParameterModifier modifier = ParameterModifier.None)
	{
		Name = name;
		ParameterModifier = modifier;
	}

	public new ParameterDeclaration Clone()
	{
		return (ParameterDeclaration)base.Clone();
	}
}
