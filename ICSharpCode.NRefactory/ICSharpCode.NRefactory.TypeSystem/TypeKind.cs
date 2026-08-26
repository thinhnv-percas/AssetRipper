namespace ICSharpCode.NRefactory.TypeSystem;

public enum TypeKind : byte
{
	Other,
	Class,
	Interface,
	Struct,
	Delegate,
	Enum,
	Module,
	Void,
	Unknown,
	Null,
	Dynamic,
	UnboundTypeArgument,
	TypeParameter,
	Array,
	Pointer,
	ByReference,
	Anonymous,
	Intersection,
	ArgList
}
