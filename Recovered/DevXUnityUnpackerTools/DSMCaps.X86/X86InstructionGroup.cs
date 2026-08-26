namespace DSMCaps.X86
{
	public sealed class X86InstructionGroup : InstructionGroup<X86InstructionGroupId>
	{
		internal static X86InstructionGroup Create(CapstoneDisassembler disassembler, X86InstructionGroupId id)
		{
			string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(disassembler.Handle, (int)id);
			return new X86InstructionGroup(id, name);
		}

		internal X86InstructionGroup(X86InstructionGroupId id, string name)
			: base(id, name)
		{
		}
	}
}
