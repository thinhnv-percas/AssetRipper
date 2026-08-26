using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IUnresolvedTypeParameter : INamedElement
{
	SymbolKind OwnerType { get; }

	int Index { get; }

	IList<IUnresolvedAttribute> Attributes { get; }

	VarianceModifier Variance { get; }

	DomRegion Region { get; }

	ITypeParameter CreateResolvedTypeParameter(ITypeResolveContext context);
}
