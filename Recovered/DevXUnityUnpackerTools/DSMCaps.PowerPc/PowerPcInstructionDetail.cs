using System.Runtime.CompilerServices;

namespace DSMCaps.PowerPc
{
	public sealed class PowerPcInstructionDetail : InstructionDetail<PowerPcInstructionDetail, PowerPcDisassembleMode, PowerPcInstructionGroup, PowerPcInstructionGroupId, PowerPcInstruction, PowerPcInstructionId, PowerPcRegister, PowerPcRegisterId>
	{
		[CompilerGenerated]
		internal readonly PowerPcBranchCode _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		internal readonly PowerPcBranchHint _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020;

		[CompilerGenerated]
		internal readonly PowerPcOperand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal readonly bool _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A;

		public PowerPcBranchCode BranchCode
		{
			get;
		}

		public PowerPcBranchHint BranchHint
		{
			get;
		}

		public PowerPcOperand[] Operands
		{
			get;
		}

		public bool UpdateCr0
		{
			get;
		}

		internal static PowerPcInstructionDetail Create(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020 _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020 = new _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020.Build(disassembler, hInstruction);
			return _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020.Create();
		}

		internal PowerPcInstructionDetail(_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020 builder)
			: base((InstructionDetailBuilder<PowerPcInstructionDetail, PowerPcDisassembleMode, PowerPcInstructionGroup, PowerPcInstructionGroupId, PowerPcInstruction, PowerPcInstructionId, PowerPcRegister, PowerPcRegisterId>)builder)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020 = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020;
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A = builder._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A;
		}
	}
}
