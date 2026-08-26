using System.Collections.Generic;
using System.Linq;
using dnSpy.Contracts.Decompiler;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.PatternMatching;

namespace ICSharpCode.Decompiler.Ast.Transforms;

public class PushNegation : DepthFirstAstVisitor<object, object>, IAstTransformPoolObject, IAstTransform
{
	private sealed class LiftedOperator
	{
	}

	public static readonly object LiftedOperatorAnnotation = new LiftedOperator();

	private static readonly AstNode asCastIsNullPattern = new BinaryOperatorExpression(new AnyNode("expr").ToExpression().CastAs(new AnyNode("type")), BinaryOperatorType.Equality, new NullReferenceExpression());

	private static readonly AstNode asCastIsNotNullPattern = new BinaryOperatorExpression(new AnyNode("expr").ToExpression().CastAs(new AnyNode("type")), BinaryOperatorType.InEquality, new NullReferenceExpression());

	public void Reset(DecompilerContext context)
	{
	}

	public override object VisitUnaryOperatorExpression(UnaryOperatorExpression unary, object data)
	{
		if (unary.Annotation<LiftedOperator>() != null || unary.Expression.Annotation<LiftedOperator>() != null)
		{
			return base.VisitUnaryOperatorExpression(unary, data);
		}
		if (unary.Operator == UnaryOperatorType.Not && unary.Expression is UnaryOperatorExpression && (unary.Expression as UnaryOperatorExpression).Operator == UnaryOperatorType.Not)
		{
			AstNode expression = (unary.Expression as UnaryOperatorExpression).Expression;
			unary.ReplaceWith(expression.WithAnnotation(unary.GetAllILSpans()));
			return expression.AcceptVisitor(this, data);
		}
		BinaryOperatorExpression binaryOperatorExpression = unary.Expression as BinaryOperatorExpression;
		if (unary.Operator == UnaryOperatorType.Not && binaryOperatorExpression != null)
		{
			bool flag = true;
			switch (binaryOperatorExpression.Operator)
			{
			case BinaryOperatorType.Equality:
				binaryOperatorExpression.Operator = BinaryOperatorType.InEquality;
				break;
			case BinaryOperatorType.InEquality:
				binaryOperatorExpression.Operator = BinaryOperatorType.Equality;
				break;
			case BinaryOperatorType.GreaterThan:
				binaryOperatorExpression.Operator = BinaryOperatorType.LessThanOrEqual;
				break;
			case BinaryOperatorType.GreaterThanOrEqual:
				binaryOperatorExpression.Operator = BinaryOperatorType.LessThan;
				break;
			case BinaryOperatorType.LessThanOrEqual:
				binaryOperatorExpression.Operator = BinaryOperatorType.GreaterThan;
				break;
			case BinaryOperatorType.LessThan:
				binaryOperatorExpression.Operator = BinaryOperatorType.GreaterThanOrEqual;
				break;
			default:
				flag = false;
				break;
			}
			if (flag)
			{
				unary.ReplaceWith(binaryOperatorExpression.WithAnnotation(unary.GetAllILSpans()));
				return binaryOperatorExpression.AcceptVisitor(this, data);
			}
			flag = true;
			switch (binaryOperatorExpression.Operator)
			{
			case BinaryOperatorType.ConditionalAnd:
				binaryOperatorExpression.Operator = BinaryOperatorType.ConditionalOr;
				break;
			case BinaryOperatorType.ConditionalOr:
				binaryOperatorExpression.Operator = BinaryOperatorType.ConditionalAnd;
				break;
			default:
				flag = false;
				break;
			}
			if (flag)
			{
				binaryOperatorExpression.Left.ReplaceWith((Expression e) => new UnaryOperatorExpression(UnaryOperatorType.Not, e));
				binaryOperatorExpression.Right.ReplaceWith((Expression e) => new UnaryOperatorExpression(UnaryOperatorType.Not, e));
				unary.ReplaceWith(binaryOperatorExpression.WithAnnotation(unary.GetAllILSpans()));
				return binaryOperatorExpression.AcceptVisitor(this, data);
			}
		}
		return base.VisitUnaryOperatorExpression(unary, data);
	}

	public override object VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression, object data)
	{
		if (binaryOperatorExpression.Annotation<LiftedOperator>() != null)
		{
			return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
		}
		BinaryOperatorType binaryOperatorType = binaryOperatorExpression.Operator;
		bool? flag = null;
		if (binaryOperatorExpression.Right is PrimitiveExpression)
		{
			flag = ((PrimitiveExpression)binaryOperatorExpression.Right).Value as bool?;
		}
		if ((binaryOperatorType == BinaryOperatorType.Equality && flag == true) || (binaryOperatorType == BinaryOperatorType.InEquality && flag == false))
		{
			List<ILSpan> allRecursiveILSpans = binaryOperatorExpression.GetAllRecursiveILSpans();
			binaryOperatorExpression.Left.AcceptVisitor(this, data);
			binaryOperatorExpression.ReplaceWith(binaryOperatorExpression.Left.WithAnnotation(allRecursiveILSpans));
			return null;
		}
		if ((binaryOperatorType == BinaryOperatorType.Equality && flag == false) || (binaryOperatorType == BinaryOperatorType.InEquality && flag == true))
		{
			Expression left = binaryOperatorExpression.Left;
			left.Remove();
			List<ILSpan> allRecursiveILSpans2 = binaryOperatorExpression.GetAllRecursiveILSpans();
			UnaryOperatorExpression unaryOperatorExpression = new UnaryOperatorExpression(UnaryOperatorType.Not, left);
			binaryOperatorExpression.ReplaceWith(unaryOperatorExpression);
			unaryOperatorExpression.AddAnnotation(allRecursiveILSpans2);
			return unaryOperatorExpression.AcceptVisitor(this, data);
		}
		bool flag2 = false;
		Match match = asCastIsNotNullPattern.Match(binaryOperatorExpression);
		if (!match.Success)
		{
			match = asCastIsNullPattern.Match(binaryOperatorExpression);
			flag2 = true;
		}
		if (match.Success)
		{
			Expression expression = match.Get<Expression>("expr").Single().Detach()
				.IsType(match.Get<AstType>("type").Single().Detach());
			if (flag2)
			{
				expression = new UnaryOperatorExpression(UnaryOperatorType.Not, expression);
			}
			binaryOperatorExpression.ReplaceWith(expression);
			expression.AddAnnotation(binaryOperatorExpression.GetAllRecursiveILSpans());
			return expression.AcceptVisitor(this, data);
		}
		return base.VisitBinaryOperatorExpression(binaryOperatorExpression, data);
	}

	void IAstTransform.Run(AstNode node)
	{
		node.AcceptVisitor(this, null);
	}
}
