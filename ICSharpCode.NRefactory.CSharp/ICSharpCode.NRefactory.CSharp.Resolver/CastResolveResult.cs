using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

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
