using System;

namespace ICSharpCode.NRefactory.TypeSystem;

[Obsolete("Use SymbolKind instead")]
public enum EntityType : byte
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
	Accessor
}
