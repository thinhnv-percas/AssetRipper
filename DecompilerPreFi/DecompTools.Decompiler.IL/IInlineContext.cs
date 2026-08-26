namespace DecompTools.Decompiler.IL;

internal interface IInlineContext
{
	ILInstruction Peek(InstructionFlags flagsBefore);

	ILInstruction Pop(InstructionFlags flagsBefore);
}
