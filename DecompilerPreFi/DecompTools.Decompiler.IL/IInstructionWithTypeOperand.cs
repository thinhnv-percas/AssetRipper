using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public interface IInstructionWithTypeOperand
{
	IType Type { get; }
}
