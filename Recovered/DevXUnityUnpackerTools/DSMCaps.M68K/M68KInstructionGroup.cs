namespace DSMCaps.M68K
{
	public sealed class M68KInstructionGroup : InstructionGroup<M68KInstructionGroupId>
	{
		internal static M68KInstructionGroup Create(CapstoneDisassembler disassembler, M68KInstructionGroupId id)
		{
			string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(disassembler.Handle, (int)id);
			return new M68KInstructionGroup(id, name);
		}

		internal M68KInstructionGroup(M68KInstructionGroupId id, string name)
			: base(id, name)
		{
		}
	}
}
