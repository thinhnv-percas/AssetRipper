namespace ICSharpCode.NRefactory.TypeSystem;

public interface IUnresolvedField : IUnresolvedMember, IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
{
	bool IsReadOnly { get; }

	bool IsVolatile { get; }

	bool IsConst { get; }

	bool IsFixed { get; }

	IConstantValue ConstantValue { get; }

	new IField Resolve(ITypeResolveContext context);
}
