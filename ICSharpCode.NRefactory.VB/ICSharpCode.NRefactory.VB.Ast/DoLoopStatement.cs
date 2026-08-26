using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class DoLoopStatement : Statement
{
	public ConditionType ConditionType { get; set; }

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
		return visitor.VisitDoLoopStatement(this, data);
	}
}
