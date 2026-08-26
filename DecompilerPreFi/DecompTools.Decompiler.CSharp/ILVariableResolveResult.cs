using System;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp;

public class ILVariableResolveResult : ResolveResult
{
	public readonly ILVariable Variable;

	public ILVariableResolveResult(ILVariable v)
		: base(v.Type)
	{
		Variable = v;
	}

	public ILVariableResolveResult(ILVariable v, IType type)
		: base(type)
	{
		Variable = v ?? throw new ArgumentNullException("v");
	}
}
