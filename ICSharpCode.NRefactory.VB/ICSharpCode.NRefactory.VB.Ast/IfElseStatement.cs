using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class IfElseStatement : Statement
{
	public static readonly Role<Statement> FalseStatementRole = new Role<Statement>("False", Statement.Null);

	public static readonly Role<Statement> TrueStatementRole = new Role<Statement>("True", Statement.Null);

	public Expression Condition
	{
		get
		{
			return GetChildByRole(Roles.Condition);
		}
		set
		{
			SetChildByRole(Roles.Condition, value);
		}
	}

	public Statement Body
	{
		get
		{
			return GetChildByRole(TrueStatementRole);
		}
		set
		{
			SetChildByRole(TrueStatementRole, value);
		}
	}

	public Statement ElseBlock
	{
		get
		{
			return GetChildByRole(FalseStatementRole);
		}
		set
		{
			SetChildByRole(FalseStatementRole, value);
		}
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitIfElseStatement(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}
}
