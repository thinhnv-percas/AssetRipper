using System;
using DecompTools.Decompiler.CSharp.Syntax;

namespace DecompTools.Decompiler.IL;

internal static class ComparisonKindExtensions
{
	public static bool IsEqualityOrInequality(this ComparisonKind kind)
	{
		return kind == ComparisonKind.Equality || kind == ComparisonKind.Inequality;
	}

	public static ComparisonKind Negate(this ComparisonKind kind)
	{
		return kind switch
		{
			ComparisonKind.Equality => ComparisonKind.Inequality, 
			ComparisonKind.Inequality => ComparisonKind.Equality, 
			ComparisonKind.LessThan => ComparisonKind.GreaterThanOrEqual, 
			ComparisonKind.LessThanOrEqual => ComparisonKind.GreaterThan, 
			ComparisonKind.GreaterThan => ComparisonKind.LessThanOrEqual, 
			ComparisonKind.GreaterThanOrEqual => ComparisonKind.LessThan, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public static BinaryOperatorType ToBinaryOperatorType(this ComparisonKind kind)
	{
		return kind switch
		{
			ComparisonKind.Equality => BinaryOperatorType.Equality, 
			ComparisonKind.Inequality => BinaryOperatorType.InEquality, 
			ComparisonKind.LessThan => BinaryOperatorType.LessThan, 
			ComparisonKind.LessThanOrEqual => BinaryOperatorType.LessThanOrEqual, 
			ComparisonKind.GreaterThan => BinaryOperatorType.GreaterThan, 
			ComparisonKind.GreaterThanOrEqual => BinaryOperatorType.GreaterThanOrEqual, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public static string GetToken(this ComparisonKind kind)
	{
		return BinaryOperatorExpression.GetOperatorRole(kind.ToBinaryOperatorType()).Token;
	}
}
