using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class SingleLineSubLambdaExpression : LambdaExpression
{
	public static readonly Role<Statement> StatementRole = BlockStatement.StatementRole;

	public Statement EmbeddedStatement
	{
		get
		{
			return GetChildByRole(StatementRole);
		}
		set
		{
			SetChildByRole(StatementRole, value);
		}
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitSingleLineSubLambdaExpression(this, data);
	}
}
