#define DEBUG
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using DecompTools.Decompiler.CSharp.Syntax;
using DecompTools.Decompiler.CSharp.TypeSystem;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.TypeSystem.Implementation;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Resolver;

public class CSharpResolver : ICodeContext, ITypeResolveContext, ICompilationProvider
{
	private sealed class TypeDefinitionCache
	{
		public readonly ITypeDefinition TypeDefinition;

		public readonly Dictionary<string, ResolveResult> SimpleNameLookupCacheExpression = new Dictionary<string, ResolveResult>();

		public readonly Dictionary<string, ResolveResult> SimpleNameLookupCacheInvocationTarget = new Dictionary<string, ResolveResult>();

		public readonly Dictionary<string, ResolveResult> SimpleTypeLookupCache = new Dictionary<string, ResolveResult>();

		public TypeDefinitionCache(ITypeDefinition typeDefinition)
		{
			TypeDefinition = typeDefinition;
		}
	}

	private sealed class ObjectInitializerContext
	{
		internal readonly ResolveResult initializedObject;

		internal readonly ObjectInitializerContext prev;

		public ObjectInitializerContext(ResolveResult initializedObject, ObjectInitializerContext prev)
		{
			this.initializedObject = initializedObject;
			this.prev = prev;
		}
	}

	private static readonly ResolveResult ErrorResult = ErrorResolveResult.UnknownError;

	private readonly ICompilation compilation;

	internal readonly CSharpConversions conversions;

	private readonly CSharpTypeResolveContext context;

	private readonly bool checkForOverflow;

	private readonly bool isWithinLambdaExpression;

	private readonly TypeDefinitionCache currentTypeDefinitionCache;

	private readonly ImmutableStack<IVariable> localVariableStack = ImmutableStack<IVariable>.Empty;

	private readonly ObjectInitializerContext objectInitializerStack;

	public ICompilation Compilation => compilation;

	public CSharpTypeResolveContext CurrentTypeResolveContext => context;

	IModule ITypeResolveContext.CurrentModule => context.CurrentModule;

	public bool CheckForOverflow => checkForOverflow;

	public bool IsWithinLambdaExpression => isWithinLambdaExpression;

	public IMember CurrentMember => context.CurrentMember;

	public ResolvedUsingScope CurrentUsingScope => context.CurrentUsingScope;

	public ITypeDefinition CurrentTypeDefinition => context.CurrentTypeDefinition;

	public IEnumerable<IVariable> LocalVariables => Enumerable.Where<IVariable>((IEnumerable<IVariable>)localVariableStack, (Func<IVariable, bool>)((IVariable v) => v != null));

	public bool IsInObjectInitializer => objectInitializerStack != null;

	public ResolveResult CurrentObjectInitializer => (objectInitializerStack != null) ? objectInitializerStack.initializedObject : ErrorResult;

	public IType CurrentObjectInitializerType => CurrentObjectInitializer.Type;

