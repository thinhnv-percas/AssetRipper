namespace DecompTools.Decompiler.IL;

internal interface ILoadInstruction : IInstructionWithVariableOperand
{
	int IndexInLoadInstructionList { get; set; }
}
