using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class UsingStatement : Statement
{
	public static readonly TokenRole UsingKeywordRole = new TokenRole("using");

	public static readonly Role<AstNode> ResourceAcquisitionRole = new Role<AstNode>("ResourceAcquisition", AstNode.Null);

	public CSharpTokenNode UsingToken => GetChildByRole(UsingKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstNode ResourceAcquisition
	{
		get
		{
			return GetChildByRole(ResourceAcquisitionRole);
		}
		set
		{
			SetChildByRole(ResourceAcquisitionRole, value);
		}
	}

	public CSharpTokenNode RParToken => GetChildByRole(Roles.RPar);

	public Statement EmbeddedStatement
	{
		get
		{
			return GetChildByRole(Roles.EmbeddedStatement);
		}
		set
		{
			SetChildByRole(Roles.EmbeddedStatement, value);
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitUsingStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitUsingStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitUsingStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is UsingStatement usingStatement && ResourceAcquisition.DoMatch(usingStatement.ResourceAcquisition, match))
		{
			return EmbeddedStatement.DoMatch(usingStatement.EmbeddedStatement, match);
		}
		return false;
	}
}
