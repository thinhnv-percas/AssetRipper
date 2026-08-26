namespace DSMCaps.Arm64
{
	public sealed class Arm64InstructionGroup : InstructionGroup<Arm64InstructionGroupId>
	{
		internal static Arm64InstructionGroup Create(CapstoneDisassembler disassembler, Arm64InstructionGroupId id)
		{
			string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(disassembler.Handle, (int)id);
			return new Arm64InstructionGroup(id, name);
		}

		public Arm64InstructionGroup(Arm64InstructionGroupId id, string name)
			: base(id, name)
		{
		}
	}
}
