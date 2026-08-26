using System;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.CSharp.OutputVisitor;

public class InsertParenthesesVisitor : DepthFirstAstVisitor
{
	private const int Primary = 17;

	private const int NullableRewrap = 16;

	private const int QueryOrLambda = 15;

	private const int Unary = 14;

	private const int RelationalAndTypeTesting = 10;

	private const int Equality = 9;

	private const int Conditional = 2;

	private const int Assignment = 1;

	public bool InsertParenthesesForReadability { get; set; }

	private static int GetPrecedence(Expression expr)
	{
		if (expr is QueryExpression)
		{
			return 15;
		}
		if (expr is UnaryOperatorExpression unaryOperatorExpression)
		{
			switch (unaryOperatorExpression.Operator)
			{
			case UnaryOperatorType.PostIncrement:
			case UnaryOperatorType.PostDecrement:
			case UnaryOperatorType.NullConditional:
			case UnaryOperatorType.SuppressNullableWarning:
				return 17;
			case UnaryOperatorType.NullConditionalRewrap:
				return 16;
			case UnaryOperatorType.IsTrue:
				return 2;
			default:
				return 14;
			}
		}
		if (expr is CastExpression)
		{
			return 14;
		}
		if (expr is PrimitiveExpression { Value: var value })
		{
			if (value is int num && num < 0)
			{
				return 14;
			}
			if (value is long num2 && num2 < 0)
			{
				return 14;
			}
			if (value is float num3 && num3 < 0f)
			{
				return 14;
			}
			if (value is double num4 && num4 < 0.0)
			{
				return 14;
			}
			if (value is decimal num5 && num5 < 0m)
			{
				return 14;
			}
		}
		if (expr is BinaryOperatorExpression binaryOperatorExpression)
		{
			switch (binaryOperatorExpression.Operator)
			{
			case BinaryOperatorType.Multiply:
			case BinaryOperatorType.Divide:
			case BinaryOperatorType.Modulus:
				return 13;
			case BinaryOperatorType.Add:
			case BinaryOperatorType.Subtract:
				return 12;
			case BinaryOperatorType.ShiftLeft:
			case BinaryOperatorType.ShiftRight:
				return 11;
			case BinaryOperatorType.GreaterThan:
			case BinaryOperatorType.GreaterThanOrEqual:
			case BinaryOperatorType.LessThan:
			case BinaryOperatorType.LessThanOrEqual:
				return 10;
			case BinaryOperatorType.Equality:
			case BinaryOperatorType.InEquality:
				return 9;
			case BinaryOperatorType.BitwiseAnd:
				return 8;
			case BinaryOperatorType.ExclusiveOr:
				return 7;
			case BinaryOperatorType.BitwiseOr:
				return 6;
			case BinaryOperatorType.ConditionalAnd:
				return 5;
			case BinaryOperatorType.ConditionalOr:
				return 4;
			case BinaryOperatorType.NullCoalescing:
				return 3;
			default:
				throw new NotSupportedException("Invalid value for BinaryOperatorType");
			}
		}
		if (expr is IsExpression || expr is AsExpression)
		{
			return 10;
		}
		if (expr is ConditionalExpression)
		{
			return 2;
		}
		if (expr is AssignmentExpression || expr is LambdaExpression)
		{
			return 1;
		}
		return 17;
	}

	private static void ParenthesizeIfRequired(Expression expr, int minimumPrecedence)
	{
		if (GetPrecedence(expr) < minimumPrecedence)
		{
			Parenthesize(expr);
		}
	}

	private static void Parenthesize(Expression expr)
	{
		expr.ReplaceWith((Expression e) => new ParenthesizedExpression
		{
			Expression = e
		});
	}

	public override void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
	{
		ParenthesizeIfRequired(memberReferenceExpression.Target, 17);
		base.VisitMemberReferenceExpression(memberReferenceExpression);
	}

	public override void VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
	{
		ParenthesizeIfRequired(pointerReferenceExpression.Target, 17);
		base.VisitPointerReferenceExpression(pointerReferenceExpression);
	}

