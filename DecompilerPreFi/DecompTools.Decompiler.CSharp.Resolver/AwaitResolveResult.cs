using System;
using System.Collections.Generic;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Resolver;

public class AwaitResolveResult : ResolveResult
{
	public readonly ResolveResult GetAwaiterInvocation;

	public readonly IType AwaiterType;

	public readonly IProperty IsCompletedProperty;

	public readonly IMethod OnCompletedMethod;

	public readonly IMethod GetResultMethod;

	public override bool IsError => GetAwaiterInvocation.IsError || (AwaiterType.Kind != TypeKind.Dynamic && (IsCompletedProperty == null || OnCompletedMethod == null || GetResultMethod == null));

	public AwaitResolveResult(IType resultType, ResolveResult getAwaiterInvocation, IType awaiterType, IProperty isCompletedProperty, IMethod onCompletedMethod, IMethod getResultMethod)
		: base(resultType)
	{
		if (awaiterType == null)
		{
			throw new ArgumentNullException("awaiterType");
		}
		if (getAwaiterInvocation == null)
		{
			throw new ArgumentNullException("getAwaiterInvocation");
		}
		GetAwaiterInvocation = getAwaiterInvocation;
		AwaiterType = awaiterType;
		IsCompletedProperty = isCompletedProperty;
		OnCompletedMethod = onCompletedMethod;
		GetResultMethod = getResultMethod;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		return new ResolveResult[1] { GetAwaiterInvocation };
	}
}
