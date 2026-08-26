namespace DecompTools.Decompiler.IL;

public enum VariableKind
{
	Local,
	PinnedLocal,
	UsingLocal,
	ForeachLocal,
	InitializerTarget,
	Parameter,
	ExceptionStackSlot,
	ExceptionLocal,
	StackSlot,
	NamedArgument,
	DisplayClassLocal
}
