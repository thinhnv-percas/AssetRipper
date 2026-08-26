using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class EnumDeclaration : AttributedNode
{
	public static readonly Role<EnumMemberDeclaration> MemberRole = new Role<EnumMemberDeclaration>("Member");

	public static readonly Role<AstType> UnderlyingTypeRole = new Role<AstType>("UnderlyingType", AstType.Null);

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

	public AstType UnderlyingType
	{
		get
		{
			return GetChildByRole(UnderlyingTypeRole);
		}
		set
		{
			SetChildByRole(UnderlyingTypeRole, value);
		}
	}

	public AstNodeCollection<EnumMemberDeclaration> Members => GetChildrenByRole(MemberRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is EnumDeclaration enumDeclaration && MatchAttributesAndModifiers(enumDeclaration, match) && Name.DoMatch(enumDeclaration.Name, match) && UnderlyingType.DoMatch(enumDeclaration.UnderlyingType, match))
		{
			return Members.DoMatch(enumDeclaration.Members, match);
		}
		return false;
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitEnumDeclaration(this, data);
	}
}
