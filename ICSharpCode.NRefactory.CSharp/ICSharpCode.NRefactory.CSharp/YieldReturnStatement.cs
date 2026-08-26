using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class YieldReturnStatement : Statement
{
	public static readonly TokenRole YieldKeywordRole = new TokenRole("yield");

	public static readonly TokenRole ReturnKeywordRole = new TokenRole("return");

	public CSharpTokenNode YieldToken => GetChildByRole(YieldKeywordRole);

	public CSharpTokenNode ReturnToken => GetChildByRole(ReturnKeywordRole);

	public Expression Expression
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

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitYieldReturnStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitYieldReturnStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitYieldReturnStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is YieldReturnStatement yieldReturnStatement)
		{
			return Expression.DoMatch(yieldReturnStatement.Expression, match);
		}
		return false;
	}
}
