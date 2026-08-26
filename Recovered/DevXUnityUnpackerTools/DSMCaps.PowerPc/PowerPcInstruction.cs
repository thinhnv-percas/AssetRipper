namespace DSMCaps.PowerPc
{
	public sealed class PowerPcInstruction : Instruction<PowerPcInstruction, PowerPcInstructionDetail, PowerPcDisassembleMode, PowerPcInstructionGroup, PowerPcInstructionGroupId, PowerPcInstructionId, PowerPcRegister, PowerPcRegisterId>
	{
		internal static PowerPcInstruction Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A = new _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A.Create();
		}

		internal PowerPcInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A builder)
			: base((InstructionBuilder<PowerPcInstructionDetail, PowerPcDisassembleMode, PowerPcInstructionGroup, PowerPcInstructionGroupId, PowerPcInstruction, PowerPcInstructionId, PowerPcRegister, PowerPcRegisterId>)builder)
		{
		}
	}
}
