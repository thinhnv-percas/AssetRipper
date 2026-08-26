#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ExpressionType = System.Linq.Expressions.ExpressionType;
using System.Threading;
using DecompTools.Decompiler.CSharp.Resolver;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.Transforms;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.IL.Transforms;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp;

internal class ExpressionBuilder : ILVisitor<TranslationContext, TranslatedExpression>
{
	private class ArrayInitializer
	{
		public ArrayInitializerExpression Expression;

		public int CurrentElementCount;

		public ArrayInitializer(ArrayInitializerExpression expression)
		{
			Expression = expression;
			CurrentElementCount = 0;
		}
	}

	private readonly IDecompilerTypeSystem typeSystem;

	private readonly ITypeResolveContext decompilationContext;

	internal readonly ILFunction currentFunction;

	internal readonly ICompilation compilation;

	internal readonly CSharpResolver resolver;

	private readonly TypeSystemAstBuilder astBuilder;

	internal readonly TypeInference typeInference;

	internal readonly DecompilerSettings settings;

	private readonly CancellationToken cancellationToken;

	private readonly HashSet<ILVariable> loadedVariablesSet = new HashSet<ILVariable>();

	public ExpressionBuilder(IDecompilerTypeSystem typeSystem, ITypeResolveContext decompilationContext, ILFunction currentFunction, DecompilerSettings settings, CancellationToken cancellationToken)
	{
		Debug.Assert(decompilationContext != null);
		this.typeSystem = typeSystem;
		this.decompilationContext = decompilationContext;
		this.currentFunction = currentFunction;
		this.settings = settings;
		this.cancellationToken = cancellationToken;
		compilation = decompilationContext.Compilation;
		resolver = new CSharpResolver(new CSharpTypeResolveContext(compilation.MainModule, null, decompilationContext.CurrentTypeDefinition, decompilationContext.CurrentMember));
		astBuilder = new TypeSystemAstBuilder(resolver);
		astBuilder.AlwaysUseShortTypeNames = true;
		astBuilder.AddResolveResultAnnotations = true;
		typeInference = new TypeInference(compilation)
		{
			Algorithm = TypeInferenceAlgorithm.Improved
		};
	}

	public AstType ConvertType(IType type)
	{
		AstType astType = astBuilder.ConvertType(type);
		Debug.Assert(astType.Annotation<TypeResolveResult>() != null);
		return astType;
	}

	public ExpressionWithResolveResult ConvertConstantValue(ResolveResult rr, bool allowImplicitConversion = false)
	{
		Expression expression = astBuilder.ConvertConstantValue(rr);
		if (!allowImplicitConversion)
		{
			if (expression is NullReferenceExpression && rr.Type.Kind != TypeKind.Null)
			{
				expression = new CastExpression(ConvertType(rr.Type), expression);
			}
			else
			{
				KnownTypeCode? knownTypeCode = rr.Type.GetDefinition()?.KnownTypeCode;
				KnownTypeCode? knownTypeCode2 = knownTypeCode;
				if (knownTypeCode2.HasValue)
				{
					KnownTypeCode valueOrDefault = knownTypeCode2.GetValueOrDefault();
					if ((uint)(valueOrDefault - 5) <= 3u)
					{
						expression = new CastExpression(new DecompTools.Decompiler.CSharp.Syntax.PrimitiveType(KnownTypeReference.GetCSharpNameByTypeCode(rr.Type.GetDefinition().KnownTypeCode)), expression);
					}
				}
			}
		}
		ResolveResult resolveResult = expression.Annotation<ResolveResult>();
		if (resolveResult == null)
		{
			resolveResult = rr;
			expression.AddAnnotation(rr);
		}
		return new ExpressionWithResolveResult(expression, resolveResult);
	}

	public TranslatedExpression Translate(ILInstruction inst, IType typeHint = null)
	{
		Debug.Assert(inst != null);
		CancellationToken cancellationToken = this.cancellationToken;
		cancellationToken.ThrowIfCancellationRequested();
		TranslationContext context = new TranslationContext
		{
			TypeHint = (typeHint ?? SpecialType.UnknownType)
		};
		TranslatedExpression result = inst.AcceptVisitor(this, context);
		if (inst.ResultType != StackType.Void && result.Type.Kind != TypeKind.Unknown && inst.ResultType != StackType.Unknown)
		{
			if (inst.ResultType.IsIntegerType())
			{
				Debug.Assert(result.Type.GetStackType().IsIntegerType(), "IL instructions of integer type must convert into C# expressions of integer type");
				Debug.Assert(result.Type.GetSign() != Sign.None, "Must have a sign specified for zero/sign-extension");
			}
			else if (inst is ILiftableInstruction { IsLifted: not false } liftableInstruction)
			{
				Debug.Assert(NullableType.IsNullable(result.Type));
				IType underlyingType = NullableType.GetUnderlyingType(result.Type);
				if (liftableInstruction.UnderlyingResultType.IsIntegerType())
				{
					Debug.Assert(underlyingType.GetStackType().IsIntegerType(), "IL instructions of integer type must convert into C# expressions of integer type");
					Debug.Assert(underlyingType.GetSign() != Sign.None, "Must have a sign specified for zero/sign-extension");
				}
				else
				{
					Debug.Assert(underlyingType.GetStackType() == liftableInstruction.UnderlyingResultType);
				}
			}
			else if (inst.ResultType == StackType.Ref)
			{
				Debug.Assert(result.Type.GetStackType() == StackType.Ref || result.Type.GetStackType().IsIntegerType());
			}
			else
			{
				Debug.Assert(result.Type.GetStackType() == inst.ResultType);
			}
		}
		return result;
	}

	public TranslatedExpression TranslateCondition(ILInstruction condition, bool negate = false)
	{
		return Translate(condition, compilation.FindType(KnownTypeCode.Boolean)).ConvertToBoolean(this, negate);
	}

	internal ExpressionWithResolveResult ConvertVariable(ILVariable variable)
	{
		Expression expression = ((variable.Kind != VariableKind.Parameter || !(variable.Index < 0)) ? ((Expression)new IdentifierExpression(variable.Name)) : ((Expression)new ThisReferenceExpression()));
		if (variable.Type.Kind == TypeKind.ByReference)
		{
			IType elementType = ((ByReferenceType)variable.Type).ElementType;
			expression.WithRR(new ILVariableResolveResult(variable, elementType));
			expression = new DirectionExpression(FieldDirection.Ref, expression);
			return expression.WithRR(new ByReferenceResolveResult(elementType, isOut: false));
		}
		return expression.WithRR(new ILVariableResolveResult(variable, variable.Type));
	}

	internal bool HidesVariableWithName(string name)
	{
		return Enumerable.Any<ILVariable>(Enumerable.SelectMany<ILFunction, ILVariable>(Enumerable.OfType<ILFunction>((IEnumerable)currentFunction.Ancestors), (Func<ILFunction, IEnumerable<ILVariable>>)((ILFunction f) => f.Variables)), (Func<ILVariable, bool>)((ILVariable v) => v.Name == name));
	}

	private bool RequiresQualifier(IMember member, TranslatedExpression target)
	{
		if (HidesVariableWithName(member.Name))
		{
			return true;
		}
		if (member.IsStatic)
		{
			return !IsCurrentOrContainingType(member.DeclaringTypeDefinition);
		}
		return !(target.Expression is ThisReferenceExpression) && !(target.Expression is BaseReferenceExpression);
	}

	private ExpressionWithResolveResult ConvertField(IField field, ILInstruction targetInstruction = null)
	{
		TranslatedExpression target = TranslateTarget(targetInstruction, nonVirtualInvocation: true, field.IsStatic, field.DeclaringType);
		bool flag = ((!settings.AutomaticProperties || !PatternStatementTransform.IsBackingFieldOfAutomaticProperty(field, out var property)) ? RequiresQualifier(field, target) : RequiresQualifier(property, target));
		bool flag2 = false;
		ResolveResult targetResolveResult = (flag ? target.ResolveResult : null);
		while (!IsUnambiguousAccess())
		{
			if (!flag)
			{
				flag = true;
				targetResolveResult = target.ResolveResult;
				continue;
			}
			if (!flag2)
			{
				flag2 = true;
				target = target.ConvertTo(field.DeclaringType, this);
				targetResolveResult = target.ResolveResult;
				continue;
			}
			break;
		}
		if (flag)
		{
			return new MemberReferenceExpression(target, field.Name).WithRR(new MemberResolveResult(target.ResolveResult, field));
		}
		return new IdentifierExpression(field.Name).WithRR(new MemberResolveResult(target.ResolveResult, field));
		bool IsUnambiguousAccess()
		{
			if (targetResolveResult == null)
			{
				return resolver.ResolveSimpleName(field.Name, EmptyList<IType>.Instance) is MemberResolveResult { IsError: false } memberResolveResult && memberResolveResult.Member.Equals(field, NormalizeTypeVisitor.TypeErasure);
			}
			MemberLookup memberLookup = new MemberLookup(resolver.CurrentTypeDefinition, resolver.CurrentTypeDefinition.ParentModule);
			return memberLookup.Lookup(target.ResolveResult, field.Name, EmptyList<IType>.Instance, isInvocation: false) is MemberResolveResult { IsError: false } memberResolveResult2 && memberResolveResult2.Member.Equals(field, NormalizeTypeVisitor.TypeErasure);
		}
	}

	private TranslatedExpression IsType(IsInst inst)
	{
		TranslatedExpression arg = Translate(inst.Argument);
		arg = UnwrapBoxingConversion(arg);
		return new IsExpression(arg.Expression, ConvertType(inst.Type)).WithILInstruction(inst).WithRR(new TypeIsResolveResult(arg.ResolveResult, inst.Type, compilation.FindType(TypeCode.Boolean)));
	}

