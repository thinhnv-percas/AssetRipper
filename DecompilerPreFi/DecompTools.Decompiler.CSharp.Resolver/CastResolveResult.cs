using DecompTools.Decompiler.Semantics;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Resolver;

internal class CastResolveResult : ConversionResolveResult
{
	public CastResolveResult(ConversionResolveResult rr)
		: base(rr.Type, rr.Input, rr.Conversion, rr.CheckForOverflow)
	{
	}

	public CastResolveResult(IType targetType, ResolveResult input, Conversion conversion, bool checkForOverflow)
		: base(targetType, input, conversion, checkForOverflow)
	{
	}
}
