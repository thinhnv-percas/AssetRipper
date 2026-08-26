using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class TryStatement : Statement
{
	public static readonly Role<BlockStatement> FinallyBlockRole = new Role<BlockStatement>("FinallyBlock", BlockStatement.Null);

	public BlockStatement Body
	{
		get
		{
			return GetChildByRole(Roles.Body);
		}
		set
		{
			SetChildByRole(Roles.Body, value);
		}
	}

	public AstNodeCollection<CatchBlock> CatchBlocks => GetChildrenByRole(CatchBlock.CatchBlockRole);

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

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitTryStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}
}
