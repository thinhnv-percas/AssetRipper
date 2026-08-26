using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp;

public static class AnnotationExtensions
{
	internal static ExpressionWithILInstruction WithILInstruction(this Expression expression, ILInstruction instruction)
	{
		expression.AddAnnotation(instruction);
		return new ExpressionWithILInstruction(expression);
	}

	internal static ExpressionWithILInstruction WithILInstruction(this Expression expression, IEnumerable<ILInstruction> instructions)
	{
		foreach (ILInstruction instruction in instructions)
		{
			expression.AddAnnotation(instruction);
		}
		return new ExpressionWithILInstruction(expression);
	}

	internal static ExpressionWithILInstruction WithoutILInstruction(this Expression expression)
	{
		return new ExpressionWithILInstruction(expression);
	}

	internal static TranslatedExpression WithILInstruction(this ExpressionWithResolveResult expression, ILInstruction instruction)
	{
		expression.Expression.AddAnnotation(instruction);
		return new TranslatedExpression(expression.Expression, expression.ResolveResult);
	}

	internal static TranslatedExpression WithILInstruction(this ExpressionWithResolveResult expression, IEnumerable<ILInstruction> instructions)
	{
		foreach (ILInstruction instruction in instructions)
		{
			expression.Expression.AddAnnotation(instruction);
		}
		return new TranslatedExpression(expression.Expression, expression.ResolveResult);
	}

	internal static TranslatedExpression WithILInstruction(this TranslatedExpression expression, ILInstruction instruction)
	{
		expression.Expression.AddAnnotation(instruction);
		return expression;
	}

	internal static TranslatedExpression WithoutILInstruction(this ExpressionWithResolveResult expression)
	{
		return new TranslatedExpression(expression.Expression, expression.ResolveResult);
	}

	internal static ExpressionWithResolveResult WithRR(this Expression expression, ResolveResult resolveResult)
	{
		expression.AddAnnotation(resolveResult);
		return new ExpressionWithResolveResult(expression, resolveResult);
	}

	internal static TranslatedExpression WithRR(this ExpressionWithILInstruction expression, ResolveResult resolveResult)
	{
		expression.Expression.AddAnnotation(resolveResult);
		return new TranslatedExpression(expression, resolveResult);
	}

	public static ISymbol GetSymbol(this AstNode node)
	{
		return node.Annotation<ResolveResult>()?.GetSymbol();
	}

	public static ResolveResult GetResolveResult(this AstNode node)
	{
		return node.Annotation<ResolveResult>() ?? ErrorResolveResult.UnknownError;
	}

	public static ILVariable GetILVariable(this IdentifierExpression expr)
	{
		if (!(expr.Annotation<ResolveResult>() is ILVariableResolveResult { Variable: var variable }))
		{
			return null;
		}
		return variable;
	}

	public static ILVariable GetILVariable(this VariableInitializer vi)
	{
		if (!(vi.Annotation<ResolveResult>() is ILVariableResolveResult { Variable: var variable }))
		{
			return null;
		}
		return variable;
	}

	public static ILVariable GetILVariable(this ForeachStatement loop)
	{
		if (!(loop.Annotation<ResolveResult>() is ILVariableResolveResult { Variable: var variable }))
		{
			return null;
		}
		return variable;
	}

	public static VariableInitializer WithILVariable(this VariableInitializer vi, ILVariable v)
	{
		vi.AddAnnotation(new ILVariableResolveResult(v, v.Type));
		return vi;
	}

	public static ForeachStatement WithILVariable(this ForeachStatement loop, ILVariable v)
	{
		loop.AddAnnotation(new ILVariableResolveResult(v, v.Type));
		return loop;
	}

	public static T CopyAnnotationsFrom<T>(this T node, AstNode other) where T : AstNode
	{
		foreach (object annotation in other.Annotations)
		{
			node.AddAnnotation(annotation);
		}
		return node;
	}

	public static T CopyInstructionsFrom<T>(this T node, AstNode other) where T : AstNode
	{
		foreach (ILInstruction item in Enumerable.OfType<ILInstruction>((IEnumerable)other.Annotations))
		{
			node.AddAnnotation(item);
		}
		return node;
	}
}
