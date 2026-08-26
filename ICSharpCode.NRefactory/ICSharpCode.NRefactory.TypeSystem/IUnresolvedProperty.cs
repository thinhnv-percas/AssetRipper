namespace ICSharpCode.NRefactory.TypeSystem;

public interface IUnresolvedProperty : IUnresolvedParameterizedMember, IUnresolvedMember, IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
{
	bool CanGet { get; }

	bool CanSet { get; }

	IUnresolvedMethod Getter { get; }

	IUnresolvedMethod Setter { get; }

	bool IsIndexer { get; }

	new IProperty Resolve(ITypeResolveContext context);
}
