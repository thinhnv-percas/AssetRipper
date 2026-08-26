namespace DSMCaps.Arm64
{
	public sealed class CapstoneArm64Disassembler : CapstoneDisassembler<Arm64DisassembleMode, Arm64Instruction, Arm64InstructionDetail, Arm64InstructionGroup, Arm64InstructionGroupId, Arm64InstructionId, Arm64Register, Arm64RegisterId>
	{
		public CapstoneArm64Disassembler(Arm64DisassembleMode disassembleMode)
			: base(DisassembleArchitecture.Arm64, disassembleMode)
		{
		}

		internal protected override Arm64Instruction CreateInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return Arm64Instruction.Create(this, hInstruction);
		}
	}
}
