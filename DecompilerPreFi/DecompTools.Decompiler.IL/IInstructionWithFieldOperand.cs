using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.IL;

public interface IInstructionWithFieldOperand
{
	IField Field { get; }
}
