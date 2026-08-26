using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class BreakStatement : Statement
{
	public static readonly TokenRole BreakKeywordRole = new TokenRole("break");

	public CSharpTokenNode BreakToken => GetChildByRole(BreakKeywordRole);

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitBreakStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitBreakStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitBreakStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		BreakStatement breakStatement = other as BreakStatement;
		return breakStatement != null;
	}
}
