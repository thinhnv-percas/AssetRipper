namespace DecompTools.Decompiler.TypeSystem;

public enum Accessibility : byte
{
	None,
	Private,
	Public,
	Protected,
	Internal,
	ProtectedOrInternal,
	ProtectedAndInternal
}
