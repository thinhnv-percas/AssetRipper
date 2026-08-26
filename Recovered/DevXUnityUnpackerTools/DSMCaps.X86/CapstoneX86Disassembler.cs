namespace DSMCaps.X86
{
	public sealed class CapstoneX86Disassembler : CapstoneDisassembler<X86DisassembleMode, X86Instruction, X86InstructionDetail, X86InstructionGroup, X86InstructionGroupId, X86InstructionId, X86Register, X86RegisterId>
	{
		public bool IsReduceModeEnabled => CapstoneDisassembler.IsX86ReduceModeEnabled;

		public CapstoneX86Disassembler(X86DisassembleMode disassembleMode)
			: base(DisassembleArchitecture.X86, disassembleMode)
		{
		}

		private protected override X86Instruction CreateInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return X86Instruction.Create(this, hInstruction);
		}
	}
}
