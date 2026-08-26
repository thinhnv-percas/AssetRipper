using System.Runtime.CompilerServices;

namespace DSMCaps.M68K
{
	public sealed class M68KInstructionDetail : InstructionDetail<M68KInstructionDetail, M68KDisassembleMode, M68KInstructionGroup, M68KInstructionGroupId, M68KInstruction, M68KInstructionId, M68KRegister, M68KRegisterId>
	{
		[CompilerGenerated]
		private readonly M68KOperand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		private readonly M68KOperationSize _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020;

		public M68KOperand[] Operands
		{
			get;
		}

		public M68KOperationSize OperationSize
		{
			get;
		}

		internal static M68KInstructionDetail Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A = new _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A.Create();
		}

		internal M68KInstructionDetail(_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A builder)
			: base((InstructionDetailBuilder<M68KInstructionDetail, M68KDisassembleMode, M68KInstructionGroup, M68KInstructionGroupId, M68KInstruction, M68KInstructionId, M68KRegister, M68KRegisterId>)builder)
		{
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020 = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020;
		}
	}
}
