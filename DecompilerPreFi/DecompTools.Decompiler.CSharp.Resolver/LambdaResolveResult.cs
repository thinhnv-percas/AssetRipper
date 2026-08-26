using System.Collections.Generic;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Resolver;

public abstract class LambdaResolveResult : ResolveResult
{
	public abstract bool HasParameterList { get; }

	public abstract bool IsAnonymousMethod { get; }

	public abstract bool IsImplicitlyTyped { get; }

	public abstract bool IsAsync { get; }

	public abstract IReadOnlyList<IParameter> Parameters { get; }

	public abstract IType ReturnType { get; }

	public abstract ResolveResult Body { get; }

	protected LambdaResolveResult()
		: base(SpecialType.NoType)
	{
	}

	public abstract IType GetInferredReturnType(IType[] parameterTypes);

	public abstract Conversion IsValid(IType[] parameterTypes, IType returnType, CSharpConversions conversions);

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		return new ResolveResult[1] { Body };
	}
}
