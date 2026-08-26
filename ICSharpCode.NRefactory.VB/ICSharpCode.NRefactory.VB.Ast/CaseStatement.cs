using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class CaseStatement : Statement
{
	public static readonly Role<CaseStatement> CaseStatementRole = new Role<CaseStatement>("CaseStatement");

	public AstNodeCollection<CaseClause> Clauses => GetChildrenByRole(CaseClause.CaseClauseRole);

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

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitCaseStatement(this, data);
	}
}
