using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class TryCatchStatement : Statement
{
	public static readonly TokenRole TryKeywordRole = new TokenRole("try");

	public static readonly Role<BlockStatement> TryBlockRole = new Role<BlockStatement>("TryBlock", BlockStatement.Null);

	public static readonly Role<CatchClause> CatchClauseRole = new Role<CatchClause>("CatchClause", CatchClause.Null);

	public static readonly TokenRole FinallyKeywordRole = new TokenRole("finally");

	public static readonly Role<BlockStatement> FinallyBlockRole = new Role<BlockStatement>("FinallyBlock", BlockStatement.Null);

	public CSharpTokenNode TryToken => GetChildByRole(TryKeywordRole);

	public BlockStatement TryBlock
	{
		get
		{
			return GetChildByRole(TryBlockRole);
		}
		set
		{
			SetChildByRole(TryBlockRole, value);
		}
	}

	public AstNodeCollection<CatchClause> CatchClauses => GetChildrenByRole(CatchClauseRole);

	public CSharpTokenNode FinallyToken => GetChildByRole(FinallyKeywordRole);

	public BlockStatement FinallyBlock
	{
		get
		{
			return GetChildByRole(FinallyBlockRole);
		}
		set
		{
			SetChildByRole(FinallyBlockRole, value);
		}
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitTryCatchStatement(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitTryCatchStatement(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTryCatchStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is TryCatchStatement tryCatchStatement && TryBlock.DoMatch(tryCatchStatement.TryBlock, match) && CatchClauses.DoMatch(tryCatchStatement.CatchClauses, match) && FinallyBlock.DoMatch(tryCatchStatement.FinallyBlock, match);
	}
}
