using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class EnumMemberDeclaration : EntityDeclaration
{
	public static readonly Role<Expression> InitializerRole = new Role<Expression>("Initializer", Expression.Null);

	public override SymbolKind SymbolKind => SymbolKind.Field;

	public CSharpTokenNode AssignToken => GetChildByRole(Roles.Assign);

	public Expression Initializer
	{
		get
		{
			return GetChildByRole(InitializerRole);
		}
		set
		{
			SetChildByRole(InitializerRole, value);
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitEnumMemberDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitEnumMemberDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitEnumMemberDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is EnumMemberDeclaration enumMemberDeclaration && MatchAttributesAndModifiers(enumMemberDeclaration, match) && AstNode.MatchString(Name, enumMemberDeclaration.Name) && Initializer.DoMatch(enumMemberDeclaration.Initializer, match);
	}
}
