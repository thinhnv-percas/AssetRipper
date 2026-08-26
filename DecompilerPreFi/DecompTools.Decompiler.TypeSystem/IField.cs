namespace DecompTools.Decompiler.TypeSystem;

public interface IField : IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IVariable
{
	new string Name { get; }

	bool IsReadOnly { get; }

	bool IsVolatile { get; }
}
