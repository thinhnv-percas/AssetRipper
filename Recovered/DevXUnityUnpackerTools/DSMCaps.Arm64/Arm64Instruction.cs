namespace DSMCaps.Arm64
{
	public sealed class Arm64Instruction : Instruction<Arm64Instruction, Arm64InstructionDetail, Arm64DisassembleMode, Arm64InstructionGroup, Arm64InstructionGroupId, Arm64InstructionId, Arm64Register, Arm64RegisterId>
	{
		internal static Arm64Instruction Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020 _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020 = new _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020.Create();
		}

		internal Arm64Instruction(_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020 builder)
			: base((InstructionBuilder<Arm64InstructionDetail, Arm64DisassembleMode, Arm64InstructionGroup, Arm64InstructionGroupId, Arm64Instruction, Arm64InstructionId, Arm64Register, Arm64RegisterId>)builder)
		{
		}
	}
}
