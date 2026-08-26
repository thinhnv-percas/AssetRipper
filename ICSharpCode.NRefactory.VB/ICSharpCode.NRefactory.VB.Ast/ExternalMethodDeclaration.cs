using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class ExternalMethodDeclaration : MemberDeclaration
{
	public CharsetModifier CharsetModifier { get; set; }

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

	public string Library { get; set; }

	public string Alias { get; set; }

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
		if (other is ExternalMethodDeclaration externalMethodDeclaration && MatchAttributesAndModifiers(externalMethodDeclaration, match) && IsSub == externalMethodDeclaration.IsSub && Name.DoMatch(externalMethodDeclaration.Name, match) && Parameters.DoMatch(externalMethodDeclaration.Parameters, match) && ReturnTypeAttributes.DoMatch(externalMethodDeclaration.ReturnTypeAttributes, match))
		{
			return ReturnType.DoMatch(externalMethodDeclaration.ReturnType, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitExternalMethodDeclaration(this, data);
	}
}
