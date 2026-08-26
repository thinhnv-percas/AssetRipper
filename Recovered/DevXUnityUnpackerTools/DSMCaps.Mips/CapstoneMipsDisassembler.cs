namespace DSMCaps.Mips
{
	public sealed class CapstoneMipsDisassembler : CapstoneDisassembler<MipsDisassembleMode, MipsInstruction, MipsInstructionDetail, MipsInstructionGroup, MipsInstructionGroupId, MipsInstructionId, MipsRegister, MipsRegisterId>
	{
		public CapstoneMipsDisassembler(MipsDisassembleMode disassembleMode)
			: base(DisassembleArchitecture.Mips, disassembleMode)
		{
		}

		internal protected override MipsInstruction CreateInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return MipsInstruction.Create(this, hInstruction);
		}
	}
}
