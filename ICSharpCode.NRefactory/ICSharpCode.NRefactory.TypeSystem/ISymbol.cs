namespace ICSharpCode.NRefactory.TypeSystem;

public interface ISymbol
{
	SymbolKind SymbolKind { get; }

	string Name { get; }

	ISymbolReference ToReference();
}
