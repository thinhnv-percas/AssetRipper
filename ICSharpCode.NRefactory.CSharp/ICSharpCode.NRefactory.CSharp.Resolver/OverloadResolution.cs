using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public class OverloadResolution
{
	private sealed class Candidate
	{
		public readonly IParameterizedMember Member;

		public readonly bool IsExpandedForm;

		public readonly IType[] ParameterTypes;

		public int[] ArgumentToParameterMap;

		public OverloadResolutionErrors Errors;

		public int ErrorCount;

		public bool HasUnmappedOptionalParameters;

		public IType[] InferredTypes;

		public readonly IList<IParameter> Parameters;

		public readonly IList<ITypeParameter> TypeParameters;

		public Conversion[] ArgumentConversions;

		public bool IsGenericMethod
		{
			get
			{
				if (Member is IMethod method)
				{
					return method.TypeParameters.Count > 0;
				}
				return false;
			}
		}

		public int ArgumentsPassedToParamsArray
		{
			get
			{
				int num = 0;
				if (IsExpandedForm)
				{
					int num2 = Parameters.Count - 1;
					int[] argumentToParameterMap = ArgumentToParameterMap;
					foreach (int num3 in argumentToParameterMap)
					{
						if (num3 == num2)
						{
							num++;
						}
					}
				}
				return num;
			}
		}

		public Candidate(IParameterizedMember member, bool isExpanded)
		{
			Member = member;
			IsExpandedForm = isExpanded;
			IParameterizedMember parameterizedMember = (IParameterizedMember)member.MemberDefinition;
			Parameters = parameterizedMember.Parameters;
			if (parameterizedMember is IMethod method && method.TypeParameters.Count > 0)
			{
				TypeParameters = method.TypeParameters;
			}
			ParameterTypes = new IType[Parameters.Count];
		}

		public void AddError(OverloadResolutionErrors newError)
		{
			Errors |= newError;
			if (!IsApplicable(newError))
			{
				ErrorCount++;
			}
		}
	}

	private sealed class ConstraintValidatingSubstitution : TypeParameterSubstitution
	{
		private readonly CSharpConversions conversions;

		public bool ConstraintsValid = true;

		public ConstraintValidatingSubstitution(IList<IType> classTypeArguments, IList<IType> methodTypeArguments, OverloadResolution overloadResolution)
			: base(classTypeArguments, methodTypeArguments)
		{
			conversions = overloadResolution.conversions;
		}

		public override IType VisitParameterizedType(ParameterizedType type)
		{
			IType type2 = base.VisitParameterizedType(type);
			if (type2 != type && ConstraintsValid && type2 is ParameterizedType parameterizedType)
			{
				IList<ITypeParameter> typeParameters = parameterizedType.GetDefinition().TypeParameters;
				TypeParameterSubstitution substitution = parameterizedType.GetSubstitution();
				for (int i = 0; i < typeParameters.Count; i++)
				{
					if (!ValidateConstraints(typeParameters[i], parameterizedType.GetTypeArgument(i), substitution, conversions))
					{
						ConstraintsValid = false;
						break;
					}
				}
			}
			return type2;
		}
	}

	public interface ILiftedOperator : IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		IList<IParameter> NonLiftedParameters { get; }
	}

	private readonly ICompilation compilation;

	private readonly ResolveResult[] arguments;

	private readonly string[] argumentNames;

	private readonly CSharpConversions conversions;

	private Candidate bestCandidate;

	private Candidate bestCandidateAmbiguousWith;

	private IType[] explicitlyGivenTypeArguments;

	private bool bestCandidateWasValidated;

	private OverloadResolutionErrors bestCandidateValidationResult;

	public bool IsExtensionMethodInvocation { get; set; }

	public bool AllowExpandingParams { get; set; }

	public bool AllowOptionalParameters { get; set; }

	public bool CheckForOverflow { get; set; }

	public IList<ResolveResult> Arguments => arguments;

	public IParameterizedMember BestCandidate
	{
		get
		{
			if (bestCandidate == null)
			{
				return null;
			}
			return bestCandidate.Member;
		}
	}

	public OverloadResolutionErrors BestCandidateErrors
	{
		get
		{
			if (bestCandidate == null)
			{
				return OverloadResolutionErrors.None;
			}
			if (!bestCandidateWasValidated)
			{
				bestCandidateValidationResult = ValidateMethodConstraints(bestCandidate);
				bestCandidateWasValidated = true;
			}
			OverloadResolutionErrors overloadResolutionErrors = bestCandidate.Errors | bestCandidateValidationResult;
			if (bestCandidateAmbiguousWith != null)
			{
				overloadResolutionErrors |= OverloadResolutionErrors.AmbiguousMatch;
			}
			return overloadResolutionErrors;
		}
	}

	public bool FoundApplicableCandidate
	{
		get
		{
			if (bestCandidate != null)
			{
				return IsApplicable(bestCandidate.Errors);
			}
			return false;
		}
	}

	public IParameterizedMember BestCandidateAmbiguousWith
	{
		get
		{
			if (bestCandidateAmbiguousWith == null)
			{
				return null;
			}
			return bestCandidateAmbiguousWith.Member;
		}
	}

	public bool BestCandidateIsExpandedForm
	{
		get
		{
			if (bestCandidate == null)
			{
				return false;
			}
			return bestCandidate.IsExpandedForm;
		}
	}

	public bool IsAmbiguous => bestCandidateAmbiguousWith != null;

	public IList<IType> InferredTypeArguments
	{
		get
		{
			if (bestCandidate != null && bestCandidate.InferredTypes != null)
			{
				return bestCandidate.InferredTypes;
			}
			return EmptyList<IType>.Instance;
		}
	}

	public IList<Conversion> ArgumentConversions
	{
		get
		{
			if (bestCandidate != null && bestCandidate.ArgumentConversions != null)
			{
				return bestCandidate.ArgumentConversions;
			}
			return Enumerable.Repeat(Conversion.None, arguments.Length).ToList();
		}
	}

	public OverloadResolution(ICompilation compilation, ResolveResult[] arguments, string[] argumentNames = null, IType[] typeArguments = null, CSharpConversions conversions = null)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (arguments == null)
		{
			throw new ArgumentNullException("arguments");
		}
		if (argumentNames == null)
		{
			argumentNames = new string[arguments.Length];
		}
		else if (argumentNames.Length != arguments.Length)
		{
			throw new ArgumentException("argumentsNames.Length must be equal to arguments.Length");
		}
		this.compilation = compilation;
		this.arguments = arguments;
		this.argumentNames = argumentNames;
		if (typeArguments != null && typeArguments.Length != 0)
		{
			explicitlyGivenTypeArguments = typeArguments;
		}
		this.conversions = conversions ?? CSharpConversions.Get(compilation);
		AllowExpandingParams = true;
		AllowOptionalParameters = true;
	}

	public OverloadResolutionErrors AddCandidate(IParameterizedMember member)
	{
		return AddCandidate(member, OverloadResolutionErrors.None);
	}

	public OverloadResolutionErrors AddCandidate(IParameterizedMember member, OverloadResolutionErrors additionalErrors)
	{
		if (member == null)
		{
			throw new ArgumentNullException("member");
		}
		Candidate candidate = new Candidate(member, isExpanded: false);
		candidate.AddError(additionalErrors);
		CalculateCandidate(candidate);
		if (AllowExpandingParams && member.Parameters.Count > 0 && member.Parameters[member.Parameters.Count - 1].IsParams)
		{
			Candidate candidate2 = new Candidate(member, isExpanded: true);
			candidate2.AddError(additionalErrors);
			if (CalculateCandidate(candidate2) && candidate2.ErrorCount < candidate.ErrorCount)
			{
				return candidate2.Errors;
			}
		}
		return candidate.Errors;
	}

	private bool CalculateCandidate(Candidate candidate)
	{
		if (!ResolveParameterTypes(candidate, useSpecializedParameters: false))
		{
			return false;
		}
		MapCorrespondingParameters(candidate);
		RunTypeInference(candidate);
		CheckApplicability(candidate);
		ConsiderIfNewCandidateIsBest(candidate);
		return true;
	}

	private bool ResolveParameterTypes(Candidate candidate, bool useSpecializedParameters)
	{
		for (int i = 0; i < candidate.Parameters.Count; i++)
		{
			IType type = ((!useSpecializedParameters) ? candidate.Parameters[i].Type : candidate.Member.Parameters[i].Type);
			if (candidate.IsExpandedForm && i == candidate.Parameters.Count - 1)
			{
				if (!(type is ArrayType { Dimensions: 1 } arrayType))
				{
					return false;
				}
				type = arrayType.ElementType;
			}
			candidate.ParameterTypes[i] = type;
		}
		return true;
	}

	public void AddMethodLists(IList<MethodListWithDeclaringType> methodLists)
	{
		if (methodLists == null)
		{
			throw new ArgumentNullException("methodLists");
		}
		bool[] array = ((methodLists.Count <= 1) ? null : new bool[methodLists.Count]);
		for (int num = methodLists.Count - 1; num >= 0; num--)
		{
			if (array == null || !array[num])
			{
				MethodListWithDeclaringType methodListWithDeclaringType = methodLists[num];
				bool flag = false;
				for (int i = 0; i < methodListWithDeclaringType.Count; i++)
				{
					IParameterizedMember member = methodListWithDeclaringType[i];
					OverloadResolutionErrors errors = AddCandidate(member);
					flag |= IsApplicable(errors);
				}
				if (flag && num > 0)
				{
					foreach (IType allBaseType in methodListWithDeclaringType.DeclaringType.GetAllBaseTypes())
					{
						for (int j = 0; j < num; j++)
						{
							if (!array[j] && allBaseType.Equals(methodLists[j].DeclaringType))
							{
								array[j] = true;
							}
						}
					}
				}
			}
		}
	}

	[Conditional("DEBUG")]
	internal void LogCandidateAddingResult(string text, IParameterizedMember method, OverloadResolutionErrors errors)
	{
	}

	private void MapCorrespondingParameters(Candidate candidate)
	{
		candidate.ArgumentToParameterMap = new int[arguments.Length];
		for (int i = 0; i < arguments.Length; i++)
		{
			candidate.ArgumentToParameterMap[i] = -1;
			if (argumentNames[i] == null)
			{
				if (i < candidate.ParameterTypes.Length)
				{
					candidate.ArgumentToParameterMap[i] = i;
				}
				else if (candidate.IsExpandedForm)
				{
					candidate.ArgumentToParameterMap[i] = candidate.ParameterTypes.Length - 1;
				}
				else
				{
					candidate.AddError(OverloadResolutionErrors.TooManyPositionalArguments);
				}
				continue;
			}
			for (int j = 0; j < candidate.Parameters.Count; j++)
			{
				if (argumentNames[i] == candidate.Parameters[j].Name)
				{
					candidate.ArgumentToParameterMap[i] = j;
				}
			}
			if (candidate.ArgumentToParameterMap[i] < 0)
			{
				candidate.AddError(OverloadResolutionErrors.NoParameterFoundForNamedArgument);
			}
		}
	}

	private void RunTypeInference(Candidate candidate)
	{
		if (candidate.TypeParameters == null)
		{
			if (explicitlyGivenTypeArguments != null)
			{
				candidate.AddError(OverloadResolutionErrors.WrongNumberOfTypeArguments);
			}
			ResolveParameterTypes(candidate, useSpecializedParameters: true);
			return;
		}
		IList<IType> classTypeArguments = ((!(candidate.Member.DeclaringType is ParameterizedType parameterizedType)) ? null : parameterizedType.TypeArguments);
		if (explicitlyGivenTypeArguments != null)
		{
			if (explicitlyGivenTypeArguments.Length == candidate.TypeParameters.Count)
			{
				candidate.InferredTypes = explicitlyGivenTypeArguments;
			}
			else
			{
				candidate.AddError(OverloadResolutionErrors.WrongNumberOfTypeArguments);
				candidate.InferredTypes = new IType[candidate.TypeParameters.Count];
				for (int i = 0; i < candidate.InferredTypes.Length; i++)
				{
					if (i < explicitlyGivenTypeArguments.Length)
					{
						candidate.InferredTypes[i] = explicitlyGivenTypeArguments[i];
					}
					else
					{
						candidate.InferredTypes[i] = SpecialType.UnknownType;
					}
				}
			}
		}
		else
		{
			TypeInference typeInference = new TypeInference(compilation, conversions);
			candidate.InferredTypes = typeInference.InferTypeArguments(candidate.TypeParameters, arguments, candidate.ParameterTypes, out var success, classTypeArguments);
			if (!success)
			{
				candidate.AddError(OverloadResolutionErrors.TypeInferenceFailed);
			}
		}
		ConstraintValidatingSubstitution constraintValidatingSubstitution = new ConstraintValidatingSubstitution(classTypeArguments, candidate.InferredTypes, this);
		for (int j = 0; j < candidate.ParameterTypes.Length; j++)
		{
			candidate.ParameterTypes[j] = candidate.ParameterTypes[j].AcceptVisitor(constraintValidatingSubstitution);
		}
		if (!constraintValidatingSubstitution.ConstraintsValid)
		{
			candidate.AddError(OverloadResolutionErrors.ConstructedTypeDoesNotSatisfyConstraint);
		}
	}

	private OverloadResolutionErrors ValidateMethodConstraints(Candidate candidate)
	{
		if ((candidate.Errors & OverloadResolutionErrors.TypeInferenceFailed) != OverloadResolutionErrors.None)
		{
			return OverloadResolutionErrors.None;
		}
		if (candidate.TypeParameters == null || candidate.TypeParameters.Count == 0)
		{
			return OverloadResolutionErrors.None;
		}
		TypeParameterSubstitution substitution = GetSubstitution(candidate);
		for (int i = 0; i < candidate.TypeParameters.Count; i++)
		{
			if (!ValidateConstraints(candidate.TypeParameters[i], substitution.MethodTypeArguments[i], substitution))
			{
				return OverloadResolutionErrors.MethodConstraintsNotSatisfied;
			}
		}
		return OverloadResolutionErrors.None;
	}

	public static bool ValidateConstraints(ITypeParameter typeParameter, IType typeArgument, TypeVisitor substitution = null)
	{
		if (typeParameter == null)
		{
			throw new ArgumentNullException("typeParameter");
		}
		if (typeArgument == null)
		{
			throw new ArgumentNullException("typeArgument");
		}
		return ValidateConstraints(typeParameter, typeArgument, substitution, CSharpConversions.Get(typeParameter.Owner.Compilation));
	}

	internal static bool ValidateConstraints(ITypeParameter typeParameter, IType typeArgument, TypeVisitor substitution, CSharpConversions conversions)
	{
		TypeKind kind = typeArgument.Kind;
		if (kind == TypeKind.Void || kind == TypeKind.Null || kind == TypeKind.Pointer)
		{
			return false;
		}
		if (typeParameter.HasReferenceTypeConstraint && typeArgument.IsReferenceType != true)
		{
			return false;
		}
		if (typeParameter.HasValueTypeConstraint && !NullableType.IsNonNullableValueType(typeArgument))
		{
			return false;
		}
		if (typeParameter.HasDefaultConstructorConstraint)
		{
			ITypeDefinition definition = typeArgument.GetDefinition();
			if (definition != null && definition.IsAbstract)
			{
				return false;
			}
			IEnumerable<IMethod> constructors = typeArgument.GetConstructors((IUnresolvedMethod m) => m.Parameters.Count == 0 && m.Accessibility == Accessibility.Public, GetMemberOptions.ReturnMemberDefinitions | GetMemberOptions.IgnoreInheritedMembers);
			if (!constructors.Any())
			{
				return false;
			}
		}
		foreach (IType directBaseType in typeParameter.DirectBaseTypes)
		{
			IType type = directBaseType;
			if (substitution != null)
			{
				type = type.AcceptVisitor(substitution);
			}
			if (!conversions.IsConstraintConvertible(typeArgument, type))
			{
				return false;
			}
		}
		return true;
	}

	public static bool IsApplicable(OverloadResolutionErrors errors)
	{
		return (errors & ~(OverloadResolutionErrors.AmbiguousMatch | OverloadResolutionErrors.MethodConstraintsNotSatisfied)) == 0;
	}

	private void CheckApplicability(Candidate candidate)
	{
		int[] array = new int[candidate.ParameterTypes.Length];
		int[] argumentToParameterMap = candidate.ArgumentToParameterMap;
		foreach (int num in argumentToParameterMap)
		{
			if (num >= 0)
			{
				array[num]++;
			}
		}
		for (int j = 0; j < array.Length; j++)
		{
			if (candidate.IsExpandedForm && j == array.Length - 1)
			{
				continue;
			}
			if (array[j] == 0)
			{
				if (AllowOptionalParameters && candidate.Parameters[j].IsOptional)
				{
					candidate.HasUnmappedOptionalParameters = true;
				}
				else
				{
					candidate.AddError(OverloadResolutionErrors.MissingArgumentForRequiredParameter);
				}
			}
			else if (array[j] > 1)
			{
				candidate.AddError(OverloadResolutionErrors.MultipleArgumentsForSingleParameter);
			}
		}
		candidate.ArgumentConversions = new Conversion[arguments.Length];
		for (int k = 0; k < arguments.Length; k++)
		{
			int num2 = candidate.ArgumentToParameterMap[k];
			if (num2 < 0)
			{
				candidate.ArgumentConversions[k] = Conversion.None;
				continue;
			}
			if (arguments[k] is ByReferenceResolveResult byReferenceResolveResult)
			{
				if ((byReferenceResolveResult.IsOut && !candidate.Parameters[num2].IsOut) || (byReferenceResolveResult.IsRef && !candidate.Parameters[num2].IsRef) || (byReferenceResolveResult.IsIn && !candidate.Parameters[num2].IsIn))
				{
					candidate.AddError(OverloadResolutionErrors.ParameterPassingModeMismatch);
				}
			}
			else if (candidate.Parameters[num2].IsOut || candidate.Parameters[num2].IsRef || candidate.Parameters[num2].IsIn)
			{
				candidate.AddError(OverloadResolutionErrors.ParameterPassingModeMismatch);
			}
			IType type = candidate.ParameterTypes[num2];
			Conversion conversion = conversions.ImplicitConversion(arguments[k], type);
			candidate.ArgumentConversions[k] = conversion;
			if (IsExtensionMethodInvocation && num2 == 0)
			{
				if (conversion != Conversion.IdentityConversion && conversion != Conversion.ImplicitReferenceConversion && conversion != Conversion.BoxingConversion)
				{
					candidate.AddError(OverloadResolutionErrors.ArgumentTypeMismatch);
				}
			}
			else if (!conversion.IsValid && !conversion.IsUserDefined && !conversion.IsMethodGroupConversion && type.Kind != TypeKind.Unknown)
			{
				candidate.AddError(OverloadResolutionErrors.ArgumentTypeMismatch);
			}
		}
	}

	private int BetterFunctionMember(Candidate c1, Candidate c2)
	{
		if (c1.ErrorCount == 0 && c2.ErrorCount > 0)
		{
			return 1;
		}
		if (c1.ErrorCount > 0 && c2.ErrorCount == 0)
		{
			return 2;
		}
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < arguments.Length; i++)
		{
			int num = c1.ArgumentToParameterMap[i];
			int num2 = c2.ArgumentToParameterMap[i];
			if (num >= 0 && num2 < 0)
			{
				flag = true;
			}
			else if (num < 0 && num2 >= 0)
			{
				flag2 = true;
			}
			else if (num >= 0 && num2 >= 0)
			{
				switch (conversions.BetterConversion(arguments[i], c1.ParameterTypes[num], c2.ParameterTypes[num2]))
				{
				case 1:
					flag = true;
					break;
				case 2:
					flag2 = true;
					break;
				}
			}
		}
		if (flag && !flag2)
		{
			return 1;
		}
		if (!flag & flag2)
		{
			return 2;
		}
		if (c1.ErrorCount < c2.ErrorCount)
		{
			return 1;
		}
		if (c1.ErrorCount > c2.ErrorCount)
		{
			return 2;
		}
		if (!flag && !flag2)
		{
			if (!c1.IsGenericMethod && c2.IsGenericMethod)
			{
				return 1;
			}
			if (c1.IsGenericMethod && !c2.IsGenericMethod)
			{
				return 2;
			}
			if (!c1.IsExpandedForm && c2.IsExpandedForm)
			{
				return 1;
			}
			if (c1.IsExpandedForm && !c2.IsExpandedForm)
			{
				return 2;
			}
			int num3 = c1.ArgumentsPassedToParamsArray.CompareTo(c2.ArgumentsPassedToParamsArray);
			if (num3 < 0)
			{
				return 1;
			}
			if (num3 > 0)
			{
				return 2;
			}
			if (!c1.HasUnmappedOptionalParameters && c2.HasUnmappedOptionalParameters)
			{
				return 1;
			}
			if (c1.HasUnmappedOptionalParameters && !c2.HasUnmappedOptionalParameters)
			{
				return 2;
			}
			num3 = MoreSpecificFormalParameters(c1, c2);
			if (num3 != 0)
			{
				return num3;
			}
			ILiftedOperator liftedOperator = c1.Member as ILiftedOperator;
			ILiftedOperator liftedOperator2 = c2.Member as ILiftedOperator;
			if (liftedOperator == null && liftedOperator2 != null)
			{
				return 1;
			}
			if (liftedOperator != null && liftedOperator2 == null)
			{
				return 2;
			}
		}
		return 0;
	}

	private int MoreSpecificFormalParameters(Candidate c1, Candidate c2)
	{
		int num = c1.Parameters.Count.CompareTo(c2.Parameters.Count);
		if (num > 0)
		{
			return 1;
		}
		if (num < 0)
		{
			return 2;
		}
		return MoreSpecificFormalParameters(c1.Parameters.Select((IParameter p) => p.Type), c2.Parameters.Select((IParameter p) => p.Type));
	}

	private static int MoreSpecificFormalParameters(IEnumerable<IType> t1, IEnumerable<IType> t2)
	{
		bool flag = false;
		bool flag2 = false;
		foreach (var item in t1.Zip(t2, (IType a, IType b) => new
		{
			Item1 = a,
			Item2 = b
		}))
		{
			switch (MoreSpecificFormalParameter(item.Item1, item.Item2))
			{
			case 1:
				flag = true;
				break;
			case 2:
				flag2 = true;
				break;
			}
		}
		if (flag && !flag2)
		{
			return 1;
		}
		if (!flag & flag2)
		{
			return 2;
		}
		return 0;
	}

	private static int MoreSpecificFormalParameter(IType t1, IType t2)
	{
		if (t1 is ITypeParameter && !(t2 is ITypeParameter))
		{
			return 2;
		}
		if (t2 is ITypeParameter && !(t1 is ITypeParameter))
		{
			return 1;
		}
		ParameterizedType parameterizedType = t1 as ParameterizedType;
		ParameterizedType parameterizedType2 = t2 as ParameterizedType;
		if (parameterizedType != null && parameterizedType2 != null && parameterizedType.TypeParameterCount == parameterizedType2.TypeParameterCount)
		{
			int num = MoreSpecificFormalParameters(parameterizedType.TypeArguments, parameterizedType2.TypeArguments);
			if (num > 0)
			{
				return num;
			}
		}
		TypeWithElementType typeWithElementType = t1 as TypeWithElementType;
		TypeWithElementType typeWithElementType2 = t2 as TypeWithElementType;
		if (typeWithElementType != null && typeWithElementType2 != null)
		{
			return MoreSpecificFormalParameter(typeWithElementType.ElementType, typeWithElementType2.ElementType);
		}
		return 0;
	}

	private void ConsiderIfNewCandidateIsBest(Candidate candidate)
	{
		if (bestCandidate == null)
		{
			bestCandidate = candidate;
			bestCandidateWasValidated = false;
			return;
		}
		switch (BetterFunctionMember(candidate, bestCandidate))
		{
		case 0:
			bestCandidateAmbiguousWith = candidate;
			break;
		case 1:
			bestCandidate = candidate;
			bestCandidateWasValidated = false;
			bestCandidateAmbiguousWith = null;
			break;
		}
	}

	public IList<int> GetArgumentToParameterMap()
	{
		if (bestCandidate != null)
		{
			return bestCandidate.ArgumentToParameterMap;
		}
		return null;
	}

	public IList<ResolveResult> GetArgumentsWithConversions()
	{
		if (bestCandidate == null)
		{
			return arguments;
		}
		return GetArgumentsWithConversions(null, null);
	}

	public IList<ResolveResult> GetArgumentsWithConversionsAndNames()
	{
		if (bestCandidate == null)
		{
			return arguments;
		}
		return GetArgumentsWithConversions(null, GetBestCandidateWithSubstitutedTypeArguments());
	}

	private IList<ResolveResult> GetArgumentsWithConversions(ResolveResult targetResolveResult, IParameterizedMember bestCandidateForNamedArguments)
	{
		IList<Conversion> argumentConversions = ArgumentConversions;
		ResolveResult[] array = new ResolveResult[arguments.Length];
		for (int i = 0; i < array.Length; i++)
		{
			ResolveResult resolveResult = arguments[i];
			if (IsExtensionMethodInvocation && i == 0 && targetResolveResult != null)
			{
				resolveResult = targetResolveResult;
			}
			int num = bestCandidate.ArgumentToParameterMap[i];
			if (num >= 0 && argumentConversions[i] != Conversion.IdentityConversion)
			{
				IType type = bestCandidate.ParameterTypes[num];
				if (type.Kind != TypeKind.Unknown)
				{
					resolveResult = ((!arguments[i].IsCompileTimeConstant || !argumentConversions[i].IsValid || argumentConversions[i].IsUserDefined) ? new ConversionResolveResult(type, resolveResult, argumentConversions[i], CheckForOverflow) : new CSharpResolver(compilation).WithCheckForOverflow(CheckForOverflow).ResolveCast(type, resolveResult));
				}
			}
			if (bestCandidateForNamedArguments != null && argumentNames[i] != null)
			{
				resolveResult = ((num < 0) ? new NamedArgumentResolveResult(argumentNames[i], resolveResult) : new NamedArgumentResolveResult(bestCandidateForNamedArguments.Parameters[num], resolveResult, bestCandidateForNamedArguments));
			}
			array[i] = resolveResult;
		}
		return array;
	}

	public IParameterizedMember GetBestCandidateWithSubstitutedTypeArguments()
	{
		if (bestCandidate == null)
		{
			return null;
		}
		if (bestCandidate.Member is IMethod method && method.TypeParameters.Count > 0)
		{
			return ((IMethod)method.MemberDefinition).Specialize(GetSubstitution(bestCandidate));
		}
		return bestCandidate.Member;
	}

	private TypeParameterSubstitution GetSubstitution(Candidate candidate)
	{
		return new TypeParameterSubstitution(candidate.Member.Substitution.ClassTypeArguments, candidate.InferredTypes);
	}

	public CSharpInvocationResolveResult CreateResolveResult(ResolveResult targetResolveResult, IList<ResolveResult> initializerStatements = null, IType returnTypeOverride = null)
	{
		IParameterizedMember bestCandidateWithSubstitutedTypeArguments = GetBestCandidateWithSubstitutedTypeArguments();
		if (bestCandidateWithSubstitutedTypeArguments == null)
		{
			throw new InvalidOperationException();
		}
		return new CSharpInvocationResolveResult(IsExtensionMethodInvocation ? new TypeResolveResult(bestCandidateWithSubstitutedTypeArguments.DeclaringType ?? SpecialType.UnknownType) : targetResolveResult, bestCandidateWithSubstitutedTypeArguments, GetArgumentsWithConversions(targetResolveResult, bestCandidateWithSubstitutedTypeArguments), BestCandidateErrors, IsExtensionMethodInvocation, BestCandidateIsExpandedForm, isDelegateInvocation: false, GetArgumentToParameterMap(), initializerStatements, returnTypeOverride);
	}
}
