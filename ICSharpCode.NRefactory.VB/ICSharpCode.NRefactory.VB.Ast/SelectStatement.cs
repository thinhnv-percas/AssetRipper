using System;
using System.Collections.Generic;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class SelectStatement : Statement
{
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

	public IList<ILSpan> HiddenEnd { get; set; }

	public AstNodeCollection<CaseStatement> Cases => GetChildrenByRole(CaseStatement.CaseStatementRole);

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitSelectStatement(this, data);
	}
}
