using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class YieldBreakStatement : Statement
{
	public static readonly TokenRole YieldKeywordRole = new TokenRole("yield");

	public static readonly TokenRole BreakKeywordRole = new TokenRole("break");

	public CSharpTokenNode YieldToken => GetChildByRole(YieldKeywordRole);

	public CSharpTokenNode BreakToken => GetChildByRole(BreakKeywordRole);

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitYieldBreakStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitYieldBreakStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitYieldBreakStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		YieldBreakStatement yieldBreakStatement = other as YieldBreakStatement;
		return yieldBreakStatement != null;
	}
}
