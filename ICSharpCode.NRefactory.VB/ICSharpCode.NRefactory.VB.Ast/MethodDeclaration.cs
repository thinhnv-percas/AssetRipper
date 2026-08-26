using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class MethodDeclaration : MemberDeclaration
{
	public bool IsSub { get; set; }

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

	public AstNodeCollection<ParameterDeclaration> Parameters => GetChildrenByRole(Roles.Parameter);

	public AstNodeCollection<AttributeBlock> ReturnTypeAttributes => GetChildrenByRole(AttributeBlock.ReturnTypeAttributeBlockRole);

	public AstType ReturnType
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

	public AstNodeCollection<EventMemberSpecifier> HandlesClause => GetChildrenByRole(EventMemberSpecifier.EventMemberSpecifierRole);

	public AstNodeCollection<InterfaceMemberSpecifier> ImplementsClause => GetChildrenByRole(InterfaceMemberSpecifier.InterfaceMemberSpecifierRole);

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

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is MethodDeclaration methodDeclaration && MatchAttributesAndModifiers(methodDeclaration, match) && IsSub == methodDeclaration.IsSub && Name.DoMatch(methodDeclaration.Name, match) && TypeParameters.DoMatch(methodDeclaration.TypeParameters, match) && Parameters.DoMatch(methodDeclaration.Parameters, match) && ReturnTypeAttributes.DoMatch(methodDeclaration.ReturnTypeAttributes, match) && ReturnType.DoMatch(methodDeclaration.ReturnType, match) && HandlesClause.DoMatch(methodDeclaration.HandlesClause, match) && ImplementsClause.DoMatch(methodDeclaration.ImplementsClause, match))
		{
			return Body.DoMatch(methodDeclaration.Body, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitMethodDeclaration(this, data);
	}
}
