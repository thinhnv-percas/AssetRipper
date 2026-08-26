#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using ExpressionType = System.Linq.Expressions.ExpressionType;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Transforms;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp;

[DebuggerDisplay("{Expression} : {ResolveResult}")]
internal struct TranslatedExpression
{
	public readonly Expression Expression;

	public readonly ResolveResult ResolveResult;

	public IEnumerable<ILInstruction> ILInstructions => Enumerable.OfType<ILInstruction>((IEnumerable)Expression.Annotations);

	public IType Type => ResolveResult.Type;

	internal TranslatedExpression(Expression expression)
	{
		Debug.Assert(expression != null);
		Expression = expression;
		ResolveResult = expression.Annotation<ResolveResult>() ?? ErrorResolveResult.UnknownError;
	}

	internal TranslatedExpression(Expression expression, ResolveResult resolveResult)
	{
		Debug.Assert(expression != null && resolveResult != null);
		Debug.Assert(expression.Annotation<ResolveResult>() == resolveResult);
		ResolveResult = resolveResult;
		Expression = expression;
	}

	public static implicit operator Expression(TranslatedExpression expression)
	{
		return expression.Expression;
	}

	public static implicit operator ExpressionWithResolveResult(TranslatedExpression expression)
	{
		return new ExpressionWithResolveResult(expression.Expression, expression.ResolveResult);
	}

	public static implicit operator ExpressionWithILInstruction(TranslatedExpression expression)
	{
		return new ExpressionWithILInstruction(expression.Expression);
	}

	public TranslatedExpression UnwrapChild(Expression descendant)
	{
		if (descendant == Expression)
		{
			return this;
		}
		for (AstNode parent = descendant.Parent; parent != null; parent = parent.Parent)
		{
			foreach (ILInstruction item in Enumerable.OfType<ILInstruction>((IEnumerable)parent.Annotations))
			{
				descendant.AddAnnotation(item);
			}
			if (parent == Expression)
			{
				return new TranslatedExpression(descendant.Detach());
			}
		}
		throw new ArgumentException("descendant must be a descendant of the current node");
	}

