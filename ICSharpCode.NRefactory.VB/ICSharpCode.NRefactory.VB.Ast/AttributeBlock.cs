using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class AttributeBlock : AstNode
{
	public static readonly Role<AttributeBlock> AttributeBlockRole = new Role<AttributeBlock>("AttributeBlock");

	public static readonly Role<AttributeBlock> ReturnTypeAttributeBlockRole = new Role<AttributeBlock>("ReturnTypeAttributeBlock");

	public VBTokenNode LChevron => GetChildByRole(Roles.LChevron);

	public AstNodeCollection<Attribute> Attributes => GetChildrenByRole(Attribute.AttributeRole);

	public VBTokenNode RChevron => GetChildByRole(Roles.RChevron);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is AttributeBlock attributeBlock)
		{
			return Attributes.DoMatch(attributeBlock.Attributes, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAttributeBlock(this, data);
	}
}
