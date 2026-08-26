namespace DSMCaps.XCore
{
	public sealed class CapstoneXCoreDisassembler : CapstoneDisassembler<XCoreDisassembleMode, XCoreInstruction, XCoreInstructionDetail, XCoreInstructionGroup, XCoreInstructionGroupId, XCoreInstructionId, XCoreRegister, XCoreRegisterId>
	{
		public CapstoneXCoreDisassembler(XCoreDisassembleMode disassembleMode)
			: base(DisassembleArchitecture.XCore, disassembleMode)
		{
		}

		private protected override XCoreInstruction CreateInstruction(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return XCoreInstruction.Create(this, hInstruction);
		}
	}
}
