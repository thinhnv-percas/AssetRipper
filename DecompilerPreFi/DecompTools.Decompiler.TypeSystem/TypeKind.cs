namespace DecompTools.Decompiler.TypeSystem;

public enum TypeKind : byte
{
	Other,
	Class,
	Interface,
	Struct,
	Delegate,
	Enum,
	Void,
	Unknown,
	Null,
	None,
	Dynamic,
	UnboundTypeArgument,
	TypeParameter,
	Array,
	Pointer,
	ByReference,
	Anonymous,
	Intersection,
	ArgList,
	Tuple,
	ModOpt,
	ModReq
}
