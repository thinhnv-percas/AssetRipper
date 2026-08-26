using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class ParameterDeclaration : AstNode
{
	public static readonly Role<AttributeSection> AttributeRole = EntityDeclaration.AttributeRole;

	public static readonly TokenRole InModifierRole = new TokenRole("in");

	public static readonly TokenRole RefModifierRole = new TokenRole("ref");

	public static readonly TokenRole OutModifierRole = new TokenRole("out");

	public static readonly TokenRole ParamsModifierRole = new TokenRole("params");

	public static readonly TokenRole ThisModifierRole = new TokenRole("this");

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
		if (other is ParameterDeclaration parameterDeclaration && Attributes.DoMatch(parameterDeclaration.Attributes, match) && ParameterModifier == parameterDeclaration.ParameterModifier && Type.DoMatch(parameterDeclaration.Type, match) && AstNode.MatchString(Name, parameterDeclaration.Name))
		{
			return DefaultExpression.DoMatch(parameterDeclaration.DefaultExpression, match);
		}
		return false;
	}

	public ParameterDeclaration()
	{
	}

	public ParameterDeclaration(AstType type, string name, ParameterModifier modifier = ParameterModifier.None)
	{
		Type = type;
		NameToken = Identifier.Create(name);
		NameToken.AddAnnotation(BoxedTextColor.Parameter);
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
