using ICSharpCode.NRefactory.PatternMatching;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp;

public class TypeDeclaration : EntityDeclaration
{
	private ClassType classType;

	public override NodeType NodeType => NodeType.TypeDeclaration;

	public override SymbolKind SymbolKind => SymbolKind.TypeDefinition;

	public CSharpTokenNode TypeKeyword => classType switch
	{
		ClassType.Class => GetChildByRole(Roles.ClassKeyword), 
		ClassType.Struct => GetChildByRole(Roles.StructKeyword), 
		ClassType.Interface => GetChildByRole(Roles.InterfaceKeyword), 
		ClassType.Enum => GetChildByRole(Roles.EnumKeyword), 
		_ => CSharpTokenNode.Null, 
	};

	public ClassType ClassType
	{
		get
		{
			return classType;
		}
		set
		{
			ThrowIfFrozen();
			classType = value;
		}
	}

	public CSharpTokenNode LChevronToken => GetChildByRole(Roles.LChevron);

	public AstNodeCollection<TypeParameterDeclaration> TypeParameters => GetChildrenByRole(Roles.TypeParameter);

	public CSharpTokenNode RChevronToken => GetChildByRole(Roles.RChevron);

	public CSharpTokenNode ColonToken => GetChildByRole(Roles.Colon);

	public AstNodeCollection<AstType> BaseTypes => GetChildrenByRole(Roles.BaseType);

	public AstNodeCollection<Constraint> Constraints => GetChildrenByRole(Roles.Constraint);

	public CSharpTokenNode LBraceToken => GetChildByRole(Roles.LBrace);

	public AstNodeCollection<EntityDeclaration> Members => GetChildrenByRole(Roles.TypeMemberRole);

	public CSharpTokenNode RBraceToken => GetChildByRole(Roles.RBrace);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitTypeDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitTypeDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTypeDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is TypeDeclaration typeDeclaration && ClassType == typeDeclaration.ClassType && AstNode.MatchString(Name, typeDeclaration.Name) && MatchAttributesAndModifiers(typeDeclaration, match) && TypeParameters.DoMatch(typeDeclaration.TypeParameters, match) && BaseTypes.DoMatch(typeDeclaration.BaseTypes, match) && Constraints.DoMatch(typeDeclaration.Constraints, match))
		{
			return Members.DoMatch(typeDeclaration.Members, match);
		}
		return false;
	}
}
