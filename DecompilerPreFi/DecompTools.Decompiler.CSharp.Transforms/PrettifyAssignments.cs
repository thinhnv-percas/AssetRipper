using System;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Syntax.PatternMatching;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Transforms;

internal class PrettifyAssignments : DepthFirstAstVisitor, IAstTransform
{
	private TransformContext context;

	public override void VisitAssignmentExpression(AssignmentExpression assignment)
	{
		base.VisitAssignmentExpression(assignment);
		if (assignment.Right is BinaryOperatorExpression binaryOperatorExpression && assignment.Operator == AssignmentOperatorType.Assign && CanConvertToCompoundAssignment(assignment.Left) && assignment.Left.IsMatch(binaryOperatorExpression.Left))
		{
			assignment.Operator = GetAssignmentOperatorForBinaryOperator(binaryOperatorExpression.Operator);
			if (assignment.Operator != AssignmentOperatorType.Assign)
			{
				assignment.CopyAnnotationsFrom(binaryOperatorExpression);
				assignment.Right = binaryOperatorExpression.Right;
			}
		}
		if ((context.Settings.IntroduceIncrementAndDecrement && assignment.Operator == AssignmentOperatorType.Add) || assignment.Operator == AssignmentOperatorType.Subtract)
		{
			ResolveResult resolveResult = assignment.Right.GetResolveResult();
			if (resolveResult.IsCompileTimeConstant && resolveResult.Type.IsCSharpPrimitiveIntegerType() && CSharpPrimitiveCast.Cast(resolveResult.Type.GetTypeCode(), 1, checkForOverflow: false).Equals(resolveResult.ConstantValue) && assignment.Annotation<CallInstruction>() == null && assignment.Annotation<UserDefinedCompoundAssign>() == null && assignment.Annotation<DynamicCompoundAssign>() == null)
			{
				UnaryOperatorType op = ((!(assignment.Parent is ExpressionStatement)) ? ((assignment.Operator == AssignmentOperatorType.Add) ? UnaryOperatorType.Increment : UnaryOperatorType.Decrement) : ((assignment.Operator == AssignmentOperatorType.Add) ? UnaryOperatorType.PostIncrement : UnaryOperatorType.PostDecrement));
				assignment.ReplaceWith(new UnaryOperatorExpression(op, assignment.Left.Detach()).CopyAnnotationsFrom(assignment));
			}
		}
	}

	public static AssignmentOperatorType GetAssignmentOperatorForBinaryOperator(BinaryOperatorType bop)
	{
		return bop switch
		{
			BinaryOperatorType.Add => AssignmentOperatorType.Add, 
			BinaryOperatorType.Subtract => AssignmentOperatorType.Subtract, 
			BinaryOperatorType.Multiply => AssignmentOperatorType.Multiply, 
			BinaryOperatorType.Divide => AssignmentOperatorType.Divide, 
			BinaryOperatorType.Modulus => AssignmentOperatorType.Modulus, 
			BinaryOperatorType.ShiftLeft => AssignmentOperatorType.ShiftLeft, 
			BinaryOperatorType.ShiftRight => AssignmentOperatorType.ShiftRight, 
			BinaryOperatorType.BitwiseAnd => AssignmentOperatorType.BitwiseAnd, 
			BinaryOperatorType.BitwiseOr => AssignmentOperatorType.BitwiseOr, 
			BinaryOperatorType.ExclusiveOr => AssignmentOperatorType.ExclusiveOr, 
			_ => AssignmentOperatorType.Assign, 
		};
	}

	private static bool CanConvertToCompoundAssignment(Expression left)
	{
		if (left is MemberReferenceExpression memberReferenceExpression)
		{
			return IsWithoutSideEffects(memberReferenceExpression.Target);
		}
		if (left is IndexerExpression indexerExpression)
		{
			return IsWithoutSideEffects(indexerExpression.Target) && Enumerable.All<Expression>((IEnumerable<Expression>)indexerExpression.Arguments, (Func<Expression, bool>)IsWithoutSideEffects);
		}
		if (left is UnaryOperatorExpression { Operator: UnaryOperatorType.Dereference } unaryOperatorExpression)
		{
			return IsWithoutSideEffects(unaryOperatorExpression.Expression);
		}
		return IsWithoutSideEffects(left);
	}

	private static bool IsWithoutSideEffects(Expression left)
	{
		return left is ThisReferenceExpression || left is IdentifierExpression || left is TypeReferenceExpression || left is BaseReferenceExpression;
	}

	void IAstTransform.Run(AstNode node, TransformContext context)
	{
		this.context = context;
		try
		{
			node.AcceptVisitor(this);
		}
		finally
		{
			this.context = null;
		}
	}
}