	protected internal override TranslatedExpression VisitIsInst(IsInst inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Argument);
		if (inst.Type.IsReferenceType == false)
		{
			if (SemanticHelper.IsPure(inst.Argument.Flags))
			{
				return new ConditionalExpression(new IsExpression(translatedExpression, ConvertType(inst.Type)).WithILInstruction(inst), translatedExpression.Expression.Clone(), new NullReferenceExpression()).WithoutILInstruction().WithRR(new ResolveResult(translatedExpression.Type));
			}
			return ErrorExpression("isinst with value type is only supported in some contexts");
		}
		translatedExpression = UnwrapBoxingConversion(translatedExpression);
		return new AsExpression(translatedExpression.Expression, ConvertType(inst.Type)).WithILInstruction(inst).WithRR(new ConversionResolveResult(inst.Type, translatedExpression.ResolveResult, Conversion.TryCast));
	}

	internal static TranslatedExpression UnwrapBoxingConversion(TranslatedExpression arg)
	{
		if (arg.Expression is CastExpression castExpression && arg.Type.IsKnownType(KnownTypeCode.Object) && arg.ResolveResult is ConversionResolveResult conversionResolveResult && conversionResolveResult.Conversion.IsBoxingConversion)
		{
			arg = arg.UnwrapChild(castExpression.Expression);
		}
		return arg;
	}

	protected internal override TranslatedExpression VisitNewObj(NewObj inst, TranslationContext context)
	{
		IType declaringType = inst.Method.DeclaringType;
		if ((declaringType.IsKnownType(KnownTypeCode.SpanOfT) || declaringType.IsKnownType(KnownTypeCode.ReadOnlySpanOfT)) && inst.Arguments.Count == 2 && inst.Arguments[0] is Block { Kind: BlockKind.StackAllocInitializer } block)
		{
			return TranslateStackAllocInitializer(block, declaringType.TypeArguments[0]);
		}
		return new CallBuilder(this, typeSystem, settings).Build(inst);
	}

	protected internal override TranslatedExpression VisitNewArr(NewArr inst, TranslationContext context)
	{
		int count = inst.Indices.Count;
		TranslatedExpression[] array = Enumerable.ToArray<TranslatedExpression>(Enumerable.Select<ILInstruction, TranslatedExpression>((IEnumerable<ILInstruction>)inst.Indices, (Func<ILInstruction, TranslatedExpression>)((ILInstruction arg) => TranslateArrayIndex(arg))));
		ArrayCreateExpression arrayCreateExpression = new ArrayCreateExpression
		{
			Type = ConvertType(inst.Type)
		};
		if (arrayCreateExpression.Type is ComposedType composedType)
		{
			composedType.ArraySpecifiers.MoveTo(arrayCreateExpression.AdditionalArraySpecifiers);
		}
		arrayCreateExpression.Arguments.AddRange(Enumerable.Select<TranslatedExpression, Expression>((IEnumerable<TranslatedExpression>)array, (Func<TranslatedExpression, Expression>)((TranslatedExpression arg) => arg.Expression)));
		return arrayCreateExpression.WithILInstruction(inst).WithRR(new ArrayCreateResolveResult(new ArrayType(compilation, inst.Type, count), Enumerable.ToList<ResolveResult>(Enumerable.Select<TranslatedExpression, ResolveResult>((IEnumerable<TranslatedExpression>)array, (Func<TranslatedExpression, ResolveResult>)((TranslatedExpression a) => a.ResolveResult))), new ResolveResult[0]));
	}

	protected internal override TranslatedExpression VisitLocAlloc(LocAlloc inst, TranslationContext context)
	{
		IType elementType;
		return TranslateLocAlloc(inst, context.TypeHint, out elementType).WithILInstruction(inst).WithRR(new ResolveResult(new PointerType(elementType)));
	}

	protected internal override TranslatedExpression VisitLocAllocSpan(LocAllocSpan inst, TranslationContext context)
	{
		IType elementType;
		return TranslateLocAllocSpan(inst, context.TypeHint, out elementType).WithILInstruction(inst).WithRR(new ResolveResult(inst.Type));
	}

	private StackAllocExpression TranslateLocAllocSpan(LocAllocSpan inst, IType typeHint, out IType elementType)
	{
		elementType = inst.Type.TypeArguments[0];
		PointerType pointerType = new PointerType(elementType);
		TranslatedExpression translatedExpression = Translate(inst.Argument).ConvertTo(compilation.FindType(KnownTypeCode.Int32), this);
		return new StackAllocExpression
		{
			Type = ConvertType(elementType),
			CountExpression = translatedExpression
		};
	}

	private StackAllocExpression TranslateLocAlloc(LocAlloc inst, IType typeHint, out IType elementType)
	{
		TranslatedExpression translatedExpression;
		if (inst.Argument.MatchBinaryNumericInstruction(BinaryNumericOperator.Mul, out var left, out var right) && right.UnwrapConv(ConversionKind.SignExtend).UnwrapConv(ConversionKind.ZeroExtend).MatchSizeOf(out elementType))
		{
			translatedExpression = Translate(left.UnwrapConv(ConversionKind.ZeroExtend));
			PointerType pointerType = new PointerType(elementType);
		}
		else
		{
			if (typeHint is PointerType pointerType2)
			{
				TranslatedExpression? pointerArithmeticOffset = GetPointerArithmeticOffset(inst.Argument, Translate(inst.Argument), pointerType2, checkForOverflow: true, unwrapZeroExtension: true);
				TranslatedExpression valueOrDefault = pointerArithmeticOffset.GetValueOrDefault();
				if (pointerArithmeticOffset.HasValue)
				{
					translatedExpression = valueOrDefault;
					elementType = pointerType2.ElementType;
					goto IL_00c2;
				}
			}
			elementType = compilation.FindType(KnownTypeCode.Byte);
			PointerType pointerType = new PointerType(elementType);
			translatedExpression = Translate(inst.Argument);
		}
		goto IL_00c2;
		IL_00c2:
		translatedExpression = translatedExpression.ConvertTo(compilation.FindType(KnownTypeCode.Int32), this);
		return new StackAllocExpression
		{
			Type = ConvertType(elementType),
			CountExpression = translatedExpression
		};
	}

	protected internal override TranslatedExpression VisitLdcI4(LdcI4 inst, TranslationContext context)
	{
		ResolveResult rr = ((context.TypeHint.GetSign() != Sign.Unsigned) ? new ConstantResolveResult(compilation.FindType(KnownTypeCode.Int32), inst.Value) : new ConstantResolveResult(compilation.FindType(KnownTypeCode.UInt32), (uint)inst.Value));
		rr = AdjustConstantToType(rr, context.TypeHint);
		astBuilder.PrintIntegralValuesAsHex = ShouldDisplayAsHex(inst.Value, inst.Parent);
		try
		{
			return ConvertConstantValue(rr, allowImplicitConversion: true).WithILInstruction(inst);
		}
		finally
		{
			astBuilder.PrintIntegralValuesAsHex = false;
		}
	}

	protected internal override TranslatedExpression VisitLdcI8(LdcI8 inst, TranslationContext context)
	{
		ResolveResult rr = ((context.TypeHint.GetSign() != Sign.Unsigned) ? new ConstantResolveResult(compilation.FindType(KnownTypeCode.Int64), inst.Value) : new ConstantResolveResult(compilation.FindType(KnownTypeCode.UInt64), (ulong)inst.Value));
		rr = AdjustConstantToType(rr, context.TypeHint);
		astBuilder.PrintIntegralValuesAsHex = ShouldDisplayAsHex(inst.Value, inst.Parent);
		try
		{
			return ConvertConstantValue(rr, allowImplicitConversion: true).WithILInstruction(inst);
		}
		finally
		{
			astBuilder.PrintIntegralValuesAsHex = false;
		}
	}

	private bool ShouldDisplayAsHex(long value, ILInstruction parent)
	{
		if (parent is Conv conv)
		{
			parent = conv.Parent;
		}
		if (value <= 9)
		{
			return false;
		}
		ILInstruction iLInstruction = parent;
		ILInstruction iLInstruction2 = iLInstruction;
		if (iLInstruction2 != null && iLInstruction2 is BinaryNumericInstruction binaryNumericInstruction)
		{
			BinaryNumericInstruction binaryNumericInstruction2 = binaryNumericInstruction;
			if (binaryNumericInstruction2.Operator == BinaryNumericOperator.BitAnd || binaryNumericInstruction2.Operator == BinaryNumericOperator.BitOr || binaryNumericInstruction2.Operator == BinaryNumericOperator.BitXor)
			{
				return true;
			}
		}
		return false;
	}

	protected internal override TranslatedExpression VisitLdcF4(LdcF4 inst, TranslationContext context)
	{
		Expression expression = astBuilder.ConvertConstantValue(compilation.FindType(KnownTypeCode.Single), inst.Value);
		return new TranslatedExpression(expression.WithILInstruction(inst));
	}

	protected internal override TranslatedExpression VisitLdcF8(LdcF8 inst, TranslationContext context)
	{
		Expression expression = astBuilder.ConvertConstantValue(compilation.FindType(KnownTypeCode.Double), inst.Value);
		return new TranslatedExpression(expression.WithILInstruction(inst));
	}

	protected internal override TranslatedExpression VisitLdcDecimal(LdcDecimal inst, TranslationContext context)
	{
		Expression expression = astBuilder.ConvertConstantValue(compilation.FindType(KnownTypeCode.Decimal), inst.Value);
		return new TranslatedExpression(expression.WithILInstruction(inst));
	}

	protected internal override TranslatedExpression VisitLdStr(LdStr inst, TranslationContext context)
	{
		return new PrimitiveExpression(inst.Value).WithILInstruction(inst).WithRR(new ConstantResolveResult(compilation.FindType(KnownTypeCode.String), inst.Value));
	}

	protected internal override TranslatedExpression VisitLdNull(LdNull inst, TranslationContext context)
	{
		return GetDefaultValueExpression(SpecialType.NullType).WithILInstruction(inst);
	}

	protected internal override TranslatedExpression VisitDefaultValue(DefaultValue inst, TranslationContext context)
	{
		return GetDefaultValueExpression(inst.Type).WithILInstruction(inst);
	}

	internal ExpressionWithResolveResult GetDefaultValueExpression(IType type)
	{
		Expression expression;
		IType type2;
		if (type.IsReferenceType == true || type.IsKnownType(KnownTypeCode.NullableOfT))
		{
			expression = new NullReferenceExpression();
			type2 = SpecialType.NullType;
		}
		else
		{
			expression = new DefaultValueExpression(ConvertType(type));
			type2 = type;
		}
		return expression.WithRR(new ConstantResolveResult(type2, null));
	}

	protected internal override TranslatedExpression VisitSizeOf(SizeOf inst, TranslationContext context)
	{
		return new SizeOfExpression(ConvertType(inst.Type)).WithILInstruction(inst).WithRR(new SizeOfResolveResult(compilation.FindType(KnownTypeCode.Int32), inst.Type, null));
	}

	protected internal override TranslatedExpression VisitLdTypeToken(LdTypeToken inst, TranslationContext context)
	{
		return new MemberReferenceExpression(new TypeOfExpression(ConvertType(inst.Type)), "TypeHandle").WithILInstruction(inst).WithRR(new TypeOfResolveResult(compilation.FindType(new TopLevelTypeName("System", "RuntimeTypeHandle")), inst.Type));
	}

	protected internal override TranslatedExpression VisitBitNot(BitNot inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Argument);
		IType underlyingType = NullableType.GetUnderlyingType(translatedExpression.Type);
		if (underlyingType.GetStackType().GetSize() < inst.UnderlyingResultType.GetSize() || (underlyingType.Kind == TypeKind.Enum && underlyingType.IsSmallIntegerType()) || underlyingType.GetStackType() == StackType.I || underlyingType.IsKnownType(KnownTypeCode.Boolean) || underlyingType.IsKnownType(KnownTypeCode.Char))
		{
			StackType stackType = inst.UnderlyingResultType;
			if (stackType == StackType.I)
			{
				stackType = StackType.I8;
			}
			IType type = compilation.FindType(stackType.ToKnownTypeCode(underlyingType.GetSign()));
			if (inst.IsLifted)
			{
				type = NullableType.Create(compilation, type);
			}
			translatedExpression = translatedExpression.ConvertTo(type, this);
		}
		return new UnaryOperatorExpression(UnaryOperatorType.BitNot, translatedExpression).WithRR(resolver.ResolveUnaryOperator(UnaryOperatorType.BitNot, translatedExpression.ResolveResult)).WithILInstruction(inst);
	}

	internal ExpressionWithResolveResult LogicNot(TranslatedExpression expr)
	{
		expr = expr.UnwrapImplicitBoolConversion((IType type) => !Enumerable.Any<IMethod>(type.GetMethods((IMethod m) => m.IsOperator && m.Name == "op_LogicalNot")));
		return new UnaryOperatorExpression(UnaryOperatorType.Not, expr.Expression).WithRR(new OperatorResolveResult(compilation.FindType(KnownTypeCode.Boolean), (ExpressionType)34, expr.ResolveResult));
	}

	protected internal override TranslatedExpression VisitLdLoc(LdLoc inst, TranslationContext context)
	{
		if (inst.Variable.Kind == VariableKind.StackSlot && inst.Variable.IsSingleDefinition)
		{
			loadedVariablesSet.Add(inst.Variable);
		}
		return ConvertVariable(inst.Variable).WithILInstruction(inst);
	}

	protected internal override TranslatedExpression VisitLdLoca(LdLoca inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = ConvertVariable(inst.Variable).WithILInstruction(inst);
		return new DirectionExpression(FieldDirection.Ref, translatedExpression.Expression).WithoutILInstruction().WithRR(new ByReferenceResolveResult(translatedExpression.ResolveResult, isOut: false));
	}

	protected internal override TranslatedExpression VisitStLoc(StLoc inst, TranslationContext context)
	{
		TranslatedExpression right = Translate(inst.Value, inst.Variable.Type);
		if (inst.Variable.Kind == VariableKind.StackSlot && !loadedVariablesSet.Contains(inst.Variable))
		{
			IType type;
			if ((inst.Variable.IsSingleDefinition || IsOtherValueType(right.Type) || inst.Variable.StackType == StackType.Ref) && inst.Variable.StackType == right.Type.GetStackType() && right.Type.Kind != TypeKind.Null)
			{
				inst.Variable.Type = right.Type;
			}
			else if (inst.Value.MatchDefaultValue(out type) && IsOtherValueType(type))
			{
				inst.Variable.Type = type;
			}
		}
		TranslatedExpression left = ConvertVariable(inst.Variable).WithoutILInstruction();
		if (left.Expression is DirectionExpression directionExpression && left.ResolveResult is ByReferenceResolveResult byReferenceResolveResult)
		{
			left = left.UnwrapChild(directionExpression.Expression);
			ExpressionWithResolveResult expressionWithResolveResult = new AssignmentExpression(left.Expression, right.Expression).WithRR(new OperatorResolveResult(left.Type, (ExpressionType)46, byReferenceResolveResult, right.ResolveResult));
			return new DirectionExpression(FieldDirection.Ref, expressionWithResolveResult).WithoutILInstruction().WithRR(byReferenceResolveResult);
		}
		return Assignment(left, right).WithILInstruction(inst);
		static bool IsOtherValueType(IType type2)
		{
			return type2.IsReferenceType == false && type2.GetStackType() == StackType.O;
		}
	}

	protected internal override TranslatedExpression VisitComp(Comp inst, TranslationContext context)
	{
		if (inst.LiftingKind == ComparisonLiftingKind.ThreeValuedLogic)
		{
			if (inst.Kind == ComparisonKind.Equality && inst.Right.MatchLdcI4(0))
			{
				IType type = NullableType.Create(compilation, compilation.FindType(KnownTypeCode.Boolean));
				TranslatedExpression translatedExpression = Translate(inst.Left, type).ConvertTo(type, this);
				return new UnaryOperatorExpression(UnaryOperatorType.Not, translatedExpression.Expression).WithRR(new OperatorResolveResult(type, (ExpressionType)34, translatedExpression.ResolveResult)).WithILInstruction(inst);
			}
			return ErrorExpression("Nullable comparisons with three-valued-logic not supported in C#");
		}
		if (inst.Kind.IsEqualityOrInequality())
		{
			TranslatedExpression translatedExpression2 = TranslateCeq(inst, out var negateOutput);
			if (negateOutput)
			{
				return LogicNot(translatedExpression2).WithILInstruction(inst);
			}
			return translatedExpression2;
		}
		return TranslateComp(inst);
	}

	private TranslatedExpression TranslateCeq(Comp inst, out bool negateOutput)
	{
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		Debug.Assert(inst.Kind.IsEqualityOrInequality());
		if (inst.Left.OpCode == OpCode.IsInst && inst.Right.OpCode == OpCode.LdNull)
		{
			negateOutput = inst.Kind == ComparisonKind.Equality;
			return IsType((IsInst)inst.Left);
		}
		if (inst.Right.OpCode == OpCode.IsInst && inst.Left.OpCode == OpCode.LdNull)
		{
			negateOutput = inst.Kind == ComparisonKind.Equality;
			return IsType((IsInst)inst.Right);
		}
		TranslatedExpression translatedExpression = Translate(inst.Left);
		TranslatedExpression translatedExpression2 = Translate(inst.Right);
		if (translatedExpression.Type.IsKnownType(KnownTypeCode.Boolean))
		{
			if (inst.Right.MatchLdcI4(0))
			{
				negateOutput = inst.Kind == ComparisonKind.Equality;
				return translatedExpression;
			}
			if (inst.Right.MatchLdcI4(1))
			{
				negateOutput = inst.Kind == ComparisonKind.Inequality;
				return translatedExpression;
			}
		}
		else if (translatedExpression2.Type.IsKnownType(KnownTypeCode.Boolean))
		{
			if (inst.Left.MatchLdcI4(0))
			{
				negateOutput = inst.Kind == ComparisonKind.Equality;
				return translatedExpression2;
			}
			if (inst.Left.MatchLdcI4(1))
			{
				negateOutput = inst.Kind == ComparisonKind.Inequality;
				return translatedExpression2;
			}
		}
		if (translatedExpression.Type.Kind == TypeKind.Pointer && inst.Right.MatchLdcI(0L))
		{
			negateOutput = false;
			translatedExpression2 = new NullReferenceExpression().WithRR(new ConstantResolveResult(SpecialType.NullType, null)).WithILInstruction(inst.Right);
			return CreateBuiltinBinaryOperator(translatedExpression, inst.Kind.ToBinaryOperatorType(), translatedExpression2).WithILInstruction(inst);
		}
		if (translatedExpression2.Type.Kind == TypeKind.Pointer && inst.Left.MatchLdcI(0L))
		{
			negateOutput = false;
			translatedExpression = new NullReferenceExpression().WithRR(new ConstantResolveResult(SpecialType.NullType, null)).WithILInstruction(inst.Left);
			return CreateBuiltinBinaryOperator(translatedExpression, inst.Kind.ToBinaryOperatorType(), translatedExpression2).WithILInstruction(inst);
		}
		translatedExpression = AdjustConstantExpressionToType(translatedExpression, translatedExpression2.Type);
		translatedExpression2 = AdjustConstantExpressionToType(translatedExpression2, translatedExpression.Type);
		if (IsSpecialCasedReferenceComparisonWithNull(translatedExpression, translatedExpression2))
		{
			negateOutput = false;
			return CreateBuiltinBinaryOperator(translatedExpression, inst.Kind.ToBinaryOperatorType(), translatedExpression2).WithILInstruction(inst);
		}
		OperatorResolveResult operatorResolveResult = ((!translatedExpression.Type.IsKnownType(KnownTypeCode.String) || !translatedExpression2.Type.IsKnownType(KnownTypeCode.String)) ? (resolver.ResolveBinaryOperator(inst.Kind.ToBinaryOperatorType(), translatedExpression.ResolveResult, translatedExpression2.ResolveResult) as OperatorResolveResult) : null);
		if (operatorResolveResult == null || operatorResolveResult.IsError || operatorResolveResult.UserDefinedOperatorMethod != null || NullableType.GetUnderlyingType(operatorResolveResult.Operands[0].Type).GetStackType() != inst.InputType || !operatorResolveResult.Type.IsKnownType(KnownTypeCode.Boolean))
		{
			IType type;
			if (inst.InputType == StackType.O)
			{
				type = compilation.FindType(KnownTypeCode.Object);
			}
			else
			{
				IType underlyingType = NullableType.GetUnderlyingType(translatedExpression.Type);
				IType underlyingType2 = NullableType.GetUnderlyingType(translatedExpression2.Type);
				type = ((underlyingType.GetStackType() == inst.InputType && !underlyingType.IsSmallIntegerType()) ? underlyingType : ((underlyingType2.GetStackType() != inst.InputType || underlyingType2.IsSmallIntegerType()) ? compilation.FindType(inst.InputType.ToKnownTypeCode(underlyingType.GetSign())) : underlyingType2));
			}
			if (inst.IsLifted)
			{
				type = NullableType.Create(compilation, type);
			}
			if (type.Equals(translatedExpression.Type))
			{
				translatedExpression2 = translatedExpression2.ConvertTo(type, this);
			}
			else
			{
				translatedExpression = translatedExpression.ConvertTo(type, this);
			}
			operatorResolveResult = resolver.ResolveBinaryOperator(inst.Kind.ToBinaryOperatorType(), translatedExpression.ResolveResult, translatedExpression2.ResolveResult) as OperatorResolveResult;
			if (operatorResolveResult == null || operatorResolveResult.IsError || operatorResolveResult.UserDefinedOperatorMethod != null || NullableType.GetUnderlyingType(operatorResolveResult.Operands[0].Type).GetStackType() != inst.InputType || !operatorResolveResult.Type.IsKnownType(KnownTypeCode.Boolean))
			{
				translatedExpression = translatedExpression.ConvertTo(type, this);
				translatedExpression2 = translatedExpression2.ConvertTo(type, this);
				operatorResolveResult = new OperatorResolveResult(compilation.FindType(KnownTypeCode.Boolean), BinaryOperatorExpression.GetLinqNodeType(inst.Kind.ToBinaryOperatorType(), checkForOverflow: false), translatedExpression.ResolveResult, translatedExpression2.ResolveResult);
			}
		}
		negateOutput = false;
		return new BinaryOperatorExpression(translatedExpression.Expression, inst.Kind.ToBinaryOperatorType(), translatedExpression2.Expression).WithILInstruction(inst).WithRR(operatorResolveResult);
	}

	private bool IsSpecialCasedReferenceComparisonWithNull(TranslatedExpression lhs, TranslatedExpression rhs)
	{
		if (lhs.Type.Kind == TypeKind.Null)
		{
			ExtensionMethods.Swap(ref lhs, ref rhs);
		}
		return rhs.Type.Kind == TypeKind.Null && (lhs.Type.Kind == TypeKind.Delegate || lhs.Type.IsKnownType(KnownTypeCode.String));
	}

	private ExpressionWithResolveResult CreateBuiltinBinaryOperator(TranslatedExpression left, BinaryOperatorType type, TranslatedExpression right, bool checkForOverflow = false)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		return new BinaryOperatorExpression(left.Expression, type, right.Expression).WithRR(new OperatorResolveResult(compilation.FindType(KnownTypeCode.Boolean), BinaryOperatorExpression.GetLinqNodeType(type, checkForOverflow), left.ResolveResult, right.ResolveResult));
	}

	private TranslatedExpression TranslateComp(Comp inst)
	{
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		BinaryOperatorType binaryOperatorType = inst.Kind.ToBinaryOperatorType();
		TranslatedExpression translatedExpression = Translate(inst.Left);
		TranslatedExpression translatedExpression2 = Translate(inst.Right);
		if (translatedExpression.Type.Kind == TypeKind.Pointer && translatedExpression2.Type.Kind == TypeKind.Pointer)
		{
			return CreateBuiltinBinaryOperator(translatedExpression, binaryOperatorType, translatedExpression2).WithILInstruction(inst);
		}
		translatedExpression = PrepareArithmeticArgument(translatedExpression, inst.InputType, inst.Sign, inst.IsLifted);
		translatedExpression2 = PrepareArithmeticArgument(translatedExpression2, inst.InputType, inst.Sign, inst.IsLifted);
		translatedExpression = AdjustConstantExpressionToType(translatedExpression, translatedExpression2.Type);
		translatedExpression2 = AdjustConstantExpressionToType(translatedExpression2, translatedExpression.Type);
		if (resolver.ResolveBinaryOperator(inst.Kind.ToBinaryOperatorType(), translatedExpression.ResolveResult, translatedExpression2.ResolveResult) is OperatorResolveResult { IsError: false } operatorResolveResult)
		{
			IType underlyingType = NullableType.GetUnderlyingType(operatorResolveResult.Operands[0].Type);
			if (underlyingType.GetSign() == inst.Sign && underlyingType.GetStackType() == inst.InputType)
			{
				return new BinaryOperatorExpression(translatedExpression.Expression, binaryOperatorType, translatedExpression2.Expression).WithILInstruction(inst).WithRR(operatorResolveResult);
			}
		}
		KnownTypeCode knownTypeCode = KnownTypeCode.None;
		switch (inst.InputType)
		{
		case StackType.I:
		case StackType.I8:
			knownTypeCode = ((inst.Sign == Sign.Unsigned) ? KnownTypeCode.UInt64 : KnownTypeCode.Int64);
			break;
		case StackType.I4:
			knownTypeCode = ((inst.Sign == Sign.Unsigned) ? KnownTypeCode.UInt32 : KnownTypeCode.Int32);
			break;
		}
		if (knownTypeCode != KnownTypeCode.None)
		{
			IType type = compilation.FindType(knownTypeCode);
			if (inst.IsLifted)
			{
				type = NullableType.Create(compilation, type);
			}
			translatedExpression = translatedExpression.ConvertTo(type, this);
			translatedExpression2 = translatedExpression2.ConvertTo(type, this);
		}
		return new BinaryOperatorExpression(translatedExpression.Expression, binaryOperatorType, translatedExpression2.Expression).WithILInstruction(inst).WithRR(new OperatorResolveResult(compilation.FindType(TypeCode.Boolean), BinaryOperatorExpression.GetLinqNodeType(binaryOperatorType, checkForOverflow: false), translatedExpression.ResolveResult, translatedExpression2.ResolveResult));
	}

	protected internal override TranslatedExpression VisitThreeValuedBoolAnd(ThreeValuedBoolAnd inst, TranslationContext context)
	{
		return HandleThreeValuedLogic(inst, BinaryOperatorType.BitwiseAnd, (ExpressionType)2);
	}

	protected internal override TranslatedExpression VisitThreeValuedBoolOr(ThreeValuedBoolOr inst, TranslationContext context)
	{
		return HandleThreeValuedLogic(inst, BinaryOperatorType.BitwiseOr, (ExpressionType)36);
	}

	private TranslatedExpression HandleThreeValuedLogic(BinaryInstruction inst, BinaryOperatorType op, ExpressionType eop)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		TranslatedExpression translatedExpression = Translate(inst.Left);
		TranslatedExpression translatedExpression2 = Translate(inst.Right);
		IType type = compilation.FindType(KnownTypeCode.Boolean);
		IType type2 = NullableType.Create(compilation, type);
		if (NullableType.IsNullable(translatedExpression.Type))
		{
			translatedExpression = translatedExpression.ConvertTo(type2, this);
			translatedExpression2 = ((!NullableType.IsNullable(translatedExpression2.Type)) ? translatedExpression2.ConvertTo(type, this) : translatedExpression2.ConvertTo(type2, this));
		}
		else
		{
			translatedExpression = translatedExpression.ConvertTo(type, this);
			translatedExpression2 = translatedExpression2.ConvertTo(type2, this);
		}
		return new BinaryOperatorExpression(translatedExpression.Expression, op, translatedExpression2.Expression).WithRR(new OperatorResolveResult(type2, eop, null, isLiftedOperator: true, new ResolveResult[2] { translatedExpression.ResolveResult, translatedExpression2.ResolveResult })).WithILInstruction(inst);
	}

	protected internal override TranslatedExpression VisitUserDefinedLogicOperator(UserDefinedLogicOperator inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Left, inst.Method.Parameters[0].Type).ConvertTo(inst.Method.Parameters[0].Type, this);
		TranslatedExpression translatedExpression2 = Translate(inst.Right, inst.Method.Parameters[1].Type).ConvertTo(inst.Method.Parameters[1].Type, this);
		BinaryOperatorType op;
		if (inst.Method.Name == "op_BitwiseAnd")
		{
			op = BinaryOperatorType.ConditionalAnd;
		}
		else
		{
			if (!(inst.Method.Name == "op_BitwiseOr"))
			{
				throw new InvalidOperationException("Invalid method name");
			}
			op = BinaryOperatorType.ConditionalOr;
		}
		return new BinaryOperatorExpression(translatedExpression.Expression, op, translatedExpression2.Expression).WithRR(new InvocationResolveResult(null, inst.Method, new ResolveResult[2] { translatedExpression.ResolveResult, translatedExpression2.ResolveResult })).WithILInstruction(inst);
	}

	private ExpressionWithResolveResult Assignment(TranslatedExpression left, TranslatedExpression right)
	{
		right = right.ConvertTo(left.Type, this, checkForOverflow: false, allowImplicitConversion: true);
		return new AssignmentExpression(left.Expression, right.Expression).WithRR(new OperatorResolveResult(left.Type, (ExpressionType)46, left.ResolveResult, right.ResolveResult));
	}

	protected internal override TranslatedExpression VisitBinaryNumericInstruction(BinaryNumericInstruction inst, TranslationContext context)
	{
		return inst.Operator switch
		{
			BinaryNumericOperator.Add => HandleBinaryNumeric(inst, BinaryOperatorType.Add), 
			BinaryNumericOperator.Sub => HandleBinaryNumeric(inst, BinaryOperatorType.Subtract), 
			BinaryNumericOperator.Mul => HandleBinaryNumeric(inst, BinaryOperatorType.Multiply), 
			BinaryNumericOperator.Div => HandlePointerSubtraction(inst) ?? HandleBinaryNumeric(inst, BinaryOperatorType.Divide), 
			BinaryNumericOperator.Rem => HandleBinaryNumeric(inst, BinaryOperatorType.Modulus), 
			BinaryNumericOperator.BitAnd => HandleBinaryNumeric(inst, BinaryOperatorType.BitwiseAnd), 
			BinaryNumericOperator.BitOr => HandleBinaryNumeric(inst, BinaryOperatorType.BitwiseOr), 
			BinaryNumericOperator.BitXor => HandleBinaryNumeric(inst, BinaryOperatorType.ExclusiveOr), 
			BinaryNumericOperator.ShiftLeft => HandleShift(inst, BinaryOperatorType.ShiftLeft), 
			BinaryNumericOperator.ShiftRight => HandleShift(inst, BinaryOperatorType.ShiftRight), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private TranslatedExpression? HandlePointerArithmetic(BinaryNumericInstruction inst, TranslatedExpression left, TranslatedExpression right)
	{
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		if (inst.Operator != BinaryNumericOperator.Add && inst.Operator != BinaryNumericOperator.Sub)
		{
			return null;
		}
		if (inst.CheckForOverflow || inst.IsLifted)
		{
			return null;
		}
		if (inst.LeftInputType != StackType.I || inst.RightInputType != StackType.I)
		{
			return null;
		}
		ILInstruction byteOffsetInst;
		TranslatedExpression byteOffsetExpr;
		PointerType pointerType;
		if (left.Type.Kind == TypeKind.Pointer)
		{
			byteOffsetInst = inst.Right;
			byteOffsetExpr = right;
			pointerType = (PointerType)left.Type;
		}
		else
		{
			if (right.Type.Kind != TypeKind.Pointer)
			{
				return null;
			}
			if (inst.Operator != BinaryNumericOperator.Add)
			{
				return null;
			}
			byteOffsetInst = inst.Left;
			byteOffsetExpr = left;
			pointerType = (PointerType)right.Type;
		}
		TranslatedExpression translatedExpression = GetPointerArithmeticOffset(byteOffsetInst, byteOffsetExpr, pointerType, inst.CheckForOverflow) ?? FallBackToBytePointer();
		if (left.Type.Kind == TypeKind.Pointer)
		{
			Debug.Assert(inst.Operator == BinaryNumericOperator.Add || inst.Operator == BinaryNumericOperator.Sub);
			left = left.ConvertTo(pointerType, this);
			right = translatedExpression;
		}
		else
		{
			Debug.Assert(inst.Operator == BinaryNumericOperator.Add);
			Debug.Assert(right.Type.Kind == TypeKind.Pointer);
			left = translatedExpression;
			right = right.ConvertTo(pointerType, this);
		}
		BinaryOperatorType op = ((inst.Operator == BinaryNumericOperator.Add) ? BinaryOperatorType.Add : BinaryOperatorType.Subtract);
		return new BinaryOperatorExpression(left, op, right).WithILInstruction(inst).WithRR(new OperatorResolveResult(pointerType, BinaryOperatorExpression.GetLinqNodeType(op, inst.CheckForOverflow), left.ResolveResult, right.ResolveResult));
		TranslatedExpression FallBackToBytePointer()
		{
			pointerType = new PointerType(compilation.FindType(KnownTypeCode.Byte));
			return EnsureIntegerType(byteOffsetExpr);
		}
	}

	private TranslatedExpression EnsureIntegerType(TranslatedExpression expr)
	{
		if (!expr.Type.IsCSharpPrimitiveIntegerType())
		{
			StackType stackType = ((expr.Type.GetStackType() == StackType.I4) ? StackType.I4 : StackType.I8);
			expr = expr.ConvertTo(compilation.FindType(stackType.ToKnownTypeCode(expr.Type.GetSign())), this);
		}
		return expr;
	}

	private TranslatedExpression? GetPointerArithmeticOffset(ILInstruction byteOffsetInst, TranslatedExpression byteOffsetExpr, PointerType pointerType, bool checkForOverflow, bool unwrapZeroExtension = false)
	{
		ILInstruction iLInstruction = PointerArithmeticOffset.Detect(byteOffsetInst, pointerType, checkForOverflow, unwrapZeroExtension);
		if (iLInstruction == null)
		{
			return null;
		}
		if (iLInstruction == byteOffsetInst)
		{
			return EnsureIntegerType(byteOffsetExpr);
		}
		return EnsureIntegerType(Translate(iLInstruction));
	}

	private TranslatedExpression? HandlePointerSubtraction(BinaryNumericInstruction inst)
	{
		Debug.Assert(inst.Operator == BinaryNumericOperator.Div);
		if (inst.CheckForOverflow || inst.LeftInputType != StackType.I)
		{
			return null;
		}
		if (!(inst.Left is BinaryNumericInstruction { Operator: BinaryNumericOperator.Sub } binaryNumericInstruction))
		{
			return null;
		}
		if (binaryNumericInstruction.CheckForOverflow)
		{
			return null;
		}
		IType elementType;
		if (inst.Right.MatchLdcI(out var elementSize))
		{
			elementType = null;
		}
		else if (!inst.Right.UnwrapConv(ConversionKind.SignExtend).MatchSizeOf(out elementType))
		{
			return null;
		}
		TranslatedExpression translatedExpression = Translate(binaryNumericInstruction.Left);
		TranslatedExpression translatedExpression2 = Translate(binaryNumericInstruction.Right);
		IType targetType;
		if (IsMatchingPointerType(translatedExpression.Type))
		{
			targetType = translatedExpression.Type;
		}
		else if (IsMatchingPointerType(translatedExpression2.Type))
		{
			targetType = translatedExpression2.Type;
		}
		else
		{
			if (elementSize != 1 || translatedExpression.Type.Kind != TypeKind.Pointer || translatedExpression2.Type.Kind != TypeKind.Pointer)
			{
				return null;
			}
			targetType = new PointerType(compilation.FindType(KnownTypeCode.Byte));
		}
		translatedExpression = translatedExpression.ConvertTo(targetType, this);
		translatedExpression2 = translatedExpression2.ConvertTo(targetType, this);
		OperatorResolveResult resolveResult = new OperatorResolveResult(compilation.FindType(KnownTypeCode.Int64), (ExpressionType)42, translatedExpression.ResolveResult, translatedExpression2.ResolveResult);
		return new BinaryOperatorExpression(translatedExpression.Expression, BinaryOperatorType.Subtract, translatedExpression2.Expression).WithILInstruction(new BinaryNumericInstruction[2] { inst, binaryNumericInstruction }).WithRR(resolveResult);
		bool IsMatchingPointerType(IType type)
		{
			if (type is PointerType pointerType)
			{
				if (elementType != null)
				{
					return elementType.Equals(pointerType.ElementType);
				}
				if (elementSize > 0)
				{
					return PointerArithmeticOffset.ComputeSizeOf(pointerType.ElementType) == elementSize;
				}
			}
			return false;
		}
	}

	private TranslatedExpression HandleBinaryNumeric(BinaryNumericInstruction inst, BinaryOperatorType op)
	{
		CSharpResolver cSharpResolver = resolver.WithCheckForOverflow(inst.CheckForOverflow);
		TranslatedExpression translatedExpression = Translate(inst.Left);
		TranslatedExpression translatedExpression2 = Translate(inst.Right);
		if (translatedExpression.Type.Kind == TypeKind.Pointer || translatedExpression2.Type.Kind == TypeKind.Pointer)
		{
			TranslatedExpression? translatedExpression3 = HandlePointerArithmetic(inst, translatedExpression, translatedExpression2);
			if (translatedExpression3.HasValue)
			{
				return translatedExpression3.Value;
			}
		}
		translatedExpression = PrepareArithmeticArgument(translatedExpression, inst.LeftInputType, inst.Sign, inst.IsLifted);
		translatedExpression2 = PrepareArithmeticArgument(translatedExpression2, inst.RightInputType, inst.Sign, inst.IsLifted);
		if (op == BinaryOperatorType.Subtract && inst.Left.MatchLdcI(0L))
		{
			IType underlyingType = NullableType.GetUnderlyingType(translatedExpression2.Type);
			if (underlyingType.IsKnownType(KnownTypeCode.Int32) || underlyingType.IsKnownType(KnownTypeCode.Int64) || underlyingType.IsCSharpSmallIntegerType())
			{
				UnaryOperatorExpression unaryOperatorExpression = new UnaryOperatorExpression(UnaryOperatorType.Minus, translatedExpression2.Expression);
				unaryOperatorExpression.AddAnnotation(inst.CheckForOverflow ? AddCheckedBlocks.CheckedAnnotation : AddCheckedBlocks.UncheckedAnnotation);
				IType type = (underlyingType.IsKnownType(KnownTypeCode.Int64) ? underlyingType : compilation.FindType(KnownTypeCode.Int32));
				if (inst.IsLifted)
				{
					type = NullableType.Create(compilation, type);
				}
				return unaryOperatorExpression.WithILInstruction(inst).WithRR(new OperatorResolveResult(type, (ExpressionType)(inst.CheckForOverflow ? 30 : 28), translatedExpression2.ResolveResult));
			}
		}
		if (op.IsBitwise() && (translatedExpression.Type.Kind == TypeKind.Enum || translatedExpression2.Type.Kind == TypeKind.Enum))
		{
			translatedExpression = AdjustConstantExpressionToType(translatedExpression, translatedExpression2.Type);
			translatedExpression2 = AdjustConstantExpressionToType(translatedExpression2, translatedExpression.Type);
		}
		ResolveResult resolveResult = cSharpResolver.ResolveBinaryOperator(op, translatedExpression.ResolveResult, translatedExpression2.ResolveResult);
		if (resolveResult.IsError || NullableType.GetUnderlyingType(resolveResult.Type).GetStackType() != inst.UnderlyingResultType || !IsCompatibleWithSign(translatedExpression.Type, inst.Sign) || !IsCompatibleWithSign(translatedExpression2.Type, inst.Sign))
		{
			StackType stackType = ((inst.UnderlyingResultType == StackType.I) ? StackType.I8 : inst.UnderlyingResultType);
			IType type2 = compilation.FindType(stackType.ToKnownTypeCode(inst.Sign));
			translatedExpression = translatedExpression.ConvertTo(NullableType.IsNullable(translatedExpression.Type) ? NullableType.Create(compilation, type2) : type2, this);
			translatedExpression2 = translatedExpression2.ConvertTo(NullableType.IsNullable(translatedExpression2.Type) ? NullableType.Create(compilation, type2) : type2, this);
			resolveResult = cSharpResolver.ResolveBinaryOperator(op, translatedExpression.ResolveResult, translatedExpression2.ResolveResult);
		}
		TranslatedExpression result = new BinaryOperatorExpression(translatedExpression.Expression, op, translatedExpression2.Expression).WithILInstruction(inst).WithRR(resolveResult);
		if (BinaryOperatorMightCheckForOverflow(op))
		{
			result.Expression.AddAnnotation(inst.CheckForOverflow ? AddCheckedBlocks.CheckedAnnotation : AddCheckedBlocks.UncheckedAnnotation);
		}
		return result;
	}

	private TranslatedExpression PrepareArithmeticArgument(TranslatedExpression arg, StackType argStackType, Sign sign, bool isLifted)
	{
		if (isLifted && !NullableType.IsNullable(arg.Type))
		{
			isLifted = false;
		}
		IType type = (isLifted ? NullableType.GetUnderlyingType(arg.Type) : arg.Type);
		if (argStackType.IsIntegerType() && argStackType.GetSize() < type.GetSize())
		{
			IType type2 = compilation.FindType(argStackType.ToKnownTypeCode(sign));
			type = type2;
			if (isLifted)
			{
				type2 = NullableType.Create(compilation, type2);
			}
			arg = arg.ConvertTo(type2, this);
		}
		if (type.GetStackType() == StackType.I)
		{
			IType type3 = compilation.FindType(StackType.I8.ToKnownTypeCode(sign));
			if (isLifted)
			{
				type3 = NullableType.Create(compilation, type3);
			}
			arg = arg.ConvertTo(type3, this);
		}
		return arg;
	}

	private static bool IsCompatibleWithSign(IType type, Sign sign)
	{
		return sign == Sign.None || NullableType.GetUnderlyingType(type).GetSign() == sign;
	}

	private static bool BinaryOperatorMightCheckForOverflow(BinaryOperatorType op)
	{
		if ((uint)(op - 1) <= 1u || op == BinaryOperatorType.ExclusiveOr || (uint)(op - 17) <= 1u)
		{
			return false;
		}
		return true;
	}

	private TranslatedExpression HandleShift(BinaryNumericInstruction inst, BinaryOperatorType op)
	{
		TranslatedExpression translatedExpression = Translate(inst.Left);
		TranslatedExpression translatedExpression2 = Translate(inst.Right);
		Sign sign = inst.Sign;
		IType underlyingType = NullableType.GetUnderlyingType(translatedExpression.Type);
		if (!underlyingType.IsCSharpSmallIntegerType() || sign == Sign.Unsigned || inst.UnderlyingResultType != StackType.I4)
		{
			if (sign == Sign.None)
			{
				sign = underlyingType.GetSign();
			}
			IType type = ((inst.UnderlyingResultType != StackType.I4) ? compilation.FindType((sign == Sign.Unsigned) ? KnownTypeCode.UInt64 : KnownTypeCode.Int64) : compilation.FindType((sign == Sign.Unsigned) ? KnownTypeCode.UInt32 : KnownTypeCode.Int32));
			if (NullableType.IsNullable(translatedExpression.Type))
			{
				type = NullableType.Create(compilation, type);
			}
			translatedExpression = translatedExpression.ConvertTo(type, this);
		}
		translatedExpression2 = ((!NullableType.IsNullable(translatedExpression2.Type)) ? translatedExpression2.ConvertTo(compilation.FindType(KnownTypeCode.Int32), this) : translatedExpression2.ConvertTo(NullableType.Create(compilation, compilation.FindType(KnownTypeCode.Int32)), this));
		return new BinaryOperatorExpression(translatedExpression.Expression, op, translatedExpression2.Expression).WithILInstruction(inst).WithRR(resolver.ResolveBinaryOperator(op, translatedExpression.ResolveResult, translatedExpression2.ResolveResult));
	}

	protected internal override TranslatedExpression VisitUserDefinedCompoundAssign(UserDefinedCompoundAssign inst, TranslationContext context)
	{
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		TranslatedExpression translatedExpression = Translate(inst.Target);
		if (UserDefinedCompoundAssign.IsStringConcat(inst.Method))
		{
			Debug.Assert(inst.Method.Parameters.Count == 2);
			TranslatedExpression translatedExpression2 = Translate(inst.Value).ConvertTo(inst.Method.Parameters[1].Type, this, checkForOverflow: false, allowImplicitConversion: true);
			return new AssignmentExpression(translatedExpression, AssignmentOperatorType.Add, translatedExpression2).WithILInstruction(inst).WithRR(new OperatorResolveResult(inst.Method.ReturnType, (ExpressionType)63, inst.Method, inst.IsLifted, new ResolveResult[2] { translatedExpression.ResolveResult, translatedExpression2.ResolveResult }));
		}
		if (inst.Method.Parameters.Count == 2)
		{
			TranslatedExpression translatedExpression3 = Translate(inst.Value).ConvertTo(inst.Method.Parameters[1].Type, this);
			AssignmentOperatorType? assignmentOperatorTypeFromMetadataName = GetAssignmentOperatorTypeFromMetadataName(inst.Method.Name);
			Debug.Assert(assignmentOperatorTypeFromMetadataName.HasValue);
			return new AssignmentExpression(translatedExpression, assignmentOperatorTypeFromMetadataName.Value, translatedExpression3).WithILInstruction(inst).WithRR(new OperatorResolveResult(inst.Method.ReturnType, AssignmentExpression.GetLinqNodeType(assignmentOperatorTypeFromMetadataName.Value, checkForOverflow: false), inst.Method, inst.IsLifted, new ResolveResult[2] { translatedExpression.ResolveResult, translatedExpression3.ResolveResult }));
		}
		UnaryOperatorType? unaryOperatorTypeFromMetadataName = GetUnaryOperatorTypeFromMetadataName(inst.Method.Name, inst.CompoundAssignmentType == CompoundAssignmentType.EvaluatesToOldValue);
		Debug.Assert(unaryOperatorTypeFromMetadataName.HasValue);
		return new UnaryOperatorExpression(unaryOperatorTypeFromMetadataName.Value, translatedExpression).WithILInstruction(inst).WithRR(new OperatorResolveResult(inst.Method.ReturnType, UnaryOperatorExpression.GetLinqNodeType(unaryOperatorTypeFromMetadataName.Value, checkForOverflow: false), inst.Method, inst.IsLifted, new ResolveResult[1] { translatedExpression.ResolveResult }));
	}

	internal static AssignmentOperatorType? GetAssignmentOperatorTypeFromMetadataName(string name)
	{
		return name switch
		{
			"op_Addition" => AssignmentOperatorType.Add, 
			"op_Subtraction" => AssignmentOperatorType.Subtract, 
			"op_Multiply" => AssignmentOperatorType.Multiply, 
			"op_Division" => AssignmentOperatorType.Divide, 
			"op_Modulus" => AssignmentOperatorType.Modulus, 
			"op_BitwiseAnd" => AssignmentOperatorType.BitwiseAnd, 
			"op_BitwiseOr" => AssignmentOperatorType.BitwiseOr, 
			"op_ExclusiveOr" => AssignmentOperatorType.ExclusiveOr, 
			"op_LeftShift" => AssignmentOperatorType.ShiftLeft, 
			"op_RightShift" => AssignmentOperatorType.ShiftRight, 
			_ => null, 
		};
	}

	internal static UnaryOperatorType? GetUnaryOperatorTypeFromMetadataName(string name, bool isPostfix)
	{
		if (!(name == "op_Increment"))
		{
			if (name == "op_Decrement")
			{
				return isPostfix ? UnaryOperatorType.PostDecrement : UnaryOperatorType.Decrement;
			}
			return null;
		}
		return isPostfix ? UnaryOperatorType.PostIncrement : UnaryOperatorType.Increment;
	}

	protected internal override TranslatedExpression VisitNumericCompoundAssign(NumericCompoundAssign inst, TranslationContext context)
	{
		return inst.Operator switch
		{
			BinaryNumericOperator.Add => HandleCompoundAssignment(inst, AssignmentOperatorType.Add), 
			BinaryNumericOperator.Sub => HandleCompoundAssignment(inst, AssignmentOperatorType.Subtract), 
			BinaryNumericOperator.Mul => HandleCompoundAssignment(inst, AssignmentOperatorType.Multiply), 
			BinaryNumericOperator.Div => HandleCompoundAssignment(inst, AssignmentOperatorType.Divide), 
			BinaryNumericOperator.Rem => HandleCompoundAssignment(inst, AssignmentOperatorType.Modulus), 
			BinaryNumericOperator.BitAnd => HandleCompoundAssignment(inst, AssignmentOperatorType.BitwiseAnd), 
			BinaryNumericOperator.BitOr => HandleCompoundAssignment(inst, AssignmentOperatorType.BitwiseOr), 
			BinaryNumericOperator.BitXor => HandleCompoundAssignment(inst, AssignmentOperatorType.ExclusiveOr), 
			BinaryNumericOperator.ShiftLeft => HandleCompoundShift(inst, AssignmentOperatorType.ShiftLeft), 
			BinaryNumericOperator.ShiftRight => HandleCompoundShift(inst, AssignmentOperatorType.ShiftRight), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private TranslatedExpression HandleCompoundAssignment(NumericCompoundAssign inst, AssignmentOperatorType op)
	{
		//IL_0243: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		TranslatedExpression translatedExpression = Translate(inst.Target);
		TranslatedExpression arg = Translate(inst.Value);
		arg = PrepareArithmeticArgument(arg, inst.RightInputType, inst.Sign, inst.IsLifted);
		TranslatedExpression result;
		if (inst.CompoundAssignmentType == CompoundAssignmentType.EvaluatesToOldValue)
		{
			Debug.Assert(op == AssignmentOperatorType.Add || op == AssignmentOperatorType.Subtract);
			Debug.Assert(arg.ResolveResult.IsCompileTimeConstant && 1.Equals(arg.ResolveResult.ConstantValue));
			UnaryOperatorType op2;
			ExpressionType operatorType;
			if (op == AssignmentOperatorType.Add)
			{
				op2 = UnaryOperatorType.PostIncrement;
				operatorType = (ExpressionType)79;
			}
			else
			{
				op2 = UnaryOperatorType.PostDecrement;
				operatorType = (ExpressionType)80;
			}
			result = new UnaryOperatorExpression(op2, translatedExpression).WithILInstruction(inst).WithRR(new OperatorResolveResult(translatedExpression.Type, operatorType, translatedExpression.ResolveResult));
		}
		else
		{
			switch (op)
			{
			case AssignmentOperatorType.Add:
			case AssignmentOperatorType.Subtract:
			{
				if (translatedExpression.Type.Kind == TypeKind.Pointer)
				{
					TranslatedExpression? pointerArithmeticOffset = GetPointerArithmeticOffset(inst.Value, arg, (PointerType)translatedExpression.Type, inst.CheckForOverflow);
					if (pointerArithmeticOffset.HasValue)
					{
						arg = pointerArithmeticOffset.Value;
					}
					else
					{
						arg.Expression.AddChild(new Comment("ILSpy Error: GetPointerArithmeticOffset() failed", CommentType.MultiLine), Roles.Comment);
					}
					break;
				}
				IType type2 = NullableType.GetUnderlyingType(translatedExpression.Type).GetEnumUnderlyingType();
				if (NullableType.IsNullable(arg.Type))
				{
					type2 = NullableType.Create(compilation, type2);
				}
				arg = arg.ConvertTo(type2, this, inst.CheckForOverflow, allowImplicitConversion: true);
				break;
			}
			case AssignmentOperatorType.Multiply:
			case AssignmentOperatorType.Divide:
			case AssignmentOperatorType.Modulus:
			case AssignmentOperatorType.BitwiseAnd:
			case AssignmentOperatorType.BitwiseOr:
			case AssignmentOperatorType.ExclusiveOr:
			{
				IType type = NullableType.GetUnderlyingType(translatedExpression.Type);
				if (NullableType.IsNullable(arg.Type))
				{
					type = NullableType.Create(compilation, type);
				}
				arg = arg.ConvertTo(type, this, inst.CheckForOverflow, allowImplicitConversion: true);
				break;
			}
			}
			result = new AssignmentExpression(translatedExpression.Expression, op, arg.Expression).WithILInstruction(inst).WithRR(new OperatorResolveResult(translatedExpression.Type, AssignmentExpression.GetLinqNodeType(op, inst.CheckForOverflow), translatedExpression.ResolveResult, arg.ResolveResult));
		}
		if (AssignmentOperatorMightCheckForOverflow(op))
		{
			result.Expression.AddAnnotation(inst.CheckForOverflow ? AddCheckedBlocks.CheckedAnnotation : AddCheckedBlocks.UncheckedAnnotation);
		}
		return result;
	}

	private TranslatedExpression HandleCompoundShift(NumericCompoundAssign inst, AssignmentOperatorType op)
	{
		Debug.Assert(inst.CompoundAssignmentType == CompoundAssignmentType.EvaluatesToNewValue);
		TranslatedExpression translatedExpression = Translate(inst.Target);
		TranslatedExpression translatedExpression2 = Translate(inst.Value);
		translatedExpression2 = ((!NullableType.IsNullable(translatedExpression2.Type)) ? translatedExpression2.ConvertTo(compilation.FindType(KnownTypeCode.Int32), this) : translatedExpression2.ConvertTo(NullableType.Create(compilation, compilation.FindType(KnownTypeCode.Int32)), this));
		return new AssignmentExpression(translatedExpression.Expression, op, translatedExpression2.Expression).WithILInstruction(inst).WithRR(resolver.ResolveAssignment(op, translatedExpression.ResolveResult, translatedExpression2.ResolveResult));
	}

	private static bool AssignmentOperatorMightCheckForOverflow(AssignmentOperatorType op)
	{
		if ((uint)(op - 6) <= 4u)
		{
			return false;
		}
		return true;
	}

	protected internal override TranslatedExpression VisitConv(Conv inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Argument);
		IType underlyingType = NullableType.GetUnderlyingType(translatedExpression.Type);
		StackType inputType = inst.InputType;
		if (inst.CheckForOverflow || inst.Kind == ConversionKind.IntToFloat)
		{
			Debug.Assert(inst.InputSign != Sign.None);
			if (underlyingType.GetSize() > inputType.GetSize() || underlyingType.GetSign() != inst.InputSign)
			{
				translatedExpression = translatedExpression.ConvertTo(GetType(inputType.ToKnownTypeCode(inst.InputSign)), this);
			}
			return translatedExpression.ConvertTo(GetType(inst.TargetType.ToKnownTypeCode()), this, inst.CheckForOverflow).WithILInstruction(inst);
		}
		switch (inst.Kind)
		{
		case ConversionKind.StartGCTracking:
			return translatedExpression;
		case ConversionKind.StopGCTracking:
			if (underlyingType.Kind == TypeKind.ByReference)
			{
				PointerType targetType = new PointerType(((ByReferenceType)underlyingType).ElementType);
				return translatedExpression.ConvertTo(targetType, this).WithILInstruction(inst);
			}
			if (translatedExpression.Type.GetStackType().IsIntegerType())
			{
				return translatedExpression;
			}
			break;
		case ConversionKind.SignExtend:
			if (underlyingType.GetSign() != Sign.Signed || ValueMightBeOversized(translatedExpression.ResolveResult, inputType))
			{
				translatedExpression = translatedExpression.ConvertTo(GetType(inputType.ToKnownTypeCode(Sign.Signed)), this);
			}
			return translatedExpression.WithILInstruction(inst);
		case ConversionKind.ZeroExtend:
			if (underlyingType.GetSign() != Sign.Unsigned || underlyingType.GetSize() > inputType.GetSize())
			{
				translatedExpression = translatedExpression.ConvertTo(GetType(inputType.ToKnownTypeCode(Sign.Unsigned)), this);
			}
			return translatedExpression.WithILInstruction(inst);
		case ConversionKind.Nop:
			return translatedExpression.WithILInstruction(inst);
		case ConversionKind.Truncate:
			if (inst.TargetType.IsSmallIntegerType())
			{
				if (underlyingType.GetSize() <= inst.TargetType.GetSize() && underlyingType.GetSign() == inst.TargetType.GetSign())
				{
					return translatedExpression.WithILInstruction(inst);
				}
				break;
			}
			Debug.Assert(inst.TargetType.GetSize() == inst.UnderlyingResultType.GetSize());
			return translatedExpression.WithILInstruction(inst);
		}
		IType targetType2 = ((inst.TargetType == NullableType.GetUnderlyingType(context.TypeHint).ToPrimitiveType() && NullableType.IsNullable(context.TypeHint) == inst.IsLifted) ? context.TypeHint : ((inst.TargetType != DecompTools.Decompiler.IL.PrimitiveType.Ref) ? GetType(inst.TargetType.ToKnownTypeCode()) : new ByReferenceType(compilation.FindType(KnownTypeCode.Byte))));
		return translatedExpression.ConvertTo(targetType2, this, inst.CheckForOverflow).WithILInstruction(inst);
		IType GetType(KnownTypeCode typeCode)
		{
			IType type = compilation.FindType(typeCode);
			if (inst.IsLifted)
			{
				type = NullableType.Create(compilation, type);
			}
			return type;
		}
	}

	private bool ValueMightBeOversized(ResolveResult rr, StackType stackType)
	{
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		IType underlyingType = NullableType.GetUnderlyingType(rr.Type);
		if (underlyingType.GetSize() <= stackType.GetSize())
		{
			return false;
		}
		if (rr is OperatorResolveResult operatorResolveResult && stackType == StackType.I && (int)operatorResolveResult.OperatorType == 42 && operatorResolveResult.Operands.Count == 2 && operatorResolveResult.Operands[0].Type.Kind == TypeKind.Pointer && operatorResolveResult.Operands[1].Type.Kind == TypeKind.Pointer)
		{
			return false;
		}
		return true;
	}

	protected internal override TranslatedExpression VisitCall(Call inst, TranslationContext context)
	{
		return WrapInRef(new CallBuilder(this, typeSystem, settings).Build(inst), inst.Method.ReturnType);
	}

	protected internal override TranslatedExpression VisitCallVirt(CallVirt inst, TranslationContext context)
	{
		return WrapInRef(new CallBuilder(this, typeSystem, settings).Build(inst), inst.Method.ReturnType);
	}

	private TranslatedExpression WrapInRef(TranslatedExpression expr, IType type)
	{
		if (type.Kind == TypeKind.ByReference)
		{
			return new DirectionExpression(FieldDirection.Ref, expr.Expression).WithoutILInstruction().WithRR(new ByReferenceResolveResult(expr.ResolveResult, isOut: false));
		}
		return expr;
	}

	internal bool IsCurrentOrContainingType(ITypeDefinition type)
	{
		for (ITypeDefinition typeDefinition = decompilationContext.CurrentTypeDefinition; typeDefinition != null; typeDefinition = typeDefinition.DeclaringTypeDefinition)
		{
			if (type == typeDefinition)
			{
				return true;
			}
		}
		return false;
	}

	internal ExpressionWithResolveResult TranslateFunction(IType delegateType, ILFunction function)
	{
		IMethod method = function.Method?.MemberDefinition as IMethod;
		AnonymousMethodExpression anonymousMethodExpression = new AnonymousMethodExpression();
		anonymousMethodExpression.IsAsync = function.IsAsync;
		anonymousMethodExpression.Parameters.AddRange(MakeParameters(function.Parameters, function));
		anonymousMethodExpression.HasParameterList = anonymousMethodExpression.Parameters.Count > 0;
		StatementBuilder statementBuilder = new StatementBuilder(typeSystem, decompilationContext, function, settings, cancellationToken);
		BlockStatement blockStatement = statementBuilder.ConvertAsBlock(function.Body);
		Comment prevSibling = null;
		foreach (string warning in function.Warnings)
		{
			blockStatement.InsertChildAfter(prevSibling, prevSibling = new Comment(warning), Roles.Comment);
		}
		bool flag = false;
		if (Enumerable.Any<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)anonymousMethodExpression.Parameters, (Func<ParameterDeclaration, bool>)((ParameterDeclaration p) => p.Type.IsNull)))
		{
			flag = true;
		}
		else if (settings.UseLambdaSyntax && Enumerable.All<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)anonymousMethodExpression.Parameters, (Func<ParameterDeclaration, bool>)((ParameterDeclaration p) => p.ParameterModifier == ParameterModifier.None)))
		{
			flag = blockStatement.Statements.Count == 1 && Enumerable.Single<Statement>((IEnumerable<Statement>)blockStatement.Statements) is ReturnStatement;
		}
		IEnumerable<IdentifierExpression> enumerable = Enumerable.Select(Enumerable.Where(Enumerable.Select(Enumerable.OfType<IdentifierExpression>((IEnumerable)blockStatement.Descendants), (IdentifierExpression ident) => new
		{
			ident = ident,
			v = ident.GetILVariable()
		}), _003C_003Eh__TransparentIdentifier0 => _003C_003Eh__TransparentIdentifier0.v != null && _003C_003Eh__TransparentIdentifier0.v.Function == function && _003C_003Eh__TransparentIdentifier0.v.Kind == VariableKind.Parameter), _003C_003Eh__TransparentIdentifier0 => _003C_003Eh__TransparentIdentifier0.ident);
		if (!flag && !Enumerable.Any<IdentifierExpression>(enumerable))
		{
			anonymousMethodExpression.Parameters.Clear();
			anonymousMethodExpression.HasParameterList = false;
		}
		IType type;
		Expression expression;
		if (flag)
		{
			LambdaExpression lambdaExpression = new LambdaExpression();
			lambdaExpression.IsAsync = anonymousMethodExpression.IsAsync;
			lambdaExpression.CopyAnnotationsFrom(anonymousMethodExpression);
			anonymousMethodExpression.Parameters.MoveTo(lambdaExpression.Parameters);
			if (blockStatement.Statements.Count == 1 && Enumerable.Single<Statement>((IEnumerable<Statement>)blockStatement.Statements) is ReturnStatement returnStatement)
			{
				lambdaExpression.Body = returnStatement.Expression.Detach();
				type = lambdaExpression.Body.GetResolveResult().Type;
			}
			else
			{
				lambdaExpression.Body = blockStatement;
				type = InferReturnType(blockStatement);
			}
			expression = lambdaExpression;
		}
		else
		{
			anonymousMethodExpression.Body = blockStatement;
			type = InferReturnType(blockStatement);
			expression = anonymousMethodExpression;
		}
		if (anonymousMethodExpression.IsAsync)
		{
			type = GetTaskType(type);
		}
		DecompiledLambdaResolveResult decompiledLambdaResolveResult = new DecompiledLambdaResolveResult(function, delegateType, type, flag || anonymousMethodExpression.HasParameterList, !flag, Enumerable.Any<ParameterDeclaration>((IEnumerable<ParameterDeclaration>)anonymousMethodExpression.Parameters, (Func<ParameterDeclaration, bool>)((ParameterDeclaration p) => p.Type.IsNull)));
		TranslatedExpression translatedExpression = expression.WithILInstruction(function).WithRR(decompiledLambdaResolveResult);
		return new CastExpression(ConvertType(delegateType), translatedExpression).WithRR(new ConversionResolveResult(delegateType, decompiledLambdaResolveResult, LambdaConversion.Instance));
	}

	protected internal override TranslatedExpression VisitILFunction(ILFunction function, TranslationContext context)
	{
		return TranslateFunction(function.DelegateType, function).WithILInstruction(function);
	}

	private IType InferReturnType(BlockStatement body)
	{
		List<ResolveResult> returnExpressions = new List<ResolveResult>();
		CollectReturnExpressions(body);
		TypeInference typeInference = new TypeInference(compilation, resolver.conversions);
		bool success;
		return typeInference.GetBestCommonType(returnExpressions, out success);
		void CollectReturnExpressions(AstNode node)
		{
			if (node is ReturnStatement returnStatement)
			{
				if (!returnStatement.Expression.IsNull)
				{
					returnExpressions.Add(returnStatement.Expression.GetResolveResult());
				}
			}
			else if (node is LambdaExpression || node is AnonymousMethodExpression)
			{
				return;
			}
			foreach (AstNode child in node.Children)
			{
				CollectReturnExpressions(child);
			}
		}
	}

	private IType GetTaskType(IType resultType)
	{
		if (resultType.Kind == TypeKind.Unknown)
		{
			return SpecialType.UnknownType;
		}
		if (resultType.Kind == TypeKind.Void)
		{
			return compilation.FindType(KnownTypeCode.Task);
		}
		ITypeDefinition definition = compilation.FindType(KnownTypeCode.TaskOfT).GetDefinition();
		if (definition != null)
		{
			return new ParameterizedType(definition, new IType[1] { resultType });
		}
		return SpecialType.UnknownType;
	}

	private IEnumerable<ParameterDeclaration> MakeParameters(IReadOnlyList<IParameter> parameters, ILFunction function)
	{
		Dictionary<int?, ILVariable> variables = Enumerable.ToDictionary<ILVariable, int?>(Enumerable.Where<ILVariable>((IEnumerable<ILVariable>)function.Variables, (Func<ILVariable, bool>)((ILVariable iLVariable) => iLVariable.Kind == VariableKind.Parameter)), (Func<ILVariable, int?>)((ILVariable iLVariable) => iLVariable.Index));
		int i = 0;
		foreach (IParameter parameter in parameters)
		{
			ParameterDeclaration pd = astBuilder.ConvertParameter(parameter);
			if (settings.AnonymousTypes && parameter.Type.ContainsAnonymousType())
			{
				pd.Type = null;
			}
			if (variables.TryGetValue(i, out var v))
			{
				pd.AddAnnotation(new ILVariableResolveResult(v, parameters[i].Type));
			}
			yield return pd;
			i = checked(i + 1);
			v = null;
		}
	}

	internal TranslatedExpression TranslateTarget(ILInstruction target, bool nonVirtualInvocation, bool memberStatic, IType memberDeclaringType)
	{
		if (!memberStatic && target != null)
		{
			if (nonVirtualInvocation && target.MatchLdThis() && memberDeclaringType.GetDefinition() != resolver.CurrentTypeDefinition)
			{
				return new BaseReferenceExpression().WithILInstruction(target).WithRR(new ThisResolveResult(memberDeclaringType, nonVirtualInvocation));
			}
			TranslatedExpression translatedExpression = Translate(target, memberDeclaringType);
			if (CallInstruction.ExpectedTypeForThisPointer(memberDeclaringType) == StackType.Ref && (!(translatedExpression.Type is ByReferenceType byReferenceType) || !NormalizeTypeVisitor.TypeErasure.EquivalentTypes(byReferenceType.ElementType, memberDeclaringType)))
			{
				translatedExpression = translatedExpression.ConvertTo(new ByReferenceType(memberDeclaringType), this);
			}
			if (translatedExpression.Expression is DirectionExpression)
			{
				translatedExpression = translatedExpression.UnwrapChild(((DirectionExpression)(Expression)translatedExpression).Expression);
			}
			else if (translatedExpression.Expression is UnaryOperatorExpression { Operator: UnaryOperatorType.NullConditional } unaryOperatorExpression && unaryOperatorExpression.Expression is DirectionExpression)
			{
				translatedExpression = translatedExpression.UnwrapChild(((DirectionExpression)unaryOperatorExpression.Expression).Expression);
				translatedExpression = new UnaryOperatorExpression(UnaryOperatorType.NullConditional, translatedExpression).WithRR(new ResolveResult(NullableType.GetUnderlyingType(translatedExpression.Type))).WithoutILInstruction();
			}
			return EnsureTargetNotNullable(translatedExpression);
		}
		return new TypeReferenceExpression(ConvertType(memberDeclaringType)).WithoutILInstruction().WithRR(new TypeResolveResult(memberDeclaringType));
	}

	private TranslatedExpression EnsureTargetNotNullable(TranslatedExpression expr)
	{
		if (expr.Type.Nullability == Nullability.Nullable)
		{
			if (expr.Expression is UnaryOperatorExpression { Operator: UnaryOperatorType.NullConditional })
			{
				return expr;
			}
			return new UnaryOperatorExpression(UnaryOperatorType.SuppressNullableWarning, expr).WithRR(new ResolveResult(expr.Type.ChangeNullability(Nullability.Oblivious))).WithoutILInstruction();
		}
		return expr;
	}

	protected internal override TranslatedExpression VisitLdObj(LdObj inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Target);
		if (TypeUtils.IsCompatiblePointerTypeForMemoryAccess(translatedExpression.Type, inst.Type))
		{
			TranslatedExpression result;
			if (translatedExpression.Expression is DirectionExpression directionExpression)
			{
				result = translatedExpression.UnwrapChild(directionExpression.Expression);
				result.Expression.AddAnnotation(inst);
			}
			else
			{
				if (!(translatedExpression.Type is PointerType pointerType))
				{
					return new UnaryOperatorExpression(UnaryOperatorType.Dereference, translatedExpression.ConvertTo(new PointerType(inst.Type), this).Expression).WithILInstruction(inst).WithRR(new ResolveResult(inst.Type));
				}
				if (translatedExpression.Expression is UnaryOperatorExpression { Operator: UnaryOperatorType.AddressOf } unaryOperatorExpression)
				{
					result = translatedExpression.UnwrapChild(unaryOperatorExpression.Expression);
					result.Expression.AddAnnotation(inst);
				}
				else
				{
					result = new UnaryOperatorExpression(UnaryOperatorType.Dereference, translatedExpression.Expression).WithILInstruction(inst).WithRR(new ResolveResult(pointerType.ElementType));
				}
			}
			if (translatedExpression.Type.IsSmallIntegerType() && inst.Type.IsSmallIntegerType() && translatedExpression.Type.GetSign() != inst.Type.GetSign())
			{
				return result.ConvertTo(inst.Type, this);
			}
			return result;
		}
		return new UnaryOperatorExpression(UnaryOperatorType.Dereference, translatedExpression.ConvertTo(new PointerType(inst.Type), this).Expression).WithILInstruction(inst).WithRR(new ResolveResult(inst.Type));
	}

	protected internal override TranslatedExpression VisitStObj(StObj inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Target);
		TranslatedExpression right = default(TranslatedExpression);
		TranslatedExpression left;
		if (translatedExpression.Expression is DirectionExpression && TypeUtils.IsCompatiblePointerTypeForMemoryAccess(translatedExpression.Type, inst.Type))
		{
			left = translatedExpression.UnwrapChild(((DirectionExpression)translatedExpression.Expression).Expression);
		}
		else
		{
			if (!TypeUtils.IsCompatiblePointerTypeForMemoryAccess(translatedExpression.Type, inst.Type))
			{
				right = Translate(inst.Value, inst.Type);
				translatedExpression = ((!TypeUtils.IsCompatibleTypeForMemoryAccess(right.Type, inst.Type)) ? translatedExpression.ConvertTo(new PointerType(inst.Type), this) : translatedExpression.ConvertTo(new PointerType(right.Type), this));
			}
			left = ((!(translatedExpression.Expression is UnaryOperatorExpression { Operator: UnaryOperatorType.AddressOf } unaryOperatorExpression)) ? new UnaryOperatorExpression(UnaryOperatorType.Dereference, translatedExpression.Expression).WithoutILInstruction().WithRR(new ResolveResult(((TypeWithElementType)translatedExpression.Type).ElementType)) : translatedExpression.UnwrapChild(unaryOperatorExpression.Expression));
		}
		if (right.Expression == null)
		{
			right = Translate(inst.Value, left.Type);
		}
		return Assignment(left, right).WithILInstruction(inst);
	}

	protected internal override TranslatedExpression VisitLdLen(LdLen inst, TranslationContext context)
	{
		TranslatedExpression expr = Translate(inst.Array);
		if (expr.Type.Kind != TypeKind.Array)
		{
			expr = expr.ConvertTo(compilation.FindType(KnownTypeCode.Array), this);
		}
		expr = EnsureTargetNotNullable(expr);
		if (inst.ResultType == StackType.I4)
		{
			return new MemberReferenceExpression(expr.Expression, "Length").WithILInstruction(inst).WithRR(new ResolveResult(compilation.FindType(KnownTypeCode.Int32)));
		}
		return new MemberReferenceExpression(expr.Expression, "LongLength").WithILInstruction(inst).WithRR(new ResolveResult(compilation.FindType(KnownTypeCode.Int64)));
	}

	protected internal override TranslatedExpression VisitLdFlda(LdFlda inst, TranslationContext context)
	{
		if (settings.FixedBuffers && inst.Field.Name == "FixedElementField" && inst.Target is LdFlda ldFlda && CSharpDecompiler.IsFixedField(ldFlda.Field, out var type, out var _))
		{
			Expression expression = ConvertField(ldFlda.Field, ldFlda.Target);
			expression.RemoveAnnotations<ResolveResult>();
			TranslatedExpression result = expression.WithRR(new ResolveResult(new PointerType(type))).WithILInstruction(inst);
			if (inst.ResultType == StackType.Ref)
			{
				return result.ConvertTo(new ByReferenceType(type), this);
			}
			return result;
		}
		TranslatedExpression translatedExpression2;
		if (TupleTransform.MatchTupleFieldAccess(inst, out var tupleType, out var target, out var position))
		{
			TranslatedExpression translatedExpression = TranslateTarget(target, nonVirtualInvocation: true, memberStatic: false, tupleType);
			if (translatedExpression.Type is TupleType tupleType2 && tupleType2.UnderlyingType.Equals(tupleType) && position <= tupleType2.ElementNames.Length)
			{
				string text = tupleType2.ElementNames[checked(position - 1)];
				if (text == null)
				{
					text = "Item" + position;
				}
				translatedExpression2 = new MemberReferenceExpression(translatedExpression, text).WithRR(new MemberResolveResult(translatedExpression.ResolveResult, inst.Field)).WithILInstruction(inst);
			}
			else
			{
				translatedExpression2 = ConvertField(inst.Field, inst.Target).WithILInstruction(inst);
			}
		}
		else
		{
			translatedExpression2 = ConvertField(inst.Field, inst.Target).WithILInstruction(inst);
		}
		if (inst.ResultType == StackType.I)
		{
			return new UnaryOperatorExpression(UnaryOperatorType.AddressOf, translatedExpression2).WithoutILInstruction().WithRR(new ResolveResult(new PointerType(translatedExpression2.Type)));
		}
		return new DirectionExpression(FieldDirection.Ref, translatedExpression2).WithoutILInstruction().WithRR(new ByReferenceResolveResult(translatedExpression2.ResolveResult, isOut: false));
	}

	protected internal override TranslatedExpression VisitLdsFlda(LdsFlda inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = ConvertField(inst.Field).WithILInstruction(inst);
		return new DirectionExpression(FieldDirection.Ref, translatedExpression).WithoutILInstruction().WithRR(new ByReferenceResolveResult(translatedExpression.Type, isOut: false));
	}

	protected internal override TranslatedExpression VisitLdElema(LdElema inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Array);
		ArrayType arrayType = translatedExpression.Type as ArrayType;
		if (arrayType == null || !TypeUtils.IsCompatibleTypeForMemoryAccess(arrayType.ElementType, inst.Type))
		{
			arrayType = new ArrayType(compilation, inst.Type, inst.Indices.Count);
			translatedExpression = translatedExpression.ConvertTo(arrayType, this);
		}
		TranslatedExpression translatedExpression2 = new IndexerExpression(translatedExpression, Enumerable.Select<ILInstruction, Expression>((IEnumerable<ILInstruction>)inst.Indices, (Func<ILInstruction, Expression>)((ILInstruction i) => TranslateArrayIndex(i).Expression))).WithILInstruction(inst).WithRR(new ResolveResult(arrayType.ElementType));
		return new DirectionExpression(FieldDirection.Ref, translatedExpression2).WithoutILInstruction().WithRR(new ByReferenceResolveResult(translatedExpression2.Type, isOut: false));
	}

	private TranslatedExpression TranslateArrayIndex(ILInstruction i)
	{
		TranslatedExpression result = Translate(i);
		KnownTypeCode typeCode;
		if (i.ResultType == StackType.I4)
		{
			if (result.Type.IsSmallIntegerType() && result.Type.Kind != TypeKind.Enum)
			{
				return result;
			}
			typeCode = ((result.Type.GetSign() == Sign.Unsigned) ? KnownTypeCode.UInt32 : KnownTypeCode.Int32);
		}
		else
		{
			typeCode = ((result.Type.GetSign() == Sign.Unsigned) ? KnownTypeCode.UInt64 : KnownTypeCode.Int64);
		}
		return result.ConvertTo(compilation.FindType(typeCode), this);
	}

	protected internal override TranslatedExpression VisitUnboxAny(UnboxAny inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression;
		if (inst.Argument is IsInst isInst && inst.Type.Equals(isInst.Type))
		{
			translatedExpression = UnwrapBoxingConversion(Translate(isInst.Argument));
			return new AsExpression(translatedExpression, ConvertType(inst.Type)).WithILInstruction(inst).WithRR(new ConversionResolveResult(inst.Type, translatedExpression.ResolveResult, Conversion.TryCast));
		}
		translatedExpression = Translate(inst.Argument);
		IType type = inst.Type;
		if (type.Kind == TypeKind.TypeParameter)
		{
			ResolveResult resolveResult = resolver.ResolveCast(type, translatedExpression.ResolveResult);
			if (resolveResult.IsError)
			{
				translatedExpression = translatedExpression.ConvertTo(((ITypeParameter)type).EffectiveBaseClass, this);
			}
		}
		else
		{
			translatedExpression = translatedExpression.ConvertTo(compilation.FindType(KnownTypeCode.Object), this);
		}
		return new CastExpression(ConvertType(type), translatedExpression.Expression).WithILInstruction(inst).WithRR(new ConversionResolveResult(type, translatedExpression.ResolveResult, Conversion.UnboxingConversion));
	}

	protected internal override TranslatedExpression VisitUnbox(Unbox inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Argument);
		ExpressionWithResolveResult expressionWithResolveResult = new CastExpression(ConvertType(inst.Type), translatedExpression.Expression).WithRR(new ConversionResolveResult(inst.Type, translatedExpression.ResolveResult, Conversion.UnboxingConversion));
		return new DirectionExpression(FieldDirection.Ref, expressionWithResolveResult).WithILInstruction(inst).WithRR(new ByReferenceResolveResult(expressionWithResolveResult.ResolveResult, isOut: false));
	}

	protected internal override TranslatedExpression VisitBox(Box inst, TranslationContext context)
	{
		IType type = compilation.FindType(KnownTypeCode.Object);
		TranslatedExpression translatedExpression = Translate(inst.Argument, inst.Type).ConvertTo(inst.Type, this);
		return new CastExpression(ConvertType(type), translatedExpression.Expression).WithILInstruction(inst).WithRR(new ConversionResolveResult(type, translatedExpression.ResolveResult, Conversion.BoxingConversion));
	}

	protected internal override TranslatedExpression VisitCastClass(CastClass inst, TranslationContext context)
	{
		return Translate(inst.Argument).ConvertTo(inst.Type, this);
	}

	protected internal override TranslatedExpression VisitExpressionTreeCast(ExpressionTreeCast inst, TranslationContext context)
	{
		return Translate(inst.Argument).ConvertTo(inst.Type, this, inst.IsChecked);
	}

	protected internal override TranslatedExpression VisitArglist(Arglist inst, TranslationContext context)
	{
		return new UndocumentedExpression
		{
			UndocumentedExpressionType = UndocumentedExpressionType.ArgListAccess
		}.WithILInstruction(inst).WithRR(new TypeResolveResult(compilation.FindType(new TopLevelTypeName("System", "RuntimeArgumentHandle"))));
	}

	protected internal override TranslatedExpression VisitMakeRefAny(MakeRefAny inst, TranslationContext context)
	{
		Expression expression = Translate(inst.Argument).Expression;
		if (expression is DirectionExpression)
		{
			expression = ((DirectionExpression)expression).Expression;
		}
		return new UndocumentedExpression
		{
			UndocumentedExpressionType = UndocumentedExpressionType.MakeRef,
			Arguments = { expression.Detach() }
		}.WithILInstruction(inst).WithRR(new TypeResolveResult(compilation.FindType(new TopLevelTypeName("System", "TypedReference"))));
	}

	protected internal override TranslatedExpression VisitRefAnyType(RefAnyType inst, TranslationContext context)
	{
		return new MemberReferenceExpression(new UndocumentedExpression
		{
			UndocumentedExpressionType = UndocumentedExpressionType.RefType,
			Arguments = { Translate(inst.Argument).Expression.Detach() }
		}, "TypeHandle").WithILInstruction(inst).WithRR(new TypeResolveResult(compilation.FindType(new TopLevelTypeName("System", "RuntimeTypeHandle"))));
	}

	protected internal override TranslatedExpression VisitRefAnyValue(RefAnyValue inst, TranslationContext context)
	{
		ExpressionWithResolveResult expression = new UndocumentedExpression
		{
			UndocumentedExpressionType = UndocumentedExpressionType.RefValue,
			Arguments = 
			{
				Translate(inst.Argument).Expression,
				(Expression)new TypeReferenceExpression(ConvertType(inst.Type))
			}
		}.WithRR(new ResolveResult(inst.Type));
		return new DirectionExpression(FieldDirection.Ref, expression.WithILInstruction(inst)).WithoutILInstruction().WithRR(new ByReferenceResolveResult(inst.Type, isOut: false));
	}

	protected internal override TranslatedExpression VisitBlock(Block block, TranslationContext context)
	{
		switch (block.Kind)
		{
		case BlockKind.ArrayInitializer:
			return TranslateArrayInitializer(block);
		case BlockKind.StackAllocInitializer:
			return TranslateStackAllocInitializer(block, context.TypeHint);
		case BlockKind.CollectionInitializer:
		case BlockKind.ObjectInitializer:
			return TranslateObjectAndCollectionInitializer(block);
		case BlockKind.PostfixOperator:
			return TranslatePostfixOperator(block);
		case BlockKind.CallInlineAssign:
			return TranslateSetterCallAssignment(block);
		case BlockKind.CallWithNamedArgs:
			return TranslateCallWithNamedArgs(block);
		default:
			return ErrorExpression("Unknown block type: " + block.Kind);
		}
	}

	private TranslatedExpression TranslateCallWithNamedArgs(Block block)
	{
		return WrapInRef(new CallBuilder(this, typeSystem, settings).CallWithNamedArgs(block), ((CallInstruction)block.FinalInstruction).Method.ReturnType);
	}

	private TranslatedExpression TranslateSetterCallAssignment(Block block)
	{
		if (!block.MatchInlineAssignBlock(out var call, out var value))
		{
			return ErrorExpression("Error: MatchInlineAssignBlock() returned false");
		}
		List<ILInstruction> list = Enumerable.ToList<ILInstruction>((IEnumerable<ILInstruction>)call.Arguments);
		list[checked(list.Count - 1)] = value;
		return new CallBuilder(this, typeSystem, settings).Build(call.OpCode, call.Method, list).WithILInstruction(call);
	}

	private TranslatedExpression TranslateObjectAndCollectionInitializer(Block block)
	{
		StLoc stLoc = block.Instructions.FirstOrDefault() as StLoc;
		LdLoc ldLoc = block.FinalInstruction as LdLoc;
		if (stLoc == null || ldLoc == null || stLoc.Variable != ldLoc.Variable || stLoc.Variable.Kind != VariableKind.InitializerTarget)
		{
			throw new ArgumentException("given Block is invalid!");
		}
		ILInstruction value = stLoc.Value;
		ILInstruction iLInstruction = value;
		if (iLInstruction == null)
		{
			goto IL_013c;
		}
		TranslatedExpression expression;
		InitializedObjectResolveResult initializedObjectResolveResult;
		if (!(iLInstruction is NewObj newObj))
		{
			if (!(iLInstruction is DefaultValue defaultValue))
			{
				if (iLInstruction is Block block2)
				{
					Block block3 = block2;
					if (block3.Kind == BlockKind.CallWithNamedArgs)
					{
						expression = TranslateCallWithNamedArgs(block3);
						initializedObjectResolveResult = new InitializedObjectResolveResult(expression.Type);
						goto IL_0147;
					}
				}
				goto IL_013c;
			}
			DefaultValue defaultValue2 = defaultValue;
			initializedObjectResolveResult = new InitializedObjectResolveResult(defaultValue2.Type);
			expression = new ObjectCreateExpression(ConvertType(defaultValue2.Type)).WithILInstruction(defaultValue2).WithRR(new TypeResolveResult(defaultValue2.Type));
		}
		else
		{
			NewObj newObj2 = newObj;
			initializedObjectResolveResult = new InitializedObjectResolveResult(newObj2.Method.DeclaringType);
			expression = new CallBuilder(this, typeSystem, settings).Build(newObj2);
		}
		goto IL_0147;
		IL_0147:
		Stack<List<TranslatedExpression>> val = new Stack<List<TranslatedExpression>>();
		List<TranslatedExpression> list = new List<TranslatedExpression>(block.Instructions.Count);
		val.Push(list);
		List<AccessPathElement> list2 = null;
		Dictionary<ILVariable, ILInstruction> dictionary = new Dictionary<ILVariable, ILInstruction>();
		checked
		{
			foreach (ILInstruction item2 in Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)block.Instructions, 1))
			{
				if (item2 is StLoc stLoc2)
				{
					dictionary.Add(stLoc2.Variable, stLoc2.Value);
					continue;
				}
				(AccessPathKind, List<AccessPathElement>, List<ILInstruction>, ILVariable) accessPath = AccessPathElement.GetAccessPath(item2, initializedObjectResolveResult.Type, settings);
				if (accessPath.Item1 == AccessPathKind.Invalid)
				{
					continue;
				}
				if (list2 == null)
				{
					list2 = accessPath.Item2;
				}
				else
				{
					int num = Math.Min(list2.Count, accessPath.Item2.Count);
					int i;
					for (i = 0; i < num && accessPath.Item2[i] == list2[i]; i++)
					{
					}
					while (val.Count - 1 > i)
					{
						AccessPathElement memberPath = list2[val.Count - 1];
						AccessPathElement valuePath = list2[val.Count - 2];
						List<TranslatedExpression> values = val.Pop();
						val.Peek().Add(MakeInitializerAssignment(initializedObjectResolveResult, memberPath, valuePath, values, dictionary));
					}
					list2 = accessPath.Item2;
				}
				while (val.Count < list2.Count)
				{
					val.Push(new List<TranslatedExpression>());
				}
				AccessPathElement accessPathElement = list2.Last();
				MemberResolveResult memberResolveResult = new MemberResolveResult(initializedObjectResolveResult, accessPathElement.Member);
				switch (accessPath.Item1)
				{
				case AccessPathKind.Adder:
					Debug.Assert(accessPathElement.Member is IMethod);
					val.Peek().Add(new CallBuilder(this, typeSystem, settings).BuildCollectionInitializerExpression(accessPathElement.OpCode, (IMethod)accessPathElement.Member, initializedObjectResolveResult, accessPath.Item3).WithILInstruction(item2));
					break;
				case AccessPathKind.Setter:
				{
					Debug.Assert(accessPathElement.Member is IProperty || accessPathElement.Member is IField);
					ILInstruction[] indices = accessPathElement.Indices;
					if (indices != null && indices.Length != 0)
					{
						IProperty property = (IProperty)accessPathElement.Member;
						Debug.Assert(property.IsIndexer);
						val.Peek().Add(new CallBuilder(this, typeSystem, settings).BuildDictionaryInitializerExpression(accessPathElement.OpCode, property.Setter, initializedObjectResolveResult, Enumerable.ToList<ILInstruction>(GetIndices(accessPathElement.Indices, dictionary)), Enumerable.Single<ILInstruction>((IEnumerable<ILInstruction>)accessPath.Item3)).WithILInstruction(item2));
					}
					else
					{
						TranslatedExpression translatedExpression = Translate(Enumerable.Single<ILInstruction>((IEnumerable<ILInstruction>)accessPath.Item3), memberResolveResult.Type).ConvertTo(memberResolveResult.Type, this, checkForOverflow: false, allowImplicitConversion: true);
						TranslatedExpression item = new NamedExpression(accessPathElement.Member.Name, translatedExpression).WithILInstruction(item2).WithRR(memberResolveResult);
						val.Peek().Add(item);
					}
					break;
				}
				}
			}
			while (val.Count > 1)
			{
				AccessPathElement memberPath2 = list2[val.Count - 1];
				AccessPathElement valuePath2 = list2[val.Count - 2];
				List<TranslatedExpression> values2 = val.Pop();
				val.Peek().Add(MakeInitializerAssignment(initializedObjectResolveResult, memberPath2, valuePath2, values2, dictionary));
			}
			ObjectCreateExpression objectCreateExpression = (ObjectCreateExpression)expression.Expression;
			objectCreateExpression.Initializer = new ArrayInitializerExpression(list.SelectArray((TranslatedExpression e) => e.Expression));
			return expression.WithILInstruction(block);
		}
		IL_013c:
		throw new ArgumentException("given Block is invalid!");
	}

	private IEnumerable<ILInstruction> GetIndices(IEnumerable<ILInstruction> indices, Dictionary<ILVariable, ILInstruction> indexVariables)
	{
		foreach (ILInstruction inst in indices)
		{
			LdLoc ldLoc;
			LdLoc ld = (ldLoc = inst as LdLoc);
			if (ldLoc != null && indexVariables.TryGetValue(ld.Variable, out var newInst))
			{
				yield return newInst;
			}
			else
			{
				yield return inst;
			}
			newInst = null;
		}
	}

	private TranslatedExpression MakeInitializerAssignment(InitializedObjectResolveResult rr, AccessPathElement memberPath, AccessPathElement valuePath, List<TranslatedExpression> values, Dictionary<ILVariable, ILInstruction> indexVariables)
	{
		TranslatedExpression translatedExpression = ((!(memberPath.Member is IMethod { Name: "Add" })) ? ((values.Count != 1 || values[0].Expression is AssignmentExpression || values[0].Expression is NamedExpression) ? new ArrayInitializerExpression(Enumerable.Select<TranslatedExpression, Expression>((IEnumerable<TranslatedExpression>)values, (Func<TranslatedExpression, Expression>)((TranslatedExpression v) => v.Expression))).WithRR(new ResolveResult(SpecialType.UnknownType)).WithoutILInstruction() : values[0]) : new ArrayInitializerExpression(Enumerable.Select<TranslatedExpression, Expression>((IEnumerable<TranslatedExpression>)values, (Func<TranslatedExpression, Expression>)((TranslatedExpression v) => v.Expression))).WithRR(new ResolveResult(SpecialType.UnknownType)).WithoutILInstruction());
		ILInstruction[] indices = valuePath.Indices;
		if (indices == null || indices.Length == 0)
		{
			return new NamedExpression(valuePath.Member.Name, translatedExpression).WithRR(new MemberResolveResult(rr, valuePath.Member)).WithoutILInstruction();
		}
		Expression left = ((!(memberPath.Member is IProperty property)) ? new IndexerExpression(null, Enumerable.Select<ILInstruction, Expression>(GetIndices(valuePath.Indices, indexVariables), (Func<ILInstruction, Expression>)((ILInstruction i) => Translate(i).Expression))) : ((Expression)new CallBuilder(this, typeSystem, settings).BuildDictionaryInitializerExpression(valuePath.OpCode, property.Setter, rr, Enumerable.ToList<ILInstruction>(GetIndices(valuePath.Indices, indexVariables)))));
		return new AssignmentExpression(left, translatedExpression).WithRR(new MemberResolveResult(rr, memberPath.Member)).WithoutILInstruction();
	}

	private TranslatedExpression TranslateArrayInitializer(Block block)
	{
		StLoc stLoc = block.Instructions.FirstOrDefault() as StLoc;
		LdLoc ldLoc = block.FinalInstruction as LdLoc;
		if (stLoc == null || ldLoc == null || !stLoc.Value.MatchNewArr(out var type) || stLoc.Variable != ldLoc.Variable || stLoc.Variable.Kind != VariableKind.InitializerTarget)
		{
			throw new ArgumentException("given Block is invalid!");
		}
		NewArr newArr = (NewArr)stLoc.Value;
		TranslatedExpression[] array = Enumerable.ToArray<TranslatedExpression>(Enumerable.Select<ILInstruction, TranslatedExpression>((IEnumerable<ILInstruction>)newArr.Indices, (Func<ILInstruction, TranslatedExpression>)((ILInstruction i) => Translate(i))));
		if (!array.All((TranslatedExpression dim) => dim.ResolveResult.IsCompileTimeConstant))
		{
			throw new ArgumentException("given Block is invalid!");
		}
		int count = newArr.Indices.Count;
		int[] array2 = Enumerable.ToArray<int>(Enumerable.Select<TranslatedExpression, int>((IEnumerable<TranslatedExpression>)array, (Func<TranslatedExpression, int>)((TranslatedExpression dim) => (int)dim.ResolveResult.ConstantValue)));
		Stack<ArrayInitializer> val = new Stack<ArrayInitializer>();
		ArrayInitializer arrayInitializer = new ArrayInitializer(new ArrayInitializerExpression());
		val.Push(arrayInitializer);
		List<ResolveResult> list = new List<ResolveResult>();
		checked
		{
			for (int num = 1; num < block.Instructions.Count; num++)
			{
				if (!block.Instructions[num].MatchStObj(out var target, out var value, out var type2) || !type.Equals(type2))
				{
					throw new ArgumentException("given Block is invalid!");
				}
				if (!target.MatchLdElema(out type2, out var array3) || !type.Equals(type2))
				{
					throw new ArgumentException("given Block is invalid!");
				}
				if (!array3.MatchLdLoc(out var variable) || variable != ldLoc.Variable)
				{
					throw new ArgumentException("given Block is invalid!");
				}
				while (val.Count < count)
				{
					ArrayInitializerExpression arrayInitializerExpression = new ArrayInitializerExpression();
					ArrayInitializer arrayInitializer2 = val.Peek();
					if (arrayInitializer2.CurrentElementCount > 0)
					{
						arrayInitializer2.Expression.AddChild(new CSharpTokenNode(TextLocation.Empty, Roles.Comma), Roles.Comma);
					}
					arrayInitializer2.Expression.Elements.Add(arrayInitializerExpression);
					arrayInitializer2.CurrentElementCount++;
					val.Push(new ArrayInitializer(arrayInitializerExpression));
				}
				bool useSpecialConstants = astBuilder.UseSpecialConstants;
				TranslatedExpression translatedExpression;
				try
				{
					astBuilder.UseSpecialConstants = !type.IsCSharpPrimitiveIntegerType() && !type.IsKnownType(KnownTypeCode.Decimal);
					translatedExpression = Translate(value, type).ConvertTo(type, this, checkForOverflow: false, allowImplicitConversion: true);
				}
				finally
				{
					astBuilder.UseSpecialConstants = useSpecialConstants;
				}
				ArrayInitializer arrayInitializer3 = val.Peek();
				if (arrayInitializer3.CurrentElementCount > 0)
				{
					arrayInitializer3.Expression.AddChild(new CSharpTokenNode(TextLocation.Empty, Roles.Comma), Roles.Comma);
				}
				arrayInitializer3.Expression.Elements.Add(translatedExpression);
				arrayInitializer3.CurrentElementCount++;
				list.Add(translatedExpression.ResolveResult);
				while (val.Count > 0 && val.Peek().CurrentElementCount == array2[val.Count - 1])
				{
					val.Pop();
				}
			}
			AstType astType;
			ArraySpecifier[] nodes;
			if (settings.AnonymousTypes && type.ContainsAnonymousType())
			{
				astType = null;
				nodes = new ArraySpecifier[1]
				{
					new ArraySpecifier()
				};
			}
			else
			{
				astType = ConvertType(type);
				if (astType is ComposedType composedType && composedType.ArraySpecifiers.Count > 0)
				{
					nodes = Enumerable.ToArray<ArraySpecifier>(Enumerable.Select<ArraySpecifier, ArraySpecifier>((IEnumerable<ArraySpecifier>)composedType.ArraySpecifiers, (Func<ArraySpecifier, ArraySpecifier>)((ArraySpecifier a) => (ArraySpecifier)a.Clone())));
					composedType.ArraySpecifiers.Clear();
				}
				else
				{
					nodes = Empty<ArraySpecifier>.Array;
				}
			}
			ArrayCreateExpression arrayCreateExpression = new ArrayCreateExpression
			{
				Type = astType,
				Initializer = arrayInitializer.Expression
			};
			arrayCreateExpression.AdditionalArraySpecifiers.AddRange(nodes);
			if (!type.ContainsAnonymousType())
			{
				arrayCreateExpression.Arguments.AddRange(Enumerable.Select<ILInstruction, Expression>((IEnumerable<ILInstruction>)newArr.Indices, (Func<ILInstruction, Expression>)((ILInstruction i) => Translate(i).Expression)));
			}
			return arrayCreateExpression.WithILInstruction(block).WithRR(new ArrayCreateResolveResult(new ArrayType(compilation, type, count), Enumerable.ToArray<ResolveResult>(Enumerable.Select<ILInstruction, ResolveResult>((IEnumerable<ILInstruction>)newArr.Indices, (Func<ILInstruction, ResolveResult>)((ILInstruction i) => Translate(i).ResolveResult))), list));
		}
	}

	private TranslatedExpression TranslateStackAllocInitializer(Block block, IType typeHint)
	{
		StLoc stLoc = block.Instructions.FirstOrDefault() as StLoc;
		LdLoc ldLoc = block.FinalInstruction as LdLoc;
		if (stLoc == null || ldLoc == null || stLoc.Variable != ldLoc.Variable || stLoc.Variable.Kind != VariableKind.InitializerTarget)
		{
			throw new ArgumentException("given Block is invalid!");
		}
		if (block.Instructions.Count < 2 || !block.Instructions[1].MatchStObj(out var _, out var _, out var type))
		{
			throw new ArgumentException("given Block is invalid!");
		}
		if (typeHint is PointerType pointerType && !TypeUtils.IsCompatibleTypeForMemoryAccess(type, pointerType.ElementType))
		{
			typeHint = new PointerType(type);
		}
		ILInstruction value2 = stLoc.Value;
		ILInstruction iLInstruction = value2;
		if (iLInstruction == null)
		{
			goto IL_011b;
		}
		StackAllocExpression stackAllocExpression;
		IType elementType;
		if (!(iLInstruction is LocAlloc locAlloc))
		{
			if (!(iLInstruction is LocAllocSpan locAllocSpan))
			{
				goto IL_011b;
			}
			LocAllocSpan inst = locAllocSpan;
			stackAllocExpression = TranslateLocAllocSpan(inst, typeHint, out elementType);
		}
		else
		{
			LocAlloc inst2 = locAlloc;
			stackAllocExpression = TranslateLocAlloc(inst2, typeHint, out elementType);
		}
		ArrayInitializerExpression arrayInitializerExpression = (stackAllocExpression.Initializer = new ArrayInitializerExpression());
		ArrayInitializerExpression arrayInitializerExpression3 = arrayInitializerExpression;
		PointerType pointerType2 = new PointerType(elementType);
		long num = 0L;
		checked
		{
			for (int i = 1; i < block.Instructions.Count; i++)
			{
				if (!block.Instructions[i].MatchStObj(out var target2, out var value3, out type) || !TypeUtils.IsCompatibleTypeForMemoryAccess(elementType, type))
				{
					throw new ArgumentException("given Block is invalid!");
				}
				long val = 0L;
				target2 = target2.UnwrapConv(ConversionKind.StopGCTracking);
				if (!target2.MatchLdLoc(stLoc.Variable))
				{
					if (!target2.MatchBinaryNumericInstruction(BinaryNumericOperator.Add, out var left, out var right))
					{
						throw new ArgumentException("given Block is invalid!");
					}
					BinaryNumericInstruction binaryNumericInstruction = (BinaryNumericInstruction)target2;
					left = left.UnwrapConv(ConversionKind.StopGCTracking);
					ILInstruction iLInstruction2 = PointerArithmeticOffset.Detect(right, pointerType2, binaryNumericInstruction.CheckForOverflow);
					if (!left.MatchLdLoc(ldLoc.Variable) || iLInstruction2 == null)
					{
						throw new ArgumentException("given Block is invalid!");
					}
					if (!iLInstruction2.MatchLdcI(out val))
					{
						throw new ArgumentException("given Block is invalid!");
					}
				}
				for (; num < val; num++)
				{
					arrayInitializerExpression3.Elements.Add(Translate(TransformArrayInitializers.GetNullExpression(elementType), elementType));
				}
				TranslatedExpression translatedExpression = Translate(value3, elementType).ConvertTo(elementType, this, checkForOverflow: false, allowImplicitConversion: true);
				arrayInitializerExpression3.Elements.Add(translatedExpression);
				num++;
			}
			return stackAllocExpression.WithILInstruction(block).WithRR(new ResolveResult(stLoc.Variable.Type));
		}
		IL_011b:
		throw new ArgumentException("given Block is invalid!");
	}

	private TranslatedExpression TranslatePostfixOperator(Block block)
	{
		ILInstruction iLInstruction = (block.Instructions.ElementAtOrDefault(0) as StLoc)?.Value;
		BinaryNumericInstruction binaryNumericInstruction = (block.Instructions.ElementAtOrDefault(1) as StLoc)?.Value as BinaryNumericInstruction;
		if (iLInstruction == null || binaryNumericInstruction == null || (binaryNumericInstruction.Operator != BinaryNumericOperator.Add && binaryNumericInstruction.Operator != BinaryNumericOperator.Sub))
		{
			throw new ArgumentException("given Block is invalid!");
		}
		UnaryOperatorType op = ((binaryNumericInstruction.Operator == BinaryNumericOperator.Add) ? UnaryOperatorType.PostIncrement : UnaryOperatorType.PostDecrement);
		TranslatedExpression translatedExpression = Translate(iLInstruction);
		return new UnaryOperatorExpression(op, translatedExpression).WithILInstruction(block).WithRR(resolver.WithCheckForOverflow(binaryNumericInstruction.CheckForOverflow).ResolveUnaryOperator(op, translatedExpression.ResolveResult));
	}

	private TranslatedExpression AdjustConstantExpressionToType(TranslatedExpression expr, IType typeHint)
	{
		ResolveResult resolveResult = AdjustConstantToType(expr.ResolveResult, typeHint);
		if (resolveResult == expr.ResolveResult)
		{
			return expr;
		}
		return ConvertConstantValue(resolveResult, allowImplicitConversion: true).WithILInstruction(expr.ILInstructions);
	}

	private ResolveResult AdjustConstantToType(ResolveResult rr, IType typeHint)
	{
		if (!rr.IsCompileTimeConstant)
		{
			return rr;
		}
		typeHint = NullableType.GetUnderlyingType(typeHint);
		if (rr.Type.Equals(typeHint))
		{
			return rr;
		}
		if (typeHint.IsKnownType(KnownTypeCode.Boolean))
		{
			if (object.Equals(rr.ConstantValue, 0) || object.Equals(rr.ConstantValue, 0u))
			{
				rr = new ConstantResolveResult(typeHint, false);
			}
			else if (object.Equals(rr.ConstantValue, 1) || object.Equals(rr.ConstantValue, 1u))
			{
				rr = new ConstantResolveResult(typeHint, true);
			}
		}
		else if (typeHint.Kind == TypeKind.Enum || typeHint.IsKnownType(KnownTypeCode.Char) || typeHint.IsCSharpSmallIntegerType())
		{
			ResolveResult resolveResult = resolver.WithCheckForOverflow(checkForOverflow: true).ResolveCast(typeHint, rr);
			if (resolveResult.IsCompileTimeConstant && !resolveResult.IsError)
			{
				rr = resolveResult;
			}
		}
		return rr;
	}

	protected internal override TranslatedExpression VisitNullCoalescingInstruction(NullCoalescingInstruction inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.ValueInst);
		TranslatedExpression expr = Translate(inst.FallbackInst);
		expr = AdjustConstantExpressionToType(expr, translatedExpression.Type);
		ResolveResult resolveResult = resolver.ResolveBinaryOperator(BinaryOperatorType.NullCoalescing, translatedExpression.ResolveResult, expr.ResolveResult);
		if (resolveResult.IsError)
		{
			IType type = ((translatedExpression.Type.Equals(SpecialType.NullType) || expr.Type.Equals(SpecialType.NullType) || translatedExpression.Type.Equals(expr.Type)) ? (translatedExpression.Type.Equals(SpecialType.NullType) ? expr.Type : translatedExpression.Type) : compilation.FindType(inst.UnderlyingResultType.ToKnownTypeCode()));
			translatedExpression = ((inst.Kind == NullCoalescingKind.Ref) ? translatedExpression.ConvertTo(type, this) : translatedExpression.ConvertTo(NullableType.Create(compilation, type), this));
			if (inst.Kind == NullCoalescingKind.Nullable)
			{
				translatedExpression = translatedExpression.ConvertTo(NullableType.Create(compilation, type), this);
			}
			else
			{
				expr = expr.ConvertTo(type, this);
			}
			resolveResult = new ResolveResult(type);
		}
		return new BinaryOperatorExpression(translatedExpression, BinaryOperatorType.NullCoalescing, expr).WithILInstruction(inst).WithRR(resolveResult);
	}

	protected internal override TranslatedExpression VisitIfInstruction(IfInstruction inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = TranslateCondition(inst.Condition);
		TranslatedExpression translatedExpression2 = Translate(inst.TrueInst, context.TypeHint);
		TranslatedExpression translatedExpression3 = Translate(inst.FalseInst, context.TypeHint);
		BinaryOperatorType binaryOperatorType = BinaryOperatorType.Any;
		TranslatedExpression translatedExpression4 = default(TranslatedExpression);
		if (inst.MatchLogicAnd(out var lhs, out var rhs) && !rhs.MatchLdcI4(1))
		{
			binaryOperatorType = BinaryOperatorType.ConditionalAnd;
			Debug.Assert(rhs == inst.TrueInst);
			translatedExpression4 = translatedExpression2;
		}
		else if (inst.MatchLogicOr(out lhs, out rhs) && !rhs.MatchLdcI4(0))
		{
			binaryOperatorType = BinaryOperatorType.ConditionalOr;
			Debug.Assert(rhs == inst.FalseInst);
			translatedExpression4 = translatedExpression3;
		}
		if (binaryOperatorType != BinaryOperatorType.Any && (translatedExpression4.Type.IsKnownType(KnownTypeCode.Boolean) || IfInstruction.IsInConditionSlot(inst)))
		{
			translatedExpression4 = translatedExpression4.ConvertToBoolean(this);
			return new BinaryOperatorExpression(translatedExpression, binaryOperatorType, translatedExpression4).WithILInstruction(inst).WithRR(new ResolveResult(compilation.FindType(KnownTypeCode.Boolean)));
		}
		translatedExpression = translatedExpression.UnwrapImplicitBoolConversion();
		translatedExpression2 = AdjustConstantExpressionToType(translatedExpression2, translatedExpression3.Type);
		translatedExpression3 = AdjustConstantExpressionToType(translatedExpression3, translatedExpression2.Type);
		ResolveResult resolveResult = resolver.ResolveConditional(translatedExpression.ResolveResult, translatedExpression2.ResolveResult, translatedExpression3.ResolveResult);
		if (resolveResult.IsError)
		{
			IType type;
			if (!translatedExpression2.Type.Equals(SpecialType.NullType) && !translatedExpression3.Type.Equals(SpecialType.NullType) && !translatedExpression2.Type.Equals(translatedExpression3.Type))
			{
				type = typeInference.GetBestCommonType(new ResolveResult[2] { translatedExpression2.ResolveResult, translatedExpression3.ResolveResult }, out var success);
				if (!success || type.GetStackType() != inst.ResultType)
				{
					type = ((inst.ResultType != StackType.Ref) ? compilation.FindType(inst.ResultType.ToKnownTypeCode()) : ((translatedExpression2.Type.Kind == TypeKind.ByReference) ? translatedExpression2.Type : ((translatedExpression3.Type.Kind != TypeKind.ByReference) ? new ByReferenceType(compilation.FindType(KnownTypeCode.Byte)) : translatedExpression3.Type)));
				}
			}
			else
			{
				type = (translatedExpression2.Type.Equals(SpecialType.NullType) ? translatedExpression3.Type : translatedExpression2.Type);
			}
			translatedExpression2 = translatedExpression2.ConvertTo(type, this);
			translatedExpression3 = translatedExpression3.ConvertTo(type, this);
			resolveResult = new ResolveResult(type);
		}
		if (resolveResult.Type.Kind == TypeKind.ByReference)
		{
			ResolveResult resolveResult2 = new ResolveResult(((ByReferenceType)resolveResult.Type).ElementType);
			return new DirectionExpression(FieldDirection.Ref, new ConditionalExpression(translatedExpression.Expression, translatedExpression2.Expression, translatedExpression3.Expression).WithILInstruction(inst).WithRR(resolveResult2)).WithoutILInstruction().WithRR(new ByReferenceResolveResult(resolveResult2, isOut: false));
		}
		return new ConditionalExpression(translatedExpression.Expression, translatedExpression2.Expression, translatedExpression3.Expression).WithILInstruction(inst).WithRR(resolveResult);
	}

	protected internal override TranslatedExpression VisitAddressOf(AddressOf inst, TranslationContext context)
	{
		IType typeHint = null;
		if (context.TypeHint is ByReferenceType byReferenceType)
		{
			typeHint = byReferenceType.ElementType;
		}
		else if (context.TypeHint is PointerType pointerType)
		{
			typeHint = pointerType.ElementType;
		}
		TranslatedExpression translatedExpression = Translate(inst.Value, typeHint);
		return new DirectionExpression(FieldDirection.Ref, translatedExpression).WithILInstruction(inst).WithRR(new ByReferenceResolveResult(translatedExpression.ResolveResult, isOut: false));
	}

	protected internal override TranslatedExpression VisitAwait(Await inst, TranslationContext context)
	{
		IType type = null;
		if (inst.GetAwaiterMethod != null)
		{
			type = ((!inst.GetAwaiterMethod.IsStatic) ? inst.GetAwaiterMethod.DeclaringType : Enumerable.FirstOrDefault<IParameter>((IEnumerable<IParameter>)inst.GetAwaiterMethod.Parameters)?.Type);
		}
		TranslatedExpression translatedExpression = Translate(inst.Value, type);
		if (translatedExpression.Expression is DirectionExpression)
		{
			translatedExpression = translatedExpression.UnwrapChild(((DirectionExpression)translatedExpression.Expression).Expression);
		}
		if (type != null)
		{
			translatedExpression = translatedExpression.ConvertTo(type, this, checkForOverflow: false, allowImplicitConversion: true);
		}
		return new UnaryOperatorExpression(UnaryOperatorType.Await, translatedExpression.Expression).WithILInstruction(inst).WithRR(new ResolveResult(inst.GetResultMethod?.ReturnType ?? SpecialType.UnknownType));
	}

	protected internal override TranslatedExpression VisitNullableRewrap(NullableRewrap inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Argument);
		IType type = translatedExpression.Type;
		if (NullableType.IsNonNullableValueType(type))
		{
			type = NullableType.Create(compilation, type);
		}
		return new UnaryOperatorExpression(UnaryOperatorType.NullConditionalRewrap, translatedExpression).WithILInstruction(inst).WithRR(new ResolveResult(type));
	}

	protected internal override TranslatedExpression VisitNullableUnwrap(NullableUnwrap inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Argument);
		if (inst.RefInput && !inst.RefOutput && translatedExpression.Expression is DirectionExpression directionExpression)
		{
			translatedExpression = translatedExpression.UnwrapChild(directionExpression.Expression);
		}
		return new UnaryOperatorExpression(UnaryOperatorType.NullConditional, translatedExpression).WithILInstruction(inst).WithRR(new ResolveResult(NullableType.GetUnderlyingType(translatedExpression.Type)));
	}

	protected internal override TranslatedExpression VisitDynamicConvertInstruction(DynamicConvertInstruction inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = Translate(inst.Argument).ConvertTo(SpecialType.Dynamic, this);
		TranslatedExpression result = new CastExpression(ConvertType(inst.Type), translatedExpression).WithILInstruction(inst).WithRR(new ConversionResolveResult(inst.Type, translatedExpression.ResolveResult, inst.IsExplicit ? Conversion.ExplicitDynamicConversion : Conversion.ImplicitDynamicConversion));
		result.Expression.AddAnnotation(inst.IsChecked ? AddCheckedBlocks.CheckedAnnotation : AddCheckedBlocks.UncheckedAnnotation);
		return result;
	}

	protected internal override TranslatedExpression VisitDynamicGetIndexInstruction(DynamicGetIndexInstruction inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = TranslateDynamicTarget(inst.Arguments[0], inst.ArgumentInfo[0]);
		List<TranslatedExpression> list = Enumerable.ToList<TranslatedExpression>(TranslateDynamicArguments(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)inst.Arguments, 1), Enumerable.Skip<CSharpArgumentInfo>((IEnumerable<CSharpArgumentInfo>)inst.ArgumentInfo, 1)));
		return new IndexerExpression(translatedExpression, Enumerable.Select<TranslatedExpression, Expression>((IEnumerable<TranslatedExpression>)list, (Func<TranslatedExpression, Expression>)((TranslatedExpression a) => a.Expression))).WithILInstruction(inst).WithRR(new DynamicInvocationResolveResult(translatedExpression.ResolveResult, DynamicInvocationType.Indexing, Enumerable.ToArray<ResolveResult>(Enumerable.Select<TranslatedExpression, ResolveResult>((IEnumerable<TranslatedExpression>)list, (Func<TranslatedExpression, ResolveResult>)((TranslatedExpression a) => a.ResolveResult)))));
	}

	protected internal override TranslatedExpression VisitDynamicGetMemberInstruction(DynamicGetMemberInstruction inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = TranslateDynamicTarget(inst.Target, inst.TargetArgumentInfo);
		return new MemberReferenceExpression(translatedExpression, inst.Name).WithILInstruction(inst).WithRR(new DynamicMemberResolveResult(translatedExpression.ResolveResult, inst.Name));
	}

	protected internal override TranslatedExpression VisitDynamicInvokeConstructorInstruction(DynamicInvokeConstructorInstruction inst, TranslationContext context)
	{
		if (!inst.ArgumentInfo[0].HasFlag(CSharpArgumentInfoFlags.IsStaticType) || !TransformExpressionTrees.MatchGetTypeFromHandle(inst.Arguments[0], out var type))
		{
			return ErrorExpression("Could not detect static type for DynamicInvokeConstructorInstruction");
		}
		List<TranslatedExpression> list = Enumerable.ToList<TranslatedExpression>(TranslateDynamicArguments(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)inst.Arguments, 1), Enumerable.Skip<CSharpArgumentInfo>((IEnumerable<CSharpArgumentInfo>)inst.ArgumentInfo, 1)));
		return new ObjectCreateExpression(ConvertType(type), Enumerable.Select<TranslatedExpression, Expression>((IEnumerable<TranslatedExpression>)list, (Func<TranslatedExpression, Expression>)((TranslatedExpression a) => a.Expression))).WithILInstruction(inst).WithRR(new ResolveResult(type));
	}

	protected internal override TranslatedExpression VisitDynamicInvokeMemberInstruction(DynamicInvokeMemberInstruction inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = TranslateDynamicTarget(inst.Arguments[0], inst.ArgumentInfo[0]);
		List<TranslatedExpression> list = Enumerable.ToList<TranslatedExpression>(TranslateDynamicArguments(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)inst.Arguments, 1), Enumerable.Skip<CSharpArgumentInfo>((IEnumerable<CSharpArgumentInfo>)inst.ArgumentInfo, 1)));
		return new InvocationExpression(new MemberReferenceExpression(translatedExpression, inst.Name, Enumerable.Select<IType, AstType>((IEnumerable<IType>)inst.TypeArguments, (Func<IType, AstType>)ConvertType)), Enumerable.Select<TranslatedExpression, Expression>((IEnumerable<TranslatedExpression>)list, (Func<TranslatedExpression, Expression>)((TranslatedExpression a) => a.Expression))).WithILInstruction(inst).WithRR(new DynamicInvocationResolveResult(translatedExpression.ResolveResult, DynamicInvocationType.Invocation, Enumerable.ToArray<ResolveResult>(Enumerable.Select<TranslatedExpression, ResolveResult>((IEnumerable<TranslatedExpression>)list, (Func<TranslatedExpression, ResolveResult>)((TranslatedExpression a) => a.ResolveResult)))));
	}

	protected internal override TranslatedExpression VisitDynamicInvokeInstruction(DynamicInvokeInstruction inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = TranslateDynamicTarget(inst.Arguments[0], inst.ArgumentInfo[0]);
		List<TranslatedExpression> list = Enumerable.ToList<TranslatedExpression>(TranslateDynamicArguments(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)inst.Arguments, 1), Enumerable.Skip<CSharpArgumentInfo>((IEnumerable<CSharpArgumentInfo>)inst.ArgumentInfo, 1)));
		return new InvocationExpression(translatedExpression, Enumerable.Select<TranslatedExpression, Expression>((IEnumerable<TranslatedExpression>)list, (Func<TranslatedExpression, Expression>)((TranslatedExpression a) => a.Expression))).WithILInstruction(inst).WithRR(new DynamicInvocationResolveResult(translatedExpression.ResolveResult, DynamicInvocationType.Invocation, Enumerable.ToArray<ResolveResult>(Enumerable.Select<TranslatedExpression, ResolveResult>((IEnumerable<TranslatedExpression>)list, (Func<TranslatedExpression, ResolveResult>)((TranslatedExpression a) => a.ResolveResult)))));
	}

	private TranslatedExpression TranslateDynamicTarget(ILInstruction inst, CSharpArgumentInfo argumentInfo)
	{
		Debug.Assert(!argumentInfo.HasFlag(CSharpArgumentInfoFlags.NamedArgument));
		Debug.Assert(!argumentInfo.HasFlag(CSharpArgumentInfoFlags.IsOut));
		Debug.Assert(!argumentInfo.HasFlag(CSharpArgumentInfoFlags.Constant));
		if (argumentInfo.HasFlag(CSharpArgumentInfoFlags.IsStaticType) && TransformExpressionTrees.MatchGetTypeFromHandle(inst, out var type))
		{
			return new TypeReferenceExpression(ConvertType(type)).WithoutILInstruction().WithRR(new TypeResolveResult(type));
		}
		IType type2 = SpecialType.Dynamic;
		if (argumentInfo.HasFlag(CSharpArgumentInfoFlags.UseCompileTimeType))
		{
			type2 = argumentInfo.CompileTimeType;
		}
		TranslatedExpression translatedExpression = Translate(inst, type2).ConvertTo(type2, this);
		if (argumentInfo.HasFlag(CSharpArgumentInfoFlags.IsRef) && translatedExpression.Expression is DirectionExpression)
		{
			translatedExpression = translatedExpression.UnwrapChild(((DirectionExpression)(Expression)translatedExpression).Expression);
		}
		return translatedExpression;
	}

	private IEnumerable<TranslatedExpression> TranslateDynamicArguments(IEnumerable<ILInstruction> arguments, IEnumerable<CSharpArgumentInfo> argumentInfo)
	{
		foreach (var (argument, info) in arguments.Zip(argumentInfo))
		{
			yield return TranslateDynamicArgument(argument, info);
		}
	}

	private TranslatedExpression TranslateDynamicArgument(ILInstruction argument, CSharpArgumentInfo info)
	{
		Debug.Assert(!info.HasFlag(CSharpArgumentInfoFlags.IsStaticType));
		IType type = SpecialType.Dynamic;
		if (info.HasFlag(CSharpArgumentInfoFlags.UseCompileTimeType))
		{
			type = info.CompileTimeType;
		}
		TranslatedExpression translatedExpression = Translate(argument, type);
		if (!type.Equals(SpecialType.Dynamic) || !translatedExpression.Type.Equals(SpecialType.NullType))
		{
			translatedExpression = translatedExpression.ConvertTo(type, this);
		}
		if (info.HasFlag(CSharpArgumentInfoFlags.IsOut))
		{
			translatedExpression = ChangeDirectionExpressionToOut(translatedExpression);
		}
		if (info.HasFlag(CSharpArgumentInfoFlags.NamedArgument) && !string.IsNullOrWhiteSpace(info.Name))
		{
			translatedExpression = new TranslatedExpression(new NamedArgumentExpression(info.Name, translatedExpression.Expression));
		}
		return translatedExpression;
	}

	internal static TranslatedExpression ChangeDirectionExpressionToOut(TranslatedExpression input)
	{
		if (!(input.Expression is DirectionExpression directionExpression) || !(input.ResolveResult is ByReferenceResolveResult byReferenceResolveResult))
		{
			return input;
		}
		directionExpression.FieldDirection = FieldDirection.Out;
		directionExpression.RemoveAnnotations<ByReferenceResolveResult>();
		ByReferenceResolveResult annotation = ((byReferenceResolveResult.ElementResult != null) ? new ByReferenceResolveResult(byReferenceResolveResult.ElementResult, isOut: true) : new ByReferenceResolveResult(byReferenceResolveResult.ElementType, isOut: true));
		directionExpression.AddAnnotation(annotation);
		return new TranslatedExpression(directionExpression);
	}

	protected internal override TranslatedExpression VisitDynamicSetIndexInstruction(DynamicSetIndexInstruction inst, TranslationContext context)
	{
		Debug.Assert(inst.Arguments.Count >= 3);
		TranslatedExpression translatedExpression = TranslateDynamicTarget(inst.Arguments[0], inst.ArgumentInfo[0]);
		List<TranslatedExpression> list = Enumerable.ToList<TranslatedExpression>(TranslateDynamicArguments(Enumerable.Skip<ILInstruction>((IEnumerable<ILInstruction>)inst.Arguments, 1), Enumerable.Skip<CSharpArgumentInfo>((IEnumerable<CSharpArgumentInfo>)inst.ArgumentInfo, 1)));
		TranslatedExpression right = new TranslatedExpression(list.Last());
		TranslatedExpression left = new IndexerExpression(translatedExpression, Enumerable.Select<TranslatedExpression, Expression>(list.SkipLast(1), (Func<TranslatedExpression, Expression>)((TranslatedExpression a) => a.Expression))).WithoutILInstruction().WithRR(new DynamicInvocationResolveResult(translatedExpression.ResolveResult, DynamicInvocationType.Indexing, Enumerable.ToArray<ResolveResult>(Enumerable.Select<TranslatedExpression, ResolveResult>(list.SkipLast(1), (Func<TranslatedExpression, ResolveResult>)((TranslatedExpression a) => a.ResolveResult)))));
		return Assignment(left, right).WithILInstruction(inst);
	}

	protected internal override TranslatedExpression VisitDynamicSetMemberInstruction(DynamicSetMemberInstruction inst, TranslationContext context)
	{
		TranslatedExpression translatedExpression = TranslateDynamicTarget(inst.Target, inst.TargetArgumentInfo);
		TranslatedExpression right = TranslateDynamicArgument(inst.Value, inst.ValueArgumentInfo);
		TranslatedExpression left = new MemberReferenceExpression(translatedExpression, inst.Name).WithoutILInstruction().WithRR(new DynamicMemberResolveResult(translatedExpression.ResolveResult, inst.Name));
		return Assignment(left, right).WithILInstruction(inst);
	}

	protected internal override TranslatedExpression VisitDynamicBinaryOperatorInstruction(DynamicBinaryOperatorInstruction inst, TranslationContext context)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected I4, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected I4, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Expected I4, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected I4, but got Unknown
		ExpressionBuilder expressionBuilder = this;
		DynamicBinaryOperatorInstruction inst2 = inst;
		ExpressionType operation = inst2.Operation;
		if ((int)operation <= 36)
		{
			switch ((int)operation)
			{
			case 0:
				goto IL_0108;
			case 1:
				goto IL_0138;
			case 2:
				goto IL_029c;
			}
			switch ((int)operation - 12)
			{
			case 14:
				break;
			case 15:
				goto IL_01c4;
			case 0:
				goto IL_01da;
			case 13:
				goto IL_01f3;
			case 1:
				return CreateBinaryOperator(BinaryOperatorType.Equality, null);
			case 23:
				return CreateBinaryOperator(BinaryOperatorType.InEquality, null);
			case 8:
				return CreateBinaryOperator(BinaryOperatorType.LessThan, null);
			case 9:
				return CreateBinaryOperator(BinaryOperatorType.LessThanOrEqual, null);
			case 3:
				return CreateBinaryOperator(BinaryOperatorType.GreaterThan, null);
			case 4:
				return CreateBinaryOperator(BinaryOperatorType.GreaterThanOrEqual, null);
			case 24:
				goto IL_02b1;
			case 2:
				goto IL_02c6;
			case 7:
				goto IL_02db;
			default:
				goto IL_0307;
			}
			goto IL_0194;
		}
		switch ((int)operation - 41)
		{
		case 1:
			goto IL_014e;
		case 2:
			goto IL_017e;
		case 0:
			goto IL_02f1;
		}
		switch ((int)operation - 63)
		{
		case 0:
			break;
		case 11:
			goto IL_0138;
		case 10:
			goto IL_014e;
		case 13:
			goto IL_017e;
		case 6:
			goto IL_0194;
		case 12:
			goto IL_01c4;
		case 2:
			goto IL_01da;
		case 5:
			goto IL_01f3;
		case 1:
			goto IL_029c;
		case 7:
			goto IL_02b1;
		case 3:
			goto IL_02c6;
		case 4:
			goto IL_02db;
		case 9:
			goto IL_02f1;
		default:
			goto IL_0307;
		}
		goto IL_0108;
		IL_02db:
		return CreateBinaryOperator(BinaryOperatorType.ShiftLeft, null);
		IL_0194:
		return CreateBinaryOperator(BinaryOperatorType.Multiply, inst2.BinderFlags.HasFlag(CSharpBinderFlags.CheckedContext));
		IL_02f1:
		return CreateBinaryOperator(BinaryOperatorType.ShiftRight, null);
		IL_014e:
		return CreateBinaryOperator(BinaryOperatorType.Subtract, inst2.BinderFlags.HasFlag(CSharpBinderFlags.CheckedContext));
		IL_017e:
		return CreateBinaryOperator(BinaryOperatorType.Subtract, true);
		IL_0307:
		return base.VisitDynamicBinaryOperatorInstruction(inst2, context);
		IL_0108:
		return CreateBinaryOperator(BinaryOperatorType.Add, inst2.BinderFlags.HasFlag(CSharpBinderFlags.CheckedContext));
		IL_0138:
		return CreateBinaryOperator(BinaryOperatorType.Add, true);
		IL_029c:
		return CreateBinaryOperator(BinaryOperatorType.BitwiseAnd, null);
		IL_01c4:
		return CreateBinaryOperator(BinaryOperatorType.Multiply, true);
		IL_01da:
		return CreateBinaryOperator(BinaryOperatorType.Divide, null);
		IL_01f3:
		return CreateBinaryOperator(BinaryOperatorType.Modulus, null);
		IL_02c6:
		return CreateBinaryOperator(BinaryOperatorType.ExclusiveOr, null);
		IL_02b1:
		return CreateBinaryOperator(BinaryOperatorType.BitwiseOr, null);
		TranslatedExpression CreateBinaryOperator(BinaryOperatorType operatorType, bool? isChecked)
		{
			TranslatedExpression translatedExpression = TranslateDynamicArgument(inst2.Left, inst2.LeftArgumentInfo);
			TranslatedExpression translatedExpression2 = TranslateDynamicArgument(inst2.Right, inst2.RightArgumentInfo);
			BinaryOperatorExpression binaryOperatorExpression = new BinaryOperatorExpression(translatedExpression.Expression, operatorType, translatedExpression2.Expression);
			if (isChecked == true)
			{
				binaryOperatorExpression.AddAnnotation(AddCheckedBlocks.CheckedAnnotation);
			}
			else if (isChecked == false)
			{
				binaryOperatorExpression.AddAnnotation(AddCheckedBlocks.UncheckedAnnotation);
			}
			return binaryOperatorExpression.WithILInstruction(inst2).WithRR(new ResolveResult(SpecialType.Dynamic));
		}
	}

	protected internal override TranslatedExpression VisitDynamicLogicOperatorInstruction(DynamicLogicOperatorInstruction inst, TranslationContext context)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		BinaryOperatorType op;
		if ((int)inst.Operation == 3)
		{
			op = BinaryOperatorType.ConditionalAnd;
		}
		else
		{
			if ((int)inst.Operation != 37)
			{
				Debug.Fail("Unknown operation for DynamicLogicOperatorInstruction");
				return base.VisitDynamicLogicOperatorInstruction(inst, context);
			}
			op = BinaryOperatorType.ConditionalOr;
		}
		TranslatedExpression translatedExpression = TranslateDynamicArgument(inst.Left, inst.LeftArgumentInfo);
		TranslatedExpression translatedExpression2 = TranslateDynamicArgument(inst.Right, inst.RightArgumentInfo);
		BinaryOperatorExpression expression = new BinaryOperatorExpression(translatedExpression.Expression, op, translatedExpression2.Expression);
		return expression.WithILInstruction(inst).WithRR(new ResolveResult(SpecialType.Dynamic));
	}

	protected internal override TranslatedExpression VisitDynamicUnaryOperatorInstruction(DynamicUnaryOperatorInstruction inst, TranslationContext context)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected I4, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Invalid comparison between Unknown and I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		ExpressionType operation = inst.Operation;
		if ((int)operation <= 49)
		{
			switch ((int)operation - 28)
			{
			default:
				if ((int)operation != 49)
				{
					break;
				}
				return CreateUnaryOperator(UnaryOperatorType.Decrement, inst.BinderFlags.HasFlag(CSharpBinderFlags.CheckedContext));
			case 6:
				return CreateUnaryOperator(UnaryOperatorType.Not, null);
			case 0:
				return CreateUnaryOperator(UnaryOperatorType.Minus, inst.BinderFlags.HasFlag(CSharpBinderFlags.CheckedContext));
			case 2:
				return CreateUnaryOperator(UnaryOperatorType.Minus, true);
			case 1:
				return CreateUnaryOperator(UnaryOperatorType.Plus, inst.BinderFlags.HasFlag(CSharpBinderFlags.CheckedContext));
			case 3:
			case 4:
			case 5:
				break;
			}
		}
		else
		{
			if ((int)operation == 54)
			{
				return CreateUnaryOperator(UnaryOperatorType.Increment, inst.BinderFlags.HasFlag(CSharpBinderFlags.CheckedContext));
			}
			if ((int)operation == 83)
			{
				TranslatedExpression translatedExpression = TranslateDynamicArgument(inst.Operand, inst.OperandArgumentInfo);
				Expression expression = ((inst.SlotInfo != IfInstruction.ConditionSlot) ? ((Expression)new ConditionalExpression(translatedExpression, new PrimitiveExpression(true), new PrimitiveExpression(false))) : ((Expression)new UnaryOperatorExpression(UnaryOperatorType.IsTrue, translatedExpression)));
				return expression.WithILInstruction(inst).WithRR(new ResolveResult(compilation.FindType(KnownTypeCode.Boolean)));
			}
			if ((int)operation == 84)
			{
				TranslatedExpression translatedExpression = TranslateDynamicArgument(inst.Operand, inst.OperandArgumentInfo);
				Expression expression = new ConditionalExpression(translatedExpression, new PrimitiveExpression(false), new PrimitiveExpression(true));
				return expression.WithILInstruction(inst).WithRR(new ResolveResult(compilation.FindType(KnownTypeCode.Boolean)));
			}
		}
		return base.VisitDynamicUnaryOperatorInstruction(inst, context);
		TranslatedExpression CreateUnaryOperator(UnaryOperatorType operatorType, bool? isChecked)
		{
			UnaryOperatorExpression unaryOperatorExpression = new UnaryOperatorExpression(operatorType, TranslateDynamicArgument(inst.Operand, inst.OperandArgumentInfo).Expression);
			if (isChecked == true)
			{
				unaryOperatorExpression.AddAnnotation(AddCheckedBlocks.CheckedAnnotation);
			}
			else if (isChecked == false)
			{
				unaryOperatorExpression.AddAnnotation(AddCheckedBlocks.UncheckedAnnotation);
			}
			return unaryOperatorExpression.WithILInstruction(inst).WithRR(new ResolveResult(SpecialType.Dynamic));
		}
	}

	protected internal override TranslatedExpression VisitDynamicCompoundAssign(DynamicCompoundAssign inst, TranslationContext context)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		TranslatedExpression translatedExpression = TranslateDynamicArgument(inst.Target, inst.TargetArgumentInfo);
		TranslatedExpression translatedExpression2 = TranslateDynamicArgument(inst.Value, inst.ValueArgumentInfo);
		AssignmentExpression assignmentExpression = new AssignmentExpression(translatedExpression, AssignmentExpression.GetAssignmentOperatorTypeFromExpressionType(inst.Operation).Value, translatedExpression2);
		if (inst.BinderFlags.HasFlag(CSharpBinderFlags.CheckedContext))
		{
			assignmentExpression.AddAnnotation(AddCheckedBlocks.CheckedAnnotation);
		}
		else
		{
			assignmentExpression.AddAnnotation(AddCheckedBlocks.UncheckedAnnotation);
		}
		return assignmentExpression.WithILInstruction(inst).WithRR(new OperatorResolveResult(SpecialType.Dynamic, inst.Operation, translatedExpression.ResolveResult, translatedExpression2.ResolveResult));
	}

	protected internal override TranslatedExpression VisitInvalidBranch(InvalidBranch inst, TranslationContext context)
	{
		string text = "Error";
		if (inst.StartILOffset != 0)
		{
			text += $" near IL_{inst.StartILOffset:x4}";
		}
		if (!string.IsNullOrEmpty(inst.Message))
		{
			text = text + ": " + inst.Message;
		}
		return ErrorExpression(text);
	}

	protected internal override TranslatedExpression VisitInvalidExpression(InvalidExpression inst, TranslationContext context)
	{
		string text = "Error";
		if (inst.StartILOffset != 0)
		{
			text += $" near IL_{inst.StartILOffset:x4}";
		}
		if (!string.IsNullOrEmpty(inst.Message))
		{
			text = text + ": " + inst.Message;
		}
		return ErrorExpression(text);
	}

	protected override TranslatedExpression Default(ILInstruction inst, TranslationContext context)
	{
		return ErrorExpression("OpCode not supported: " + inst.OpCode);
	}

	private static TranslatedExpression ErrorExpression(string message)
	{
		ErrorExpression errorExpression = new ErrorExpression();
		errorExpression.AddChild(new Comment(message, CommentType.MultiLine), Roles.Comment);
		return errorExpression.WithoutILInstruction().WithRR(ErrorResolveResult.UnknownError);
	}
}
