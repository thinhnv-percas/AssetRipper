using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class ExternAliasDeclaration : AstNode
{
	public override NodeType NodeType => NodeType.Unknown;

	public CSharpTokenNode ExternToken => GetChildByRole(Roles.ExternKeyword);

	public CSharpTokenNode AliasToken => GetChildByRole(Roles.AliasKeyword);

	public string Name
	{
		get
		{
			return GetChildByRole(Roles.Identifier).Name;
		}
		set
		{
			SetChildByRole(Roles.Identifier, Identifier.Create(value));
		}
	}

	public Identifier NameToken
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

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitExternAliasDeclaration(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitExternAliasDeclaration(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitExternAliasDeclaration(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is ExternAliasDeclaration externAliasDeclaration)
		{
			return AstNode.MatchString(Name, externAliasDeclaration.Name);
		}
		return false;
	}
}
