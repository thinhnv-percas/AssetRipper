using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class InitializedObjectResolveResult : ResolveResult
{
	public InitializedObjectResolveResult(IType type)
		: base(type)
	{
	}
}
