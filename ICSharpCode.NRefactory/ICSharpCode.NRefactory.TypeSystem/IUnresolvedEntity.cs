using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem;

public interface IUnresolvedEntity : INamedElement, IHasAccessibility
{
	SymbolKind SymbolKind { get; }

	DomRegion Region { get; }

	DomRegion BodyRegion { get; }

	IUnresolvedTypeDefinition DeclaringTypeDefinition { get; }

	IUnresolvedFile UnresolvedFile { get; }

	IList<IUnresolvedAttribute> Attributes { get; }

	bool IsStatic { get; }

	bool IsAbstract { get; }

	bool IsSealed { get; }

	bool IsShadowing { get; }

	bool IsSynthetic { get; }
}
