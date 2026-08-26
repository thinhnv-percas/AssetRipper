namespace DecompTools.Decompiler.IL;

public enum BlockKind
{
	ControlFlow,
	ArrayInitializer,
	CollectionInitializer,
	ObjectInitializer,
	StackAllocInitializer,
	PostfixOperator,
	CallInlineAssign,
	CallWithNamedArgs
}
