namespace DSMCaps.PowerPc
{
	public sealed class CapstonePowerPcDisassembler : CapstoneDisassembler<PowerPcDisassembleMode, PowerPcInstruction, PowerPcInstructionDetail, PowerPcInstructionGroup, PowerPcInstructionGroupId, PowerPcInstructionId, PowerPcRegister, PowerPcRegisterId>
	{
		public CapstonePowerPcDisassembler(PowerPcDisassembleMode disassembleMode)
			: base(DisassembleArchitecture.PowerPc, disassembleMode)
		{
		}

		internal protected override PowerPcInstruction CreateInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return PowerPcInstruction.Create(this, hInstruction);
		}
	}
}
