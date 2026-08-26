namespace DSMCaps.M68K
{
	public sealed class M68KInstruction : Instruction<M68KInstruction, M68KInstructionDetail, M68KDisassembleMode, M68KInstructionGroup, M68KInstructionGroupId, M68KInstructionId, M68KRegister, M68KRegisterId>
	{
		internal static M68KInstruction Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020 _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020 = new _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020.Create();
		}

		internal M68KInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020 builder)
			: base((InstructionBuilder<M68KInstructionDetail, M68KDisassembleMode, M68KInstructionGroup, M68KInstructionGroupId, M68KInstruction, M68KInstructionId, M68KRegister, M68KRegisterId>)builder)
		{
		}
	}
}
