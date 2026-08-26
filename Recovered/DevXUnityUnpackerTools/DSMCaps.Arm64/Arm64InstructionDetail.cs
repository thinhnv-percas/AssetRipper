using System.Runtime.CompilerServices;

namespace DSMCaps.Arm64
{
	public sealed class Arm64InstructionDetail : InstructionDetail<Arm64InstructionDetail, Arm64DisassembleMode, Arm64InstructionGroup, Arm64InstructionGroupId, Arm64Instruction, Arm64InstructionId, Arm64Register, Arm64RegisterId>
	{
		[CompilerGenerated]
		private readonly Arm64ConditionCode _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		private readonly Arm64Operand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		private readonly bool _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		private readonly bool _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020;

		public Arm64ConditionCode ConditionCode
		{
			get;
		}

		public Arm64Operand[] Operands
		{
			get;
		}

		public bool UpdateFlags
		{
			get;
		}

		public bool WriteBack
		{
			get;
		}

		internal static Arm64InstructionDetail Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A = new _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A.Create();
		}

		internal Arm64InstructionDetail(_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A builder)
			: base((InstructionDetailBuilder<Arm64InstructionDetail, Arm64DisassembleMode, Arm64InstructionGroup, Arm64InstructionGroupId, Arm64Instruction, Arm64InstructionId, Arm64Register, Arm64RegisterId>)builder)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020 = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020 = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020;
		}
	}
}
