using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class AmbiguousTypeResolveResult : TypeResolveResult
{
	public override bool IsError => true;

	public AmbiguousTypeResolveResult(IType type)
		: base(type)
	{
	}
}
