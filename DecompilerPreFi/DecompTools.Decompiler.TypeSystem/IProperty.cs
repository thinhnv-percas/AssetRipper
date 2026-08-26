namespace DecompTools.Decompiler.TypeSystem;

public interface IProperty : IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	bool CanGet { get; }

	bool CanSet { get; }

	IMethod Getter { get; }

	IMethod Setter { get; }

	bool IsIndexer { get; }
}
