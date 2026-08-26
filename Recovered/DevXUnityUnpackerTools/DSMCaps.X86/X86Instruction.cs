namespace DSMCaps.X86
{
	public sealed class X86Instruction : Instruction<X86Instruction, X86InstructionDetail, X86DisassembleMode, X86InstructionGroup, X86InstructionGroupId, X86InstructionId, X86Register, X86RegisterId>
	{
		internal static X86Instruction Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020 _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020 = new _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020();
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020.Create();
		}

		internal X86Instruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020 builder)
			: base((InstructionBuilder<X86InstructionDetail, X86DisassembleMode, X86InstructionGroup, X86InstructionGroupId, X86Instruction, X86InstructionId, X86Register, X86RegisterId>)builder)
		{
		}
	}
}
