#define DEBUG
using System.Diagnostics;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp;

internal struct ExpressionWithResolveResult
{
	public readonly Expression Expression;

	public readonly ResolveResult ResolveResult;

	public IType Type => ResolveResult.Type;

	internal ExpressionWithResolveResult(Expression expression)
	{
		Debug.Assert(expression != null);
		Expression = expression;
		ResolveResult = expression.Annotation<ResolveResult>() ?? ErrorResolveResult.UnknownError;
	}

	internal ExpressionWithResolveResult(Expression expression, ResolveResult resolveResult)
	{
		Debug.Assert(expression != null && resolveResult != null);
		Debug.Assert(expression.Annotation<ResolveResult>() == resolveResult);
		Expression = expression;
		ResolveResult = resolveResult;
	}

	public static implicit operator Expression(ExpressionWithResolveResult expression)
	{
		return expression.Expression;
	}
}