	public TranslatedExpression ConvertTo(IType targetType, ExpressionBuilder expressionBuilder, bool checkForOverflow = false, bool allowImplicitConversion = false)
	{
		IType type = Type;
		if (type.Equals(targetType))
		{
			if (allowImplicitConversion)
			{
				ResolveResult resolveResult = ResolveResult;
				ResolveResult resolveResult2 = resolveResult;
				if (resolveResult2 != null)
				{
					if (!(resolveResult2 is ConversionResolveResult conversionResolveResult))
					{
						if (resolveResult2 is InvocationResolveResult invocationResolveResult)
						{
							InvocationResolveResult invocationResolveResult2 = invocationResolveResult;
							if (Expression is ObjectCreateExpression objectCreateExpression && objectCreateExpression.Arguments.Count == 1 && invocationResolveResult2.Type.IsKnownType(KnownTypeCode.NullableOfT))
							{
								return UnwrapChild(Enumerable.Single<Expression>((IEnumerable<Expression>)objectCreateExpression.Arguments));
							}
						}
					}
					else
					{
						ConversionResolveResult conversionResolveResult2 = conversionResolveResult;
						if (Expression is CastExpression castExpression && CastCanBeMadeImplicit(CSharpConversions.Get(expressionBuilder.compilation), conversionResolveResult2.Conversion, conversionResolveResult2.Input.Type, type, targetType))
						{
							return UnwrapChild(castExpression.Expression);
						}
						if (Expression is ObjectCreateExpression objectCreateExpression2 && conversionResolveResult2.Conversion.IsMethodGroupConversion && objectCreateExpression2.Arguments.Count == 1 && expressionBuilder.settings.UseImplicitMethodGroupConversion)
						{
							return UnwrapChild(Enumerable.Single<Expression>((IEnumerable<Expression>)objectCreateExpression2.Arguments));
						}
					}
				}
			}
			return this;
		}
		if (targetType.Kind == TypeKind.Unknown || targetType.Kind == TypeKind.Void || targetType.Kind == TypeKind.None)
		{
			return this;
		}
		if (Expression is TupleExpression tupleExpression && targetType is TupleType tupleType && tupleExpression.Elements.Count == tupleType.ElementTypes.Length)
		{
			TupleExpression tupleExpression2 = new TupleExpression();
			List<ResolveResult> list = new List<ResolveResult>();
			foreach (var item3 in tupleExpression.Elements.Zip(tupleType.ElementTypes))
			{
				Expression item = item3.Item1;
				IType item2 = item3.Item2;
				TranslatedExpression translatedExpression = new TranslatedExpression(item.Detach()).ConvertTo(item2, expressionBuilder, checkForOverflow, allowImplicitConversion);
				tupleExpression2.Elements.Add(translatedExpression.Expression);
				list.Add(translatedExpression.ResolveResult);
			}
			return tupleExpression2.WithILInstruction(ILInstructions).WithRR(new TupleResolveResult(expressionBuilder.compilation, list.ToImmutableArray(), default(ImmutableArray<string>), tupleType.GetDefinition()?.ParentModule));
		}
		ICompilation compilation = expressionBuilder.compilation;
		CSharpConversions cSharpConversions = CSharpConversions.Get(compilation);
		if (ResolveResult is ConversionResolveResult conversionResolveResult3 && Expression is CastExpression castExpression2 && CastCanBeMadeImplicit(cSharpConversions, conversionResolveResult3.Conversion, conversionResolveResult3.Input.Type, type, targetType))
		{
			TranslatedExpression result = UnwrapChild(castExpression2.Expression);
			if (allowImplicitConversion)
			{
				return result;
			}
			return result.ConvertTo(targetType, expressionBuilder, checkForOverflow, allowImplicitConversion);
		}
		if (Expression is UnaryOperatorExpression { Operator: UnaryOperatorType.NullConditional } unaryOperatorExpression && targetType.IsReferenceType == true)
		{
			return new UnaryOperatorExpression(UnaryOperatorType.NullConditional, UnwrapChild(unaryOperatorExpression.Expression).ConvertTo(targetType, expressionBuilder, checkForOverflow, allowImplicitConversion)).WithRR(new ResolveResult(targetType)).WithoutILInstruction();
		}
		bool flag = type.IsKnownType(KnownTypeCode.NullableOfT) && targetType.IsKnownType(KnownTypeCode.NullableOfT);
		IType type2 = (flag ? NullableType.GetUnderlyingType(type) : type);
		IType type3 = (flag ? NullableType.GetUnderlyingType(targetType) : targetType);
		if (type.IsKnownType(KnownTypeCode.Boolean) && targetType.GetStackType().IsIntegerType())
		{
			return new ConditionalExpression(Expression, LdcI4(compilation, 1).ConvertTo(targetType, expressionBuilder, checkForOverflow), LdcI4(compilation, 0).ConvertTo(targetType, expressionBuilder, checkForOverflow)).WithoutILInstruction().WithRR(new ResolveResult(targetType));
		}
		if (targetType.IsKnownType(KnownTypeCode.Boolean))
		{
			return ConvertTo(compilation.FindType(KnownTypeCode.Byte), expressionBuilder, checkForOverflow).ConvertToBoolean(expressionBuilder);
		}
		if (type.IsKnownType(KnownTypeCode.IntPtr))
		{
			if (!targetType.IsKnownType(KnownTypeCode.Int64) && (!checkForOverflow || !targetType.IsKnownType(KnownTypeCode.Int32)))
			{
				return ConvertTo(compilation.FindType(KnownTypeCode.Int64), expressionBuilder, checkForOverflow).ConvertTo(targetType, expressionBuilder, checkForOverflow);
			}
		}
		else if (type.IsKnownType(KnownTypeCode.UIntPtr) && !targetType.IsKnownType(KnownTypeCode.UInt64) && (!checkForOverflow || !targetType.IsKnownType(KnownTypeCode.UInt32)))
		{
			return ConvertTo(compilation.FindType(KnownTypeCode.UInt64), expressionBuilder, checkForOverflow).ConvertTo(targetType, expressionBuilder, checkForOverflow);
		}
		if (targetType.IsKnownType(KnownTypeCode.IntPtr))
		{
			if (!type.IsKnownType(KnownTypeCode.Int32))
			{
				if (checkForOverflow)
				{
					if (!type.IsKnownType(KnownTypeCode.Int64))
					{
						return ConvertTo(compilation.FindType(KnownTypeCode.Int64), expressionBuilder, checkForOverflow).ConvertTo(targetType, expressionBuilder, checkForOverflow);
					}
				}
				else if (type.Kind != TypeKind.Pointer)
				{
					return ConvertTo(new PointerType(compilation.FindType(KnownTypeCode.Void)), expressionBuilder, checkForOverflow).ConvertTo(targetType, expressionBuilder, checkForOverflow);
				}
			}
		}
		else if (targetType.IsKnownType(KnownTypeCode.UIntPtr) && !type.IsKnownType(KnownTypeCode.UInt32) && type.Kind != TypeKind.Pointer)
		{
			if (!checkForOverflow)
			{
				return ConvertTo(new PointerType(compilation.FindType(KnownTypeCode.Void)), expressionBuilder, checkForOverflow).ConvertTo(targetType, expressionBuilder, checkForOverflow);
			}
			if (!type.IsKnownType(KnownTypeCode.UInt64))
			{
				return ConvertTo(compilation.FindType(KnownTypeCode.UInt64), expressionBuilder, checkForOverflow).ConvertTo(targetType, expressionBuilder, checkForOverflow);
			}
		}
		if (targetType.Kind == TypeKind.Pointer && type.Kind == TypeKind.Enum)
		{
			return ConvertTo(type.GetEnumUnderlyingType(), expressionBuilder, checkForOverflow).ConvertTo(targetType, expressionBuilder, checkForOverflow);
		}
		if (targetType.Kind == TypeKind.Enum && type.Kind == TypeKind.Pointer)
		{
			return ConvertTo(targetType.GetEnumUnderlyingType(), expressionBuilder, checkForOverflow).ConvertTo(targetType, expressionBuilder, checkForOverflow);
		}
		if ((targetType.Kind == TypeKind.Pointer && type.IsKnownType(KnownTypeCode.Char)) || (targetType.IsKnownType(KnownTypeCode.Char) && type.Kind == TypeKind.Pointer))
		{
			return ConvertTo(compilation.FindType(KnownTypeCode.UInt16), expressionBuilder, checkForOverflow).ConvertTo(targetType, expressionBuilder, checkForOverflow);
		}
		if (targetType.Kind == TypeKind.Pointer && type.Kind == TypeKind.ByReference && Expression is DirectionExpression)
		{
			Expression expression = ((DirectionExpression)Expression).Expression.Detach();
			PointerType type4 = new PointerType(((ByReferenceType)type).ElementType);
			if (expression is UnaryOperatorExpression { Operator: UnaryOperatorType.Dereference } unaryOperatorExpression2)
			{
				return new TranslatedExpression(unaryOperatorExpression2).UnwrapChild(unaryOperatorExpression2.Expression).ConvertTo(targetType, expressionBuilder);
			}
			return new UnaryOperatorExpression(UnaryOperatorType.AddressOf, expression).WithILInstruction(ILInstructions).WithRR(new ResolveResult(type4)).ConvertTo(targetType, expressionBuilder);
		}
		if (targetType.Kind == TypeKind.ByReference)
		{
			IType elementType = ((ByReferenceType)targetType).ElementType;
			if (Expression is DirectionExpression directionExpression && Enumerable.Any<ILInstruction>(ILInstructions, (Func<ILInstruction, bool>)((ILInstruction i) => i.OpCode == OpCode.AddressOf)) && directionExpression.Expression.GetResolveResult()?.Type.GetStackType() == elementType.GetStackType())
			{
				TranslatedExpression translatedExpression2 = UnwrapChild(directionExpression.Expression).ConvertTo(elementType, expressionBuilder, checkForOverflow);
				return new DirectionExpression(FieldDirection.Ref, translatedExpression2).WithILInstruction(ILInstructions).WithRR(new ByReferenceResolveResult(translatedExpression2.ResolveResult, isOut: false));
			}
			TranslatedExpression translatedExpression3 = ConvertTo(new PointerType(elementType), expressionBuilder, checkForOverflow);
			Expression expression2;
			ResolveResult resolveResult3;
			if (translatedExpression3.Expression is UnaryOperatorExpression { Operator: UnaryOperatorType.AddressOf } unaryOperatorExpression3)
			{
				expression2 = translatedExpression3.UnwrapChild(unaryOperatorExpression3.Expression);
				resolveResult3 = expression2.GetResolveResult();
			}
			else
			{
				expression2 = new UnaryOperatorExpression(UnaryOperatorType.Dereference, translatedExpression3.Expression);
				resolveResult3 = new ResolveResult(elementType);
				expression2.AddAnnotation(resolveResult3);
			}
			return new DirectionExpression(FieldDirection.Ref, expression2).WithoutILInstruction().WithRR(new ByReferenceResolveResult(resolveResult3, isOut: false));
		}
		ResolveResult resolveResult4 = expressionBuilder.resolver.WithCheckForOverflow(checkForOverflow).ResolveCast(targetType, ResolveResult);
		if (resolveResult4.IsCompileTimeConstant && !resolveResult4.IsError)
		{
			return expressionBuilder.ConvertConstantValue(resolveResult4, allowImplicitConversion).WithILInstruction(ILInstructions);
		}
		if (targetType.Kind == TypeKind.Pointer && (0.Equals(ResolveResult.ConstantValue) || 0u.Equals(ResolveResult.ConstantValue)))
		{
			if (allowImplicitConversion)
			{
				return new NullReferenceExpression().WithILInstruction(ILInstructions).WithRR(new ConstantResolveResult(targetType, null));
			}
			return new CastExpression(expressionBuilder.ConvertType(targetType), new NullReferenceExpression()).WithILInstruction(ILInstructions).WithRR(new ConstantResolveResult(targetType, null));
		}
		if (allowImplicitConversion && cSharpConversions.ImplicitConversion(ResolveResult, targetType).IsValid)
		{
			return this;
		}
		CastExpression castExpression3 = new CastExpression(expressionBuilder.ConvertType(targetType), Expression);
		if (type3.GetStackType().IsIntegerType())
		{
			castExpression3.AddAnnotation(checkForOverflow ? AddCheckedBlocks.CheckedAnnotation : AddCheckedBlocks.UncheckedAnnotation);
		}
		return castExpression3.WithoutILInstruction().WithRR(resolveResult4);
	}

