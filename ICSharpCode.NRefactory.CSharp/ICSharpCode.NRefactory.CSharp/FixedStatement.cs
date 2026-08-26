using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class FixedStatement : Statement
{
	public static readonly TokenRole FixedKeywordRole = new TokenRole("fixed");

	public CSharpTokenNode FixedToken => GetChildByRole(FixedKeywordRole);

	public CSharpTokenNode LParToken => GetChildByRole(Roles.LPar);

	public AstType Type
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

	public AstNodeCollection<VariableInitializer> Variables => GetChildrenByRole(Roles.Variable);

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
		visitor.VisitFixedStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitFixedStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitFixedStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is FixedStatement fixedStatement && Type.DoMatch(fixedStatement.Type, match) && Variables.DoMatch(fixedStatement.Variables, match))
		{
			return EmbeddedStatement.DoMatch(fixedStatement.EmbeddedStatement, match);
		}
		return false;
	}
}
