namespace DSMCaps.M68K
{
	public sealed class CapstoneM68KDisassembler : CapstoneDisassembler<M68KDisassembleMode, M68KInstruction, M68KInstructionDetail, M68KInstructionGroup, M68KInstructionGroupId, M68KInstructionId, M68KRegister, M68KRegisterId>
	{
		public CapstoneM68KDisassembler(M68KDisassembleMode disassembleMode)
			: base(DisassembleArchitecture.M68K, disassembleMode)
		{
		}

		internal protected override M68KInstruction CreateInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return M68KInstruction.Create(this, hInstruction);
		}
	}
}
