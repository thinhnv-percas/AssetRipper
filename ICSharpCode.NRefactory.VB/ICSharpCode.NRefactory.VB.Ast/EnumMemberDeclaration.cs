using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class EnumMemberDeclaration : AstNode
{
	public AstNodeCollection<AttributeBlock> Attributes => GetChildrenByRole(AttributeBlock.AttributeBlockRole);

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

	public Expression Value
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

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		EnumMemberDeclaration enumMemberDeclaration = other as EnumMemberDeclaration;
		if (Attributes.DoMatch(enumMemberDeclaration.Attributes, match) && Name.DoMatch(enumMemberDeclaration.Name, match))
		{
			return Value.DoMatch(enumMemberDeclaration.Value, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitEnumMemberDeclaration(this, data);
	}
}