	public override void VisitInvocationExpression(InvocationExpression invocationExpression)
	{
		ParenthesizeIfRequired(invocationExpression.Target, 17);
		base.VisitInvocationExpression(invocationExpression);
	}

	public override void VisitIndexerExpression(IndexerExpression indexerExpression)
	{
		ParenthesizeIfRequired(indexerExpression.Target, 17);
		if (indexerExpression.Target is ArrayCreateExpression arrayCreateExpression && (InsertParenthesesForReadability || arrayCreateExpression.Initializer.IsNull))
		{
			Parenthesize(indexerExpression.Target);
		}
		base.VisitIndexerExpression(indexerExpression);
	}

	public override void VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
	{
		ParenthesizeIfRequired(unaryOperatorExpression.Expression, GetPrecedence(unaryOperatorExpression));
		if (unaryOperatorExpression.Expression is UnaryOperatorExpression expr && InsertParenthesesForReadability)
		{
			Parenthesize(expr);
		}
		base.VisitUnaryOperatorExpression(unaryOperatorExpression);
	}

	public override void VisitCastExpression(CastExpression castExpression)
	{
		if (!(castExpression.Expression is CastExpression))
		{
			ParenthesizeIfRequired(castExpression.Expression, InsertParenthesesForReadability ? 16 : 14);
		}
		if (castExpression.Expression is UnaryOperatorExpression { Operator: not UnaryOperatorType.BitNot, Operator: not UnaryOperatorType.Not } && TypeCanBeMisinterpretedAsExpression(castExpression.Type))
		{
			Parenthesize(castExpression.Expression);
		}
		if (castExpression.Expression is PrimitiveExpression { Value: not null } primitiveExpression && TypeCanBeMisinterpretedAsExpression(castExpression.Type))
		{
			switch (Type.GetTypeCode(primitiveExpression.Value.GetType()))
			{
			case TypeCode.SByte:
				if ((sbyte)primitiveExpression.Value < 0)
				{
					Parenthesize(castExpression.Expression);
				}
				break;
			case TypeCode.Int16:
				if ((short)primitiveExpression.Value < 0)
				{
					Parenthesize(castExpression.Expression);
				}
				break;
			case TypeCode.Int32:
				if ((int)primitiveExpression.Value < 0)
				{
					Parenthesize(castExpression.Expression);
				}
				break;
			case TypeCode.Int64:
				if ((long)primitiveExpression.Value < 0)
				{
					Parenthesize(castExpression.Expression);
				}
				break;
			case TypeCode.Single:
				if ((float)primitiveExpression.Value < 0f)
				{
					Parenthesize(castExpression.Expression);
				}
				break;
			case TypeCode.Double:
				if ((double)primitiveExpression.Value < 0.0)
				{
					Parenthesize(castExpression.Expression);
				}
				break;
			case TypeCode.Decimal:
				if ((decimal)primitiveExpression.Value < 0m)
				{
					Parenthesize(castExpression.Expression);
				}
				break;
			}
		}
		base.VisitCastExpression(castExpression);
	}

	private static bool TypeCanBeMisinterpretedAsExpression(AstType type)
	{
		if (type is MemberType memberType)
		{
			return !memberType.IsDoubleColon;
		}
		return type is SimpleType;
	}

	public override void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
	{
		int precedence = GetPrecedence(binaryOperatorExpression);
		checked
		{
			if (binaryOperatorExpression.Operator == BinaryOperatorType.NullCoalescing)
			{
				if (InsertParenthesesForReadability)
				{
					ParenthesizeIfRequired(binaryOperatorExpression.Left, 16);
					if (GetBinaryOperatorType(binaryOperatorExpression.Right) == BinaryOperatorType.NullCoalescing)
					{
						ParenthesizeIfRequired(binaryOperatorExpression.Right, precedence);
					}
					else
					{
						ParenthesizeIfRequired(binaryOperatorExpression.Right, 16);
					}
				}
				else
				{
					ParenthesizeIfRequired(binaryOperatorExpression.Left, precedence + 1);
					ParenthesizeIfRequired(binaryOperatorExpression.Right, precedence);
				}
			}
			else if (InsertParenthesesForReadability && precedence < 9)
			{
				int minimumPrecedence = (IsBitwise(binaryOperatorExpression.Operator) ? 14 : 9);
				if (GetBinaryOperatorType(binaryOperatorExpression.Left) == binaryOperatorExpression.Operator)
				{
					ParenthesizeIfRequired(binaryOperatorExpression.Left, precedence);
				}
				else
				{
					ParenthesizeIfRequired(binaryOperatorExpression.Left, minimumPrecedence);
				}
				ParenthesizeIfRequired(binaryOperatorExpression.Right, minimumPrecedence);
			}
			else
			{
				ParenthesizeIfRequired(binaryOperatorExpression.Left, precedence);
				ParenthesizeIfRequired(binaryOperatorExpression.Right, precedence + 1);
			}
			base.VisitBinaryOperatorExpression(binaryOperatorExpression);
		}
	}

