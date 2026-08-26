using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class TypeDeclaration : AttributedNode
{
	public static readonly Role<AttributedNode> MemberRole = new Role<AttributedNode>("Member");

	public static readonly Role<AstType> InheritsTypeRole = new Role<AstType>("InheritsType", AstType.Null);

	public static readonly Role<AstType> ImplementsTypesRole = new Role<AstType>("ImplementsTypes", AstType.Null);

	public AstNodeCollection<AttributedNode> Members => GetChildrenByRole(MemberRole);

	public ClassType ClassType { get; set; }

	public Identifier Name
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

	public AstNodeCollection<TypeParameterDeclaration> TypeParameters => GetChildrenByRole(Roles.TypeParameter);

	public AstType InheritsType
	{
		get
		{
			return GetChildByRole(InheritsTypeRole);
		}
		set
		{
			SetChildByRole(InheritsTypeRole, value);
		}
	}

	public AstNodeCollection<AstType> ImplementsTypes => GetChildrenByRole(ImplementsTypesRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is TypeDeclaration typeDeclaration && MatchAttributesAndModifiers(typeDeclaration, match) && Members.DoMatch(typeDeclaration.Members, match) && ClassType == typeDeclaration.ClassType && Name.DoMatch(typeDeclaration.Name, match) && TypeParameters.DoMatch(typeDeclaration.TypeParameters, match) && InheritsType.DoMatch(typeDeclaration.InheritsType, match))
		{
			return ImplementsTypes.DoMatch(typeDeclaration.ImplementsTypes, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTypeDeclaration(this, data);
	}
}
