namespace DecompTools.Decompiler.IL;

public interface IInstructionWithVariableOperand
{
	ILVariable Variable { get; set; }

	int IndexInVariableInstructionMapping { get; set; }
}