	private static bool IsBitwise(BinaryOperatorType op)
	{
		return op == BinaryOperatorType.BitwiseAnd || op == BinaryOperatorType.BitwiseOr || op == BinaryOperatorType.ExclusiveOr;
	}

	private BinaryOperatorType? GetBinaryOperatorType(Expression expr)
	{
		if (expr is BinaryOperatorExpression binaryOperatorExpression)
		{
			return binaryOperatorExpression.Operator;
		}
		return null;
	}

	public override void VisitIsExpression(IsExpression isExpression)
	{
		if (InsertParenthesesForReadability)
		{
			ParenthesizeIfRequired(isExpression.Expression, 16);
		}
		else
		{
			ParenthesizeIfRequired(isExpression.Expression, 10);
		}
		base.VisitIsExpression(isExpression);
	}

	public override void VisitAsExpression(AsExpression asExpression)
	{
		if (InsertParenthesesForReadability)
		{
			ParenthesizeIfRequired(asExpression.Expression, 16);
		}
		else
		{
			ParenthesizeIfRequired(asExpression.Expression, 10);
		}
		base.VisitAsExpression(asExpression);
	}

	public override void VisitConditionalExpression(ConditionalExpression conditionalExpression)
	{
		if (conditionalExpression.Parent is Interpolation)
		{
			Parenthesize(conditionalExpression);
		}
		if (InsertParenthesesForReadability)
		{
			ParenthesizeIfRequired(conditionalExpression.Condition, 16);
			ParenthesizeIfRequired(conditionalExpression.TrueExpression, 16);
			ParenthesizeIfRequired(conditionalExpression.FalseExpression, 16);
		}
		else
		{
			ParenthesizeIfRequired(conditionalExpression.Condition, 3);
			ParenthesizeIfRequired(conditionalExpression.TrueExpression, 2);
			ParenthesizeIfRequired(conditionalExpression.FalseExpression, 2);
		}
		base.VisitConditionalExpression(conditionalExpression);
	}

	public override void VisitAssignmentExpression(AssignmentExpression assignmentExpression)
	{
		ParenthesizeIfRequired(assignmentExpression.Left, 2);
		if (InsertParenthesesForReadability)
		{
			ParenthesizeIfRequired(assignmentExpression.Right, 11);
		}
		else
		{
			ParenthesizeIfRequired(assignmentExpression.Right, 1);
		}
		base.VisitAssignmentExpression(assignmentExpression);
	}

	public override void VisitQueryExpression(QueryExpression queryExpression)
	{
		if (queryExpression.Role == BinaryOperatorExpression.LeftRole)
		{
			Parenthesize(queryExpression);
		}
		if (queryExpression.Parent is IsExpression || queryExpression.Parent is AsExpression)
		{
			Parenthesize(queryExpression);
		}
		if (InsertParenthesesForReadability && (queryExpression.Parent is UnaryOperatorExpression || queryExpression.Parent is BinaryOperatorExpression))
		{
			Parenthesize(queryExpression);
		}
		base.VisitQueryExpression(queryExpression);
	}

	public override void VisitNamedExpression(NamedExpression namedExpression)
	{
		if (InsertParenthesesForReadability)
		{
			ParenthesizeIfRequired(namedExpression.Expression, 11);
		}
		base.VisitNamedExpression(namedExpression);
	}
}
