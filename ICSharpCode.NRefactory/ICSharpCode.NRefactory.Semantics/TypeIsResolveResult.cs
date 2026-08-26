using System;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class TypeIsResolveResult : ResolveResult
{
	public readonly ResolveResult Input;

	public readonly IType TargetType;

	public TypeIsResolveResult(ResolveResult input, IType targetType, IType booleanType)
		: base(booleanType)
	{
		if (input == null)
		{
			throw new ArgumentNullException("input");
		}
		if (targetType == null)
		{
			throw new ArgumentNullException("targetType");
		}
		Input = input;
		TargetType = targetType;
	}
}