	private bool CastCanBeMadeImplicit(CSharpConversions conversions, Conversion conversion, IType inputType, IType oldTargetType, IType newTargetType)
	{
		if (!conversion.IsImplicit)
		{
			return false;
		}
		if (conversion.IsBoxingConversion)
		{
			return conversions.IsBoxingConversionOrInvolvingTypeParameter(inputType, newTargetType);
		}
		if (conversion.IsInterpolatedStringConversion)
		{
			return newTargetType.IsKnownType(KnownTypeCode.FormattableString) || newTargetType.IsKnownType(KnownTypeCode.IFormattable);
		}
		return oldTargetType.Equals(newTargetType);
	}

	private TranslatedExpression LdcI4(ICompilation compilation, int val)
	{
		return new PrimitiveExpression(val).WithoutILInstruction().WithRR(new ConstantResolveResult(compilation.FindType(KnownTypeCode.Int32), val));
	}

	public TranslatedExpression UnwrapImplicitBoolConversion(Func<IType, bool> typeFilter = null)
	{
		if (!Type.IsKnownType(KnownTypeCode.Boolean))
		{
			return this;
		}
		if (!(ResolveResult is ConversionResolveResult conversionResolveResult))
		{
			return this;
		}
		if (!conversionResolveResult.Conversion.IsUserDefined || !conversionResolveResult.Conversion.IsImplicit)
		{
			return this;
		}
		if (typeFilter != null && !typeFilter(conversionResolveResult.Input.Type))
		{
			return this;
		}
		if (Expression is CastExpression castExpression)
		{
			return UnwrapChild(castExpression.Expression);
		}
		return this;
	}

