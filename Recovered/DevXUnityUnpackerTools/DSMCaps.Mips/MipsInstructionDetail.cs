using System.Runtime.CompilerServices;

namespace DSMCaps.Mips
{
	public sealed class MipsInstructionDetail : InstructionDetail<MipsInstructionDetail, MipsDisassembleMode, MipsInstructionGroup, MipsInstructionGroupId, MipsInstruction, MipsInstructionId, MipsRegister, MipsRegisterId>
	{
		[CompilerGenerated]
		internal readonly MipsOperand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		public MipsOperand[] Operands
		{
			get;
		}

		internal static MipsInstructionDetail Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A = new _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A.Create();
		}

		internal MipsInstructionDetail(_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A builder)
			: base((InstructionDetailBuilder<MipsInstructionDetail, MipsDisassembleMode, MipsInstructionGroup, MipsInstructionGroupId, MipsInstruction, MipsInstructionId, MipsRegister, MipsRegisterId>)builder)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020;
		}
	}
}
