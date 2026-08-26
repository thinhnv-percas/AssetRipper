namespace DSMCaps.PowerPc
{
	public sealed class PowerPcInstructionGroup : InstructionGroup<PowerPcInstructionGroupId>
	{
		internal static PowerPcInstructionGroup Create(CapstoneDisassembler disassembler, PowerPcInstructionGroupId id)
		{
			string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(disassembler.Handle, (int)id);
			return new PowerPcInstructionGroup(id, name);
		}

		internal PowerPcInstructionGroup(PowerPcInstructionGroupId id, string name)
			: base(id, name)
		{
		}
	}
}
