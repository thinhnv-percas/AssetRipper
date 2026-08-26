namespace DSMCaps.XCore
{
	public sealed class XCoreInstructionGroup : InstructionGroup<XCoreInstructionGroupId>
	{
		internal static XCoreInstructionGroup Create(CapstoneDisassembler disassembler, XCoreInstructionGroupId id)
		{
			string name = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020(disassembler.Handle, (int)id);
			return new XCoreInstructionGroup(id, name);
		}

		internal XCoreInstructionGroup(XCoreInstructionGroupId id, string name)
			: base(id, name)
		{
		}
	}
}
