#define DEBUG
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.IL;

namespace DecompTools.Decompiler.CSharp;

internal struct ExpressionWithILInstruction
{
	public readonly Expression Expression;

	public IEnumerable<ILInstruction> ILInstructions => Enumerable.OfType<ILInstruction>((IEnumerable)Expression.Annotations);

	internal ExpressionWithILInstruction(Expression expression)
	{
		Debug.Assert(expression != null);
		Expression = expression;
	}

	public static implicit operator Expression(ExpressionWithILInstruction expression)
	{
		return expression.Expression;
	}
}
