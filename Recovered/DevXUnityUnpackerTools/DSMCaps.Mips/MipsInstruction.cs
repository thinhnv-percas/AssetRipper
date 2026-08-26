namespace DSMCaps.Mips
{
	public sealed class MipsInstruction : Instruction<MipsInstruction, MipsInstructionDetail, MipsDisassembleMode, MipsInstructionGroup, MipsInstructionGroupId, MipsInstructionId, MipsRegister, MipsRegisterId>
	{
		internal static MipsInstruction Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 = new _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Create();
		}

		internal MipsInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 builder)
			: base((InstructionBuilder<MipsInstructionDetail, MipsDisassembleMode, MipsInstructionGroup, MipsInstructionGroupId, MipsInstruction, MipsInstructionId, MipsRegister, MipsRegisterId>)builder)
		{
		}
	}
}
