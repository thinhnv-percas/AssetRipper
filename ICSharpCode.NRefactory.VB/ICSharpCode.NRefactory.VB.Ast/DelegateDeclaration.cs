using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class DelegateDeclaration : AttributedNode
{
	public bool IsSub { get; set; }

	public AstNodeCollection<TypeParameterDeclaration> TypeParameters => GetChildrenByRole(Roles.TypeParameter);

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

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is DelegateDeclaration delegateDeclaration && MatchAttributesAndModifiers(delegateDeclaration, match) && IsSub == delegateDeclaration.IsSub && TypeParameters.DoMatch(delegateDeclaration.TypeParameters, match) && Name.DoMatch(delegateDeclaration.Name, match) && Parameters.DoMatch(delegateDeclaration.Parameters, match) && ReturnTypeAttributes.DoMatch(delegateDeclaration.ReturnTypeAttributes, match))
		{
			return ReturnType.DoMatch(delegateDeclaration.ReturnType, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitDelegateDeclaration(this, data);
	}
}
