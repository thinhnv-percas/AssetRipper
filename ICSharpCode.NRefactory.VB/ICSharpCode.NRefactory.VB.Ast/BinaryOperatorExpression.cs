using System;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.VB.Ast;

public class BinaryOperatorExpression : Expression
{
	public static readonly Role<Expression> LeftExpressionRole = new Role<Expression>("Left");

	public static readonly Role<VBTokenNode> OperatorRole = new Role<VBTokenNode>("Operator");

	public static readonly Role<Expression> RightExpressionRole = new Role<Expression>("Right");

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

	public BinaryOperatorType Operator { get; set; }

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

	public BinaryOperatorExpression(Expression left, BinaryOperatorType type, Expression right)
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
		return visitor.VisitBinaryOperatorExpression(this, data);
	}
}
