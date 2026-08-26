using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class TypeResolveResult : ResolveResult
{
	public override bool IsError => base.Type.Kind == TypeKind.Unknown;

	public TypeResolveResult(IType type)
		: base(type)
	{
	}
}