	public CSharpResolver(ICompilation compilation)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		this.compilation = compilation;
		conversions = CSharpConversions.Get(compilation);
		context = new CSharpTypeResolveContext(compilation.MainModule);
	}

	public CSharpResolver(CSharpTypeResolveContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		compilation = context.Compilation;
		conversions = CSharpConversions.Get(compilation);
		this.context = context;
		if (context.CurrentTypeDefinition != null)
		{
			currentTypeDefinitionCache = new TypeDefinitionCache(context.CurrentTypeDefinition);
		}
	}

	private CSharpResolver(ICompilation compilation, CSharpConversions conversions, CSharpTypeResolveContext context, bool checkForOverflow, bool isWithinLambdaExpression, TypeDefinitionCache currentTypeDefinitionCache, ImmutableStack<IVariable> localVariableStack, ObjectInitializerContext objectInitializerStack)
	{
		this.compilation = compilation;
		this.conversions = conversions;
		this.context = context;
		this.checkForOverflow = checkForOverflow;
		this.isWithinLambdaExpression = isWithinLambdaExpression;
		this.currentTypeDefinitionCache = currentTypeDefinitionCache;
		this.localVariableStack = localVariableStack;
		this.objectInitializerStack = objectInitializerStack;
	}

	private CSharpResolver WithContext(CSharpTypeResolveContext newContext)
	{
		return new CSharpResolver(compilation, conversions, newContext, checkForOverflow, isWithinLambdaExpression, currentTypeDefinitionCache, localVariableStack, objectInitializerStack);
	}

	public CSharpResolver WithCheckForOverflow(bool checkForOverflow)
	{
		if (checkForOverflow == this.checkForOverflow)
		{
			return this;
		}
		return new CSharpResolver(compilation, conversions, context, checkForOverflow, isWithinLambdaExpression, currentTypeDefinitionCache, localVariableStack, objectInitializerStack);
	}

	public CSharpResolver WithIsWithinLambdaExpression(bool isWithinLambdaExpression)
	{
		return new CSharpResolver(compilation, conversions, context, checkForOverflow, isWithinLambdaExpression, currentTypeDefinitionCache, localVariableStack, objectInitializerStack);
	}

	public CSharpResolver WithCurrentMember(IMember member)
	{
		return WithContext(context.WithCurrentMember(member));
	}

	ITypeResolveContext ITypeResolveContext.WithCurrentMember(IMember member)
	{
		return WithCurrentMember(member);
	}

	public CSharpResolver WithCurrentUsingScope(ResolvedUsingScope usingScope)
	{
		return WithContext(context.WithUsingScope(usingScope));
	}

	public CSharpResolver WithCurrentTypeDefinition(ITypeDefinition typeDefinition)
	{
		if (CurrentTypeDefinition == typeDefinition)
		{
			return this;
		}
		return new CSharpResolver(currentTypeDefinitionCache: (typeDefinition == null) ? null : new TypeDefinitionCache(typeDefinition), compilation: compilation, conversions: conversions, context: context.WithCurrentTypeDefinition(typeDefinition), checkForOverflow: checkForOverflow, isWithinLambdaExpression: isWithinLambdaExpression, localVariableStack: localVariableStack, objectInitializerStack: objectInitializerStack);
	}

	ITypeResolveContext ITypeResolveContext.WithCurrentTypeDefinition(ITypeDefinition typeDefinition)
	{
		return WithCurrentTypeDefinition(typeDefinition);
	}

	private CSharpResolver WithLocalVariableStack(ImmutableStack<IVariable> stack)
	{
		return new CSharpResolver(compilation, conversions, context, checkForOverflow, isWithinLambdaExpression, currentTypeDefinitionCache, stack, objectInitializerStack);
	}

	public CSharpResolver PushBlock()
	{
		return WithLocalVariableStack(localVariableStack.Push(null));
	}

	public CSharpResolver PopBlock()
	{
		ImmutableStack<IVariable> immutableStack = localVariableStack;
		IVariable variable;
		do
		{
			variable = immutableStack.Peek();
			immutableStack = immutableStack.Pop();
		}
		while (variable != null);
		return WithLocalVariableStack(immutableStack);
	}

	public CSharpResolver AddVariable(IVariable variable)
	{
		if (variable == null)
		{
			throw new ArgumentNullException("variable");
		}
		return WithLocalVariableStack(localVariableStack.Push(variable));
	}

	public CSharpResolver PopLastVariable()
	{
		if (localVariableStack.Peek() == null)
		{
			throw new InvalidOperationException("There is no variable within the current block.");
		}
		return WithLocalVariableStack(localVariableStack.Pop());
	}

	private CSharpResolver WithObjectInitializerStack(ObjectInitializerContext stack)
	{
		return new CSharpResolver(compilation, conversions, context, checkForOverflow, isWithinLambdaExpression, currentTypeDefinitionCache, localVariableStack, stack);
	}

	public CSharpResolver PushObjectInitializer(ResolveResult initializedObject)
	{
		if (initializedObject == null)
		{
			throw new ArgumentNullException("initializedObject");
		}
		return WithObjectInitializerStack(new ObjectInitializerContext(initializedObject, objectInitializerStack));
	}

	public CSharpResolver PopObjectInitializer()
	{
		if (objectInitializerStack == null)
		{
			throw new InvalidOperationException();
		}
		return WithObjectInitializerStack(objectInitializerStack.prev);
	}

	public ResolveResult ResolveUnaryOperator(UnaryOperatorType op, ResolveResult expression)
	{
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bc: Unknown result type (might be due to invalid IL or missing references)
		if (expression.Type.Kind == TypeKind.Dynamic)
		{
			if (op == UnaryOperatorType.Await)
			{
				return new AwaitResolveResult(SpecialType.Dynamic, new DynamicInvocationResolveResult(new DynamicMemberResolveResult(expression, "GetAwaiter"), DynamicInvocationType.Invocation, EmptyList<ResolveResult>.Instance), SpecialType.Dynamic, null, null, null);
			}
			return UnaryOperatorResolveResult(SpecialType.Dynamic, op, expression);
		}
		string overloadableOperatorName = GetOverloadableOperatorName(op);
		if (overloadableOperatorName == null)
		{
			switch (op)
			{
			case UnaryOperatorType.Dereference:
				if (expression.Type is PointerType pointerType)
				{
					return UnaryOperatorResolveResult(pointerType.ElementType, op, expression);
				}
				return ErrorResult;
			case UnaryOperatorType.AddressOf:
				return UnaryOperatorResolveResult(new PointerType(expression.Type), op, expression);
			case UnaryOperatorType.Await:
			{
				ResolveResult target = ResolveMemberAccess(expression, "GetAwaiter", EmptyList<IType>.Instance, NameLookupMode.InvocationTarget);
				ResolveResult targetResolveResult = ResolveInvocation(target, new ResolveResult[0], null, allowOptionalParameters: false);
				MemberLookup memberLookup = CreateMemberLookup();
				if (memberLookup.Lookup(targetResolveResult, "GetResult", EmptyList<IType>.Instance, isInvocation: true) is MethodGroupResolveResult methodGroupResolveResult)
				{
					OverloadResolution overloadResolution = methodGroupResolveResult.PerformOverloadResolution(compilation, new ResolveResult[0], null, allowExtensionMethods: false, allowExpandingParams: true, allowOptionalParameters: true, checkForOverflow: false, conversions);
					IMethod method = (overloadResolution.FoundApplicableCandidate ? (overloadResolution.GetBestCandidateWithSubstitutedTypeArguments() as IMethod) : null);
					IType type;
					if (method == null)
					{
						IType unknownType = SpecialType.UnknownType;
						type = unknownType;
					}
					else
					{
						type = method.ReturnType;
					}
					IType type2 = type;
				}
				else
				{
					IMethod method = null;
					IType type2 = SpecialType.UnknownType;
				}
				ResolveResult resolveResult = memberLookup.Lookup(targetResolveResult, "IsCompleted", EmptyList<IType>.Instance, isInvocation: false);
				IProperty property = ((resolveResult is MemberResolveResult) ? (((MemberResolveResult)resolveResult).Member as IProperty) : null);
				if (property != null && (!property.ReturnType.IsKnownType(KnownTypeCode.Boolean) || !property.CanGet))
				{
					property = null;
				}
				throw new NotImplementedException();
			}
			default:
				return ErrorResolveResult.UnknownError;
			}
		}
		IType type3 = NullableType.GetUnderlyingType(expression.Type);
		bool flag = NullableType.IsNullable(expression.Type);
		OverloadResolution overloadResolution2 = CreateOverloadResolution(new ResolveResult[1] { expression });
		foreach (IParameterizedMember userDefinedOperatorCandidate in GetUserDefinedOperatorCandidates(type3, overloadableOperatorName))
		{
			overloadResolution2.AddCandidate(userDefinedOperatorCandidate);
		}
		if (overloadResolution2.FoundApplicableCandidate)
		{
			return CreateResolveResultForUserDefinedOperator(overloadResolution2, UnaryOperatorExpression.GetLinqNodeType(op, CheckForOverflow));
		}
		expression = UnaryNumericPromotion(op, ref type3, flag, expression);
		CSharpOperators cSharpOperators = CSharpOperators.Get(compilation);
		CSharpOperators.OperatorMethod[] array;
		switch (op)
		{
		case UnaryOperatorType.Increment:
		case UnaryOperatorType.Decrement:
		case UnaryOperatorType.PostIncrement:
		case UnaryOperatorType.PostDecrement:
		{
			TypeCode typeCode = type3.GetTypeCode();
			if ((typeCode >= TypeCode.Char && typeCode <= TypeCode.Decimal) || type3.Kind == TypeKind.Enum || type3.Kind == TypeKind.Pointer)
			{
				return UnaryOperatorResolveResult(expression.Type, op, expression, flag);
			}
			return new ErrorResolveResult(expression.Type);
		}
		case UnaryOperatorType.Plus:
			array = cSharpOperators.UnaryPlusOperators;
			break;
		case UnaryOperatorType.Minus:
			array = (CheckForOverflow ? cSharpOperators.CheckedUnaryMinusOperators : cSharpOperators.UncheckedUnaryMinusOperators);
			break;
		case UnaryOperatorType.Not:
			array = cSharpOperators.LogicalNegationOperators;
			break;
		case UnaryOperatorType.BitNot:
			if (type3.Kind == TypeKind.Enum)
			{
				if (expression.IsCompileTimeConstant && !flag && expression.ConstantValue != null)
				{
					IType type4 = compilation.FindType(expression.ConstantValue.GetType());
					ConstantResolveResult expression2 = new ConstantResolveResult(type4, expression.ConstantValue);
					ResolveResult expression3 = ResolveUnaryOperator(op, expression2);
					expression3 = WithCheckForOverflow(checkForOverflow: false).ResolveCast(type3, expression3);
					if (expression3.IsCompileTimeConstant)
					{
						return expression3;
					}
				}
				return UnaryOperatorResolveResult(expression.Type, op, expression, flag);
			}
			array = cSharpOperators.BitwiseComplementOperators;
			break;
		default:
			throw new InvalidOperationException();
		}
		OverloadResolution overloadResolution3 = CreateOverloadResolution(new ResolveResult[1] { expression });
		CSharpOperators.OperatorMethod[] array2 = array;
		foreach (CSharpOperators.OperatorMethod member in array2)
		{
			overloadResolution3.AddCandidate(member);
		}
		CSharpOperators.UnaryOperatorMethod unaryOperatorMethod = (CSharpOperators.UnaryOperatorMethod)overloadResolution3.BestCandidate;
		IType returnType = unaryOperatorMethod.ReturnType;
		if (overloadResolution3.BestCandidateErrors != OverloadResolutionErrors.None)
		{
			if (overloadResolution2.BestCandidate != null)
			{
				return CreateResolveResultForUserDefinedOperator(overloadResolution2, UnaryOperatorExpression.GetLinqNodeType(op, CheckForOverflow));
			}
			if (overloadResolution3.BestCandidateAmbiguousWith != null)
			{
				return new ErrorResolveResult(expression.Type);
			}
			return new ErrorResolveResult(returnType);
		}
		if (expression.IsCompileTimeConstant && unaryOperatorMethod.CanEvaluateAtCompileTime)
		{
			object constantValue;
			try
			{
				constantValue = unaryOperatorMethod.Invoke(this, expression.ConstantValue);
			}
			catch (ArithmeticException)
			{
				return new ErrorResolveResult(returnType);
			}
			return new ConstantResolveResult(returnType, constantValue);
		}
		expression = Convert(expression, unaryOperatorMethod.Parameters[0].Type, overloadResolution3.ArgumentConversions[0]);
		return UnaryOperatorResolveResult(returnType, op, expression, overloadResolution3.BestCandidate is ILiftedOperator);
	}

	private OperatorResolveResult UnaryOperatorResolveResult(IType resultType, UnaryOperatorType op, ResolveResult expression, bool isLifted = false)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return new OperatorResolveResult(resultType, UnaryOperatorExpression.GetLinqNodeType(op, CheckForOverflow), null, isLifted, new ResolveResult[1] { expression });
	}

	private ResolveResult UnaryNumericPromotion(UnaryOperatorType op, ref IType type, bool isNullable, ResolveResult expression)
	{
		TypeCode typeCode = type.GetTypeCode();
		if (isNullable && type.Kind == TypeKind.Null)
		{
			typeCode = TypeCode.SByte;
		}
		switch (op)
		{
		case UnaryOperatorType.Minus:
			if (typeCode == TypeCode.UInt32)
			{
				type = compilation.FindType(KnownTypeCode.Int64);
				return Convert(expression, MakeNullable(type, isNullable), isNullable ? Conversion.ImplicitNullableConversion : Conversion.ImplicitNumericConversion);
			}
			goto case UnaryOperatorType.BitNot;
		case UnaryOperatorType.BitNot:
		case UnaryOperatorType.Plus:
			if (typeCode >= TypeCode.Char && typeCode <= TypeCode.UInt16)
			{
				type = compilation.FindType(KnownTypeCode.Int32);
				return Convert(expression, MakeNullable(type, isNullable), isNullable ? Conversion.ImplicitNullableConversion : Conversion.ImplicitNumericConversion);
			}
			break;
		}
		return expression;
	}

	private static string GetOverloadableOperatorName(UnaryOperatorType op)
	{
		switch (op)
		{
		case UnaryOperatorType.Not:
			return "op_LogicalNot";
		case UnaryOperatorType.BitNot:
			return "op_OnesComplement";
		case UnaryOperatorType.Minus:
			return "op_UnaryNegation";
		case UnaryOperatorType.Plus:
			return "op_UnaryPlus";
		case UnaryOperatorType.Increment:
		case UnaryOperatorType.PostIncrement:
			return "op_Increment";
		case UnaryOperatorType.Decrement:
		case UnaryOperatorType.PostDecrement:
			return "op_Decrement";
		default:
			return null;
		}
	}

	public ResolveResult ResolveBinaryOperator(BinaryOperatorType op, ResolveResult lhs, ResolveResult rhs)
	{
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8b: Unknown result type (might be due to invalid IL or missing references)
		if (lhs.Type.Kind == TypeKind.Dynamic || rhs.Type.Kind == TypeKind.Dynamic)
		{
			lhs = Convert(lhs, SpecialType.Dynamic);
			rhs = Convert(rhs, SpecialType.Dynamic);
			return BinaryOperatorResolveResult(SpecialType.Dynamic, lhs, op, rhs);
		}
		string overloadableOperatorName = GetOverloadableOperatorName(op);
		if (overloadableOperatorName == null)
		{
			switch (op)
			{
			case BinaryOperatorType.ConditionalAnd:
				overloadableOperatorName = GetOverloadableOperatorName(BinaryOperatorType.BitwiseAnd);
				break;
			case BinaryOperatorType.ConditionalOr:
				overloadableOperatorName = GetOverloadableOperatorName(BinaryOperatorType.BitwiseOr);
				break;
			case BinaryOperatorType.NullCoalescing:
				return ResolveNullCoalescingOperator(lhs, rhs);
			default:
				return ErrorResolveResult.UnknownError;
			}
		}
		bool isNullable = NullableType.IsNullable(lhs.Type) || NullableType.IsNullable(rhs.Type);
		IType type = NullableType.GetUnderlyingType(lhs.Type);
		IType type2 = NullableType.GetUnderlyingType(rhs.Type);
		OverloadResolution overloadResolution = CreateOverloadResolution(new ResolveResult[2] { lhs, rhs });
		HashSet<IParameterizedMember> val = new HashSet<IParameterizedMember>();
		val.UnionWith(GetUserDefinedOperatorCandidates(type, overloadableOperatorName));
		val.UnionWith(GetUserDefinedOperatorCandidates(type2, overloadableOperatorName));
		Enumerator<IParameterizedMember> enumerator = val.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				IParameterizedMember current = enumerator.Current;
				overloadResolution.AddCandidate(current);
			}
		}
		finally
		{
			((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
		}
		if (overloadResolution.FoundApplicableCandidate)
		{
			return CreateResolveResultForUserDefinedOperator(overloadResolution, BinaryOperatorExpression.GetLinqNodeType(op, CheckForOverflow));
		}
		if ((type.Kind == TypeKind.Null && type2.IsReferenceType == false) || (type.IsReferenceType == false && type2.Kind == TypeKind.Null))
		{
			isNullable = true;
		}
		if (op == BinaryOperatorType.ShiftLeft || op == BinaryOperatorType.ShiftRight)
		{
			if (type.Kind == TypeKind.Null && type2.Kind == TypeKind.Null)
			{
				isNullable = true;
			}
			lhs = UnaryNumericPromotion(UnaryOperatorType.Plus, ref type, isNullable, lhs);
			rhs = UnaryNumericPromotion(UnaryOperatorType.Plus, ref type2, isNullable, rhs);
		}
		else
		{
			bool allowNullableConstants = op == BinaryOperatorType.Equality || op == BinaryOperatorType.InEquality;
			if (!BinaryNumericPromotion(isNullable, ref lhs, ref rhs, allowNullableConstants))
			{
				return new ErrorResolveResult(lhs.Type);
			}
		}
		type = NullableType.GetUnderlyingType(lhs.Type);
		type2 = NullableType.GetUnderlyingType(rhs.Type);
		CSharpOperators cSharpOperators = CSharpOperators.Get(compilation);
		IEnumerable<CSharpOperators.OperatorMethod> enumerable;
		switch (op)
		{
		case BinaryOperatorType.Multiply:
			enumerable = cSharpOperators.MultiplicationOperators;
			break;
		case BinaryOperatorType.Divide:
			enumerable = cSharpOperators.DivisionOperators;
			break;
		case BinaryOperatorType.Modulus:
			enumerable = cSharpOperators.RemainderOperators;
			break;
		case BinaryOperatorType.Add:
			enumerable = cSharpOperators.AdditionOperators;
			if (type.Kind == TypeKind.Enum)
			{
				IType targetType = MakeNullable(GetEnumUnderlyingType(type), isNullable);
				if (TryConvertEnum(ref rhs, targetType, ref isNullable, ref lhs))
				{
					return HandleEnumOperator(isNullable, type, op, lhs, rhs);
				}
			}
			if (type2.Kind == TypeKind.Enum)
			{
				IType targetType2 = MakeNullable(GetEnumUnderlyingType(type2), isNullable);
				if (TryConvertEnum(ref lhs, targetType2, ref isNullable, ref rhs))
				{
					return HandleEnumOperator(isNullable, type2, op, lhs, rhs);
				}
			}
			if (type.Kind == TypeKind.Delegate && TryConvert(ref rhs, type))
			{
				return BinaryOperatorResolveResult(type, lhs, op, rhs);
			}
			if (type2.Kind == TypeKind.Delegate && TryConvert(ref lhs, type2))
			{
				return BinaryOperatorResolveResult(type2, lhs, op, rhs);
			}
			if (type is PointerType)
			{
				enumerable = new CSharpOperators.BinaryOperatorMethod[4]
				{
					PointerArithmeticOperator(type, type, KnownTypeCode.Int32),
					PointerArithmeticOperator(type, type, KnownTypeCode.UInt32),
					PointerArithmeticOperator(type, type, KnownTypeCode.Int64),
					PointerArithmeticOperator(type, type, KnownTypeCode.UInt64)
				};
			}
			else if (type2 is PointerType)
			{
				enumerable = new CSharpOperators.BinaryOperatorMethod[4]
				{
					PointerArithmeticOperator(type2, KnownTypeCode.Int32, type2),
					PointerArithmeticOperator(type2, KnownTypeCode.UInt32, type2),
					PointerArithmeticOperator(type2, KnownTypeCode.Int64, type2),
					PointerArithmeticOperator(type2, KnownTypeCode.UInt64, type2)
				};
			}
			if (type.Kind == TypeKind.Null && type2.Kind == TypeKind.Null)
			{
				return new ErrorResolveResult(SpecialType.NullType);
			}
			break;
		case BinaryOperatorType.Subtract:
			enumerable = cSharpOperators.SubtractionOperators;
			if (type.Kind == TypeKind.Enum)
			{
				if (TryConvertEnum(ref rhs, lhs.Type, ref isNullable, ref lhs, allowConversionFromConstantZero: false))
				{
					return HandleEnumSubtraction(isNullable, type, lhs, rhs);
				}
				IType targetType3 = MakeNullable(GetEnumUnderlyingType(type), isNullable);
				if (TryConvertEnum(ref rhs, targetType3, ref isNullable, ref lhs))
				{
					return HandleEnumOperator(isNullable, type, op, lhs, rhs);
				}
			}
			if (type2.Kind == TypeKind.Enum)
			{
				if (TryConvertEnum(ref lhs, rhs.Type, ref isNullable, ref rhs))
				{
					return HandleEnumSubtraction(isNullable, type2, lhs, rhs);
				}
				IType targetType4 = MakeNullable(GetEnumUnderlyingType(type2), isNullable);
				if (TryConvertEnum(ref lhs, targetType4, ref isNullable, ref rhs))
				{
					return HandleEnumOperator(isNullable, type2, op, lhs, rhs);
				}
			}
			if (type.Kind == TypeKind.Delegate && TryConvert(ref rhs, type))
			{
				return BinaryOperatorResolveResult(type, lhs, op, rhs);
			}
			if (type2.Kind == TypeKind.Delegate && TryConvert(ref lhs, type2))
			{
				return BinaryOperatorResolveResult(type2, lhs, op, rhs);
			}
			if (type is PointerType)
			{
				if (type2 is PointerType)
				{
					IType type3 = compilation.FindType(KnownTypeCode.Int64);
					if (type.Equals(type2))
					{
						return BinaryOperatorResolveResult(type3, lhs, op, rhs);
					}
					return new ErrorResolveResult(type3);
				}
				enumerable = new CSharpOperators.BinaryOperatorMethod[4]
				{
					PointerArithmeticOperator(type, type, KnownTypeCode.Int32),
					PointerArithmeticOperator(type, type, KnownTypeCode.UInt32),
					PointerArithmeticOperator(type, type, KnownTypeCode.Int64),
					PointerArithmeticOperator(type, type, KnownTypeCode.UInt64)
				};
			}
			if (type.Kind == TypeKind.Null && type2.Kind == TypeKind.Null)
			{
				return new ErrorResolveResult(SpecialType.NullType);
			}
			break;
		case BinaryOperatorType.ShiftLeft:
			enumerable = cSharpOperators.ShiftLeftOperators;
			break;
		case BinaryOperatorType.ShiftRight:
			enumerable = cSharpOperators.ShiftRightOperators;
			break;
		case BinaryOperatorType.GreaterThan:
		case BinaryOperatorType.GreaterThanOrEqual:
		case BinaryOperatorType.Equality:
		case BinaryOperatorType.InEquality:
		case BinaryOperatorType.LessThan:
		case BinaryOperatorType.LessThanOrEqual:
			if (type.Kind == TypeKind.Enum && TryConvert(ref rhs, lhs.Type))
			{
				return HandleEnumComparison(op, type, isNullable, lhs, rhs);
			}
			if (type2.Kind == TypeKind.Enum && TryConvert(ref lhs, rhs.Type))
			{
				return HandleEnumComparison(op, type2, isNullable, lhs, rhs);
			}
			if (type is PointerType && type2 is PointerType)
			{
				return BinaryOperatorResolveResult(compilation.FindType(KnownTypeCode.Boolean), lhs, op, rhs);
			}
			if (op == BinaryOperatorType.Equality || op == BinaryOperatorType.InEquality)
			{
				if (type.IsReferenceType == true && type2.IsReferenceType == true)
				{
					enumerable = ((op != BinaryOperatorType.Equality) ? cSharpOperators.ReferenceInequalityOperators : cSharpOperators.ReferenceEqualityOperators);
					break;
				}
				if ((type.Kind == TypeKind.Null && IsNullableTypeOrNonValueType(rhs.Type)) || (IsNullableTypeOrNonValueType(lhs.Type) && type2.Kind == TypeKind.Null))
				{
					return BinaryOperatorResolveResult(compilation.FindType(KnownTypeCode.Boolean), lhs, op, rhs);
				}
			}
			enumerable = op switch
			{
				BinaryOperatorType.Equality => cSharpOperators.ValueEqualityOperators, 
				BinaryOperatorType.InEquality => cSharpOperators.ValueInequalityOperators, 
				BinaryOperatorType.LessThan => cSharpOperators.LessThanOperators, 
				BinaryOperatorType.GreaterThan => cSharpOperators.GreaterThanOperators, 
				BinaryOperatorType.LessThanOrEqual => cSharpOperators.LessThanOrEqualOperators, 
				BinaryOperatorType.GreaterThanOrEqual => cSharpOperators.GreaterThanOrEqualOperators, 
				_ => throw new InvalidOperationException(), 
			};
			break;
		case BinaryOperatorType.BitwiseAnd:
		case BinaryOperatorType.BitwiseOr:
		case BinaryOperatorType.ExclusiveOr:
			if (type.Kind == TypeKind.Enum && TryConvertEnum(ref rhs, lhs.Type, ref isNullable, ref lhs))
			{
				return HandleEnumOperator(isNullable, type, op, lhs, rhs);
			}
			if (type2.Kind == TypeKind.Enum && TryConvertEnum(ref lhs, rhs.Type, ref isNullable, ref rhs))
			{
				return HandleEnumOperator(isNullable, type2, op, lhs, rhs);
			}
			enumerable = op switch
			{
				BinaryOperatorType.BitwiseAnd => cSharpOperators.BitwiseAndOperators, 
				BinaryOperatorType.BitwiseOr => cSharpOperators.BitwiseOrOperators, 
				BinaryOperatorType.ExclusiveOr => cSharpOperators.BitwiseXorOperators, 
				_ => throw new InvalidOperationException(), 
			};
			break;
		case BinaryOperatorType.ConditionalAnd:
			enumerable = cSharpOperators.LogicalAndOperators;
			break;
		case BinaryOperatorType.ConditionalOr:
			enumerable = cSharpOperators.LogicalOrOperators;
			break;
		default:
			throw new InvalidOperationException();
		}
		OverloadResolution overloadResolution2 = CreateOverloadResolution(new ResolveResult[2] { lhs, rhs });
		foreach (CSharpOperators.OperatorMethod item in enumerable)
		{
			overloadResolution2.AddCandidate(item);
		}
		CSharpOperators.BinaryOperatorMethod binaryOperatorMethod = (CSharpOperators.BinaryOperatorMethod)overloadResolution2.BestCandidate;
		IType returnType = binaryOperatorMethod.ReturnType;
		if (overloadResolution2.BestCandidateErrors != OverloadResolutionErrors.None)
		{
			if (overloadResolution.BestCandidate != null)
			{
				return CreateResolveResultForUserDefinedOperator(overloadResolution, BinaryOperatorExpression.GetLinqNodeType(op, CheckForOverflow));
			}
			return new ErrorResolveResult(returnType);
		}
		if (lhs.IsCompileTimeConstant && rhs.IsCompileTimeConstant && binaryOperatorMethod.CanEvaluateAtCompileTime)
		{
			object constantValue;
			try
			{
				constantValue = binaryOperatorMethod.Invoke(this, lhs.ConstantValue, rhs.ConstantValue);
			}
			catch (ArithmeticException)
			{
				return new ErrorResolveResult(returnType);
			}
			return new ConstantResolveResult(returnType, constantValue);
		}
		lhs = Convert(lhs, binaryOperatorMethod.Parameters[0].Type, overloadResolution2.ArgumentConversions[0]);
		rhs = Convert(rhs, binaryOperatorMethod.Parameters[1].Type, overloadResolution2.ArgumentConversions[1]);
		return BinaryOperatorResolveResult(returnType, lhs, op, rhs, overloadResolution2.BestCandidate is ILiftedOperator);
	}

	private bool IsNullableTypeOrNonValueType(IType type)
	{
		return NullableType.IsNullable(type) || type.IsReferenceType != false;
	}

	private ResolveResult BinaryOperatorResolveResult(IType resultType, ResolveResult lhs, BinaryOperatorType op, ResolveResult rhs, bool isLifted = false)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		return new OperatorResolveResult(resultType, BinaryOperatorExpression.GetLinqNodeType(op, CheckForOverflow), null, isLifted, new ResolveResult[2] { lhs, rhs });
	}

	private CSharpOperators.BinaryOperatorMethod PointerArithmeticOperator(IType resultType, IType inputType1, KnownTypeCode inputType2)
	{
		return PointerArithmeticOperator(resultType, inputType1, compilation.FindType(inputType2));
	}

	private CSharpOperators.BinaryOperatorMethod PointerArithmeticOperator(IType resultType, KnownTypeCode inputType1, IType inputType2)
	{
		return PointerArithmeticOperator(resultType, compilation.FindType(inputType1), inputType2);
	}

	private CSharpOperators.BinaryOperatorMethod PointerArithmeticOperator(IType resultType, IType inputType1, IType inputType2)
	{
		return new CSharpOperators.BinaryOperatorMethod(compilation)
		{
			ReturnType = resultType,
			parameters = 
			{
				(IParameter)new DefaultParameter(inputType1, string.Empty),
				(IParameter)new DefaultParameter(inputType2, string.Empty)
			}
		};
	}

	private IType GetEnumUnderlyingType(IType enumType)
	{
		ITypeDefinition definition = enumType.GetDefinition();
		IType result;
		if (definition == null)
		{
			IType unknownType = SpecialType.UnknownType;
			result = unknownType;
		}
		else
		{
			result = definition.EnumUnderlyingType;
		}
		return result;
	}

	private ResolveResult HandleEnumComparison(BinaryOperatorType op, IType enumType, bool isNullable, ResolveResult lhs, ResolveResult rhs)
	{
		IType enumUnderlyingType = GetEnumUnderlyingType(enumType);
		if (lhs.IsCompileTimeConstant && rhs.IsCompileTimeConstant && !isNullable && enumUnderlyingType.Kind != TypeKind.Enum)
		{
			ResolveResult resolveResult = ResolveBinaryOperator(op, ResolveCast(enumUnderlyingType, lhs), ResolveCast(enumUnderlyingType, rhs));
			if (resolveResult.IsCompileTimeConstant)
			{
				return resolveResult;
			}
		}
		IType resultType = compilation.FindType(KnownTypeCode.Boolean);
		return BinaryOperatorResolveResult(resultType, lhs, op, rhs, isNullable);
	}

	private ResolveResult HandleEnumSubtraction(bool isNullable, IType enumType, ResolveResult lhs, ResolveResult rhs)
	{
		IType enumUnderlyingType = GetEnumUnderlyingType(enumType);
		if (lhs.IsCompileTimeConstant && rhs.IsCompileTimeConstant && !isNullable && enumUnderlyingType.Kind != TypeKind.Enum)
		{
			ResolveResult expression = ResolveBinaryOperator(BinaryOperatorType.Subtract, ResolveCast(enumUnderlyingType, lhs), ResolveCast(enumUnderlyingType, rhs));
			expression = WithCheckForOverflow(checkForOverflow: false).ResolveCast(enumUnderlyingType, expression);
			if (expression.IsCompileTimeConstant)
			{
				return expression;
			}
		}
		IType resultType = MakeNullable(enumUnderlyingType, isNullable);
		return BinaryOperatorResolveResult(resultType, lhs, BinaryOperatorType.Subtract, rhs, isNullable);
	}

	private ResolveResult HandleEnumOperator(bool isNullable, IType enumType, BinaryOperatorType op, ResolveResult lhs, ResolveResult rhs)
	{
		if (lhs.IsCompileTimeConstant && rhs.IsCompileTimeConstant && !isNullable)
		{
			IType enumUnderlyingType = GetEnumUnderlyingType(enumType);
			if (enumUnderlyingType.Kind != TypeKind.Enum)
			{
				ResolveResult expression = ResolveBinaryOperator(op, ResolveCast(enumUnderlyingType, lhs), ResolveCast(enumUnderlyingType, rhs));
				expression = WithCheckForOverflow(checkForOverflow: false).ResolveCast(enumType, expression);
				if (expression.IsCompileTimeConstant)
				{
					return expression;
				}
			}
		}
		IType resultType = MakeNullable(enumType, isNullable);
		return BinaryOperatorResolveResult(resultType, lhs, op, rhs, isNullable);
	}

	private IType MakeNullable(IType type, bool isNullable)
	{
		if (isNullable)
		{
			return NullableType.Create(compilation, type);
		}
		return type;
	}

	private bool BinaryNumericPromotion(bool isNullable, ref ResolveResult lhs, ref ResolveResult rhs, bool allowNullableConstants)
	{
		TypeCode typeCode = NullableType.GetUnderlyingType(lhs.Type).GetTypeCode();
		TypeCode typeCode2 = NullableType.GetUnderlyingType(rhs.Type).GetTypeCode();
		if (isNullable && lhs.Type.Kind == TypeKind.Null && typeCode2 >= TypeCode.Boolean && typeCode2 <= TypeCode.Decimal)
		{
			lhs = CastTo(typeCode2, isNullable, lhs, allowNullableConstants);
			typeCode = typeCode2;
		}
		else if (isNullable && rhs.Type.Kind == TypeKind.Null && typeCode >= TypeCode.Boolean && typeCode <= TypeCode.Decimal)
		{
			rhs = CastTo(typeCode, isNullable, rhs, allowNullableConstants);
			typeCode2 = typeCode;
		}
		bool flag = false;
		if (typeCode >= TypeCode.Char && typeCode <= TypeCode.Decimal && typeCode2 >= TypeCode.Char && typeCode2 <= TypeCode.Decimal)
		{
			TypeCode targetType;
			if (typeCode == TypeCode.Decimal || typeCode2 == TypeCode.Decimal)
			{
				targetType = TypeCode.Decimal;
				flag = typeCode == TypeCode.Single || typeCode == TypeCode.Double || typeCode2 == TypeCode.Single || typeCode2 == TypeCode.Double;
			}
			else if (typeCode == TypeCode.Double || typeCode2 == TypeCode.Double)
			{
				targetType = TypeCode.Double;
			}
			else if (typeCode == TypeCode.Single || typeCode2 == TypeCode.Single)
			{
				targetType = TypeCode.Single;
			}
			else if (typeCode == TypeCode.UInt64 || typeCode2 == TypeCode.UInt64)
			{
				targetType = TypeCode.UInt64;
				flag = IsSigned(typeCode, lhs) || IsSigned(typeCode2, rhs);
			}
			else
			{
				targetType = ((typeCode != TypeCode.Int64 && typeCode2 != TypeCode.Int64) ? ((typeCode != TypeCode.UInt32 && typeCode2 != TypeCode.UInt32) ? TypeCode.Int32 : ((IsSigned(typeCode, lhs) || IsSigned(typeCode2, rhs)) ? TypeCode.Int64 : TypeCode.UInt32)) : TypeCode.Int64);
			}
			lhs = CastTo(targetType, isNullable, lhs, allowNullableConstants);
			rhs = CastTo(targetType, isNullable, rhs, allowNullableConstants);
		}
		return !flag;
	}

	private bool IsSigned(TypeCode code, ResolveResult rr)
	{
		switch (code)
		{
		case TypeCode.SByte:
		case TypeCode.Int16:
			return true;
		case TypeCode.Int32:
			if (rr.IsCompileTimeConstant && rr.ConstantValue != null && (int)rr.ConstantValue >= 0)
			{
				return false;
			}
			return true;
		case TypeCode.Int64:
			if (rr.IsCompileTimeConstant && rr.ConstantValue != null && (long)rr.ConstantValue >= 0)
			{
				return false;
			}
			return true;
		default:
			return false;
		}
	}

	private ResolveResult CastTo(TypeCode targetType, bool isNullable, ResolveResult expression, bool allowNullableConstants)
	{
		IType type = compilation.FindType(targetType);
		IType type2 = MakeNullable(type, isNullable);
		if (type2.Equals(expression.Type))
		{
			return expression;
		}
		if (allowNullableConstants && expression.IsCompileTimeConstant)
		{
			if (expression.ConstantValue == null)
			{
				return new ConstantResolveResult(type2, null);
			}
			ResolveResult resolveResult = ResolveCast(type, expression);
			if (resolveResult.IsError)
			{
				return resolveResult;
			}
			Debug.Assert(resolveResult.IsCompileTimeConstant);
			return new ConstantResolveResult(type2, resolveResult.ConstantValue);
		}
		return Convert(expression, type2, isNullable ? Conversion.ImplicitNullableConversion : Conversion.ImplicitNumericConversion);
	}

	private static string GetOverloadableOperatorName(BinaryOperatorType op)
	{
		return op switch
		{
			BinaryOperatorType.Add => "op_Addition", 
			BinaryOperatorType.Subtract => "op_Subtraction", 
			BinaryOperatorType.Multiply => "op_Multiply", 
			BinaryOperatorType.Divide => "op_Division", 
			BinaryOperatorType.Modulus => "op_Modulus", 
			BinaryOperatorType.BitwiseAnd => "op_BitwiseAnd", 
			BinaryOperatorType.BitwiseOr => "op_BitwiseOr", 
			BinaryOperatorType.ExclusiveOr => "op_ExclusiveOr", 
			BinaryOperatorType.ShiftLeft => "op_LeftShift", 
			BinaryOperatorType.ShiftRight => "op_RightShift", 
			BinaryOperatorType.Equality => "op_Equality", 
			BinaryOperatorType.InEquality => "op_Inequality", 
			BinaryOperatorType.GreaterThan => "op_GreaterThan", 
			BinaryOperatorType.LessThan => "op_LessThan", 
			BinaryOperatorType.GreaterThanOrEqual => "op_GreaterThanOrEqual", 
			BinaryOperatorType.LessThanOrEqual => "op_LessThanOrEqual", 
			_ => null, 
		};
	}

	private ResolveResult ResolveNullCoalescingOperator(ResolveResult lhs, ResolveResult rhs)
	{
		if (NullableType.IsNullable(lhs.Type))
		{
			IType underlyingType = NullableType.GetUnderlyingType(lhs.Type);
			if (TryConvert(ref rhs, underlyingType))
			{
				return BinaryOperatorResolveResult(underlyingType, lhs, BinaryOperatorType.NullCoalescing, rhs);
			}
		}
		if (TryConvert(ref rhs, lhs.Type))
		{
			return BinaryOperatorResolveResult(lhs.Type, lhs, BinaryOperatorType.NullCoalescing, rhs);
		}
		if (TryConvert(ref lhs, rhs.Type))
		{
			return BinaryOperatorResolveResult(rhs.Type, lhs, BinaryOperatorType.NullCoalescing, rhs);
		}
		return new ErrorResolveResult(lhs.Type);
	}

	public IEnumerable<IParameterizedMember> GetUserDefinedOperatorCandidates(IType type, string operatorName)
	{
		if (operatorName == null)
		{
			return EmptyList<IMethod>.Instance;
		}
		TypeCode typeCode = type.GetTypeCode();
		if ((TypeCode.Boolean <= typeCode && typeCode <= TypeCode.Decimal) || typeCode == TypeCode.String)
		{
			return EmptyList<IMethod>.Instance;
		}
		List<IMethod> list = Enumerable.ToList<IMethod>(type.GetMethods((IMethod m) => m.IsOperator && m.Name == operatorName));
		LiftUserDefinedOperators(list);
		return list;
	}

	private void LiftUserDefinedOperators(List<IMethod> operators)
	{
		int count = operators.Count;
		for (int i = 0; i < count; i = checked(i + 1))
		{
			IMethod method = CSharpOperators.LiftUserDefinedOperator(operators[i]);
			if (method != null)
			{
				operators.Add(method);
			}
		}
	}

	private ResolveResult CreateResolveResultForUserDefinedOperator(OverloadResolution r, ExpressionType operatorType)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		if (r.BestCandidateErrors != OverloadResolutionErrors.None)
		{
			return r.CreateResolveResult(null);
		}
		IMethod method = (IMethod)r.BestCandidate;
		return new OperatorResolveResult(method.ReturnType, operatorType, method, method is ILiftedOperator, r.GetArgumentsWithConversions());
	}

	private bool TryConvert(ref ResolveResult rr, IType targetType)
	{
		Conversion conversion = conversions.ImplicitConversion(rr, targetType);
		if (conversion.IsValid)
		{
			rr = Convert(rr, targetType, conversion);
			return true;
		}
		return false;
	}

	private bool TryConvertEnum(ref ResolveResult rr, IType targetType, ref bool isNullable, ref ResolveResult enumRR, bool allowConversionFromConstantZero = true)
	{
		Conversion conversion;
		if (!isNullable)
		{
			conversion = conversions.ImplicitConversion(rr, targetType);
			if (conversion.IsValid && (allowConversionFromConstantZero || !conversion.IsEnumerationConversion))
			{
				rr = Convert(rr, targetType, conversion);
				return true;
			}
		}
		if (!targetType.IsKnownType(KnownTypeCode.NullableOfT))
		{
			targetType = NullableType.Create(compilation, targetType);
		}
		conversion = conversions.ImplicitConversion(rr, targetType);
		if (conversion.IsValid && (allowConversionFromConstantZero || !conversion.IsEnumerationConversion))
		{
			rr = Convert(rr, targetType, conversion);
			isNullable = true;
			if (!enumRR.Type.IsKnownType(KnownTypeCode.NullableOfT))
			{
				IType targetType2 = NullableType.Create(compilation, enumRR.Type);
				enumRR = new ConversionResolveResult(targetType2, enumRR, Conversion.ImplicitNullableConversion);
			}
			return true;
		}
		return false;
	}

	private ResolveResult Convert(ResolveResult rr, IType targetType)
	{
		return Convert(rr, targetType, conversions.ImplicitConversion(rr, targetType));
	}

	private ResolveResult Convert(ResolveResult rr, IType targetType, Conversion c)
	{
		if (c == Conversion.IdentityConversion)
		{
			return rr;
		}
		if (rr.IsCompileTimeConstant && c != Conversion.None && !c.IsUserDefined)
		{
			return ResolveCast(targetType, rr);
		}
		return new ConversionResolveResult(targetType, rr, c, checkForOverflow);
	}

	public ResolveResult ResolveCast(IType targetType, ResolveResult expression)
	{
		Conversion conversion = conversions.ExplicitConversion(expression, targetType);
		if (expression.IsCompileTimeConstant && !conversion.IsUserDefined)
		{
			TypeCode typeCode = targetType.GetTypeCode();
			if (typeCode >= TypeCode.Boolean && typeCode <= TypeCode.Decimal && expression.ConstantValue != null)
			{
				try
				{
					return new ConstantResolveResult(targetType, CSharpPrimitiveCast(typeCode, expression.ConstantValue));
				}
				catch (OverflowException)
				{
					return new ErrorResolveResult(targetType);
				}
				catch (InvalidCastException)
				{
					return new ErrorResolveResult(targetType);
				}
			}
			if (typeCode == TypeCode.String)
			{
				if (expression.ConstantValue == null || expression.ConstantValue is string)
				{
					return new ConstantResolveResult(targetType, expression.ConstantValue);
				}
				return new ErrorResolveResult(targetType);
			}
			if (targetType.Kind == TypeKind.Enum)
			{
				typeCode = GetEnumUnderlyingType(targetType).GetTypeCode();
				if (typeCode >= TypeCode.SByte && typeCode <= TypeCode.UInt64 && expression.ConstantValue != null)
				{
					try
					{
						return new ConstantResolveResult(targetType, CSharpPrimitiveCast(typeCode, expression.ConstantValue));
					}
					catch (OverflowException)
					{
						return new ErrorResolveResult(targetType);
					}
					catch (InvalidCastException)
					{
						return new ErrorResolveResult(targetType);
					}
				}
			}
		}
		return new ConversionResolveResult(targetType, expression, conversion, checkForOverflow);
	}

	internal object CSharpPrimitiveCast(TypeCode targetType, object input)
	{
		return DecompTools.Decompiler.Util.CSharpPrimitiveCast.Cast(targetType, input, CheckForOverflow);
	}

	public ResolveResult ResolveSimpleName(string identifier, IReadOnlyList<IType> typeArguments, bool isInvocationTarget = false)
	{
		return LookupSimpleNameOrTypeName(identifier, typeArguments, isInvocationTarget ? NameLookupMode.InvocationTarget : NameLookupMode.Expression);
	}

	public ResolveResult LookupSimpleNameOrTypeName(string identifier, IReadOnlyList<IType> typeArguments, NameLookupMode lookupMode)
	{
		if (identifier == null)
		{
			throw new ArgumentNullException("identifier");
		}
		if (typeArguments == null)
		{
			throw new ArgumentNullException("typeArguments");
		}
		int count = typeArguments.Count;
		if (count == 0)
		{
			if (lookupMode == NameLookupMode.Expression || lookupMode == NameLookupMode.InvocationTarget)
			{
				foreach (IVariable localVariable in LocalVariables)
				{
					if (localVariable.Name == identifier)
					{
						return new LocalResolveResult(localVariable);
					}
				}
				if (CurrentMember is IParameterizedMember parameterizedMember)
				{
					foreach (IParameter parameter in parameterizedMember.Parameters)
					{
						if (parameter.Name == identifier)
						{
							return new LocalResolveResult(parameter);
						}
					}
				}
			}
			if (CurrentMember is IMethod method)
			{
				foreach (ITypeParameter typeParameter in method.TypeParameters)
				{
					if (typeParameter.Name == identifier)
					{
						return new TypeResolveResult(typeParameter);
					}
				}
			}
		}
		bool parameterizeResultType = typeArguments.Count == 0 || !Enumerable.All<IType>((IEnumerable<IType>)typeArguments, (Func<IType, bool>)((IType t) => t.Kind == TypeKind.UnboundTypeArgument));
		ResolveResult value = null;
		if (currentTypeDefinitionCache != null)
		{
			Dictionary<string, ResolveResult> dictionary = null;
			bool flag = false;
			if (count == 0)
			{
				switch (lookupMode)
				{
				case NameLookupMode.Expression:
					dictionary = currentTypeDefinitionCache.SimpleNameLookupCacheExpression;
					break;
				case NameLookupMode.InvocationTarget:
					dictionary = currentTypeDefinitionCache.SimpleNameLookupCacheInvocationTarget;
					break;
				case NameLookupMode.Type:
					dictionary = currentTypeDefinitionCache.SimpleTypeLookupCache;
					break;
				}
				if (dictionary != null)
				{
					lock (dictionary)
					{
						flag = dictionary.TryGetValue(identifier, out value);
					}
				}
			}
			if (flag)
			{
				value = value?.ShallowClone();
			}
			else
			{
				value = LookInCurrentType(identifier, typeArguments, lookupMode, parameterizeResultType);
				if (dictionary != null)
				{
					lock (dictionary)
					{
						dictionary[identifier] = value;
					}
				}
			}
			if (value != null)
			{
				return value;
			}
		}
		if (context.CurrentUsingScope == null)
		{
			value = LookInUsingScopeNamespace(null, compilation.RootNamespace, identifier, typeArguments, parameterizeResultType);
		}
		else if (count == 0 && lookupMode != NameLookupMode.TypeInUsingDeclaration)
		{
			if (context.CurrentUsingScope.ResolveCache.TryGetValue(identifier, ref value))
			{
				value = value?.ShallowClone();
			}
			else
			{
				value = LookInCurrentUsingScope(identifier, typeArguments, isInUsingDeclaration: false, parameterizeResultType: false);
				context.CurrentUsingScope.ResolveCache.TryAdd(identifier, value);
			}
		}
		else
		{
			value = LookInCurrentUsingScope(identifier, typeArguments, lookupMode == NameLookupMode.TypeInUsingDeclaration, parameterizeResultType);
		}
		if (value != null)
		{
			return value;
		}
		if (typeArguments.Count == 0 && identifier == "dynamic")
		{
			return new TypeResolveResult(SpecialType.Dynamic);
		}
		return new UnknownIdentifierResolveResult(identifier, typeArguments.Count);
	}

	public bool IsVariableReferenceWithSameType(ResolveResult rr, string identifier, out TypeResolveResult trr)
	{
		if (!(rr is MemberResolveResult) && !(rr is LocalResolveResult))
		{
			trr = null;
			return false;
		}
		trr = LookupSimpleNameOrTypeName(identifier, EmptyList<IType>.Instance, NameLookupMode.Type) as TypeResolveResult;
		return trr != null && trr.Type.Equals(rr.Type);
	}

	private ResolveResult LookInCurrentType(string identifier, IReadOnlyList<IType> typeArguments, NameLookupMode lookupMode, bool parameterizeResultType)
	{
		int count = typeArguments.Count;
		MemberLookup memberLookup = CreateMemberLookup(lookupMode);
		for (ITypeDefinition typeDefinition = CurrentTypeDefinition; typeDefinition != null; typeDefinition = typeDefinition.DeclaringTypeDefinition)
		{
			if (count == 0)
			{
				IReadOnlyList<ITypeParameter> typeParameters = typeDefinition.TypeParameters;
				for (int i = 0; i < typeParameters.Count; i = checked(i + 1))
				{
					if (typeParameters[i].Name == identifier)
					{
						return new TypeResolveResult(typeParameters[i]);
					}
				}
			}
			if (lookupMode != NameLookupMode.BaseTypeReference || typeDefinition != CurrentTypeDefinition)
			{
				ResolveResult resolveResult;
				if (lookupMode == NameLookupMode.Expression || lookupMode == NameLookupMode.InvocationTarget)
				{
					ResolveResult targetResolveResult = ((typeDefinition == CurrentTypeDefinition) ? ResolveThisReference() : new TypeResolveResult(typeDefinition));
					resolveResult = memberLookup.Lookup(targetResolveResult, identifier, typeArguments, lookupMode == NameLookupMode.InvocationTarget);
				}
				else
				{
					resolveResult = memberLookup.LookupType(typeDefinition, identifier, typeArguments, parameterizeResultType);
				}
				if (!(resolveResult is UnknownMemberResolveResult))
				{
					return resolveResult;
				}
			}
		}
		return null;
	}

	private ResolveResult LookInCurrentUsingScope(string identifier, IReadOnlyList<IType> typeArguments, bool isInUsingDeclaration, bool parameterizeResultType)
	{
		ResolvedUsingScope currentUsingScope = CurrentUsingScope;
		for (ResolvedUsingScope resolvedUsingScope = currentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
		{
			ResolveResult resolveResult = LookInUsingScopeNamespace(resolvedUsingScope, resolvedUsingScope.Namespace, identifier, typeArguments, parameterizeResultType);
			if (resolveResult != null)
			{
				return resolveResult;
			}
			if (typeArguments.Count == 0)
			{
				if (resolvedUsingScope.ExternAliases.Contains(identifier))
				{
					return ResolveExternAlias(identifier);
				}
				if (!isInUsingDeclaration || resolvedUsingScope != currentUsingScope)
				{
					foreach (KeyValuePair<string, ResolveResult> usingAlias in resolvedUsingScope.UsingAliases)
					{
						if (usingAlias.Key == identifier)
						{
							return usingAlias.Value.ShallowClone();
						}
					}
				}
			}
			if (!isInUsingDeclaration || resolvedUsingScope != currentUsingScope)
			{
				IType type = null;
				foreach (INamespace @using in resolvedUsingScope.Usings)
				{
					ITypeDefinition typeDefinition = @using.GetTypeDefinition(identifier, typeArguments.Count);
					if (typeDefinition == null)
					{
						continue;
					}
					IType type2 = ((!parameterizeResultType || typeArguments.Count <= 0) ? ((IType)typeDefinition) : ((IType)new ParameterizedType(typeDefinition, typeArguments)));
					if (type == null || !TopLevelTypeDefinitionIsAccessible(type.GetDefinition()))
					{
						if (TopLevelTypeDefinitionIsAccessible(type2.GetDefinition()))
						{
							type = type2;
						}
					}
					else if (TopLevelTypeDefinitionIsAccessible(typeDefinition))
					{
						return new AmbiguousTypeResolveResult(type);
					}
				}
				if (type != null)
				{
					return new TypeResolveResult(type);
				}
			}
		}
		return null;
	}

	private ResolveResult LookInUsingScopeNamespace(ResolvedUsingScope usingScope, INamespace n, string identifier, IReadOnlyList<IType> typeArguments, bool parameterizeResultType)
	{
		if (n == null)
		{
			return null;
		}
		int count = typeArguments.Count;
		if (count == 0)
		{
			INamespace childNamespace = n.GetChildNamespace(identifier);
			if (childNamespace != null)
			{
				if (usingScope != null && usingScope.HasAlias(identifier))
				{
					return new AmbiguousTypeResolveResult(new UnknownType(null, identifier));
				}
				return new NamespaceResolveResult(childNamespace);
			}
		}
		ITypeDefinition typeDefinition = n.GetTypeDefinition(identifier, count);
		if (typeDefinition != null)
		{
			IType type = typeDefinition;
			if (parameterizeResultType && count > 0)
			{
				type = new ParameterizedType(typeDefinition, typeArguments);
			}
			if (usingScope != null && usingScope.HasAlias(identifier))
			{
				return new AmbiguousTypeResolveResult(type);
			}
			return new TypeResolveResult(type);
		}
		return null;
	}

	private bool TopLevelTypeDefinitionIsAccessible(ITypeDefinition typeDef)
	{
		if (typeDef.Accessibility == Accessibility.Internal)
		{
			return typeDef.ParentModule.InternalsVisibleTo(compilation.MainModule);
		}
		return true;
	}

	public ResolveResult ResolveAlias(string identifier)
	{
		if (identifier == "global")
		{
			return new NamespaceResolveResult(compilation.RootNamespace);
		}
		for (ResolvedUsingScope resolvedUsingScope = CurrentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
		{
			if (resolvedUsingScope.ExternAliases.Contains(identifier))
			{
				return ResolveExternAlias(identifier);
			}
			foreach (KeyValuePair<string, ResolveResult> usingAlias in resolvedUsingScope.UsingAliases)
			{
				if (usingAlias.Key == identifier)
				{
					return (usingAlias.Value as NamespaceResolveResult) ?? ErrorResult;
				}
			}
		}
		return ErrorResult;
	}

	private ResolveResult ResolveExternAlias(string alias)
	{
		INamespace namespaceForExternAlias = compilation.GetNamespaceForExternAlias(alias);
		if (namespaceForExternAlias != null)
		{
			return new NamespaceResolveResult(namespaceForExternAlias);
		}
		return ErrorResult;
	}

	public ResolveResult ResolveMemberAccess(ResolveResult target, string identifier, IReadOnlyList<IType> typeArguments, NameLookupMode lookupMode = NameLookupMode.Expression)
	{
		bool parameterizeResultType = typeArguments.Count == 0 || !Enumerable.All<IType>((IEnumerable<IType>)typeArguments, (Func<IType, bool>)((IType t) => t.Kind == TypeKind.UnboundTypeArgument));
		if (target is NamespaceResolveResult nrr)
		{
			return ResolveMemberAccessOnNamespace(nrr, identifier, typeArguments, parameterizeResultType);
		}
		if (target.Type.Kind == TypeKind.Dynamic)
		{
			return new DynamicMemberResolveResult(target, identifier);
		}
		MemberLookup memberLookup = CreateMemberLookup(lookupMode);
		ResolveResult resolveResult;
		switch (lookupMode)
		{
		case NameLookupMode.Expression:
			resolveResult = memberLookup.Lookup(target, identifier, typeArguments, isInvocation: false);
			break;
		case NameLookupMode.InvocationTarget:
			resolveResult = memberLookup.Lookup(target, identifier, typeArguments, isInvocation: true);
			break;
		case NameLookupMode.Type:
		case NameLookupMode.TypeInUsingDeclaration:
		case NameLookupMode.BaseTypeReference:
			return memberLookup.LookupType(target.Type, identifier, typeArguments, parameterizeResultType);
		default:
			throw new NotSupportedException("Invalid value for NameLookupMode");
		}
		if (resolveResult is UnknownMemberResolveResult)
		{
			List<List<IMethod>> extensionMethods = GetExtensionMethods(identifier, typeArguments);
			if (extensionMethods.Count > 0)
			{
				return new MethodGroupResolveResult(target, identifier, EmptyList<MethodListWithDeclaringType>.Instance, typeArguments)
				{
					extensionMethods = extensionMethods
				};
			}
		}
		else if (resolveResult is MethodGroupResolveResult methodGroupResolveResult)
		{
			Debug.Assert(methodGroupResolveResult.extensionMethods == null);
			methodGroupResolveResult.resolver = this;
		}
		return resolveResult;
	}

	private ResolveResult ResolveMemberAccessOnNamespace(NamespaceResolveResult nrr, string identifier, IReadOnlyList<IType> typeArguments, bool parameterizeResultType)
	{
		if (typeArguments.Count == 0)
		{
			INamespace childNamespace = nrr.Namespace.GetChildNamespace(identifier);
			if (childNamespace != null)
			{
				return new NamespaceResolveResult(childNamespace);
			}
		}
		ITypeDefinition typeDefinition = nrr.Namespace.GetTypeDefinition(identifier, typeArguments.Count);
		if (typeDefinition != null)
		{
			if (parameterizeResultType && typeArguments.Count > 0)
			{
				return new TypeResolveResult(new ParameterizedType(typeDefinition, typeArguments));
			}
			return new TypeResolveResult(typeDefinition);
		}
		return ErrorResult;
	}

	public MemberLookup CreateMemberLookup()
	{
		ITypeDefinition currentTypeDefinition = CurrentTypeDefinition;
		bool isInEnumMemberInitializer = CurrentMember != null && CurrentMember.SymbolKind == SymbolKind.Field && currentTypeDefinition != null && currentTypeDefinition.Kind == TypeKind.Enum;
		return new MemberLookup(currentTypeDefinition, Compilation.MainModule, isInEnumMemberInitializer);
	}

	public MemberLookup CreateMemberLookup(NameLookupMode lookupMode)
	{
		if (lookupMode == NameLookupMode.BaseTypeReference && CurrentTypeDefinition != null)
		{
			return new MemberLookup(CurrentTypeDefinition.DeclaringTypeDefinition, Compilation.MainModule);
		}
		return CreateMemberLookup();
	}

	public ResolveResult ResolveIdentifierInObjectInitializer(string identifier)
	{
		MemberLookup memberLookup = CreateMemberLookup();
		return memberLookup.Lookup(CurrentObjectInitializer, identifier, EmptyList<IType>.Instance, isInvocation: false);
	}

	public ForEachResolveResult ResolveForeach(ResolveResult expression)
	{
		MemberLookup memberLookup = CreateMemberLookup();
		ResolveResult resolveResult = null;
		IType collectionType;
		IType enumeratorType;
		IType elementType;
		ResolveResult target;
		if (expression.Type.Kind == TypeKind.Array || expression.Type.Kind == TypeKind.Dynamic)
		{
			collectionType = compilation.FindType(KnownTypeCode.IEnumerable);
			enumeratorType = compilation.FindType(KnownTypeCode.IEnumerator);
			elementType = ((expression.Type.Kind != TypeKind.Array) ? SpecialType.Dynamic : ((ArrayType)expression.Type).ElementType);
			target = ResolveCast(collectionType, expression);
			target = ResolveMemberAccess(target, "GetEnumerator", EmptyList<IType>.Instance, NameLookupMode.InvocationTarget);
			target = ResolveInvocation(target, new ResolveResult[0]);
		}
		else if (memberLookup.Lookup(expression, "GetEnumerator", EmptyList<IType>.Instance, isInvocation: true) is MethodGroupResolveResult methodGroupResolveResult)
		{
			OverloadResolution overloadResolution = methodGroupResolveResult.PerformOverloadResolution(compilation, new ResolveResult[0], null, allowExtensionMethods: false, allowExpandingParams: false, allowOptionalParameters: false);
			if (overloadResolution.FoundApplicableCandidate && !overloadResolution.IsAmbiguous && !overloadResolution.BestCandidate.IsStatic && overloadResolution.BestCandidate.Accessibility == Accessibility.Public)
			{
				collectionType = expression.Type;
				target = overloadResolution.CreateResolveResult(expression);
				enumeratorType = target.Type;
				resolveResult = memberLookup.Lookup(new ResolveResult(enumeratorType), "Current", EmptyList<IType>.Instance, isInvocation: false);
				elementType = resolveResult.Type;
			}
			else
			{
				CheckForEnumerableInterface(expression, out collectionType, out enumeratorType, out elementType, out target);
			}
		}
		else
		{
			CheckForEnumerableInterface(expression, out collectionType, out enumeratorType, out elementType, out target);
		}
		IMethod moveNextMethod = null;
		if (memberLookup.Lookup(new ResolveResult(enumeratorType), "MoveNext", EmptyList<IType>.Instance, isInvocation: false) is MethodGroupResolveResult methodGroupResolveResult2)
		{
			OverloadResolution overloadResolution2 = methodGroupResolveResult2.PerformOverloadResolution(compilation, new ResolveResult[0], null, allowExtensionMethods: false, allowExpandingParams: false, allowOptionalParameters: false);
			moveNextMethod = overloadResolution2.GetBestCandidateWithSubstitutedTypeArguments() as IMethod;
		}
		if (resolveResult == null)
		{
			resolveResult = memberLookup.Lookup(new ResolveResult(enumeratorType), "Current", EmptyList<IType>.Instance, isInvocation: false);
		}
		IProperty currentProperty = null;
		if (resolveResult is MemberResolveResult)
		{
			currentProperty = ((MemberResolveResult)resolveResult).Member as IProperty;
		}
		IType voidType = compilation.FindType(KnownTypeCode.Void);
		return new ForEachResolveResult(target, collectionType, enumeratorType, elementType, currentProperty, moveNextMethod, voidType);
	}

	private void CheckForEnumerableInterface(ResolveResult expression, out IType collectionType, out IType enumeratorType, out IType elementType, out ResolveResult getEnumeratorInvocation)
	{
		elementType = expression.Type.GetElementTypeFromIEnumerable(compilation, allowIEnumerator: false, out var isGeneric);
		if (isGeneric == true)
		{
			ITypeDefinition definition = compilation.FindType(KnownTypeCode.IEnumerableOfT).GetDefinition();
			if (definition != null)
			{
				collectionType = new ParameterizedType(definition, new IType[1] { elementType });
			}
			else
			{
				collectionType = SpecialType.UnknownType;
			}
			ITypeDefinition definition2 = compilation.FindType(KnownTypeCode.IEnumeratorOfT).GetDefinition();
			if (definition2 != null)
			{
				enumeratorType = new ParameterizedType(definition2, new IType[1] { elementType });
			}
			else
			{
				enumeratorType = SpecialType.UnknownType;
			}
		}
		else if (isGeneric == false)
		{
			collectionType = compilation.FindType(KnownTypeCode.IEnumerable);
			enumeratorType = compilation.FindType(KnownTypeCode.IEnumerator);
		}
		else
		{
			collectionType = SpecialType.UnknownType;
			enumeratorType = SpecialType.UnknownType;
		}
		getEnumeratorInvocation = ResolveCast(collectionType, expression);
		getEnumeratorInvocation = ResolveMemberAccess(getEnumeratorInvocation, "GetEnumerator", EmptyList<IType>.Instance, NameLookupMode.InvocationTarget);
		getEnumeratorInvocation = ResolveInvocation(getEnumeratorInvocation, new ResolveResult[0]);
	}

	public List<List<IMethod>> GetExtensionMethods(string name = null, IReadOnlyList<IType> typeArguments = null)
	{
		return GetExtensionMethods(null, name, typeArguments);
	}

	public List<List<IMethod>> GetExtensionMethods(IType targetType, string name = null, IReadOnlyList<IType> typeArguments = null, bool substituteInferredTypes = false)
	{
		MemberLookup memberLookup = CreateMemberLookup();
		List<List<IMethod>> list = new List<List<IMethod>>();
		foreach (List<IMethod> allExtensionMethod in GetAllExtensionMethods(memberLookup))
		{
			List<IMethod> list2 = new List<IMethod>();
			foreach (IMethod item in allExtensionMethod)
			{
				if ((name != null && item.Name != name) || !memberLookup.IsAccessible(item, allowProtectedAccess: false))
				{
					continue;
				}
				IType[] outInferredTypes;
				if (typeArguments != null && typeArguments.Count > 0)
				{
					if (item.TypeParameters.Count == typeArguments.Count)
					{
						IMethod method = item.Specialize(new TypeParameterSubstitution(null, typeArguments));
						if (IsEligibleExtensionMethod(compilation, conversions, targetType, method, useTypeInference: false, out outInferredTypes))
						{
							list2.Add(method);
						}
					}
				}
				else if (IsEligibleExtensionMethod(compilation, conversions, targetType, item, useTypeInference: true, out outInferredTypes))
				{
					if (substituteInferredTypes && outInferredTypes != null)
					{
						list2.Add(item.Specialize(new TypeParameterSubstitution(null, outInferredTypes)));
					}
					else
					{
						list2.Add(item);
					}
				}
			}
			if (list2.Count > 0)
			{
				list.Add(list2);
			}
		}
		return list;
	}

	public static bool IsEligibleExtensionMethod(IType targetType, IMethod method, bool useTypeInference, out IType[] outInferredTypes)
	{
		if (targetType == null)
		{
			throw new ArgumentNullException("targetType");
		}
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		ICompilation compilation = method.Compilation;
		return IsEligibleExtensionMethod(compilation, CSharpConversions.Get(compilation), targetType, method, useTypeInference, out outInferredTypes);
	}

	private static bool IsEligibleExtensionMethod(ICompilation compilation, CSharpConversions conversions, IType targetType, IMethod method, bool useTypeInference, out IType[] outInferredTypes)
	{
		outInferredTypes = null;
		if (targetType == null)
		{
			return true;
		}
		if (method.Parameters.Count == 0)
		{
			return false;
		}
		IType type = method.Parameters[0].Type;
		if (useTypeInference && method.TypeParameters.Count > 0)
		{
			TypeInference typeInference = new TypeInference(compilation, conversions);
			ResolveResult[] arguments = new ResolveResult[1]
			{
				new ResolveResult(targetType)
			};
			IType[] parameterTypes = new IType[1] { method.Parameters[0].Type };
			IType[] array = typeInference.InferTypeArguments(method.TypeParameters, arguments, parameterTypes, out var _);
			TypeParameterSubstitution typeParameterSubstitution = new TypeParameterSubstitution(null, array);
			bool flag = false;
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				if (array[i].Kind != TypeKind.Unknown && array[i].Kind != TypeKind.UnboundTypeArgument)
				{
					flag = true;
					if (!OverloadResolution.ValidateConstraints(method.TypeParameters[i], array[i], typeParameterSubstitution, conversions))
					{
						return false;
					}
				}
				else
				{
					array[i] = method.TypeParameters[i];
				}
			}
			if (flag)
			{
				outInferredTypes = array;
			}
			type = type.AcceptVisitor(typeParameterSubstitution);
		}
		Conversion conversion = conversions.ImplicitConversion(targetType, type);
		return conversion.IsValid && (conversion.IsIdentityConversion || conversion.IsReferenceConversion || conversion.IsBoxingConversion);
	}

	private IList<List<IMethod>> GetAllExtensionMethods(MemberLookup lookup)
	{
		ResolvedUsingScope currentUsingScope = context.CurrentUsingScope;
		if (currentUsingScope == null)
		{
			return EmptyList<List<IMethod>>.Instance;
		}
		List<List<IMethod>> list = LazyInit.VolatileRead(ref currentUsingScope.AllExtensionMethods);
		if (list != null)
		{
			return list;
		}
		list = new List<List<IMethod>>();
		for (ResolvedUsingScope resolvedUsingScope = currentUsingScope; resolvedUsingScope != null; resolvedUsingScope = resolvedUsingScope.Parent)
		{
			INamespace obj = resolvedUsingScope.Namespace;
			List<IMethod> list2;
			if (obj != null)
			{
				list2 = Enumerable.ToList<IMethod>(GetExtensionMethods(lookup, obj));
				if (list2.Count > 0)
				{
					list.Add(list2);
				}
			}
			list2 = Enumerable.ToList<IMethod>(Enumerable.SelectMany<INamespace, IMethod>(Enumerable.Distinct<INamespace>((IEnumerable<INamespace>)resolvedUsingScope.Usings), (Func<INamespace, IEnumerable<IMethod>>)((INamespace importedNamespace) => GetExtensionMethods(lookup, importedNamespace))));
			if (list2.Count > 0)
			{
				list.Add(list2);
			}
		}
		return LazyInit.GetOrSet(ref currentUsingScope.AllExtensionMethods, list);
	}

	private IEnumerable<IMethod> GetExtensionMethods(MemberLookup lookup, INamespace ns)
	{
		return Enumerable.Select(Enumerable.Where(Enumerable.SelectMany(Enumerable.Where<ITypeDefinition>(ns.Types, (Func<ITypeDefinition, bool>)((ITypeDefinition c) => c.IsStatic && c.HasExtensionMethods && c.TypeParameters.Count == 0 && lookup.IsAccessible(c, allowProtectedAccess: false))), (Func<ITypeDefinition, IEnumerable<IMethod>>)((ITypeDefinition c) => c.Methods), (ITypeDefinition c, IMethod m) => new { c, m }), _003C_003Eh__TransparentIdentifier0 => _003C_003Eh__TransparentIdentifier0.m.IsExtensionMethod), _003C_003Eh__TransparentIdentifier0 => _003C_003Eh__TransparentIdentifier0.m);
	}

	private IList<ResolveResult> AddArgumentNamesIfNecessary(ResolveResult[] arguments, string[] argumentNames)
	{
		if (argumentNames == null)
		{
			return arguments;
		}
		ResolveResult[] array = new ResolveResult[arguments.Length];
		for (int i = 0; i < arguments.Length; i = checked(i + 1))
		{
			array[i] = ((argumentNames[i] != null) ? new NamedArgumentResolveResult(argumentNames[i], arguments[i]) : arguments[i]);
		}
		return array;
	}

	private ResolveResult ResolveInvocation(ResolveResult target, ResolveResult[] arguments, string[] argumentNames, bool allowOptionalParameters)
	{
		if (target.Type.Kind == TypeKind.Dynamic)
		{
			return new DynamicInvocationResolveResult(target, DynamicInvocationType.Invocation, AddArgumentNamesIfNecessary(arguments, argumentNames));
		}
		bool flag = arguments.Any((ResolveResult a) => a.Type.Kind == TypeKind.Dynamic);
		checked
		{
			if (target is MethodGroupResolveResult methodGroupResolveResult)
			{
				if (flag)
				{
					OverloadResolution or2 = CreateOverloadResolution(arguments, argumentNames, Enumerable.ToArray<IType>((IEnumerable<IType>)methodGroupResolveResult.TypeArguments));
					var list = Enumerable.ToList(Enumerable.Where(Enumerable.SelectMany(methodGroupResolveResult.MethodsGroupedByDeclaringType, (Func<MethodListWithDeclaringType, IEnumerable<IParameterizedMember>>)((MethodListWithDeclaringType m) => m), (MethodListWithDeclaringType x, IParameterizedMember m) => new
					{
						DeclaringType = x.DeclaringType,
						Method = m
					}), x => OverloadResolution.IsApplicable(or2.AddCandidate(x.Method))));
					if (list.Count > 1)
					{
						ResolveResult targetResult = ((!list.All(x => x.Method.IsStatic) || methodGroupResolveResult.TargetResult is TypeResolveResult) ? methodGroupResolveResult.TargetResult : new TypeResolveResult(methodGroupResolveResult.TargetType));
						List<MethodListWithDeclaringType> list2 = new List<MethodListWithDeclaringType>();
						foreach (var item in list)
						{
							if (list2.Count == 0 || list2[list2.Count - 1].DeclaringType != item.DeclaringType)
							{
								list2.Add(new MethodListWithDeclaringType(item.DeclaringType));
							}
							list2[list2.Count - 1].Add(item.Method);
						}
						return new DynamicInvocationResolveResult(new MethodGroupResolveResult(targetResult, methodGroupResolveResult.MethodName, list2, methodGroupResolveResult.TypeArguments), DynamicInvocationType.Invocation, AddArgumentNamesIfNecessary(arguments, argumentNames));
					}
				}
				ICompilation obj = compilation;
				bool flag2 = checkForOverflow;
				CSharpConversions cSharpConversions = conversions;
				OverloadResolution overloadResolution = methodGroupResolveResult.PerformOverloadResolution(obj, arguments, argumentNames, allowExtensionMethods: true, allowExpandingParams: true, allowOptionalParameters, flag2, cSharpConversions);
				if (overloadResolution.BestCandidate != null)
				{
					if (overloadResolution.BestCandidate.IsStatic && !overloadResolution.IsExtensionMethodInvocation && !(methodGroupResolveResult.TargetResult is TypeResolveResult))
					{
						return overloadResolution.CreateResolveResult(new TypeResolveResult(methodGroupResolveResult.TargetType), null, flag ? SpecialType.Dynamic : null);
					}
					return overloadResolution.CreateResolveResult(methodGroupResolveResult.TargetResult, null, flag ? SpecialType.Dynamic : null);
				}
				return new UnknownMethodResolveResult(methodGroupResolveResult.TargetType, methodGroupResolveResult.MethodName, methodGroupResolveResult.TypeArguments, CreateParameters(arguments, argumentNames));
			}
			if (target is UnknownMemberResolveResult unknownMemberResolveResult)
			{
				return new UnknownMethodResolveResult(unknownMemberResolveResult.TargetType, unknownMemberResolveResult.MemberName, unknownMemberResolveResult.TypeArguments, CreateParameters(arguments, argumentNames));
			}
			if (target is UnknownIdentifierResolveResult unknownIdentifierResolveResult && CurrentTypeDefinition != null)
			{
				return new UnknownMethodResolveResult(CurrentTypeDefinition, unknownIdentifierResolveResult.Identifier, EmptyList<IType>.Instance, CreateParameters(arguments, argumentNames));
			}
			IMethod delegateInvokeMethod = target.Type.GetDelegateInvokeMethod();
			if (delegateInvokeMethod != null)
			{
				OverloadResolution overloadResolution2 = CreateOverloadResolution(arguments, argumentNames);
				overloadResolution2.AddCandidate(delegateInvokeMethod);
				return new CSharpInvocationResolveResult(target, delegateInvokeMethod, overloadResolution2.GetArgumentsWithConversionsAndNames(), overloadResolution2.BestCandidateErrors, isExtensionMethodInvocation: false, overloadResolution2.BestCandidateIsExpandedForm, isDelegateInvocation: true, overloadResolution2.GetArgumentToParameterMap(), null, flag ? SpecialType.Dynamic : null);
			}
			return ErrorResult;
		}
	}

	public ResolveResult ResolveInvocation(ResolveResult target, ResolveResult[] arguments, string[] argumentNames = null)
	{
		return ResolveInvocation(target, arguments, argumentNames, allowOptionalParameters: true);
	}

	private List<IParameter> CreateParameters(ResolveResult[] arguments, string[] argumentNames)
	{
		List<IParameter> list = new List<IParameter>();
		if (argumentNames == null)
		{
			argumentNames = new string[arguments.Length];
		}
		else
		{
			if (argumentNames.Length != arguments.Length)
			{
				throw new ArgumentException();
			}
			argumentNames = (string[])argumentNames.Clone();
		}
		checked
		{
			for (int i = 0; i < arguments.Length; i++)
			{
				if (argumentNames[i] == null)
				{
					string text = GuessParameterName(arguments[i]);
					if (Enumerable.Contains<string>((IEnumerable<string>)argumentNames, text))
					{
						int num = 1;
						string text2;
						do
						{
							text2 = text + num;
							num++;
						}
						while (Enumerable.Contains<string>((IEnumerable<string>)argumentNames, text2));
						text = text2;
					}
					argumentNames[i] = text;
				}
				if (arguments[i] is ByReferenceResolveResult byReferenceResolveResult)
				{
					list.Add(new DefaultParameter(arguments[i].Type, argumentNames[i], null, null, byReferenceResolveResult.IsRef, byReferenceResolveResult.IsOut));
					continue;
				}
				IType type = arguments[i].Type;
				if (type.Kind == TypeKind.Null || type.Kind == TypeKind.None)
				{
					list.Add(new DefaultParameter(compilation.FindType(KnownTypeCode.Object), argumentNames[i]));
				}
				else
				{
					list.Add(new DefaultParameter(type, argumentNames[i]));
				}
			}
			return list;
		}
	}

	private static string GuessParameterName(ResolveResult rr)
	{
		if (rr is MemberResolveResult memberResolveResult)
		{
			return memberResolveResult.Member.Name;
		}
		if (rr is UnknownMemberResolveResult { MemberName: var memberName })
		{
			return memberName;
		}
		if (!(rr is MethodGroupResolveResult { MethodName: var methodName }))
		{
			if (rr is LocalResolveResult localResolveResult)
			{
				return MakeParameterName(localResolveResult.Variable.Name);
			}
			if (rr.Type.Kind != TypeKind.Unknown && !string.IsNullOrEmpty(rr.Type.Name))
			{
				return MakeParameterName(rr.Type.Name);
			}
			return "parameter";
		}
		return methodName;
	}

	private static string MakeParameterName(string variableName)
	{
		if (string.IsNullOrEmpty(variableName))
		{
			return "parameter";
		}
		if (variableName.Length > 1 && variableName[0] == '_')
		{
			variableName = variableName.Substring(1);
		}
		return char.ToLower(variableName[0]) + variableName.Substring(1);
	}

	private OverloadResolution CreateOverloadResolution(ResolveResult[] arguments, string[] argumentNames = null, IType[] typeArguments = null)
	{
		OverloadResolution overloadResolution = new OverloadResolution(compilation, arguments, argumentNames, typeArguments, conversions);
		overloadResolution.CheckForOverflow = checkForOverflow;
		return overloadResolution;
	}

	public ResolveResult ResolveIndexer(ResolveResult target, ResolveResult[] arguments, string[] argumentNames = null)
	{
		switch (target.Type.Kind)
		{
		case TypeKind.Dynamic:
			return new DynamicInvocationResolveResult(target, DynamicInvocationType.Indexing, AddArgumentNamesIfNecessary(arguments, argumentNames));
		case TypeKind.Array:
		case TypeKind.Pointer:
			AdjustArrayAccessArguments(arguments);
			return new ArrayAccessResolveResult(((TypeWithElementType)target.Type).ElementType, target, arguments);
		default:
		{
			MemberLookup memberLookup = CreateMemberLookup();
			IReadOnlyList<MethodListWithDeclaringType> readOnlyList = memberLookup.LookupIndexers(target);
			if (arguments.Any((ResolveResult a) => a.Type.Kind == TypeKind.Dynamic))
			{
				OverloadResolution or2 = CreateOverloadResolution(arguments, argumentNames);
				List<IParameterizedMember> list = Enumerable.ToList<IParameterizedMember>(Enumerable.Where<IParameterizedMember>(Enumerable.SelectMany<MethodListWithDeclaringType, IParameterizedMember>((IEnumerable<MethodListWithDeclaringType>)readOnlyList, (Func<MethodListWithDeclaringType, IEnumerable<IParameterizedMember>>)((MethodListWithDeclaringType x) => x)), (Func<IParameterizedMember, bool>)((IParameterizedMember m) => OverloadResolution.IsApplicable(or2.AddCandidate(m)))));
				if (list.Count > 1)
				{
					return new DynamicInvocationResolveResult(target, DynamicInvocationType.Indexing, AddArgumentNamesIfNecessary(arguments, argumentNames));
				}
			}
			OverloadResolution overloadResolution = CreateOverloadResolution(arguments, argumentNames);
			overloadResolution.AddMethodLists(readOnlyList);
			if (overloadResolution.BestCandidate != null)
			{
				return overloadResolution.CreateResolveResult(target);
			}
			return ErrorResult;
		}
		}
	}

	private void AdjustArrayAccessArguments(ResolveResult[] arguments)
	{
		for (int i = 0; i < arguments.Length; i = checked(i + 1))
		{
			if (!TryConvert(ref arguments[i], compilation.FindType(KnownTypeCode.Int32)) && !TryConvert(ref arguments[i], compilation.FindType(KnownTypeCode.UInt32)) && !TryConvert(ref arguments[i], compilation.FindType(KnownTypeCode.Int64)) && !TryConvert(ref arguments[i], compilation.FindType(KnownTypeCode.UInt64)))
			{
				arguments[i] = Convert(arguments[i], compilation.FindType(KnownTypeCode.Int32), Conversion.None);
			}
		}
	}

	public ResolveResult ResolveObjectCreation(IType type, ResolveResult[] arguments, string[] argumentNames = null, bool allowProtectedAccess = false, IList<ResolveResult> initializerStatements = null)
	{
		if (type.Kind == TypeKind.Delegate && arguments.Length == 1)
		{
			ResolveResult resolveResult = arguments[0];
			IMethod delegateInvokeMethod = resolveResult.Type.GetDelegateInvokeMethod();
			if (delegateInvokeMethod != null)
			{
				resolveResult = new MethodGroupResolveResult(resolveResult, delegateInvokeMethod.Name, new MethodListWithDeclaringType[1]
				{
					new MethodListWithDeclaringType(resolveResult.Type) { delegateInvokeMethod }
				}, EmptyList<IType>.Instance);
			}
			return Convert(resolveResult, type);
		}
		OverloadResolution overloadResolution = CreateOverloadResolution(arguments, argumentNames);
		MemberLookup memberLookup = CreateMemberLookup();
		List<IMethod> list = (arguments.Any((ResolveResult a) => a.Type.Kind == TypeKind.Dynamic) ? new List<IMethod>() : null);
		foreach (IMethod constructor in type.GetConstructors())
		{
			if (memberLookup.IsAccessible(constructor, allowProtectedAccess))
			{
				OverloadResolutionErrors errors = overloadResolution.AddCandidate(constructor);
				if (list != null && OverloadResolution.IsApplicable(errors))
				{
					list.Add(constructor);
				}
			}
			else
			{
				overloadResolution.AddCandidate(constructor, OverloadResolutionErrors.Inaccessible);
			}
		}
		if (list != null && list.Count > 1)
		{
			return new DynamicInvocationResolveResult(new MethodGroupResolveResult(null, list[0].Name, new MethodListWithDeclaringType[1]
			{
				new MethodListWithDeclaringType(type, list)
			}, null), DynamicInvocationType.ObjectCreation, AddArgumentNamesIfNecessary(arguments, argumentNames), initializerStatements);
		}
		if (overloadResolution.BestCandidate != null)
		{
			return overloadResolution.CreateResolveResult(null, initializerStatements);
		}
		return new ErrorResolveResult(type);
	}

	public ResolveResult ResolveSizeOf(IType type)
	{
		IType @int = compilation.FindType(KnownTypeCode.Int32);
		int? constantValue = null;
		IType type2 = ((type.Kind == TypeKind.Enum) ? type.GetDefinition().EnumUnderlyingType : type);
		switch (type2.GetTypeCode())
		{
		case TypeCode.Boolean:
		case TypeCode.SByte:
		case TypeCode.Byte:
			constantValue = 1;
			break;
		case TypeCode.Char:
		case TypeCode.Int16:
		case TypeCode.UInt16:
			constantValue = 2;
			break;
		case TypeCode.Int32:
		case TypeCode.UInt32:
		case TypeCode.Single:
			constantValue = 4;
			break;
		case TypeCode.Int64:
		case TypeCode.UInt64:
		case TypeCode.Double:
			constantValue = 8;
			break;
		}
		return new SizeOfResolveResult(@int, type, constantValue);
	}

	public ResolveResult ResolveThisReference()
	{
		ITypeDefinition currentTypeDefinition = CurrentTypeDefinition;
		if (currentTypeDefinition != null)
		{
			if (currentTypeDefinition.TypeParameterCount != 0)
			{
				return new ThisResolveResult(new ParameterizedType(currentTypeDefinition, currentTypeDefinition.TypeParameters));
			}
			return new ThisResolveResult(currentTypeDefinition);
		}
		return ErrorResult;
	}

	public ResolveResult ResolveBaseReference()
	{
		ITypeDefinition currentTypeDefinition = CurrentTypeDefinition;
		if (currentTypeDefinition != null)
		{
			foreach (IType directBaseType in currentTypeDefinition.DirectBaseTypes)
			{
				if (directBaseType.Kind != TypeKind.Unknown && directBaseType.Kind != TypeKind.Interface)
				{
					return new ThisResolveResult(directBaseType, causesNonVirtualInvocation: true);
				}
			}
		}
		return ErrorResult;
	}

	public ResolveResult ResolveCondition(ResolveResult input)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		IType type = compilation.FindType(KnownTypeCode.Boolean);
		Conversion conversion = conversions.ImplicitConversion(input, type);
		if (!conversion.IsValid)
		{
			IMethod method = Enumerable.FirstOrDefault<IMethod>(input.Type.GetMethods((IMethod m) => m.IsOperator && m.Name == "op_True"));
			if (method != null)
			{
				conversion = Conversion.UserDefinedConversion(method, isImplicit: true, Conversion.None, Conversion.None);
			}
		}
		return Convert(input, type, conversion);
	}

	public ResolveResult ResolveConditionFalse(ResolveResult input)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		IType type = compilation.FindType(KnownTypeCode.Boolean);
		Conversion conversion = conversions.ImplicitConversion(input, type);
		if (!conversion.IsValid)
		{
			IMethod method = Enumerable.FirstOrDefault<IMethod>(input.Type.GetMethods((IMethod m) => m.IsOperator && m.Name == "op_False"));
			if (method != null)
			{
				conversion = Conversion.UserDefinedConversion(method, isImplicit: true, Conversion.None, Conversion.None);
				return Convert(input, type, conversion);
			}
		}
		return ResolveUnaryOperator(UnaryOperatorType.Not, Convert(input, type, conversion));
	}

	public ResolveResult ResolveConditional(ResolveResult condition, ResolveResult trueExpression, ResolveResult falseExpression)
	{
		IType type;
		bool flag;
		if (trueExpression.Type.Kind == TypeKind.Dynamic || falseExpression.Type.Kind == TypeKind.Dynamic)
		{
			type = SpecialType.Dynamic;
			flag = TryConvert(ref trueExpression, type) & TryConvert(ref falseExpression, type);
		}
		else if (HasType(trueExpression) && HasType(falseExpression))
		{
			Conversion conversion = conversions.ImplicitConversion(trueExpression, falseExpression.Type);
			Conversion conversion2 = conversions.ImplicitConversion(falseExpression, trueExpression.Type);
			if (IsBetterConditionalConversion(conversion, conversion2))
			{
				type = falseExpression.Type;
				flag = true;
				trueExpression = Convert(trueExpression, type, conversion);
			}
			else if (IsBetterConditionalConversion(conversion2, conversion))
			{
				type = trueExpression.Type;
				flag = true;
				falseExpression = Convert(falseExpression, type, conversion2);
			}
			else
			{
				type = trueExpression.Type;
				flag = trueExpression.Type.Equals(falseExpression.Type);
			}
		}
		else if (HasType(trueExpression))
		{
			type = trueExpression.Type;
			flag = TryConvert(ref falseExpression, type);
		}
		else
		{
			if (!HasType(falseExpression))
			{
				return ErrorResult;
			}
			type = falseExpression.Type;
			flag = TryConvert(ref trueExpression, type);
		}
		condition = ResolveCondition(condition);
		if (flag)
		{
			if (condition.IsCompileTimeConstant && trueExpression.IsCompileTimeConstant && falseExpression.IsCompileTimeConstant)
			{
				bool? flag2 = condition.ConstantValue as bool?;
				if (flag2 == true)
				{
					return trueExpression;
				}
				if (flag2 == false)
				{
					return falseExpression;
				}
			}
			return new OperatorResolveResult(type, (ExpressionType)8, condition, trueExpression, falseExpression);
		}
		return new ErrorResolveResult(type);
	}

	private bool IsBetterConditionalConversion(Conversion c1, Conversion c2)
	{
		if (!c1.IsValid)
		{
			return false;
		}
		if (c1 != Conversion.ImplicitConstantExpressionConversion && c2 == Conversion.ImplicitConstantExpressionConversion)
		{
			return true;
		}
		return !c2.IsValid;
	}

	private bool HasType(ResolveResult r)
	{
		return r.Type.Kind != TypeKind.None && r.Type.Kind != TypeKind.Null;
	}

	public ResolveResult ResolvePrimitive(object value)
	{
		if (value == null)
		{
			return new ResolveResult(SpecialType.NullType);
		}
		TypeCode typeCode = Type.GetTypeCode(value.GetType());
		IType type = compilation.FindType(typeCode);
		return new ConstantResolveResult(type, value);
	}

	public ResolveResult ResolveDefaultValue(IType type)
	{
		return new ConstantResolveResult(type, GetDefaultValue(type));
	}

	public static object GetDefaultValue(IType type)
	{
		ITypeDefinition definition = type.GetDefinition();
		if (definition == null)
		{
			return null;
		}
		if (definition.Kind == TypeKind.Enum)
		{
			definition = definition.EnumUnderlyingType.GetDefinition();
			if (definition == null)
			{
				return null;
			}
		}
		return definition.KnownTypeCode switch
		{
			KnownTypeCode.Boolean => false, 
			KnownTypeCode.Char => '\0', 
			KnownTypeCode.SByte => (sbyte)0, 
			KnownTypeCode.Byte => (byte)0, 
			KnownTypeCode.Int16 => (short)0, 
			KnownTypeCode.UInt16 => (ushort)0, 
			KnownTypeCode.Int32 => 0, 
			KnownTypeCode.UInt32 => 0u, 
			KnownTypeCode.Int64 => 0L, 
			KnownTypeCode.UInt64 => 0uL, 
			KnownTypeCode.Single => 0f, 
			KnownTypeCode.Double => 0.0, 
			KnownTypeCode.Decimal => 0m, 
			_ => null, 
		};
	}

	public ArrayCreateResolveResult ResolveArrayCreation(IType elementType, int[] sizeArguments, ResolveResult[] initializerElements = null)
	{
		ResolveResult[] array = new ResolveResult[sizeArguments.Length];
		for (int i = 0; i < sizeArguments.Length; i = checked(i + 1))
		{
			if (sizeArguments[i] < 0)
			{
				array[i] = ErrorResolveResult.UnknownError;
			}
			else
			{
				array[i] = new ConstantResolveResult(compilation.FindType(KnownTypeCode.Int32), sizeArguments[i]);
			}
		}
		return ResolveArrayCreation(elementType, array, initializerElements);
	}

	public ArrayCreateResolveResult ResolveArrayCreation(IType elementType, ResolveResult[] sizeArguments, ResolveResult[] initializerElements = null)
	{
		int num = sizeArguments.Length;
		if (num == 0)
		{
			throw new ArgumentException("sizeArguments.Length must not be 0");
		}
		if (elementType == null)
		{
			TypeInference typeInference = new TypeInference(compilation, conversions);
			elementType = typeInference.GetBestCommonType(initializerElements, out var _);
		}
		IType arrayType = new ArrayType(compilation, elementType, num);
		AdjustArrayAccessArguments(sizeArguments);
		if (initializerElements != null)
		{
			for (int i = 0; i < initializerElements.Length; i = checked(i + 1))
			{
				initializerElements[i] = Convert(initializerElements[i], elementType);
			}
		}
		return new ArrayCreateResolveResult(arrayType, sizeArguments, initializerElements);
	}

	public ResolveResult ResolveTypeOf(IType referencedType)
	{
		return new TypeOfResolveResult(compilation.FindType(KnownTypeCode.Type), referencedType);
	}

	public ResolveResult ResolveAssignment(AssignmentOperatorType op, ResolveResult lhs, ResolveResult rhs)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		ExpressionType linqNodeType = AssignmentExpression.GetLinqNodeType(op, CheckForOverflow);
		BinaryOperatorType? correspondingBinaryOperator = AssignmentExpression.GetCorrespondingBinaryOperator(op);
		if (!correspondingBinaryOperator.HasValue)
		{
			return new OperatorResolveResult(lhs.Type, linqNodeType, lhs, Convert(rhs, lhs.Type));
		}
		ResolveResult resolveResult = ResolveBinaryOperator(correspondingBinaryOperator.Value, lhs, rhs);
		if (!(resolveResult is OperatorResolveResult operatorResolveResult) || operatorResolveResult.Operands.Count != 2)
		{
			return resolveResult;
		}
		return new OperatorResolveResult(lhs.Type, linqNodeType, operatorResolveResult.UserDefinedOperatorMethod, operatorResolveResult.IsLiftedOperator, new ResolveResult[2]
		{
			lhs,
			operatorResolveResult.Operands[1]
		});
	}
}
