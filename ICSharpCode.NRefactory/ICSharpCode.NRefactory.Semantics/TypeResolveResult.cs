using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class TypeResolveResult : ResolveResult
{
	public override bool IsError => base.Type.Kind == TypeKind.Unknown;

	public TypeResolveResult(IType type)
		: base(type)
	{
	}

	public override DomRegion GetDefinitionRegion()
	{
		return base.Type.GetDefinition()?.Region ?? DomRegion.Empty;
	}
}
