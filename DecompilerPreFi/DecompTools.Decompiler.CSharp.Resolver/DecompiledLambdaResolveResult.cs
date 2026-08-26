using System;
using System.Collections.Generic;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Resolver;

internal sealed class DecompiledLambdaResolveResult : LambdaResolveResult
{
	private readonly ILFunction function;

	public readonly IType DelegateType;

	public IType InferredReturnType;

	public override bool HasParameterList { get; }

	public override bool IsAnonymousMethod { get; }

	public override bool IsImplicitlyTyped { get; }

	public override bool IsAsync => function.IsAsync;

	public override IReadOnlyList<IParameter> Parameters => function.Parameters;

	public override IType ReturnType => function.ReturnType;

	public override ResolveResult Body { get; }

	public DecompiledLambdaResolveResult(ILFunction function, IType delegateType, IType inferredReturnType, bool hasParameterList, bool isAnonymousMethod, bool isImplicitlyTyped)
	{
		this.function = function ?? throw new ArgumentNullException("function");
		DelegateType = delegateType ?? throw new ArgumentNullException("delegateType");
		InferredReturnType = inferredReturnType ?? throw new ArgumentNullException("inferredReturnType");
		HasParameterList = hasParameterList;
		IsAnonymousMethod = isAnonymousMethod;
		IsImplicitlyTyped = isImplicitlyTyped;
		Body = new ResolveResult(SpecialType.UnknownType);
	}

	public override IType GetInferredReturnType(IType[] parameterTypes)
	{
		return InferredReturnType;
	}

	public override Conversion IsValid(IType[] parameterTypes, IType returnType, CSharpConversions conversions)
	{
		if (HasParameterList)
		{
			if (Parameters.Count != parameterTypes.Length)
			{
				return Conversion.None;
			}
			for (int i = 0; i < parameterTypes.Length; i = checked(i + 1))
			{
				if (!parameterTypes[i].Equals(Parameters[i].Type))
				{
					if (IsImplicitlyTyped)
					{
						return LambdaConversion.Instance;
					}
					return Conversion.None;
				}
			}
		}
		if (returnType.Equals(ReturnType))
		{
			return LambdaConversion.Instance;
		}
		return Conversion.None;
	}
}
