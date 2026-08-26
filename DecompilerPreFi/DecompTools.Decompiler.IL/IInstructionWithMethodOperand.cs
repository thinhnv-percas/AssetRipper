using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public interface IInstructionWithMethodOperand
{
	IMethod Method { get; }
}
