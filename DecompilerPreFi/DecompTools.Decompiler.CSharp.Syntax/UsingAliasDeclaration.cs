using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class UsingAliasDeclaration : AstNode
{
	public static readonly TokenRole UsingKeywordRole = new TokenRole("using");

	public static readonly Role<Identifier> AliasRole = new Role<Identifier>("Alias", Identifier.Null);

	public static readonly Role<AstType> ImportRole = UsingDeclaration.ImportRole;

	public override NodeType NodeType => NodeType.Unknown;

	public CSharpTokenNode UsingToken => GetChildByRole(UsingKeywordRole);

	public string Alias
	{
		get
		{
			return GetChildByRole(AliasRole).Name;
		}
		set
		{
			SetChildByRole(AliasRole, Identifier.Create(value));
		}
	}

	public CSharpTokenNode AssignToken => GetChildByRole(Roles.Assign);

	public AstType Import
	{
		get
		{
			return GetChildByRole(ImportRole);
		}
		set
		{
			SetChildByRole(ImportRole, value);
		}
	}

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public UsingAliasDeclaration()
	{
	}

	public UsingAliasDeclaration(string alias, string nameSpace)
	{
		AddChild(Identifier.Create(alias), AliasRole);
		AddChild(new SimpleType(nameSpace), ImportRole);
	}

	public UsingAliasDeclaration(string alias, AstType import)
	{
		AddChild(Identifier.Create(alias), AliasRole);
		AddChild(import, ImportRole);
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitUsingAliasDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitUsingAliasDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitUsingAliasDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is UsingAliasDeclaration usingAliasDeclaration && AstNode.MatchString(Alias, usingAliasDeclaration.Alias) && Import.DoMatch(usingAliasDeclaration.Import, match);
	}
}
