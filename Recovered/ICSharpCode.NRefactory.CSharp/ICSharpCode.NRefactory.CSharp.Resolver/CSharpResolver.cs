using ICSharpCode.NRefactory.CSharp.TypeSystem;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
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

		private sealed class LiftedUserDefinedOperator : SpecializedMethod, OverloadResolution.ILiftedOperator, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
		{
			internal readonly IParameterizedMember nonLiftedOperator;

			public IList<IParameter> NonLiftedParameters => nonLiftedOperator.Parameters;

			public LiftedUserDefinedOperator(IMethod nonLiftedMethod)
				: base((IMethod)nonLiftedMethod.MemberDefinition, nonLiftedMethod.Substitution)
			{
				nonLiftedOperator = nonLiftedMethod;
				MakeNullableVisitor makeNullableVisitor = new MakeNullableVisitor(nonLiftedMethod.Compilation, nonLiftedMethod.Substitution);
				base.Parameters = CreateParameters(makeNullableVisitor);
				if (IsComparisonOperator(nonLiftedMethod))
				{
					base.ReturnType = nonLiftedMethod.ReturnType;
				}
				else
				{
					base.ReturnType = nonLiftedMethod.ReturnType.AcceptVisitor(makeNullableVisitor);
				}
			}

			public override bool Equals(object obj)
			{
				LiftedUserDefinedOperator liftedUserDefinedOperator = obj as LiftedUserDefinedOperator;
				if (liftedUserDefinedOperator != null)
				{
					return nonLiftedOperator.Equals(liftedUserDefinedOperator.nonLiftedOperator);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return nonLiftedOperator.GetHashCode() ^ 0x7191254;
			}
		}

		private sealed class MakeNullableVisitor : TypeVisitor
		{
			private readonly ICompilation compilation;

			private readonly TypeParameterSubstitution typeParameterSubstitution;

			public MakeNullableVisitor(ICompilation compilation, TypeParameterSubstitution typeParameterSubstitution)
			{
				this.compilation = compilation;
				this.typeParameterSubstitution = typeParameterSubstitution;
			}

			public override IType VisitTypeDefinition(ITypeDefinition type)
			{
				return NullableType.Create(compilation, type.AcceptVisitor(typeParameterSubstitution));
			}

			public override IType VisitTypeParameter(ITypeParameter type)
			{
				return NullableType.Create(compilation, type.AcceptVisitor(typeParameterSubstitution));
			}

			public override IType VisitParameterizedType(ParameterizedType type)
			{
				return NullableType.Create(compilation, type.AcceptVisitor(typeParameterSubstitution));
			}

			public override IType VisitOtherType(IType type)
			{
				return NullableType.Create(compilation, type.AcceptVisitor(typeParameterSubstitution));
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

		IAssembly ITypeResolveContext.CurrentAssembly => context.CurrentAssembly;

		public bool CheckForOverflow => checkForOverflow;

		public bool IsWithinLambdaExpression => isWithinLambdaExpression;

		public IMember CurrentMember => context.CurrentMember;

		public ResolvedUsingScope CurrentUsingScope => context.CurrentUsingScope;

		public ITypeDefinition CurrentTypeDefinition => context.CurrentTypeDefinition;

		public IEnumerable<IVariable> LocalVariables => from v in localVariableStack
			where v != null
			select v;

		public bool IsInObjectInitializer => objectInitializerStack != null;

		public ResolveResult CurrentObjectInitializer
		{
			get
			{
				if (objectInitializerStack == null)
				{
					return ErrorResult;
				}
				return objectInitializerStack.initializedObject;
			}
		}

		public IType CurrentObjectInitializerType => CurrentObjectInitializer.Type;

		public CSharpResolver(ICompilation compilation)
		{
			if (compilation == null)
			{
				throw new ArgumentNullException("compilation");
			}
			this.compilation = compilation;
			conversions = CSharpConversions.Get(compilation);
			context = new CSharpTypeResolveContext(compilation.MainAssembly);
			CSharpProjectContent cSharpProjectContent = compilation.MainAssembly.UnresolvedAssembly as CSharpProjectContent;
			if (cSharpProjectContent != null)
			{
				checkForOverflow = cSharpProjectContent.CompilerSettings.CheckForOverflow;
			}
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

		[Obsolete("CSharpResolver is immutable, cloning is no longer necessary")]
		public CSharpResolver Clone()
		{
			return this;
		}

		public ResolveResult ResolveUnaryOperator(UnaryOperatorType op, ResolveResult expression)
		{
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
				{
					PointerType pointerType = expression.Type as PointerType;
					if (pointerType != null)
					{
						return UnaryOperatorResolveResult(pointerType.ElementType, op, expression);
					}
					return ErrorResult;
				}
				case UnaryOperatorType.AddressOf:
					return UnaryOperatorResolveResult(new PointerType(expression.Type), op, expression);
				case UnaryOperatorType.Await:
				{
					ResolveResult target = ResolveMemberAccess(expression, "GetAwaiter", EmptyList<IType>.Instance, NameLookupMode.InvocationTarget);
					ResolveResult resolveResult = ResolveInvocation(target, new ResolveResult[0], null, allowOptionalParameters: false);
					MemberLookup memberLookup = CreateMemberLookup();
					MethodGroupResolveResult methodGroupResolveResult = memberLookup.Lookup(resolveResult, "GetResult", EmptyList<IType>.Instance, isInvocation: true) as MethodGroupResolveResult;
					IMethod method;
					IType resultType;
					if (methodGroupResolveResult != null)
					{
						OverloadResolution overloadResolution = methodGroupResolveResult.PerformOverloadResolution(compilation, new ResolveResult[0], null, allowExtensionMethods: false, allowExpandingParams: true, allowOptionalParameters: true, checkForOverflow: false, conversions);
						method = (overloadResolution.FoundApplicableCandidate ? (overloadResolution.GetBestCandidateWithSubstitutedTypeArguments() as IMethod) : null);
						object type;
						if (method == null)
						{
							IType unknownType = SpecialType.UnknownType;
							type = unknownType;
						}
						else
						{
							type = method.ReturnType;
						}
						resultType = (IType)type;
					}
					else
					{
						method = null;
						resultType = SpecialType.UnknownType;
					}
					ResolveResult resolveResult2 = memberLookup.Lookup(resolveResult, "IsCompleted", EmptyList<IType>.Instance, isInvocation: false);
					IProperty property = (resolveResult2 is MemberResolveResult) ? (((MemberResolveResult)resolveResult2).Member as IProperty) : null;
					if (property != null && (!property.ReturnType.IsKnownType(KnownTypeCode.Boolean) || !property.CanGet))
					{
						property = null;
					}
					IMethod interfaceOnCompleted = compilation.FindType(KnownTypeCode.INotifyCompletion).GetMethods().FirstOrDefault((IMethod x) => x.Name == "OnCompleted");
					IMethod interfaceUnsafeOnCompleted = compilation.FindType(KnownTypeCode.ICriticalNotifyCompletion).GetMethods().FirstOrDefault((IMethod x) => x.Name == "UnsafeOnCompleted");
					IMethod onCompletedMethod = null;
					List<IMethod> list = (from x in resolveResult.Type.GetMethods()
						where (from y in x.ImplementedInterfaceMembers
							select y.MemberDefinition).Contains(interfaceUnsafeOnCompleted)
						select x).ToList();
					if (list.Count == 0)
					{
						list = (from x in resolveResult.Type.GetMethods()
							where (from y in x.ImplementedInterfaceMembers
								select y.MemberDefinition).Contains(interfaceOnCompleted)
							select x).ToList();
						if (list.Count == 1)
						{
							onCompletedMethod = list[0];
						}
					}
					else if (list.Count == 1)
					{
						onCompletedMethod = list[0];
					}
					return new AwaitResolveResult(resultType, resolveResult, resolveResult.Type, property, onCompletedMethod, method);
				}
				default:
					return ErrorResolveResult.UnknownError;
				}
			}
			IType type2 = NullableType.GetUnderlyingType(expression.Type);
			bool flag = NullableType.IsNullable(expression.Type);
			OverloadResolution overloadResolution2 = CreateOverloadResolution(new ResolveResult[1]
			{
				expression
			});
			foreach (IParameterizedMember userDefinedOperatorCandidate in GetUserDefinedOperatorCandidates(type2, overloadableOperatorName))
			{
				overloadResolution2.AddCandidate(userDefinedOperatorCandidate);
			}
			if (overloadResolution2.FoundApplicableCandidate)
			{
				return CreateResolveResultForUserDefinedOperator(overloadResolution2, UnaryOperatorExpression.GetLinqNodeType(op, CheckForOverflow));
			}
			expression = UnaryNumericPromotion(op, ref type2, flag, expression);
			CSharpOperators cSharpOperators = CSharpOperators.Get(compilation);
			CSharpOperators.OperatorMethod[] array;
			switch (op)
			{
			case UnaryOperatorType.Increment:
			case UnaryOperatorType.Decrement:
			case UnaryOperatorType.PostIncrement:
			case UnaryOperatorType.PostDecrement:
			{
				TypeCode typeCode = ReflectionHelper.GetTypeCode(type2);
				if ((typeCode >= TypeCode.Char && typeCode <= TypeCode.Decimal) || type2.Kind == TypeKind.Enum || type2.Kind == TypeKind.Pointer)
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
				if (type2.Kind == TypeKind.Enum)
				{
					if (expression.IsCompileTimeConstant && !flag && expression.ConstantValue != null)
					{
						ConstantResolveResult expression2 = new ConstantResolveResult(compilation.FindType(expression.ConstantValue.GetType()), expression.ConstantValue);
						ResolveResult expression3 = ResolveUnaryOperator(op, expression2);
						expression3 = WithCheckForOverflow(checkForOverflow: false).ResolveCast(type2, expression3);
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
			OverloadResolution overloadResolution3 = CreateOverloadResolution(new ResolveResult[1]
			{
				expression
			});
			CSharpOperators.OperatorMethod[] array2 = array;
			foreach (CSharpOperators.OperatorMethod member in array2)
			{
				overloadResolution3.AddCandidate(member);
			}
			CSharpOperators.UnaryOperatorMethod unaryOperatorMethod = (CSharpOperators.UnaryOperatorMethod)overloadResolution3.BestCandidate;
			IType returnType = unaryOperatorMethod.ReturnType;
			if (overloadResolution3.BestCandidateErrors != 0)
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
			return UnaryOperatorResolveResult(returnType, op, expression, overloadResolution3.BestCandidate is OverloadResolution.ILiftedOperator);
		}

		private OperatorResolveResult UnaryOperatorResolveResult(IType resultType, UnaryOperatorType op, ResolveResult expression, bool isLifted = false)
		{
			return new OperatorResolveResult(resultType, UnaryOperatorExpression.GetLinqNodeType(op, CheckForOverflow), null, isLifted, new ResolveResult[1]
			{
				expression
			});
		}

		private ResolveResult UnaryNumericPromotion(UnaryOperatorType op, ref IType type, bool isNullable, ResolveResult expression)
		{
			TypeCode typeCode = ReflectionHelper.GetTypeCode(type);
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
			OverloadResolution overloadResolution = CreateOverloadResolution(new ResolveResult[2]
			{
				lhs,
				rhs
			});
			HashSet<IParameterizedMember> hashSet = new HashSet<IParameterizedMember>();
			hashSet.UnionWith(GetUserDefinedOperatorCandidates(type, overloadableOperatorName));
			hashSet.UnionWith(GetUserDefinedOperatorCandidates(type2, overloadableOperatorName));
			foreach (IParameterizedMember item in hashSet)
			{
				overloadResolution.AddCandidate(item);
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
					IType targetType3 = MakeNullable(GetEnumUnderlyingType(type), isNullable);
					if (TryConvertEnum(ref rhs, targetType3, ref isNullable, ref lhs))
					{
						return HandleEnumOperator(isNullable, type, op, lhs, rhs);
					}
				}
				if (type2.Kind == TypeKind.Enum)
				{
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
					IType targetType = MakeNullable(GetEnumUnderlyingType(type), isNullable);
					if (TryConvertEnum(ref rhs, targetType, ref isNullable, ref lhs))
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
				switch (op)
				{
				case BinaryOperatorType.Equality:
					enumerable = cSharpOperators.ValueEqualityOperators;
					break;
				case BinaryOperatorType.InEquality:
					enumerable = cSharpOperators.ValueInequalityOperators;
					break;
				case BinaryOperatorType.LessThan:
					enumerable = cSharpOperators.LessThanOperators;
					break;
				case BinaryOperatorType.GreaterThan:
					enumerable = cSharpOperators.GreaterThanOperators;
					break;
				case BinaryOperatorType.LessThanOrEqual:
					enumerable = cSharpOperators.LessThanOrEqualOperators;
					break;
				case BinaryOperatorType.GreaterThanOrEqual:
					enumerable = cSharpOperators.GreaterThanOrEqualOperators;
					break;
				default:
					throw new InvalidOperationException();
				}
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
				switch (op)
				{
				case BinaryOperatorType.BitwiseAnd:
					enumerable = cSharpOperators.BitwiseAndOperators;
					break;
				case BinaryOperatorType.BitwiseOr:
					enumerable = cSharpOperators.BitwiseOrOperators;
					break;
				case BinaryOperatorType.ExclusiveOr:
					enumerable = cSharpOperators.BitwiseXorOperators;
					break;
				default:
					throw new InvalidOperationException();
				}
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
			OverloadResolution overloadResolution2 = CreateOverloadResolution(new ResolveResult[2]
			{
				lhs,
				rhs
			});
			foreach (CSharpOperators.OperatorMethod item2 in enumerable)
			{
				overloadResolution2.AddCandidate(item2);
			}
			CSharpOperators.BinaryOperatorMethod binaryOperatorMethod = (CSharpOperators.BinaryOperatorMethod)overloadResolution2.BestCandidate;
			IType returnType = binaryOperatorMethod.ReturnType;
			if (overloadResolution2.BestCandidateErrors != 0)
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
			return BinaryOperatorResolveResult(returnType, lhs, op, rhs, overloadResolution2.BestCandidate is OverloadResolution.ILiftedOperator);
		}

		private bool IsNullableTypeOrNonValueType(IType type)
		{
			if (!NullableType.IsNullable(type))
			{
				return type.IsReferenceType != false;
			}
			return true;
		}

		private ResolveResult BinaryOperatorResolveResult(IType resultType, ResolveResult lhs, BinaryOperatorType op, ResolveResult rhs, bool isLifted = false)
		{
			return new OperatorResolveResult(resultType, BinaryOperatorExpression.GetLinqNodeType(op, CheckForOverflow), null, isLifted, new ResolveResult[2]
			{
				lhs,
				rhs
			});
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
				Parameters = 
				{
					(IParameter)new DefaultParameter(inputType1, string.Empty),
					(IParameter)new DefaultParameter(inputType2, string.Empty)
				}
			};
		}

		private IType GetEnumUnderlyingType(IType enumType)
		{
			ITypeDefinition definition = enumType.GetDefinition();
			if (definition == null)
			{
				return SpecialType.UnknownType;
			}
			return definition.EnumUnderlyingType;
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
			TypeCode typeCode = ReflectionHelper.GetTypeCode(NullableType.GetUnderlyingType(lhs.Type));
			TypeCode typeCode2 = ReflectionHelper.GetTypeCode(NullableType.GetUnderlyingType(rhs.Type));
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
					flag = (typeCode == TypeCode.Single || typeCode == TypeCode.Double || typeCode2 == TypeCode.Single || typeCode2 == TypeCode.Double);
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
					flag = (IsSigned(typeCode, lhs) || IsSigned(typeCode2, rhs));
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
				return new ConstantResolveResult(type2, resolveResult.ConstantValue);
			}
			return Convert(expression, type2, isNullable ? Conversion.ImplicitNullableConversion : Conversion.ImplicitNumericConversion);
		}

		private static string GetOverloadableOperatorName(BinaryOperatorType op)
		{
			switch (op)
			{
			case BinaryOperatorType.Add:
				return "op_Addition";
			case BinaryOperatorType.Subtract:
				return "op_Subtraction";
			case BinaryOperatorType.Multiply:
				return "op_Multiply";
			case BinaryOperatorType.Divide:
				return "op_Division";
			case BinaryOperatorType.Modulus:
				return "op_Modulus";
			case BinaryOperatorType.BitwiseAnd:
				return "op_BitwiseAnd";
			case BinaryOperatorType.BitwiseOr:
				return "op_BitwiseOr";
			case BinaryOperatorType.ExclusiveOr:
				return "op_ExclusiveOr";
			case BinaryOperatorType.ShiftLeft:
				return "op_LeftShift";
			case BinaryOperatorType.ShiftRight:
				return "op_RightShift";
			case BinaryOperatorType.Equality:
				return "op_Equality";
			case BinaryOperatorType.InEquality:
				return "op_Inequality";
			case BinaryOperatorType.GreaterThan:
				return "op_GreaterThan";
			case BinaryOperatorType.LessThan:
				return "op_LessThan";
			case BinaryOperatorType.GreaterThanOrEqual:
				return "op_GreaterThanOrEqual";
			case BinaryOperatorType.LessThanOrEqual:
				return "op_LessThanOrEqual";
			default:
				return null;
			}
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

		private IEnumerable<IParameterizedMember> GetUserDefinedOperatorCandidates(IType type, string operatorName)
		{
			if (operatorName == null)
			{
				return EmptyList<IMethod>.Instance;
			}
			TypeCode typeCode = ReflectionHelper.GetTypeCode(type);
			if ((TypeCode.Boolean <= typeCode && typeCode <= TypeCode.Decimal) || typeCode == TypeCode.String)
			{
				return EmptyList<IMethod>.Instance;
			}
			List<IMethod> list = type.GetMethods((IUnresolvedMethod m) => m.IsOperator && m.Name == operatorName).ToList();
			LiftUserDefinedOperators(list);
			return list;
		}

		private void LiftUserDefinedOperators(List<IMethod> operators)
		{
			int count = operators.Count;
			for (int i = 0; i < count; i++)
			{
				LiftedUserDefinedOperator liftedUserDefinedOperator = LiftUserDefinedOperator(operators[i]);
				if (liftedUserDefinedOperator != null)
				{
					operators.Add(liftedUserDefinedOperator);
				}
			}
		}

		private LiftedUserDefinedOperator LiftUserDefinedOperator(IMethod m)
		{
			if (IsComparisonOperator(m))
			{
				if (!m.ReturnType.Equals(compilation.FindType(KnownTypeCode.Boolean)))
				{
					return null;
				}
			}
			else if (!NullableType.IsNonNullableValueType(m.ReturnType))
			{
				return null;
			}
			for (int i = 0; i < m.Parameters.Count; i++)
			{
				if (!NullableType.IsNonNullableValueType(m.Parameters[i].Type))
				{
					return null;
				}
			}
			return new LiftedUserDefinedOperator(m);
		}

		private static bool IsComparisonOperator(IMethod m)
		{
			OperatorType? operatorType = OperatorDeclaration.GetOperatorType(m.Name);
			if (operatorType.HasValue)
			{
				return operatorType.Value.IsComparisonOperator();
			}
			return false;
		}

		private ResolveResult CreateResolveResultForUserDefinedOperator(OverloadResolution r, ExpressionType operatorType)
		{
			if (r.BestCandidateErrors != 0)
			{
				return r.CreateResolveResult(null);
			}
			IMethod method = (IMethod)r.BestCandidate;
			return new OperatorResolveResult(method.ReturnType, operatorType, method, method is OverloadResolution.ILiftedOperator, r.GetArgumentsWithConversions());
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
				TypeCode typeCode = ReflectionHelper.GetTypeCode(targetType);
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
					typeCode = ReflectionHelper.GetTypeCode(GetEnumUnderlyingType(targetType));
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
			return ICSharpCode.NRefactory.Utils.CSharpPrimitiveCast.Cast(targetType, input, CheckForOverflow);
		}

		public ResolveResult ResolveSimpleName(string identifier, IList<IType> typeArguments, bool isInvocationTarget = false)
		{
			return LookupSimpleNameOrTypeName(identifier, typeArguments, isInvocationTarget ? NameLookupMode.InvocationTarget : NameLookupMode.Expression);
		}

		public ResolveResult LookupSimpleNameOrTypeName(string identifier, IList<IType> typeArguments, NameLookupMode lookupMode)
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
					IParameterizedMember parameterizedMember = CurrentMember as IParameterizedMember;
					if (parameterizedMember != null)
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
				IMethod method = CurrentMember as IMethod;
				if (method != null)
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
			bool parameterizeResultType = typeArguments.Count == 0 || !typeArguments.All((IType t) => t.Kind == TypeKind.UnboundTypeArgument);
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
				if (context.CurrentUsingScope.ResolveCache.TryGetValue(identifier, out value))
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
			trr = (LookupSimpleNameOrTypeName(identifier, EmptyList<IType>.Instance, NameLookupMode.Type) as TypeResolveResult);
			if (trr != null)
			{
				return trr.Type.Equals(rr.Type);
			}
			return false;
		}

		private ResolveResult LookInCurrentType(string identifier, IList<IType> typeArguments, NameLookupMode lookupMode, bool parameterizeResultType)
		{
			int count = typeArguments.Count;
			MemberLookup memberLookup = CreateMemberLookup(lookupMode);
			for (ITypeDefinition typeDefinition = CurrentTypeDefinition; typeDefinition != null; typeDefinition = typeDefinition.DeclaringTypeDefinition)
			{
				if (count == 0)
				{
					IList<ITypeParameter> typeParameters = typeDefinition.TypeParameters;
					for (int i = 0; i < typeParameters.Count; i++)
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
						ResolveResult targetResolveResult = (typeDefinition == CurrentTypeDefinition) ? ResolveThisReference() : new TypeResolveResult(typeDefinition);
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

		private ResolveResult LookInCurrentUsingScope(string identifier, IList<IType> typeArguments, bool isInUsingDeclaration, bool parameterizeResultType)
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
						if (typeDefinition != null)
						{
							IType type2 = (IType)((!parameterizeResultType || typeArguments.Count <= 0) ? ((object)typeDefinition) : ((object)new ParameterizedType(typeDefinition, typeArguments)));
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
					}
					if (type != null)
					{
						return new TypeResolveResult(type);
					}
				}
			}
			return null;
		}

		private ResolveResult LookInUsingScopeNamespace(ResolvedUsingScope usingScope, INamespace n, string identifier, IList<IType> typeArguments, bool parameterizeResultType)
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
			if (typeDef.IsInternal)
			{
				return typeDef.ParentAssembly.InternalsVisibleTo(compilation.MainAssembly);
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

		public ResolveResult ResolveMemberAccess(ResolveResult target, string identifier, IList<IType> typeArguments, NameLookupMode lookupMode = NameLookupMode.Expression)
		{
			bool parameterizeResultType = typeArguments.Count == 0 || !typeArguments.All((IType t) => t.Kind == TypeKind.UnboundTypeArgument);
			NamespaceResolveResult namespaceResolveResult = target as NamespaceResolveResult;
			if (namespaceResolveResult != null)
			{
				return ResolveMemberAccessOnNamespace(namespaceResolveResult, identifier, typeArguments, parameterizeResultType);
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
			else
			{
				MethodGroupResolveResult methodGroupResolveResult = resolveResult as MethodGroupResolveResult;
				if (methodGroupResolveResult != null)
				{
					methodGroupResolveResult.resolver = this;
				}
			}
			return resolveResult;
		}

		[Obsolete("Use ResolveMemberAccess() with NameLookupMode.Type instead")]
		public ResolveResult ResolveMemberType(ResolveResult target, string identifier, IList<IType> typeArguments)
		{
			return ResolveMemberAccess(target, identifier, typeArguments, NameLookupMode.Type);
		}

		private ResolveResult ResolveMemberAccessOnNamespace(NamespaceResolveResult nrr, string identifier, IList<IType> typeArguments, bool parameterizeResultType)
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
			return new MemberLookup(currentTypeDefinition, Compilation.MainAssembly, isInEnumMemberInitializer);
		}

		public MemberLookup CreateMemberLookup(NameLookupMode lookupMode)
		{
			if (lookupMode == NameLookupMode.BaseTypeReference && CurrentTypeDefinition != null)
			{
				return new MemberLookup(CurrentTypeDefinition.DeclaringTypeDefinition, Compilation.MainAssembly);
			}
			return CreateMemberLookup();
		}

		public ResolveResult ResolveIdentifierInObjectInitializer(string identifier)
		{
			return CreateMemberLookup().Lookup(CurrentObjectInitializer, identifier, EmptyList<IType>.Instance, isInvocation: false);
		}

		public List<List<IMethod>> GetExtensionMethods(string name = null, IList<IType> typeArguments = null)
		{
			return GetExtensionMethods(null, name, typeArguments);
		}

		public List<List<IMethod>> GetExtensionMethods(IType targetType, string name = null, IList<IType> typeArguments = null, bool substituteInferredTypes = false)
		{
			MemberLookup memberLookup = CreateMemberLookup();
			List<List<IMethod>> list = new List<List<IMethod>>();
			foreach (List<IMethod> allExtensionMethod in GetAllExtensionMethods(memberLookup))
			{
				List<IMethod> list2 = new List<IMethod>();
				foreach (IMethod item in allExtensionMethod)
				{
					if ((name == null || !(item.Name != name)) && memberLookup.IsAccessible(item, allowProtectedAccess: false))
					{
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
			ICompilation obj = method.Compilation;
			return IsEligibleExtensionMethod(obj, CSharpConversions.Get(obj), targetType, method, useTypeInference, out outInferredTypes);
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
				IType[] parameterTypes = new IType[1]
				{
					method.Parameters[0].Type
				};
				bool success;
				IType[] array = typeInference.InferTypeArguments(method.TypeParameters, arguments, parameterTypes, out success);
				TypeParameterSubstitution typeParameterSubstitution = new TypeParameterSubstitution(null, array);
				bool flag = false;
				for (int i = 0; i < array.Length; i++)
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
			if (conversion.IsValid)
			{
				if (!conversion.IsIdentityConversion && !conversion.IsReferenceConversion)
				{
					return conversion.IsBoxingConversion;
				}
				return true;
			}
			return false;
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
				INamespace @namespace = resolvedUsingScope.Namespace;
				List<IMethod> list2;
				if (@namespace != null)
				{
					list2 = GetExtensionMethods(lookup, @namespace).ToList();
					if (list2.Count > 0)
					{
						list.Add(list2);
					}
				}
				list2 = resolvedUsingScope.Usings.Distinct().SelectMany((INamespace importedNamespace) => GetExtensionMethods(lookup, importedNamespace)).ToList();
				if (list2.Count > 0)
				{
					list.Add(list2);
				}
			}
			return LazyInit.GetOrSet(ref currentUsingScope.AllExtensionMethods, list);
		}

		private IEnumerable<IMethod> GetExtensionMethods(MemberLookup lookup, INamespace ns)
		{
			return from c in ns.Types
				where c.IsStatic && c.HasExtensionMethods && c.TypeParameters.Count == 0 && lookup.IsAccessible(c, allowProtectedAccess: false)
				from m in c.Methods
				where m.IsExtensionMethod
				select m;
		}

		private IList<ResolveResult> AddArgumentNamesIfNecessary(ResolveResult[] arguments, string[] argumentNames)
		{
			if (argumentNames == null)
			{
				return arguments;
			}
			ResolveResult[] array = new ResolveResult[arguments.Length];
			for (int i = 0; i < arguments.Length; i++)
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
			MethodGroupResolveResult methodGroupResolveResult = target as MethodGroupResolveResult;
			if (methodGroupResolveResult != null)
			{
				if (flag)
				{
					OverloadResolution or2 = CreateOverloadResolution(arguments, argumentNames, methodGroupResolveResult.TypeArguments.ToArray());
					var list = (from x in methodGroupResolveResult.MethodsGroupedByDeclaringType.SelectMany((MethodListWithDeclaringType m) => m, (MethodListWithDeclaringType x, IParameterizedMember m) => new
						{
							DeclaringType = x.DeclaringType,
							Method = m
						})
						where OverloadResolution.IsApplicable(or2.AddCandidate(x.Method))
						select x).ToList();
					if (list.Count > 1)
					{
						ResolveResult targetResult = (!list.All(x => x.Method.IsStatic) || methodGroupResolveResult.TargetResult is TypeResolveResult) ? methodGroupResolveResult.TargetResult : new TypeResolveResult(methodGroupResolveResult.TargetType);
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
				MethodGroupResolveResult methodGroupResolveResult2 = methodGroupResolveResult;
				ICompilation obj = compilation;
				bool flag2 = checkForOverflow;
				CSharpConversions cSharpConversions = conversions;
				OverloadResolution overloadResolution = methodGroupResolveResult2.PerformOverloadResolution(obj, arguments, argumentNames, allowExtensionMethods: true, allowExpandingParams: true, allowOptionalParameters, flag2, cSharpConversions);
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
			UnknownMemberResolveResult unknownMemberResolveResult = target as UnknownMemberResolveResult;
			if (unknownMemberResolveResult != null)
			{
				return new UnknownMethodResolveResult(unknownMemberResolveResult.TargetType, unknownMemberResolveResult.MemberName, unknownMemberResolveResult.TypeArguments, CreateParameters(arguments, argumentNames));
			}
			UnknownIdentifierResolveResult unknownIdentifierResolveResult = target as UnknownIdentifierResolveResult;
			if (unknownIdentifierResolveResult != null && CurrentTypeDefinition != null)
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
			for (int i = 0; i < arguments.Length; i++)
			{
				if (argumentNames[i] == null)
				{
					string text = GuessParameterName(arguments[i]);
					if (argumentNames.Contains(text))
					{
						int num = 1;
						string text2;
						do
						{
							text2 = text + num.ToString();
							num++;
						}
						while (argumentNames.Contains(text2));
						text = text2;
					}
					argumentNames[i] = text;
				}
				ByReferenceResolveResult byReferenceResolveResult = arguments[i] as ByReferenceResolveResult;
				if (byReferenceResolveResult != null)
				{
					list.Add(new DefaultParameter(arguments[i].Type, argumentNames[i], null, default(DomRegion), null, byReferenceResolveResult.IsRef, byReferenceResolveResult.IsOut));
					continue;
				}
				IType type = arguments[i].Type;
				if (type.Kind == TypeKind.Null || type.Kind == TypeKind.Unknown)
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

		private static string GuessParameterName(ResolveResult rr)
		{
			MemberResolveResult memberResolveResult = rr as MemberResolveResult;
			if (memberResolveResult != null)
			{
				return memberResolveResult.Member.Name;
			}
			UnknownMemberResolveResult unknownMemberResolveResult = rr as UnknownMemberResolveResult;
			if (unknownMemberResolveResult != null)
			{
				return unknownMemberResolveResult.MemberName;
			}
			MethodGroupResolveResult methodGroupResolveResult = rr as MethodGroupResolveResult;
			if (methodGroupResolveResult != null)
			{
				return methodGroupResolveResult.MethodName;
			}
			LocalResolveResult localResolveResult = rr as LocalResolveResult;
			if (localResolveResult != null)
			{
				return MakeParameterName(localResolveResult.Variable.Name);
			}
			if (rr.Type.Kind != TypeKind.Unknown && !string.IsNullOrEmpty(rr.Type.Name))
			{
				return MakeParameterName(rr.Type.Name);
			}
			return "parameter";
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
			return char.ToLower(variableName[0]).ToString() + variableName.Substring(1);
		}

		private OverloadResolution CreateOverloadResolution(ResolveResult[] arguments, string[] argumentNames = null, IType[] typeArguments = null)
		{
			return new OverloadResolution(compilation, arguments, argumentNames, typeArguments, conversions)
			{
				CheckForOverflow = checkForOverflow
			};
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
				IList<MethodListWithDeclaringType> list = CreateMemberLookup().LookupIndexers(target);
				if (arguments.Any((ResolveResult a) => a.Type.Kind == TypeKind.Dynamic))
				{
					OverloadResolution or2 = CreateOverloadResolution(arguments, argumentNames);
					if ((from m in list.SelectMany((MethodListWithDeclaringType x) => x)
						where OverloadResolution.IsApplicable(or2.AddCandidate(m))
						select m).ToList().Count > 1)
					{
						return new DynamicInvocationResolveResult(target, DynamicInvocationType.Indexing, AddArgumentNamesIfNecessary(arguments, argumentNames));
					}
				}
				OverloadResolution overloadResolution = CreateOverloadResolution(arguments, argumentNames);
				overloadResolution.AddMethodLists(list);
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
			for (int i = 0; i < arguments.Length; i++)
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
						new MethodListWithDeclaringType(resolveResult.Type)
						{
							delegateInvokeMethod
						}
					}, EmptyList<IType>.Instance);
				}
				return Convert(resolveResult, type);
			}
			OverloadResolution overloadResolution = CreateOverloadResolution(arguments, argumentNames);
			MemberLookup memberLookup = CreateMemberLookup();
			List<IMethod> list = arguments.Any((ResolveResult a) => a.Type.Kind == TypeKind.Dynamic) ? new List<IMethod>() : null;
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
			switch (ReflectionHelper.GetTypeCode((type.Kind == TypeKind.Enum) ? type.GetDefinition().EnumUnderlyingType : type))
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
				IMethod method = input.Type.GetMethods((IUnresolvedMethod m) => m.IsOperator && m.Name == "op_True").FirstOrDefault();
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
				IMethod method = input.Type.GetMethods((IUnresolvedMethod m) => m.IsOperator && m.Name == "op_False").FirstOrDefault();
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
				flag = (TryConvert(ref trueExpression, type) & TryConvert(ref falseExpression, type));
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
				return new OperatorResolveResult(type, ExpressionType.Conditional, condition, trueExpression, falseExpression);
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
			if (r.Type.Kind != TypeKind.Unknown)
			{
				return r.Type.Kind != TypeKind.Null;
			}
			return false;
		}

		public ResolveResult ResolvePrimitive(object value)
		{
			if (value == null)
			{
				return new ResolveResult(SpecialType.NullType);
			}
			TypeCode typeCode = Type.GetTypeCode(value.GetType());
			return new ConstantResolveResult(compilation.FindType(typeCode), value);
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
			switch (definition.KnownTypeCode)
			{
			case KnownTypeCode.Boolean:
				return false;
			case KnownTypeCode.Char:
				return '\0';
			case KnownTypeCode.SByte:
				return (sbyte)0;
			case KnownTypeCode.Byte:
				return (byte)0;
			case KnownTypeCode.Int16:
				return (short)0;
			case KnownTypeCode.UInt16:
				return (ushort)0;
			case KnownTypeCode.Int32:
				return 0;
			case KnownTypeCode.UInt32:
				return 0u;
			case KnownTypeCode.Int64:
				return 0L;
			case KnownTypeCode.UInt64:
				return 0uL;
			case KnownTypeCode.Single:
				return 0f;
			case KnownTypeCode.Double:
				return 0.0;
			case KnownTypeCode.Decimal:
				return decimal.Zero;
			default:
				return null;
			}
		}

		public ArrayCreateResolveResult ResolveArrayCreation(IType elementType, int[] sizeArguments, ResolveResult[] initializerElements = null)
		{
			ResolveResult[] array = new ResolveResult[sizeArguments.Length];
			for (int i = 0; i < sizeArguments.Length; i++)
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
				elementType = new TypeInference(compilation, conversions).GetBestCommonType(initializerElements, out bool _);
			}
			IType arrayType = new ArrayType(compilation, elementType, num);
			AdjustArrayAccessArguments(sizeArguments);
			if (initializerElements != null)
			{
				for (int i = 0; i < initializerElements.Length; i++)
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
			ExpressionType linqNodeType = AssignmentExpression.GetLinqNodeType(op, CheckForOverflow);
			BinaryOperatorType? correspondingBinaryOperator = AssignmentExpression.GetCorrespondingBinaryOperator(op);
			if (!correspondingBinaryOperator.HasValue)
			{
				return new OperatorResolveResult(lhs.Type, linqNodeType, lhs, Convert(rhs, lhs.Type));
			}
			ResolveResult resolveResult = ResolveBinaryOperator(correspondingBinaryOperator.Value, lhs, rhs);
			OperatorResolveResult operatorResolveResult = resolveResult as OperatorResolveResult;
			if (operatorResolveResult == null || operatorResolveResult.Operands.Count != 2)
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
}
