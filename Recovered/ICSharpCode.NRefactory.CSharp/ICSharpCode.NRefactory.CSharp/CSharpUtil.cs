using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.NRefactory.CSharp
{
	public static class CSharpUtil
	{
		public static Expression InvertCondition(Expression condition)
		{
			return InvertConditionInternal(condition);
		}

		private static Expression InvertConditionInternal(Expression condition)
		{
			if (condition is ParenthesizedExpression)
			{
				return new ParenthesizedExpression(InvertCondition(((ParenthesizedExpression)condition).Expression));
			}
			if (condition is UnaryOperatorExpression)
			{
				UnaryOperatorExpression unaryOperatorExpression = (UnaryOperatorExpression)condition;
				if (unaryOperatorExpression.Operator == UnaryOperatorType.Not)
				{
					if (!(unaryOperatorExpression.Parent is Expression))
					{
						return GetInnerMostExpression(unaryOperatorExpression.Expression).Clone();
					}
					return unaryOperatorExpression.Expression.Clone();
				}
				return new UnaryOperatorExpression(UnaryOperatorType.Not, unaryOperatorExpression.Clone());
			}
			if (condition is BinaryOperatorExpression)
			{
				BinaryOperatorExpression binaryOperatorExpression = (BinaryOperatorExpression)condition;
				if (binaryOperatorExpression.Operator == BinaryOperatorType.ConditionalAnd || binaryOperatorExpression.Operator == BinaryOperatorType.ConditionalOr)
				{
					return new BinaryOperatorExpression(InvertCondition(binaryOperatorExpression.Left), NegateConditionOperator(binaryOperatorExpression.Operator), InvertCondition(binaryOperatorExpression.Right));
				}
				if (binaryOperatorExpression.Operator == BinaryOperatorType.Equality || binaryOperatorExpression.Operator == BinaryOperatorType.InEquality || binaryOperatorExpression.Operator == BinaryOperatorType.GreaterThan || binaryOperatorExpression.Operator == BinaryOperatorType.GreaterThanOrEqual || binaryOperatorExpression.Operator == BinaryOperatorType.LessThan || binaryOperatorExpression.Operator == BinaryOperatorType.LessThanOrEqual)
				{
					return new BinaryOperatorExpression(binaryOperatorExpression.Left.Clone(), NegateRelationalOperator(binaryOperatorExpression.Operator), binaryOperatorExpression.Right.Clone());
				}
				BinaryOperatorType binaryOperatorType = NegateRelationalOperator(binaryOperatorExpression.Operator);
				if (binaryOperatorType == BinaryOperatorType.Any)
				{
					return new UnaryOperatorExpression(UnaryOperatorType.Not, new ParenthesizedExpression(condition.Clone()));
				}
				binaryOperatorExpression = (BinaryOperatorExpression)binaryOperatorExpression.Clone();
				binaryOperatorExpression.Operator = binaryOperatorType;
				return binaryOperatorExpression;
			}
			if (condition is ConditionalExpression)
			{
				ConditionalExpression obj = condition.Clone() as ConditionalExpression;
				obj.Condition = InvertCondition(obj.Condition);
				return obj;
			}
			if (condition is PrimitiveExpression)
			{
				PrimitiveExpression primitiveExpression = condition as PrimitiveExpression;
				if (primitiveExpression.Value is bool)
				{
					return new PrimitiveExpression(!(bool)primitiveExpression.Value);
				}
			}
			return new UnaryOperatorExpression(UnaryOperatorType.Not, AddParensForUnaryExpressionIfRequired(condition.Clone()));
		}

		internal static Expression AddParensForUnaryExpressionIfRequired(Expression expression)
		{
			if (expression is BinaryOperatorExpression || expression is AssignmentExpression || expression is CastExpression || expression is AsExpression || expression is IsExpression || expression is LambdaExpression || expression is ConditionalExpression)
			{
				return new ParenthesizedExpression(expression);
			}
			return expression;
		}

		public static BinaryOperatorType NegateRelationalOperator(BinaryOperatorType op)
		{
			switch (op)
			{
			case BinaryOperatorType.GreaterThan:
				return BinaryOperatorType.LessThanOrEqual;
			case BinaryOperatorType.GreaterThanOrEqual:
				return BinaryOperatorType.LessThan;
			case BinaryOperatorType.Equality:
				return BinaryOperatorType.InEquality;
			case BinaryOperatorType.InEquality:
				return BinaryOperatorType.Equality;
			case BinaryOperatorType.LessThan:
				return BinaryOperatorType.GreaterThanOrEqual;
			case BinaryOperatorType.LessThanOrEqual:
				return BinaryOperatorType.GreaterThan;
			case BinaryOperatorType.ConditionalOr:
				return BinaryOperatorType.ConditionalAnd;
			case BinaryOperatorType.ConditionalAnd:
				return BinaryOperatorType.ConditionalOr;
			default:
				return BinaryOperatorType.Any;
			}
		}

		public static bool IsRelationalOperator(BinaryOperatorType op)
		{
			return NegateRelationalOperator(op) != BinaryOperatorType.Any;
		}

		public static BinaryOperatorType NegateConditionOperator(BinaryOperatorType op)
		{
			switch (op)
			{
			case BinaryOperatorType.ConditionalOr:
				return BinaryOperatorType.ConditionalAnd;
			case BinaryOperatorType.ConditionalAnd:
				return BinaryOperatorType.ConditionalOr;
			default:
				return BinaryOperatorType.Any;
			}
		}

		public static bool AreConditionsEqual(Expression cond1, Expression cond2)
		{
			if (cond1 == null || cond2 == null)
			{
				return false;
			}
			return GetInnerMostExpression(cond1).IsMatch(GetInnerMostExpression(cond2));
		}

		public static Expression GetInnerMostExpression(Expression target)
		{
			while (target is ParenthesizedExpression)
			{
				target = ((ParenthesizedExpression)target).Expression;
			}
			return target;
		}
	}
}
