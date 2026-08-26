using System;
using System.Linq.Expressions;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

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

	public static readonly TokenRole NullConditionalRole = new TokenRole("?");

	public static readonly TokenRole SuppressNullableWarningRole = new TokenRole("!");

	public UnaryOperatorType Operator { get; set; }

	public CSharpTokenNode OperatorToken => GetChildByRole(GetOperatorRole(Operator));

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
		return other is UnaryOperatorExpression unaryOperatorExpression && (Operator == UnaryOperatorType.Any || Operator == unaryOperatorExpression.Operator) && Expression.DoMatch(unaryOperatorExpression.Expression, match);
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
		case UnaryOperatorType.NullConditional:
			return NullConditionalRole;
		case UnaryOperatorType.NullConditionalRewrap:
		case UnaryOperatorType.IsTrue:
			return null;
		case UnaryOperatorType.SuppressNullableWarning:
			return SuppressNullableWarningRole;
		default:
			throw new NotSupportedException("Invalid value for UnaryOperatorType");
		}
	}

	public static ExpressionType GetLinqNodeType(UnaryOperatorType op, bool checkForOverflow)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		switch (op)
		{
		case UnaryOperatorType.Not:
			return (ExpressionType)34;
		case UnaryOperatorType.BitNot:
			return (ExpressionType)82;
		case UnaryOperatorType.Minus:
			return (ExpressionType)(checkForOverflow ? 30 : 28);
		case UnaryOperatorType.Plus:
			return (ExpressionType)29;
		case UnaryOperatorType.Increment:
			return (ExpressionType)77;
		case UnaryOperatorType.Decrement:
			return (ExpressionType)78;
		case UnaryOperatorType.PostIncrement:
			return (ExpressionType)79;
		case UnaryOperatorType.PostDecrement:
			return (ExpressionType)80;
		case UnaryOperatorType.Dereference:
		case UnaryOperatorType.AddressOf:
		case UnaryOperatorType.Await:
		case UnaryOperatorType.SuppressNullableWarning:
			return (ExpressionType)52;
		default:
			throw new NotSupportedException("Invalid value for UnaryOperatorType");
		}
	}
}
