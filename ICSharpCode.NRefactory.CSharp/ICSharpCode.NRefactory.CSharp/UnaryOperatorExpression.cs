using System;
using System.Linq.Expressions;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp;

public class UnaryOperatorExpression : Expression
{
	public static readonly TokenRole NotRole = new TokenRole("!");

	public static readonly TokenRole BitNotRole = new TokenRole("~");

	public static readonly TokenRole MinusRole = new TokenRole("-");

	public static readonly TokenRole PlusRole = new TokenRole("+");

	public static readonly TokenRole IncrementRole = new TokenRole("++");

	public static readonly TokenRole DecrementRole = new TokenRole("--");

	public static readonly TokenRole DereferenceRole = new TokenRole("*");

	public static readonly TokenRole AddressOfRole = new TokenRole("&");

	public static readonly TokenRole AwaitRole = new TokenRole("await");

	private static Expression NoUnaryExpressionError = new ErrorExpression("No unary expression");

	public UnaryOperatorType Operator { get; set; }

	public CSharpTokenNode OperatorToken => GetChildByRole(GetOperatorRole(Operator));

	public Expression Expression
	{
		get
		{
			return GetChildByRole(Roles.Expression) ?? NoUnaryExpressionError;
		}
		set
		{
			SetChildByRole(Roles.Expression, value);
		}
	}

	public UnaryOperatorExpression()
	{
	}

	public UnaryOperatorExpression(UnaryOperatorType op, Expression expression)
	{
		Operator = op;
		Expression = expression;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitUnaryOperatorExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitUnaryOperatorExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitUnaryOperatorExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		if (other is UnaryOperatorExpression unaryOperatorExpression && (Operator == UnaryOperatorType.Any || Operator == unaryOperatorExpression.Operator))
		{
			return Expression.DoMatch(unaryOperatorExpression.Expression, match);
		}
		return false;
	}

	public static TokenRole GetOperatorRole(UnaryOperatorType op)
	{
		switch (op)
		{
		case UnaryOperatorType.Not:
			return NotRole;
		case UnaryOperatorType.BitNot:
			return BitNotRole;
		case UnaryOperatorType.Minus:
			return MinusRole;
		case UnaryOperatorType.Plus:
			return PlusRole;
		case UnaryOperatorType.Increment:
		case UnaryOperatorType.PostIncrement:
			return IncrementRole;
		case UnaryOperatorType.Decrement:
		case UnaryOperatorType.PostDecrement:
			return DecrementRole;
		case UnaryOperatorType.Dereference:
			return DereferenceRole;
		case UnaryOperatorType.AddressOf:
			return AddressOfRole;
		case UnaryOperatorType.Await:
			return AwaitRole;
		default:
			throw new NotSupportedException("Invalid value for UnaryOperatorType");
		}
	}

	public static ExpressionType GetLinqNodeType(UnaryOperatorType op, bool checkForOverflow)
	{
		switch (op)
		{
		case UnaryOperatorType.Not:
			return ExpressionType.Not;
		case UnaryOperatorType.BitNot:
			return ExpressionType.OnesComplement;
		case UnaryOperatorType.Minus:
			if (!checkForOverflow)
			{
				return ExpressionType.Negate;
			}
			return ExpressionType.NegateChecked;
		case UnaryOperatorType.Plus:
			return ExpressionType.UnaryPlus;
		case UnaryOperatorType.Increment:
			return ExpressionType.PreIncrementAssign;
		case UnaryOperatorType.Decrement:
			return ExpressionType.PreDecrementAssign;
		case UnaryOperatorType.PostIncrement:
			return ExpressionType.PostIncrementAssign;
		case UnaryOperatorType.PostDecrement:
			return ExpressionType.PostDecrementAssign;
		case UnaryOperatorType.Dereference:
		case UnaryOperatorType.AddressOf:
		case UnaryOperatorType.Await:
			return ExpressionType.Extension;
		default:
			throw new NotSupportedException("Invalid value for UnaryOperatorType");
		}
	}
}
