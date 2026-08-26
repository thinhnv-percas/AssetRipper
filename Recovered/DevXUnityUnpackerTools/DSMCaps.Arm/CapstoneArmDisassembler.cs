namespace DSMCaps.Arm
{
	public sealed class CapstoneArmDisassembler : CapstoneDisassembler<ArmDisassembleMode, ArmInstruction, ArmInstructionDetail, ArmInstructionGroup, ArmInstructionGroupId, ArmInstructionId, ArmRegister, ArmRegisterId>
	{
		public CapstoneArmDisassembler(ArmDisassembleMode disassembleMode)
			: base(DisassembleArchitecture.Arm, disassembleMode)
		{
		}

		internal protected override ArmInstruction CreateInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return ArmInstruction.Create(this, hInstruction);
		}
	}
}
