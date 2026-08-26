using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public sealed class TypeInference
{
	private sealed class TP
	{
		public readonly HashSet<IType> LowerBounds = new HashSet<IType>();

		public readonly HashSet<IType> UpperBounds = new HashSet<IType>();

		public IType ExactBound;

		public bool MultipleDifferentExactBounds;

		public readonly ITypeParameter TypeParameter;

		public IType FixedTo;

		public bool IsFixed => FixedTo != null;

		public bool HasBounds
		{
			get
			{
				if (LowerBounds.Count <= 0 && UpperBounds.Count <= 0)
				{
					return ExactBound != null;
				}
				return true;
			}
		}

		public TP(ITypeParameter typeParameter)
		{
			if (typeParameter == null)
			{
				throw new ArgumentNullException("typeParameter");
			}
			TypeParameter = typeParameter;
		}

		public void AddExactBound(IType type)
		{
			if (ExactBound == null)
			{
				ExactBound = type;
			}
			else if (!ExactBound.Equals(type))
			{
				MultipleDifferentExactBounds = true;
			}
		}

		public override string ToString()
		{
			return TypeParameter.Name;
		}
	}

	private sealed class OccursInVisitor : TypeVisitor
	{
		private readonly TP[] tp;

		public readonly bool[] Occurs;

		public OccursInVisitor(TypeInference typeInference)
		{
			tp = typeInference.typeParameters;
			Occurs = new bool[tp.Length];
		}

		public override IType VisitTypeParameter(ITypeParameter type)
		{
			int index = type.Index;
			if (index < tp.Length && tp[index].TypeParameter == type)
			{
				Occurs[index] = true;
			}
			return base.VisitTypeParameter(type);
		}
	}

	private readonly ICompilation compilation;

	private readonly CSharpConversions conversions;

	private TypeInferenceAlgorithm algorithm;

	private const int maxNestingLevel = 5;

	private int nestingLevel;

	private TP[] typeParameters;

	private IType[] parameterTypes;

	private ResolveResult[] arguments;

	private bool[,] dependencyMatrix;

	private IList<IType> classTypeArguments;

	private static readonly IType[] emptyTypeArray = new IType[0];

	public TypeInferenceAlgorithm Algorithm
	{
		get
		{
			return algorithm;
		}
		set
		{
			algorithm = value;
		}
	}

	public TypeInference(ICompilation compilation)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		this.compilation = compilation;
		conversions = CSharpConversions.Get(compilation);
	}

	internal TypeInference(ICompilation compilation, CSharpConversions conversions)
	{
		this.compilation = compilation;
		this.conversions = conversions;
	}

	private TypeInference CreateNestedInstance()
	{
		TypeInference typeInference = new TypeInference(compilation, conversions);
		typeInference.algorithm = algorithm;
		typeInference.nestingLevel = nestingLevel + 1;
		return typeInference;
	}

	public IType[] InferTypeArguments(IList<ITypeParameter> typeParameters, IList<ResolveResult> arguments, IList<IType> parameterTypes, out bool success, IList<IType> classTypeArguments = null)
	{
		if (typeParameters == null)
		{
			throw new ArgumentNullException("typeParameters");
		}
		if (arguments == null)
		{
			throw new ArgumentNullException("arguments");
		}
		if (parameterTypes == null)
		{
			throw new ArgumentNullException("parameterTypes");
		}
		try
		{
			this.typeParameters = new TP[typeParameters.Count];
			for (int i = 0; i < this.typeParameters.Length; i++)
			{
				if (i != typeParameters[i].Index)
				{
					throw new ArgumentException("Type parameter has wrong index");
				}
				if (typeParameters[i].OwnerType != SymbolKind.Method)
				{
					throw new ArgumentException("Type parameter must be owned by a method");
				}
				this.typeParameters[i] = new TP(typeParameters[i]);
			}
			this.parameterTypes = new IType[Math.Min(arguments.Count, parameterTypes.Count)];
			this.arguments = new ResolveResult[this.parameterTypes.Length];
			for (int j = 0; j < this.parameterTypes.Length; j++)
			{
				if (arguments[j] == null || parameterTypes[j] == null)
				{
					throw new ArgumentNullException();
				}
				this.arguments[j] = arguments[j];
				this.parameterTypes[j] = parameterTypes[j];
			}
			this.classTypeArguments = classTypeArguments;
			PhaseOne();
			success = PhaseTwo();
			return this.typeParameters.Select((TP tp) => tp.FixedTo ?? SpecialType.UnknownType).ToArray();
		}
		finally
		{
			Reset();
		}
	}

	private void Reset()
	{
		typeParameters = null;
		parameterTypes = null;
		arguments = null;
		dependencyMatrix = null;
		classTypeArguments = null;
	}

	public IType[] InferTypeArgumentsFromBounds(IList<ITypeParameter> typeParameters, IType targetType, IList<IType> lowerBounds, IList<IType> upperBounds, out bool success)
	{
		if (typeParameters == null)
		{
			throw new ArgumentNullException("typeParameters");
		}
		if (targetType == null)
		{
			throw new ArgumentNullException("targetType");
		}
		if (lowerBounds == null)
		{
			throw new ArgumentNullException("lowerBounds");
		}
		if (upperBounds == null)
		{
			throw new ArgumentNullException("upperBounds");
		}
		this.typeParameters = new TP[typeParameters.Count];
		for (int i = 0; i < this.typeParameters.Length; i++)
		{
			if (i != typeParameters[i].Index)
			{
				throw new ArgumentException("Type parameter has wrong index");
			}
			this.typeParameters[i] = new TP(typeParameters[i]);
		}
		foreach (IType lowerBound in lowerBounds)
		{
			MakeLowerBoundInference(lowerBound, targetType);
		}
		foreach (IType upperBound in upperBounds)
		{
			MakeUpperBoundInference(upperBound, targetType);
		}
		IType[] array = new IType[this.typeParameters.Length];
		success = true;
		for (int j = 0; j < array.Length; j++)
		{
			success &= Fix(this.typeParameters[j]);
			array[j] = this.typeParameters[j].FixedTo ?? SpecialType.UnknownType;
		}
		Reset();
		return array;
	}

	private void PhaseOne()
	{
		for (int i = 0; i < arguments.Length; i++)
		{
			ResolveResult resolveResult = arguments[i];
			IType type = parameterTypes[i];
			LambdaResolveResult lambdaResolveResult = resolveResult as LambdaResolveResult;
			if (lambdaResolveResult != null)
			{
				MakeExplicitParameterTypeInference(lambdaResolveResult, type);
			}
			if ((lambdaResolveResult != null || resolveResult is MethodGroupResolveResult) && OutputTypeContainsUnfixed(resolveResult, type) && !InputTypesContainsUnfixed(resolveResult, type))
			{
				MakeOutputTypeInference(resolveResult, type);
			}
			if (IsValidType(resolveResult.Type))
			{
				if (type is ByReferenceType)
				{
					MakeExactInference(resolveResult.Type, type);
				}
				else
				{
					MakeLowerBoundInference(resolveResult.Type, type);
				}
			}
		}
	}

	private static bool IsValidType(IType type)
	{
		if (type.Kind != TypeKind.Unknown)
		{
			return type.Kind != TypeKind.Null;
		}
		return false;
	}

	private bool PhaseTwo()
	{
		List<TP> list = new List<TP>();
		TP[] array = typeParameters;
		foreach (TP Xi in array)
		{
			if (!Xi.IsFixed && !typeParameters.Any((TP Xj) => !Xj.IsFixed && DependsOn(Xi, Xj)))
			{
				list.Add(Xi);
			}
		}
		if (list.Count == 0)
		{
			TP[] array2 = typeParameters;
			foreach (TP Xi2 in array2)
			{
				if (!Xi2.IsFixed && Xi2.HasBounds && typeParameters.Any((TP Xj) => DependsOn(Xj, Xi2)))
				{
					list.Add(Xi2);
				}
			}
		}
		bool flag = false;
		foreach (TP item in list)
		{
			if (!Fix(item))
			{
				flag = true;
			}
		}
		if (flag)
		{
			return false;
		}
		bool flag2 = typeParameters.Any((TP X) => !X.IsFixed);
		if ((list.Count == 0) & flag2)
		{
			return false;
		}
		if (!flag2)
		{
			return true;
		}
		for (int num2 = 0; num2 < arguments.Length; num2++)
		{
			ResolveResult resolveResult = arguments[num2];
			IType type = parameterTypes[num2];
			if (OutputTypeContainsUnfixed(resolveResult, type) && !InputTypesContainsUnfixed(resolveResult, type))
			{
				MakeOutputTypeInference(resolveResult, type);
			}
		}
		return PhaseTwo();
	}

	private IType[] InputTypes(ResolveResult e, IType t)
	{
		if (e is LambdaResolveResult { IsImplicitlyTyped: not false } || e is MethodGroupResolveResult)
		{
			IMethod delegateOrExpressionTreeSignature = GetDelegateOrExpressionTreeSignature(t);
			if (delegateOrExpressionTreeSignature != null)
			{
				IType[] array = new IType[delegateOrExpressionTreeSignature.Parameters.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = delegateOrExpressionTreeSignature.Parameters[i].Type;
				}
				return array;
			}
		}
		return emptyTypeArray;
	}

	private IType[] OutputTypes(ResolveResult e, IType t)
	{
		LambdaResolveResult lambdaResolveResult = e as LambdaResolveResult;
		if (lambdaResolveResult != null || e is MethodGroupResolveResult)
		{
			IMethod delegateOrExpressionTreeSignature = GetDelegateOrExpressionTreeSignature(t);
			if (delegateOrExpressionTreeSignature != null)
			{
				return new IType[1] { delegateOrExpressionTreeSignature.ReturnType };
			}
		}
		return emptyTypeArray;
	}

	private static IMethod GetDelegateOrExpressionTreeSignature(IType t)
	{
		if (t is ParameterizedType { TypeParameterCount: 1, Name: "Expression", Namespace: "System.Linq.Expressions" } parameterizedType)
		{
			t = parameterizedType.GetTypeArgument(0);
		}
		return t.GetDelegateInvokeMethod();
	}

	private bool InputTypesContainsUnfixed(ResolveResult argument, IType parameterType)
	{
		return AnyTypeContainsUnfixedParameter(InputTypes(argument, parameterType));
	}

	private bool OutputTypeContainsUnfixed(ResolveResult argument, IType parameterType)
	{
		return AnyTypeContainsUnfixedParameter(OutputTypes(argument, parameterType));
	}

	private bool AnyTypeContainsUnfixedParameter(IEnumerable<IType> types)
	{
		OccursInVisitor occursInVisitor = new OccursInVisitor(this);
		foreach (IType type in types)
		{
			type.AcceptVisitor(occursInVisitor);
		}
		for (int i = 0; i < typeParameters.Length; i++)
		{
			if (!typeParameters[i].IsFixed && occursInVisitor.Occurs[i])
			{
				return true;
			}
		}
		return false;
	}

	private void CalculateDependencyMatrix()
	{
		int num = typeParameters.Length;
		dependencyMatrix = new bool[num, num];
		for (int i = 0; i < arguments.Length; i++)
		{
			OccursInVisitor occursInVisitor = new OccursInVisitor(this);
			OccursInVisitor occursInVisitor2 = new OccursInVisitor(this);
			IType[] array = InputTypes(arguments[i], parameterTypes[i]);
			foreach (IType type in array)
			{
				type.AcceptVisitor(occursInVisitor);
			}
			IType[] array2 = OutputTypes(arguments[i], parameterTypes[i]);
			foreach (IType type2 in array2)
			{
				type2.AcceptVisitor(occursInVisitor2);
			}
			for (int l = 0; l < num; l++)
			{
				for (int m = 0; m < num; m++)
				{
					ref bool reference = ref dependencyMatrix[l, m];
					reference |= occursInVisitor.Occurs[m] && occursInVisitor2.Occurs[l];
				}
			}
		}
		for (int n = 0; n < num; n++)
		{
			for (int num2 = 0; num2 < num; num2++)
			{
				if (!dependencyMatrix[n, num2])
				{
					continue;
				}
				for (int num3 = 0; num3 < num; num3++)
				{
					if (dependencyMatrix[num2, num3])
					{
						dependencyMatrix[n, num3] = true;
					}
				}
			}
		}
	}

	private bool DependsOn(TP x, TP y)
	{
		if (dependencyMatrix == null)
		{
			CalculateDependencyMatrix();
		}
		return dependencyMatrix[x.TypeParameter.Index, y.TypeParameter.Index];
	}

	private void MakeOutputTypeInference(ResolveResult e, IType t)
	{
		if (e is LambdaResolveResult lambdaResolveResult)
		{
			IMethod delegateOrExpressionTreeSignature = GetDelegateOrExpressionTreeSignature(t);
			if (delegateOrExpressionTreeSignature != null)
			{
				IType inferredReturnType;
				if (lambdaResolveResult.IsImplicitlyTyped)
				{
					if (delegateOrExpressionTreeSignature.Parameters.Count != lambdaResolveResult.Parameters.Count)
					{
						return;
					}
					TypeParameterSubstitution substitutionForFixedTPs = GetSubstitutionForFixedTPs();
					IType[] array = new IType[delegateOrExpressionTreeSignature.Parameters.Count];
					for (int i = 0; i < array.Length; i++)
					{
						IType type = delegateOrExpressionTreeSignature.Parameters[i].Type;
						array[i] = type.AcceptVisitor(substitutionForFixedTPs);
					}
					inferredReturnType = lambdaResolveResult.GetInferredReturnType(array);
				}
				else
				{
					inferredReturnType = lambdaResolveResult.GetInferredReturnType(null);
				}
				MakeLowerBoundInference(inferredReturnType, delegateOrExpressionTreeSignature.ReturnType);
				return;
			}
		}
		if (e is MethodGroupResolveResult methodGroupResolveResult)
		{
			IMethod delegateOrExpressionTreeSignature2 = GetDelegateOrExpressionTreeSignature(t);
			if (delegateOrExpressionTreeSignature2 == null)
			{
				return;
			}
			ResolveResult[] array2 = new ResolveResult[delegateOrExpressionTreeSignature2.Parameters.Count];
			TypeParameterSubstitution substitutionForFixedTPs2 = GetSubstitutionForFixedTPs();
			for (int j = 0; j < array2.Length; j++)
			{
				IParameter parameter = delegateOrExpressionTreeSignature2.Parameters[j];
				IType type2 = parameter.Type.AcceptVisitor(substitutionForFixedTPs2);
				if ((parameter.IsIn || parameter.IsRef || parameter.IsOut) && type2.Kind == TypeKind.ByReference)
				{
					type2 = ((ByReferenceType)type2).ElementType;
					array2[j] = new ByReferenceResolveResult(type2, parameter.IsIn, parameter.IsRef, parameter.IsOut);
				}
				else
				{
					array2[j] = new ResolveResult(type2);
				}
			}
			OverloadResolution overloadResolution = methodGroupResolveResult.PerformOverloadResolution(compilation, array2, null, allowExtensionMethods: true, allowExpandingParams: false, allowOptionalParameters: false);
			if (overloadResolution.FoundApplicableCandidate && overloadResolution.BestCandidateAmbiguousWith == null)
			{
				IType returnType = overloadResolution.GetBestCandidateWithSubstitutedTypeArguments().ReturnType;
				MakeLowerBoundInference(returnType, delegateOrExpressionTreeSignature2.ReturnType);
			}
		}
		else if (IsValidType(e.Type))
		{
			MakeLowerBoundInference(e.Type, t);
		}
	}

	private TypeParameterSubstitution GetSubstitutionForFixedTPs()
	{
		IType[] array = new IType[typeParameters.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = typeParameters[i].FixedTo ?? SpecialType.UnknownType;
		}
		return new TypeParameterSubstitution(classTypeArguments, array);
	}

	private void MakeExplicitParameterTypeInference(LambdaResolveResult e, IType t)
	{
		if (e.IsImplicitlyTyped || !e.HasParameterList)
		{
			return;
		}
		IMethod delegateOrExpressionTreeSignature = GetDelegateOrExpressionTreeSignature(t);
		if (delegateOrExpressionTreeSignature != null)
		{
			for (int i = 0; i < e.Parameters.Count && i < delegateOrExpressionTreeSignature.Parameters.Count; i++)
			{
				MakeExactInference(e.Parameters[i].Type, delegateOrExpressionTreeSignature.Parameters[i].Type);
			}
		}
	}

	private void MakeExactInference(IType U, IType V)
	{
		TP tPForType = GetTPForType(V);
		if (tPForType != null && !tPForType.IsFixed)
		{
			tPForType.AddExactBound(U);
			return;
		}
		ByReferenceType byReferenceType = U as ByReferenceType;
		ByReferenceType byReferenceType2 = V as ByReferenceType;
		if (byReferenceType != null && byReferenceType2 != null)
		{
			MakeExactInference(byReferenceType.ElementType, byReferenceType2.ElementType);
			return;
		}
		ArrayType arrayType = U as ArrayType;
		ArrayType arrayType2 = V as ArrayType;
		if (arrayType != null && arrayType2 != null && arrayType.Dimensions == arrayType2.Dimensions)
		{
			MakeExactInference(arrayType.ElementType, arrayType2.ElementType);
			return;
		}
		ParameterizedType parameterizedType = U as ParameterizedType;
		ParameterizedType parameterizedType2 = V as ParameterizedType;
		if (parameterizedType != null && parameterizedType2 != null && object.Equals(parameterizedType.GetDefinition(), parameterizedType2.GetDefinition()) && parameterizedType.TypeParameterCount == parameterizedType2.TypeParameterCount)
		{
			for (int i = 0; i < parameterizedType.TypeParameterCount; i++)
			{
				MakeExactInference(parameterizedType.GetTypeArgument(i), parameterizedType2.GetTypeArgument(i));
			}
		}
	}

	private TP GetTPForType(IType v)
	{
		if (v is ITypeParameter { Index: var index } typeParameter && index < typeParameters.Length && typeParameters[index].TypeParameter == typeParameter)
		{
			return typeParameters[index];
		}
		return null;
	}

	private void MakeLowerBoundInference(IType U, IType V)
	{
		TP tPForType = GetTPForType(V);
		if (tPForType != null && !tPForType.IsFixed)
		{
			tPForType.LowerBounds.Add(U);
			return;
		}
		if (NullableType.IsNullable(U) && NullableType.IsNullable(V))
		{
			MakeLowerBoundInference(NullableType.GetUnderlyingType(U), NullableType.GetUnderlyingType(V));
			return;
		}
		ArrayType arrayType = U as ArrayType;
		ArrayType arrayType2 = V as ArrayType;
		ParameterizedType parameterizedType = V as ParameterizedType;
		if (arrayType != null && arrayType2 != null && arrayType.Dimensions == arrayType2.Dimensions)
		{
			MakeLowerBoundInference(arrayType.ElementType, arrayType2.ElementType);
		}
		else if (arrayType != null && IsGenericInterfaceImplementedByArray(parameterizedType) && arrayType.Dimensions == 1)
		{
			MakeLowerBoundInference(arrayType.ElementType, parameterizedType.GetTypeArgument(0));
		}
		else
		{
			if (parameterizedType == null)
			{
				return;
			}
			ParameterizedType parameterizedType2 = null;
			foreach (IType allBaseType in U.GetAllBaseTypes())
			{
				if (allBaseType is ParameterizedType parameterizedType3 && object.Equals(parameterizedType3.GetDefinition(), parameterizedType.GetDefinition()) && parameterizedType3.TypeParameterCount == parameterizedType.TypeParameterCount)
				{
					if (parameterizedType2 != null)
					{
						return;
					}
					parameterizedType2 = parameterizedType3;
				}
			}
			if (parameterizedType2 == null)
			{
				return;
			}
			for (int i = 0; i < parameterizedType2.TypeParameterCount; i++)
			{
				IType typeArgument = parameterizedType2.GetTypeArgument(i);
				IType typeArgument2 = parameterizedType.GetTypeArgument(i);
				if (typeArgument.IsReferenceType == true)
				{
					ITypeParameter typeParameter = parameterizedType.GetDefinition().TypeParameters[i];
					switch (typeParameter.Variance)
					{
					case VarianceModifier.Covariant:
						MakeLowerBoundInference(typeArgument, typeArgument2);
						break;
					case VarianceModifier.Contravariant:
						MakeUpperBoundInference(typeArgument, typeArgument2);
						break;
					default:
						MakeExactInference(typeArgument, typeArgument2);
						break;
					}
				}
				else
				{
					MakeExactInference(typeArgument, typeArgument2);
				}
			}
		}
	}

	private static bool IsGenericInterfaceImplementedByArray(ParameterizedType rt)
	{
		if (rt == null || rt.TypeParameterCount != 1)
		{
			return false;
		}
		switch (rt.GetDefinition().KnownTypeCode)
		{
		case KnownTypeCode.IEnumerableOfT:
		case KnownTypeCode.ICollectionOfT:
		case KnownTypeCode.IListOfT:
		case KnownTypeCode.IReadOnlyCollectionOfT:
		case KnownTypeCode.IReadOnlyListOfT:
			return true;
		default:
			return false;
		}
	}

	private void MakeUpperBoundInference(IType U, IType V)
	{
		TP tPForType = GetTPForType(V);
		if (tPForType != null && !tPForType.IsFixed)
		{
			tPForType.UpperBounds.Add(U);
			return;
		}
		ArrayType arrayType = U as ArrayType;
		ArrayType arrayType2 = V as ArrayType;
		ParameterizedType parameterizedType = U as ParameterizedType;
		if (arrayType2 != null && arrayType != null && arrayType.Dimensions == arrayType2.Dimensions)
		{
			MakeUpperBoundInference(arrayType.ElementType, arrayType2.ElementType);
		}
		else if (arrayType2 != null && IsGenericInterfaceImplementedByArray(parameterizedType) && arrayType2.Dimensions == 1)
		{
			MakeUpperBoundInference(parameterizedType.GetTypeArgument(0), arrayType2.ElementType);
		}
		else
		{
			if (parameterizedType == null)
			{
				return;
			}
			ParameterizedType parameterizedType2 = null;
			foreach (IType allBaseType in V.GetAllBaseTypes())
			{
				if (allBaseType is ParameterizedType parameterizedType3 && object.Equals(parameterizedType.GetDefinition(), parameterizedType3.GetDefinition()) && parameterizedType.TypeParameterCount == parameterizedType3.TypeParameterCount)
				{
					if (parameterizedType2 != null)
					{
						return;
					}
					parameterizedType2 = parameterizedType3;
				}
			}
			if (parameterizedType2 == null)
			{
				return;
			}
			for (int i = 0; i < parameterizedType2.TypeParameterCount; i++)
			{
				IType typeArgument = parameterizedType.GetTypeArgument(i);
				IType typeArgument2 = parameterizedType2.GetTypeArgument(i);
				if (typeArgument.IsReferenceType == true)
				{
					ITypeParameter typeParameter = parameterizedType.GetDefinition().TypeParameters[i];
					switch (typeParameter.Variance)
					{
					case VarianceModifier.Covariant:
						MakeUpperBoundInference(typeArgument, typeArgument2);
						break;
					case VarianceModifier.Contravariant:
						MakeLowerBoundInference(typeArgument, typeArgument2);
						break;
					default:
						MakeExactInference(typeArgument, typeArgument2);
						break;
					}
				}
				else
				{
					MakeExactInference(typeArgument, typeArgument2);
				}
			}
		}
	}

	private bool Fix(TP tp)
	{
		if (tp.ExactBound != null)
		{
			tp.FixedTo = tp.ExactBound;
			if (tp.MultipleDifferentExactBounds)
			{
				return false;
			}
			if (tp.LowerBounds.All((IType b) => conversions.ImplicitConversion(b, tp.FixedTo).IsValid))
			{
				return tp.UpperBounds.All((IType b) => conversions.ImplicitConversion(tp.FixedTo, b).IsValid);
			}
			return false;
		}
		IList<IType> list = CreateNestedInstance().FindTypesInBounds(tp.LowerBounds.ToArray(), tp.UpperBounds.ToArray());
		if (algorithm == TypeInferenceAlgorithm.ImprovedReturnAllResults)
		{
			tp.FixedTo = IntersectionType.Create(list);
			return list.Count >= 1;
		}
		tp.FixedTo = GetFirstTypePreferNonInterfaces(list);
		return list.Count == 1;
	}

	public IType GetBestCommonType(IList<ResolveResult> expressions, out bool success)
	{
		if (expressions == null)
		{
			throw new ArgumentNullException("expressions");
		}
		if (expressions.Count == 1)
		{
			success = expressions[0].Type.Kind != TypeKind.Unknown;
			return expressions[0].Type;
		}
		try
		{
			ITypeParameter methodTypeParameter = DummyTypeParameter.GetMethodTypeParameter(0);
			typeParameters = new TP[1]
			{
				new TP(methodTypeParameter)
			};
			foreach (ResolveResult expression in expressions)
			{
				MakeOutputTypeInference(expression, methodTypeParameter);
			}
			success = Fix(typeParameters[0]);
			return typeParameters[0].FixedTo ?? SpecialType.UnknownType;
		}
		finally
		{
			Reset();
		}
	}

	public IType FindTypeInBounds(IList<IType> lowerBounds, IList<IType> upperBounds)
	{
		if (lowerBounds == null)
		{
			throw new ArgumentNullException("lowerBounds");
		}
		if (upperBounds == null)
		{
			throw new ArgumentNullException("upperBounds");
		}
		IList<IType> list = FindTypesInBounds(lowerBounds, upperBounds);
		if (algorithm == TypeInferenceAlgorithm.ImprovedReturnAllResults)
		{
			return IntersectionType.Create(list);
		}
		return GetFirstTypePreferNonInterfaces(list);
	}

	private static IType GetFirstTypePreferNonInterfaces(IList<IType> result)
	{
		return result.FirstOrDefault((IType c) => c.Kind != TypeKind.Interface) ?? result.FirstOrDefault() ?? SpecialType.UnknownType;
	}

	private IList<IType> FindTypesInBounds(IList<IType> lowerBounds, IList<IType> upperBounds)
	{
		if (lowerBounds.Count == 0 && upperBounds.Count <= 1)
		{
			return upperBounds;
		}
		if (upperBounds.Count == 0 && lowerBounds.Count <= 1)
		{
			return lowerBounds;
		}
		if (nestingLevel > 5)
		{
			return EmptyList<IType>.Instance;
		}
		List<IType> candidateTypes = (from c in lowerBounds.Union(upperBounds)
			where lowerBounds.All((IType b) => conversions.ImplicitConversion(b, c).IsValid)
			where upperBounds.All((IType b) => conversions.ImplicitConversion(c, b).IsValid)
			select c).ToList();
		candidateTypes = candidateTypes.Where((IType c) => candidateTypes.All((IType o) => conversions.ImplicitConversion(o, c).IsValid)).ToList();
		if (candidateTypes.Count == 1 || (algorithm != TypeInferenceAlgorithm.Improved && algorithm != TypeInferenceAlgorithm.ImprovedReturnAllResults))
		{
			return candidateTypes;
		}
		candidateTypes.Clear();
		List<ITypeDefinition> list;
		if (lowerBounds.Count > 0)
		{
			HashSet<ITypeDefinition> hashSet = new HashSet<ITypeDefinition>(lowerBounds[0].GetAllBaseTypeDefinitions());
			for (int num = 1; num < lowerBounds.Count; num++)
			{
				hashSet.IntersectWith(lowerBounds[num].GetAllBaseTypeDefinitions());
			}
			list = hashSet.ToList();
		}
		else
		{
			list = compilation.GetAllTypeDefinitions().ToList();
		}
		foreach (IType upperBound in upperBounds)
		{
			ITypeDefinition ubDef = upperBound.GetDefinition();
			if (ubDef != null)
			{
				list.RemoveAll((ITypeDefinition c) => !c.IsDerivedFrom(ubDef));
			}
		}
		foreach (ITypeDefinition candidateDef in list)
		{
			IType item;
			if (candidateDef.TypeParameterCount == 0)
			{
				item = candidateDef;
			}
			else
			{
				IType[] typeArguments = InferTypeArgumentsFromBounds(candidateDef.TypeParameters, new ParameterizedType(candidateDef, candidateDef.TypeParameters), lowerBounds, upperBounds, out var success);
				if (!success)
				{
					continue;
				}
				item = new ParameterizedType(candidateDef, typeArguments);
			}
			if (upperBounds.Count == 0)
			{
				if (!candidateTypes.Any((IType c) => c.GetDefinition().IsDerivedFrom(candidateDef)))
				{
					candidateTypes.RemoveAll((IType c) => candidateDef.IsDerivedFrom(c.GetDefinition()));
					candidateTypes.Add(item);
				}
			}
			else if (!candidateTypes.Any((IType c) => candidateDef.IsDerivedFrom(c.GetDefinition())))
			{
				candidateTypes.RemoveAll((IType c) => c.GetDefinition().IsDerivedFrom(candidateDef));
				candidateTypes.Add(item);
			}
		}
		return candidateTypes;
	}
}
