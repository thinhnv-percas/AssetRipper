namespace ICSharpCode.NRefactory.TypeSystem
{
	public enum SymbolKind : byte
	{
		None,
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
}