	public TranslatedExpression ConvertToBoolean(ExpressionBuilder expressionBuilder, bool negate = false)
	{
		if (Type.IsKnownType(KnownTypeCode.Boolean) || Type.Kind == TypeKind.Unknown)
		{
			if (negate)
			{
				return expressionBuilder.LogicNot(this).WithoutILInstruction();
			}
			return this;
		}
		Debug.Assert(Type.GetStackType().IsIntegerType());
		IType type = expressionBuilder.compilation.FindType(KnownTypeCode.Boolean);
		if (ResolveResult.IsCompileTimeConstant && ResolveResult.ConstantValue is int)
		{
			bool flag = (int)ResolveResult.ConstantValue != 0;
			flag ^= negate;
			return new PrimitiveExpression(flag).WithILInstruction(ILInstructions).WithRR(new ConstantResolveResult(type, flag));
		}
		if (ResolveResult.IsCompileTimeConstant && ResolveResult.ConstantValue is byte)
		{
			bool flag2 = (byte)ResolveResult.ConstantValue != 0;
			flag2 ^= negate;
			return new PrimitiveExpression(flag2).WithILInstruction(ILInstructions).WithRR(new ConstantResolveResult(type, flag2));
		}
		if (Type.Kind == TypeKind.Pointer)
		{
			TranslatedExpression translatedExpression = new NullReferenceExpression().WithoutILInstruction().WithRR(new ConstantResolveResult(SpecialType.NullType, null));
			BinaryOperatorType op = (negate ? BinaryOperatorType.Equality : BinaryOperatorType.InEquality);
			return new BinaryOperatorExpression(Expression, op, translatedExpression.Expression).WithoutILInstruction().WithRR(new OperatorResolveResult(type, (ExpressionType)35, ResolveResult, translatedExpression.ResolveResult));
		}
		TranslatedExpression translatedExpression2 = new PrimitiveExpression(0).WithoutILInstruction().WithRR(new ConstantResolveResult(expressionBuilder.compilation.FindType(KnownTypeCode.Int32), 0));
		BinaryOperatorType op2 = (negate ? BinaryOperatorType.Equality : BinaryOperatorType.InEquality);
		return new BinaryOperatorExpression(Expression, op2, translatedExpression2.Expression).WithoutILInstruction().WithRR(new OperatorResolveResult(type, (ExpressionType)35, ResolveResult, translatedExpression2.ResolveResult));
	}
}
