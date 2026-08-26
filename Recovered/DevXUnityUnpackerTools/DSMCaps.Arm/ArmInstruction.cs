namespace DSMCaps.Arm
{
	public sealed class ArmInstruction : Instruction<ArmInstruction, ArmInstructionDetail, ArmDisassembleMode, ArmInstructionGroup, ArmInstructionGroupId, ArmInstructionId, ArmRegister, ArmRegisterId>
	{
		internal static ArmInstruction Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A = new _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A.Create();
		}

		internal ArmInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A builder)
			: base((InstructionBuilder<ArmInstructionDetail, ArmDisassembleMode, ArmInstructionGroup, ArmInstructionGroupId, ArmInstruction, ArmInstructionId, ArmRegister, ArmRegisterId>)builder)
		{
		}
	}
}
