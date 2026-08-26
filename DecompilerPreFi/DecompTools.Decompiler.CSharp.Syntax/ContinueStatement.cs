using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class ContinueStatement : Statement
{
	public static readonly TokenRole ContinueKeywordRole = new TokenRole("continue");

	public CSharpTokenNode ContinueToken => GetChildByRole(ContinueKeywordRole);

	public CSharpTokenNode SemicolonToken => GetChildByRole(Roles.Semicolon);

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitContinueStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitContinueStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitContinueStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		ContinueStatement continueStatement = other as ContinueStatement;
		return continueStatement != null;
	}
}
