namespace DecompTools.Decompiler.IL;

public interface IStoreInstruction : IInstructionWithVariableOperand
{
	int IndexInStoreInstructionList { get; set; }
}
