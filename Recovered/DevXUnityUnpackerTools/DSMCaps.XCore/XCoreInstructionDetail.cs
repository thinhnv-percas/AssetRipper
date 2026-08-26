using System.Runtime.CompilerServices;

namespace DSMCaps.XCore
{
	public sealed class XCoreInstructionDetail : InstructionDetail<XCoreInstructionDetail, XCoreDisassembleMode, XCoreInstructionGroup, XCoreInstructionGroupId, XCoreInstruction, XCoreInstructionId, XCoreRegister, XCoreRegisterId>
	{
		[CompilerGenerated]
		internal readonly XCoreOperand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		public XCoreOperand[] Operands
		{
			get;
		}

		internal static XCoreInstructionDetail Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A = new _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A();
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A.Create();
		}

		internal XCoreInstructionDetail(_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A builder)
			: base((InstructionDetailBuilder<XCoreInstructionDetail, XCoreDisassembleMode, XCoreInstructionGroup, XCoreInstructionGroupId, XCoreInstruction, XCoreInstructionId, XCoreRegister, XCoreRegisterId>)builder)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020;
		}
	}
}
