using AssetRipper.Il2CppRestore.Binary;

namespace AssetRipper.Il2CppRestore.Lift;

/// <summary>
/// One CPU architecture's disassembler + lifter pair (guide §11.1). The guide's own recommendation —
/// Disarm for ARM64, Iced for x86/x64, both pure C# with no native DLL to lose track of — decides which
/// implementation backs this per <see cref="Architecture"/>.
/// </summary>
public interface IArchLifter
{
	Architecture Arch { get; }

	IReadOnlyList<DecodedInstruction> Disassemble(ReadOnlyMemory<byte> code, ulong baseVa);

	List<Statement> Lift(IReadOnlyList<DecodedInstruction> instructions, LiftContext context);
}
