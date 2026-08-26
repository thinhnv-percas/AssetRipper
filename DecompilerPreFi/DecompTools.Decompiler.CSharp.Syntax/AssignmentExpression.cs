using System;
using System.Linq.Expressions;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;

namespace DecompTools.Decompiler.CSharp.Syntax;

public class AssignmentExpression : Expression
{
	public static readonly Role<Expression> LeftRole = BinaryOperatorExpression.LeftRole;

	public static readonly Role<Expression> RightRole = BinaryOperatorExpression.RightRole;

	public static readonly TokenRole AssignRole = new TokenRole("=");

	public static readonly TokenRole AddRole = new TokenRole("+=");

	public static readonly TokenRole SubtractRole = new TokenRole("-=");

	public static readonly TokenRole MultiplyRole = new TokenRole("*=");

	public static readonly TokenRole DivideRole = new TokenRole("/=");

	public static readonly TokenRole ModulusRole = new TokenRole("%=");

	public static readonly TokenRole ShiftLeftRole = new TokenRole("<<=");

	public static readonly TokenRole ShiftRightRole = new TokenRole(">>=");

	public static readonly TokenRole BitwiseAndRole = new TokenRole("&=");

	public static readonly TokenRole BitwiseOrRole = new TokenRole("|=");

	public static readonly TokenRole ExclusiveOrRole = new TokenRole("^=");

	public AssignmentOperatorType Operator { get; set; }

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

	public AssignmentExpression()
	{
	}

	public AssignmentExpression(Expression left, Expression right)
	{
		Left = left;
		Right = right;
	}

	public AssignmentExpression(Expression left, AssignmentOperatorType op, Expression right)
	{
		Left = left;
		Operator = op;
		Right = right;
	}

	public override void AcceptVisitor(IAstVisitor visitor)
	{
		visitor.VisitAssignmentExpression(this);
	}

	public override T AcceptVisitor<T>(IAstVisitor<T> visitor)
	{
		return visitor.VisitAssignmentExpression(this);
	}

	public override S AcceptVisitor<T, S>(IAstVisitor<T, S> visitor, T data)
	{
		return visitor.VisitAssignmentExpression(this, data);
	}

	protected internal override bool DoMatch(AstNode other, Match match)
	{
		return other is AssignmentExpression assignmentExpression && (Operator == AssignmentOperatorType.Any || Operator == assignmentExpression.Operator) && Left.DoMatch(assignmentExpression.Left, match) && Right.DoMatch(assignmentExpression.Right, match);
	}

	public static TokenRole GetOperatorRole(AssignmentOperatorType op)
	{
		return op switch
		{
			AssignmentOperatorType.Assign => AssignRole, 
			AssignmentOperatorType.Add => AddRole, 
			AssignmentOperatorType.Subtract => SubtractRole, 
			AssignmentOperatorType.Multiply => MultiplyRole, 
			AssignmentOperatorType.Divide => DivideRole, 
			AssignmentOperatorType.Modulus => ModulusRole, 
			AssignmentOperatorType.ShiftLeft => ShiftLeftRole, 
			AssignmentOperatorType.ShiftRight => ShiftRightRole, 
			AssignmentOperatorType.BitwiseAnd => BitwiseAndRole, 
			AssignmentOperatorType.BitwiseOr => BitwiseOrRole, 
			AssignmentOperatorType.ExclusiveOr => ExclusiveOrRole, 
			_ => throw new NotSupportedException("Invalid value for AssignmentOperatorType"), 
		};
	}

	public static BinaryOperatorType? GetCorrespondingBinaryOperator(AssignmentOperatorType op)
	{
		return op switch
		{
			AssignmentOperatorType.Assign => null, 
			AssignmentOperatorType.Add => BinaryOperatorType.Add, 
			AssignmentOperatorType.Subtract => BinaryOperatorType.Subtract, 
			AssignmentOperatorType.Multiply => BinaryOperatorType.Multiply, 
			AssignmentOperatorType.Divide => BinaryOperatorType.Divide, 
			AssignmentOperatorType.Modulus => BinaryOperatorType.Modulus, 
			AssignmentOperatorType.ShiftLeft => BinaryOperatorType.ShiftLeft, 
			AssignmentOperatorType.ShiftRight => BinaryOperatorType.ShiftRight, 
			AssignmentOperatorType.BitwiseAnd => BinaryOperatorType.BitwiseAnd, 
			AssignmentOperatorType.BitwiseOr => BinaryOperatorType.BitwiseOr, 
			AssignmentOperatorType.ExclusiveOr => BinaryOperatorType.ExclusiveOr, 
			_ => throw new NotSupportedException("Invalid value for AssignmentOperatorType"), 
		};
	}

	public static ExpressionType GetLinqNodeType(AssignmentOperatorType op, bool checkForOverflow)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		return (ExpressionType)(op switch
		{
			AssignmentOperatorType.Assign => 46, 
			AssignmentOperatorType.Add => checkForOverflow ? 74 : 63, 
			AssignmentOperatorType.Subtract => checkForOverflow ? 76 : 73, 
			AssignmentOperatorType.Multiply => checkForOverflow ? 75 : 69, 
			AssignmentOperatorType.Divide => 65, 
			AssignmentOperatorType.Modulus => 68, 
			AssignmentOperatorType.ShiftLeft => 67, 
			AssignmentOperatorType.ShiftRight => 72, 
			AssignmentOperatorType.BitwiseAnd => 64, 
			AssignmentOperatorType.BitwiseOr => 70, 
			AssignmentOperatorType.ExclusiveOr => 66, 
			_ => throw new NotSupportedException("Invalid value for AssignmentOperatorType"), 
		});
	}

	public static AssignmentOperatorType? GetAssignmentOperatorTypeFromExpressionType(ExpressionType expressionType)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Expected I4, but got Unknown
		switch (expressionType - 63)
		{
		case 0:
		case 11:
			return AssignmentOperatorType.Add;
		case 1:
			return AssignmentOperatorType.BitwiseAnd;
		case 2:
			return AssignmentOperatorType.Divide;
		case 3:
			return AssignmentOperatorType.ExclusiveOr;
		case 4:
			return AssignmentOperatorType.ShiftLeft;
		case 5:
			return AssignmentOperatorType.Modulus;
		case 6:
		case 12:
			return AssignmentOperatorType.Multiply;
		case 7:
			return AssignmentOperatorType.BitwiseOr;
		case 9:
			return AssignmentOperatorType.ShiftRight;
		case 10:
		case 13:
			return AssignmentOperatorType.Subtract;
		default:
			return null;
		}
	}
}
