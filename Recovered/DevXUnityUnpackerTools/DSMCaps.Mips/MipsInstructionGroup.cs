namespace DSMCaps.Mips
{
	public sealed class MipsInstructionGroup : InstructionGroup<MipsInstructionGroupId>
	{
		internal static MipsInstructionGroup Create(CapstoneDisassembler disassembler, MipsInstructionGroupId id)
		{
			string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(disassembler.Handle, (int)id);
			return new MipsInstructionGroup(id, name);
		}

		internal MipsInstructionGroup(MipsInstructionGroupId id, string name)
			: base(id, name)
		{
		}
	}
}
