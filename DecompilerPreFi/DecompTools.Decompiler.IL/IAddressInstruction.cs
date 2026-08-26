namespace DecompTools.Decompiler.IL;

internal interface IAddressInstruction : IInstructionWithVariableOperand
{
	int IndexInAddressInstructionList { get; set; }
}
