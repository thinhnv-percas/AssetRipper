namespace DSMCaps.XCore
{
	public sealed class XCoreInstruction : Instruction<XCoreInstruction, XCoreInstructionDetail, XCoreDisassembleMode, XCoreInstructionGroup, XCoreInstructionGroupId, XCoreInstructionId, XCoreRegister, XCoreRegisterId>
	{
		internal static XCoreInstruction Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020 _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020 = new _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020();
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020.Create();
		}

		internal XCoreInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020 builder)
			: base((InstructionBuilder<XCoreInstructionDetail, XCoreDisassembleMode, XCoreInstructionGroup, XCoreInstructionGroupId, XCoreInstruction, XCoreInstructionId, XCoreRegister, XCoreRegisterId>)builder)
		{
		}
	}
}
