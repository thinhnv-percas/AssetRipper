using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class AssignmentExpression : Expression
{
	public static readonly Role<Expression> LeftExpressionRole = BinaryOperatorExpression.LeftExpressionRole;

	public static readonly Role<VBTokenNode> OperatorRole = BinaryOperatorExpression.OperatorRole;

	public static readonly Role<Expression> RightExpressionRole = BinaryOperatorExpression.RightExpressionRole;

	public Expression Left
	{
		get
		{
			return GetChildByRole(LeftExpressionRole);
		}
		set
		{
			SetChildByRole(LeftExpressionRole, value);
		}
	}

	public AssignmentOperatorType Operator { get; set; }

	public Expression Right
	{
		get
		{
			return GetChildByRole(RightExpressionRole);
		}
		set
		{
			SetChildByRole(RightExpressionRole, value);
		}
	}

	public AssignmentExpression(Expression left, AssignmentOperatorType type, Expression right)
	{
		AddChild(left, LeftExpressionRole);
		AddChild(right, RightExpressionRole);
		Operator = type;
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		throw new NotImplementedException();
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAssignmentExpression(this, data);
	}
}
