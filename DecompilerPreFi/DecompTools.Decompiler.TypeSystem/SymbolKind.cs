namespace DecompTools.Decompiler.TypeSystem;

public enum SymbolKind : byte
{
	None,
	Module,
	TypeDefinition,
	Field,
	Property,
	Indexer,
	Event,
	Method,
	Operator,
	Constructor,
	Destructor,
	Accessor,
	Namespace,
	Variable,
	Parameter,
	TypeParameter
}
