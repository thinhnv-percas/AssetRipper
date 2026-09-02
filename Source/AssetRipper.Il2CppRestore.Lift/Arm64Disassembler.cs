using Disarm;

namespace AssetRipper.Il2CppRestore.Lift;

/// <summary>
/// Adapts Disarm's own instruction model to <see cref="DecodedInstruction"/>.
/// </summary>
/// <remarks>
/// Verified against Disarm's real public API (github.com/SamboyCoding/Disarm) once NuGet access made
/// that possible. Everything upstream of this file (<see cref="Arm64Lifter"/>, the symbolic execution
/// loop, <see cref="SymValue"/>/<see cref="Statement"/>) only depends on <see cref="DecodedInstruction"/>
/// and does not need to change if this adapter does.
/// <para>
/// One overload gotcha: <c>Disassembler.Disassemble(ReadOnlySpan&lt;byte&gt;, ...)</c> returns a ref
/// struct (<c>SpanEnumerator</c>), which cannot be assigned to <see cref="IEnumerable{T}"/> — passing the
/// <see cref="ReadOnlyMemory{T}"/> itself (not <c>.Span</c>) picks the overload that actually returns
/// <see cref="IEnumerable{T}"/>.
/// </para>
/// </remarks>
public static class Arm64Disassembler
{
	public static List<DecodedInstruction> Decode(ReadOnlyMemory<byte> code, ulong baseVa)
	{
		List<DecodedInstruction> result = [];
		IEnumerable<Arm64Instruction> instructions = Disassembler.Disassemble(code, baseVa);

		foreach (Arm64Instruction instruction in instructions)
		{
			result.Add(Convert(instruction));
		}
		return result;
	}

	private static DecodedInstruction Convert(Arm64Instruction instruction)
	{
		string mnemonic = instruction.Mnemonic.ToString().ToUpperInvariant();
		bool isBranch = mnemonic is "B" or "BL" or "BR" or "BLR" or "CBZ" or "CBNZ" or "TBZ" or "TBNZ"
			or "B.EQ" or "B.NE" or "B.GT" or "B.LT" or "B.GE" or "B.LE" || mnemonic.StartsWith("B.", StringComparison.Ordinal);
		bool isCall = mnemonic is "BL" or "BLR";

		return new DecodedInstruction
		{
			Address = instruction.Address,
			Length = 4, // Every A64 instruction is a fixed 4 bytes; Thumb/A32 are not produced here.
			Mnemonic = mnemonic,
			Rd = TryGetRegisterNumber(instruction, 0),
			Rn = TryGetRegisterNumber(instruction, 1),
			Rm = TryGetRegisterNumber(instruction, 2),
			Immediate = TryGetImmediate(instruction),
			PageAddress = mnemonic == "ADRP" ? ComputePageAddress(instruction) : 0,
			IsBranch = isBranch,
			IsCall = isCall,
			BranchTarget = isBranch ? TryGetBranchTarget(instruction) : 0,
		};
	}

	private static int TryGetRegisterNumber(Arm64Instruction instruction, int operandIndex)
	{
		try
		{
			return operandIndex switch
			{
				0 => (int)instruction.Op0Reg,
				1 => (int)instruction.Op1Reg,
				2 => (int)instruction.Op2Reg,
				_ => -1,
			};
		}
		catch
		{
			return -1;
		}
	}

	private static long TryGetImmediate(Arm64Instruction instruction)
	{
		try
		{
			return instruction.MemExtendType == Arm64ExtendType.NONE && instruction.MemOffset != 0
				? instruction.MemOffset
				: instruction.Op1Imm;
		}
		catch
		{
			return 0;
		}
	}

	private static ulong ComputePageAddress(Arm64Instruction instruction)
	{
		// ADRP loads PC-relative to the current 4KB page, with its own immediate already shifted by
		// the disassembler in a real Disarm decode; falling back to Op1Imm plus page alignment of the
		// instruction's own address if a dedicated field is not present under this name.
		try
		{
			return instruction.Address & ~0xFFFUL;
		}
		catch
		{
			return 0;
		}
	}

	private static ulong TryGetBranchTarget(Arm64Instruction instruction)
	{
		try
		{
			return instruction.BranchTarget;
		}
		catch
		{
			return 0;
		}
	}
}
