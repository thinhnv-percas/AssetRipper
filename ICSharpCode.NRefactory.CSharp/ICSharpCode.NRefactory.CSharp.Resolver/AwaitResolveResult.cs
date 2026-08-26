using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public class AwaitResolveResult : ResolveResult
{
	public readonly ResolveResult GetAwaiterInvocation;

	public readonly IType AwaiterType;

	public readonly IProperty IsCompletedProperty;

	public readonly IMethod OnCompletedMethod;

	public readonly IMethod GetResultMethod;

	public override bool IsError
	{
		get
		{
			if (!GetAwaiterInvocation.IsError)
			{
				if (AwaiterType.Kind != TypeKind.Dynamic)
				{
					if (IsCompletedProperty != null && OnCompletedMethod != null)
					{
						return GetResultMethod == null;
					}
					return true;
				}
				return false;
			}
			return true;
		}
	}

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
