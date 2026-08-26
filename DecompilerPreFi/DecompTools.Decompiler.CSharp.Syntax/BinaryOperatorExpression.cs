using System;
using System.Linq.Expressions;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class BinaryOperatorExpression : Expression
{
	public static readonly TokenRole BitwiseAndRole = new TokenRole("&");

	public static readonly TokenRole BitwiseOrRole = new TokenRole("|");

	public static readonly TokenRole ConditionalAndRole = new TokenRole("&&");

	public static readonly TokenRole ConditionalOrRole = new TokenRole("||");

	public static readonly TokenRole ExclusiveOrRole = new TokenRole("^");

	public static readonly TokenRole GreaterThanRole = new TokenRole(">");

	public static readonly TokenRole GreaterThanOrEqualRole = new TokenRole(">=");

	public static readonly TokenRole EqualityRole = new TokenRole("==");

	public static readonly TokenRole InEqualityRole = new TokenRole("!=");

	public static readonly TokenRole LessThanRole = new TokenRole("<");

	public static readonly TokenRole LessThanOrEqualRole = new TokenRole("<=");

	public static readonly TokenRole AddRole = new TokenRole("+");

	public static readonly TokenRole SubtractRole = new TokenRole("-");

	public static readonly TokenRole MultiplyRole = new TokenRole("*");

	public static readonly TokenRole DivideRole = new TokenRole("/");

	public static readonly TokenRole ModulusRole = new TokenRole("%");

	public static readonly TokenRole ShiftLeftRole = new TokenRole("<<");

	public static readonly TokenRole ShiftRightRole = new TokenRole(">>");

	public static readonly TokenRole NullCoalescingRole = new TokenRole("??");

	public static readonly Role<Expression> LeftRole = new Role<Expression>("Left", Expression.Null);

	public static readonly Role<Expression> RightRole = new Role<Expression>("Right", Expression.Null);

	public BinaryOperatorType Operator { get; set; }

	public Expression Left
	{
		get
		{
			return GetChildByRole(LeftRole);
		}
		set
		{
			SetChildByRole(LeftRole, value);
		}
	}

	public CSharpTokenNode OperatorToken => GetChildByRole(GetOperatorRole(Operator));

	public Expression Right
	{
		get
		{
			return GetChildByRole(RightRole);
		}
		set
		{
			SetChildByRole(RightRole, value);
		}
	}

	public BinaryOperatorExpression()
	{
	}

	public BinaryOperatorExpression(Expression left, BinaryOperatorType op, Expression right)
	{
		Left = left;
		Operator = op;
		Right = right;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitBinaryOperatorExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitBinaryOperatorExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitBinaryOperatorExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is BinaryOperatorExpression binaryOperatorExpression && (Operator == BinaryOperatorType.Any || Operator == binaryOperatorExpression.Operator) && Left.DoMatch(binaryOperatorExpression.Left, match) && Right.DoMatch(binaryOperatorExpression.Right, match);
	}

	public static TokenRole GetOperatorRole(BinaryOperatorType op)
	{
		return op switch
		{
			BinaryOperatorType.BitwiseAnd => BitwiseAndRole, 
			BinaryOperatorType.BitwiseOr => BitwiseOrRole, 
			BinaryOperatorType.ConditionalAnd => ConditionalAndRole, 
			BinaryOperatorType.ConditionalOr => ConditionalOrRole, 
			BinaryOperatorType.ExclusiveOr => ExclusiveOrRole, 
			BinaryOperatorType.GreaterThan => GreaterThanRole, 
			BinaryOperatorType.GreaterThanOrEqual => GreaterThanOrEqualRole, 
			BinaryOperatorType.Equality => EqualityRole, 
			BinaryOperatorType.InEquality => InEqualityRole, 
			BinaryOperatorType.LessThan => LessThanRole, 
			BinaryOperatorType.LessThanOrEqual => LessThanOrEqualRole, 
			BinaryOperatorType.Add => AddRole, 
			BinaryOperatorType.Subtract => SubtractRole, 
			BinaryOperatorType.Multiply => MultiplyRole, 
			BinaryOperatorType.Divide => DivideRole, 
			BinaryOperatorType.Modulus => ModulusRole, 
			BinaryOperatorType.ShiftLeft => ShiftLeftRole, 
			BinaryOperatorType.ShiftRight => ShiftRightRole, 
			BinaryOperatorType.NullCoalescing => NullCoalescingRole, 
			_ => throw new NotSupportedException("Invalid value for BinaryOperatorType"), 
		};
	}

	public static ExpressionType GetLinqNodeType(BinaryOperatorType op, bool checkForOverflow)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		return (ExpressionType)(op switch
		{
			BinaryOperatorType.BitwiseAnd => 2, 
			BinaryOperatorType.BitwiseOr => 36, 
			BinaryOperatorType.ConditionalAnd => 3, 
			BinaryOperatorType.ConditionalOr => 37, 
			BinaryOperatorType.ExclusiveOr => 14, 
			BinaryOperatorType.GreaterThan => 15, 
			BinaryOperatorType.GreaterThanOrEqual => 16, 
			BinaryOperatorType.Equality => 13, 
			BinaryOperatorType.InEquality => 35, 
			BinaryOperatorType.LessThan => 20, 
			BinaryOperatorType.LessThanOrEqual => 21, 
			BinaryOperatorType.Add => checkForOverflow ? 1 : 0, 
			BinaryOperatorType.Subtract => checkForOverflow ? 43 : 42, 
			BinaryOperatorType.Multiply => checkForOverflow ? 27 : 26, 
			BinaryOperatorType.Divide => 12, 
			BinaryOperatorType.Modulus => 25, 
			BinaryOperatorType.ShiftLeft => 19, 
			BinaryOperatorType.ShiftRight => 41, 
			BinaryOperatorType.NullCoalescing => 7, 
			_ => throw new NotSupportedException("Invalid value for BinaryOperatorType"), 
		});
	}
}
