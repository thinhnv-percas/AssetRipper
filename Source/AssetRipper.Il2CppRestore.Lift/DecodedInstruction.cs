namespace AssetRipper.Il2CppRestore.Lift;

/// <summary>
/// One disassembled instruction, reduced to exactly the shape <see cref="Arm64Lifter"/> needs.
/// </summary>
/// <remarks>
/// This is a deliberate abstraction over Disarm's/Iced's own instruction types rather than a direct use
/// of either: their real object models could not be checked against this environment (no network access
/// to resolve NuGet packages here), so <c>Arm64Disassembler.Decode</c> is the one place that needs to
/// change once building against the real Disarm API is possible — everything in <see cref="Arm64Lifter"/>
/// consumes only this shape and does not need to know that happened.
/// </remarks>
public sealed class DecodedInstruction
{
	public required ulong Address { get; init; }
	public required int Length { get; init; }

	/// <summary>The opcode name, upper-cased (<c>"MOV"</c>, <c>"ADRP"</c>, <c>"BL"</c>, <c>"RET"</c>, …).</summary>
	public required string Mnemonic { get; init; }

	/// <summary>Destination register number, or -1 when the instruction has none.</summary>
	public int Rd { get; init; } = -1;
	/// <summary>First source register, or -1.</summary>
	public int Rn { get; init; } = -1;
	/// <summary>Second source register (rarely needed by the patterns this lifter matches), or -1.</summary>
	public int Rm { get; init; } = -1;

	/// <summary>An immediate operand — <c>MOV</c>'s constant, <c>LDR</c>'s offset, a branch's target delta, etc.</summary>
	public long Immediate { get; init; }

	/// <summary><c>ADRP</c>'s page address, precomputed by the disassembler from the instruction's own encoded offset and address.</summary>
	public ulong PageAddress { get; init; }

	public bool IsBranch { get; init; }
	public bool IsCall { get; init; }
	/// <summary>Resolved absolute target for a branch/call instruction; 0 when not a branch.</summary>
	public ulong BranchTarget { get; init; }
}
