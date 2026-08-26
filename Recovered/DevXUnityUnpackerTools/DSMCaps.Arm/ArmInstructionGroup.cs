namespace DSMCaps.Arm
{
	public sealed class ArmInstructionGroup : InstructionGroup<ArmInstructionGroupId>
	{
		internal static ArmInstructionGroup Create(CapstoneDisassembler disassembler, ArmInstructionGroupId id)
		{
			string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(disassembler.Handle, (int)id);
			return new ArmInstructionGroup(id, name);
		}

		internal ArmInstructionGroup(ArmInstructionGroupId id, string name)
			: base(id, name)
		{
		}
	}
}
