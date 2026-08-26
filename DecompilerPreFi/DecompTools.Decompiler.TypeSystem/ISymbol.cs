namespace DecompTools.Decompiler.TypeSystem;

public interface ISymbol
{
	SymbolKind SymbolKind { get; }

	string Name { get; }
}
