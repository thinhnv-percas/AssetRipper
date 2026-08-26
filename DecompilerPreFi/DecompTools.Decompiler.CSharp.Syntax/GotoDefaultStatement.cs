using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class GotoDefaultStatement : Statement
{
	public static readonly TokenRole GotoKeywordRole = new TokenRole("goto");

	public static readonly TokenRole DefaultKeywordRole = new TokenRole("default");

	public CSharpTokenNode GotoToken => GetChildByRole(GotoKeywordRole);

	public CSharpTokenNode DefaultToken => GetChildByRole(DefaultKeywordRole);

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitGotoDefaultStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitGotoDefaultStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitGotoDefaultStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		GotoDefaultStatement gotoDefaultStatement = other as GotoDefaultStatement;
		return gotoDefaultStatement != null;
	}
}
