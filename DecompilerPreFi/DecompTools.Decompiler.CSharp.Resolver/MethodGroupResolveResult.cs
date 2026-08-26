#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.CSharp.Resolver;

public class MethodGroupResolveResult : ResolveResult
{
	private readonly IReadOnlyList<MethodListWithDeclaringType> methodLists;

	private readonly IReadOnlyList<IType> typeArguments;

	private readonly ResolveResult targetResult;

	private readonly string methodName;

	internal List<List<IMethod>> extensionMethods;

	internal CSharpResolver resolver;

	public ResolveResult TargetResult => targetResult;

	public IType TargetType
	{
		get
		{
			IType result;
			if (targetResult == null)
			{
				IType unknownType = SpecialType.UnknownType;
				result = unknownType;
			}
			else
			{
				result = targetResult.Type;
			}
			return result;
		}
	}

	public string MethodName => methodName;

	public IEnumerable<IMethod> Methods => Enumerable.SelectMany<MethodListWithDeclaringType, IMethod>((IEnumerable<MethodListWithDeclaringType>)methodLists, (Func<MethodListWithDeclaringType, IEnumerable<IMethod>>)((MethodListWithDeclaringType m) => Enumerable.Cast<IMethod>((IEnumerable)m)));

	public IEnumerable<MethodListWithDeclaringType> MethodsGroupedByDeclaringType => methodLists;

	public IReadOnlyList<IType> TypeArguments => typeArguments;

	public MethodGroupResolveResult(ResolveResult targetResult, string methodName, IReadOnlyList<MethodListWithDeclaringType> methods, IReadOnlyList<IType> typeArguments)
		: base(SpecialType.NoType)
	{
		if (methods == null)
		{
			throw new ArgumentNullException("methods");
		}
		this.targetResult = targetResult;
		this.methodName = methodName;
		methodLists = methods;
		this.typeArguments = typeArguments ?? EmptyList<IType>.Instance;
	}

	public IEnumerable<IEnumerable<IMethod>> GetExtensionMethods()
	{
		if (resolver != null)
		{
			Debug.Assert(extensionMethods == null);
			try
			{
				extensionMethods = resolver.GetExtensionMethods(methodName, typeArguments);
			}
			finally
			{
				resolver = null;
			}
		}
		IEnumerable<IEnumerable<IMethod>> enumerable = extensionMethods;
		return enumerable ?? Enumerable.Empty<IEnumerable<IMethod>>();
	}

	public IEnumerable<IEnumerable<IMethod>> GetEligibleExtensionMethods(bool substituteInferredTypes)
	{
		List<List<IMethod>> list = new List<List<IMethod>>();
		foreach (IEnumerable<IMethod> extensionMethod in GetExtensionMethods())
		{
			List<IMethod> list2 = new List<IMethod>();
			foreach (IMethod item in extensionMethod)
			{
				if (CSharpResolver.IsEligibleExtensionMethod(TargetType, item, useTypeInference: true, out var outInferredTypes))
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

	public override string ToString()
	{
		return $"[{GetType().Name} with {Enumerable.Count<IMethod>(Methods)} method(s)]";
	}

	public OverloadResolution PerformOverloadResolution(ICompilation compilation, ResolveResult[] arguments, string[] argumentNames = null, bool allowExtensionMethods = true, bool allowExpandingParams = true, bool allowOptionalParameters = true, bool checkForOverflow = false, CSharpConversions conversions = null)
	{
		IType[] array = Enumerable.ToArray<IType>((IEnumerable<IType>)TypeArguments);
		OverloadResolution overloadResolution = new OverloadResolution(compilation, arguments, argumentNames, array, conversions);
		overloadResolution.AllowExpandingParams = allowExpandingParams;
		overloadResolution.AllowOptionalParameters = allowOptionalParameters;
		overloadResolution.CheckForOverflow = checkForOverflow;
		overloadResolution.AddMethodLists(methodLists);
		checked
		{
			if (allowExtensionMethods && !overloadResolution.FoundApplicableCandidate)
			{
				IEnumerable<IEnumerable<IMethod>> enumerable = GetExtensionMethods();
				if (Enumerable.Any<IEnumerable<IMethod>>(enumerable))
				{
					ResolveResult[] array2 = new ResolveResult[arguments.Length + 1];
					array2[0] = new ResolveResult(TargetType);
					arguments.CopyTo(array2, 1);
					string[] array3 = null;
					if (argumentNames != null)
					{
						array3 = new string[argumentNames.Length + 1];
						argumentNames.CopyTo(array3, 1);
					}
					OverloadResolution overloadResolution2 = new OverloadResolution(compilation, array2, array3, array, conversions);
					overloadResolution2.AllowExpandingParams = allowExpandingParams;
					overloadResolution2.AllowOptionalParameters = allowOptionalParameters;
					overloadResolution2.IsExtensionMethodInvocation = true;
					overloadResolution2.CheckForOverflow = checkForOverflow;
					foreach (IEnumerable<IMethod> item in enumerable)
					{
						foreach (IMethod item2 in item)
						{
							OverloadResolutionErrors errors = overloadResolution2.AddCandidate(item2);
							overloadResolution.LogCandidateAddingResult("  Extension", item2, errors);
						}
						if (overloadResolution2.FoundApplicableCandidate)
						{
							break;
						}
					}
					if (overloadResolution2.FoundApplicableCandidate || overloadResolution.BestCandidate == null)
					{
						overloadResolution = overloadResolution2;
					}
				}
			}
			return overloadResolution;
		}
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		if (targetResult != null)
		{
			return new ResolveResult[1] { targetResult };
		}
		return Enumerable.Empty<ResolveResult>();
	}
}
