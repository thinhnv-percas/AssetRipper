namespace ICSharpCode.NRefactory.TypeSystem;

public interface IProperty : IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
{
	bool CanGet { get; }

	bool CanSet { get; }

	IMethod Getter { get; }

	IMethod Setter { get; }

	bool IsIndexer { get; }
}
